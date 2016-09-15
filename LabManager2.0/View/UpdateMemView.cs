using LabManager.Util;
using LabManager.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabManager.View
{
    public partial class UpdateMemView : Form
    {
        Member member;
        public int id;
        //public string number;
        public UpdateMemView(LoginState loginState, Member member = null)
        {
            InitializeComponent();
            if (member != null)
            {
                this.member = member;
                Text = "修改成员";
                FillBlanks(member);
            }
            else
            {
                Text = "添加成员";
                comboBoxSex.SelectedIndex = 0;
                comboBoxLv.SelectedIndex = 2;
            }
            if (loginState == LoginState.学生)
            {
                comboBoxLv.Enabled = false;
            }
        }
        private void UpdateMember_Load(object sender, EventArgs e)
        {


        }
        void FillBlanks(Member member)
        {
            txtBoxNum.Text = member.Number;
            txtBoxName.Text = member.Name;
            comboBoxSex.Text = member.Sex.ToString();
            txtBoxPhone.Text = member.Phone;
            txtBoxMail.Text = member.Email;
            txtBoxPsw.Text = member.Psw;
            chkBoxGrad.Checked = member.Graduated;
            comboBoxLv.Text = member.Level.ToString();
        }
        Member GetMem()
        {
            Member member = new Member();
            member.Number = txtBoxNum.Text.Trim();
            member.Name = txtBoxName.Text.Trim();
            member.Sex = (Sex)Enum.Parse(typeof(Sex), comboBoxSex.Text);
            member.Phone = txtBoxPhone.Text.Trim();
            member.Email = txtBoxMail.Text.Trim();
            member.Psw = txtBoxPsw.Text.Trim();
            member.Graduated = chkBoxGrad.Checked;
            member.Level = (LoginState)Enum.Parse(typeof(LoginState), comboBoxLv.Text);
            return member;
        }
        bool CheckFilling()
        {
            bool isParaOK = true;
            if (txtBoxNum.Text.Trim() == "")
            {
                lblNum.ForeColor = Color.Red;
                isParaOK = false;
            }
            if (txtBoxName.Text.Trim() == "")
            {
                lblName.ForeColor = Color.Red;
                isParaOK = false;
            }
            if (txtBoxPhone.Text.Trim() == "")
            {
                lblPhone.ForeColor = Color.Red;
                isParaOK = false;
            }
            if (txtBoxMail.Text.Trim() == "")
            {
                lblMail.ForeColor = Color.Red;
                isParaOK = false;
            }
            if (txtBoxPsw.Text.Trim() == "")
            {
                lblPsw.ForeColor = Color.Red;
                isParaOK = false;
            }
            if (comboBoxSex.SelectedIndex == -1)
            {
                lblSex.ForeColor = Color.Red;
                isParaOK = false;
            }
            if (comboBoxLv.SelectedIndex == -1)
            {
                lblLv.ForeColor = Color.Red;
                isParaOK = false;
            }
            if (!isParaOK)
            {
                statusLbl.Text = "参数不完整";
            }
            else if (!CheckMail(txtBoxMail.Text.Trim()))
            {
                statusLbl.Text = "邮箱格式不正确";
                lblMail.ForeColor = Color.Red;
                return false;
            }
            else if (txtBoxPsw.Text.Trim().Length < 6)
            {
                statusLbl.Text = "密码长度不能少于6位";
                lblPsw.ForeColor = Color.Red;
                return false;
            }
            return isParaOK;
        }
        bool CheckMail(string mail)
        {
            return mail.Length - mail.Replace("@", "").Length == 1
                && 0 < mail.IndexOf("@")
                && mail.IndexOf("@") < mail.Length - 1;
        }

        private void txtBoxName_TextChanged(object sender, EventArgs e)
        {
            lblName.ForeColor = Color.Black;
            statusLbl.Text = "";
        }

        private void comboBoxSex_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSex.ForeColor = Color.Black;
            statusLbl.Text = "";
        }
        private void txtBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
                statusLbl.Text = "请输入正确的电话号码";
            }
            else
            {
                statusLbl.Text = "";
                lblPhone.ForeColor = Color.Black;
            }
        }

        private void txtBoxNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
                statusLbl.Text = "请输入正确的学号";
            }
            else
            {
                statusLbl.Text = "";
                lblNum.ForeColor = Color.Black;
            }
        }

        private void txtBoxMail_TextChanged(object sender, EventArgs e)
        {
            statusLbl.Text = "";
            lblMail.ForeColor = Color.Black;
        }

        private void txtBoxPsw_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxPsw.Text.Length >= 6)
            {
                statusLbl.Text = "";
                lblPsw.ForeColor = Color.Black;
            }
        }

        private void comboBoxLv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLv.SelectedIndex > -1)
            {
                statusLbl.Text = "";
                lblLv.ForeColor = Color.Black;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CheckFilling())
            {
                //string number = member.Number;
                member = GetMem();
                LblConnecting();
                if (Text == "添加成员")
                {
                    Task addMem = Task.Factory.StartNew(() => MemberDAL.AddMem(member));
                    Task.WaitAll(addMem);
                }
                else if (Text == "修改成员")
                {
                    //Console.WriteLine(member.Name+":"+number);
                    Task modifyMem = Task.Factory.StartNew(() => MemberDAL.ModifyMem(member, id));
                    Task.WaitAll(modifyMem);
                }
                LblConnected();
                DialogResult = DialogResult.OK;
                Dispose();
            }
        }
        public void LblConnecting(string text = "连接数据库")
        {
            string[] dynamicStr = { ".", "..", "...", "...." };
            lock (this)
            {
                int i = 0;
                timer1.Tick += (sender, e) =>
                {
                    statusLbl.Text = text + dynamicStr[i % dynamicStr.Length];
                    this.Enabled = false;
                    i++;
                };
                timer1.Start();
            }

        }
        public void LblConnected()
        {
            lock (this)
            {
                statusLbl.Text = "";
                timer1.Stop();
            }
        }
    }
}
