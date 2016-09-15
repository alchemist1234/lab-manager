using LabManager.Model;
using LabManager.Util;
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
    public partial class UsageView : Form
    {
        public Chemical chemical;
        string chemName;
        List<Member> listUser;
        public UsageView(Chemical chemical)
        {
            this.chemical = chemical;
            chemName = chemical.CnName == "" ? chemical.EnName : chemical.CnName;
            InitializeComponent();
        }

        private void UsageView_Load(object sender, EventArgs e)
        {
            lblInfo.Text = string.Format("药品：{0}\n厂家：{1}\n位置：{2}({3})", chemName, chemical.Manufacturer, chemical.Locaction.LocName, chemical.Lab.LocName);
            numUDNum.Maximum = chemical.Number;
            lblInfo.Left = (Width - lblInfo.Width) / 2;
            lblInfo.Top = (numUDNum.Top - lblInfo.Height) / 2;

            if (MainView.loginState == LoginState.教师 || MainView.loginState == LoginState.管理员)
            {
                listUser = MainView.ListUser;
            }
            else
            {
                listUser = new List<Member>();
                listUser.Add(MainView.user);
            }
            comboBoxUser.DisplayMember = "Name";
            comboBoxUser.ValueMember = "Id";
            comboBoxUser.DataSource = listUser;
            comboBoxUser.SelectedItem = MainView.user;
        }

        private void numUDNum_ValueChanged(object sender, EventArgs e)
        {
            if (numUDNum.Value == chemical.Number)
            {
                txtBoxAmount.Text = chemical.Residual.ToString();
                toolStriplbl.Text = "瓶数达到上限，已自动调整";
            }
            else
            {
                toolStriplbl.Text = "";
            }
            //lblNum.ForeColor = Color.Black;
            //lblAmount.ForeColor = Color.Black;
        }

        private void txtBoxAmount_TextChanged(object sender, EventArgs e)
        {
            string strAmount = txtBoxAmount.Text.Trim();
            if (strAmount != "" && strAmount != "." && Convert.ToSingle(strAmount) > chemical.Residual)
            {
                txtBoxAmount.Text = chemical.Residual.ToString();
                numUDNum.Value = chemical.Number;
                toolStriplbl.Text = "使用量超过剩余量,已自动调整";
                //lblAmount.ForeColor = Color.Red;
            }
            else
            {
                toolStriplbl.Text = "";
                lblNum.ForeColor = Color.Black;
                lblAmount.ForeColor = Color.Black;
            }
        }

        private void txtBoxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            string text = txtBoxAmount.Text.Trim();
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != '.')
            {
                toolStriplbl.Text = string.Format("\"{0}{1}\"不是一个数字", text, e.KeyChar);
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                if (txtBoxAmount.Text.Contains("."))
                {
                    toolStriplbl.Text = string.Format("\"{0}{1}\"不是一个数字", text, e.KeyChar);
                    e.Handled = true;
                }
            }
            else
            {
                toolStriplbl.Text = "";
                lblNum.ForeColor = Color.Black;
                lblAmount.ForeColor = Color.Black;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtBoxAmount.Text.Trim() == "" || txtBoxAmount.Text.Trim() == ".")
            {
                toolStriplbl.Text = "未输入使用量或使用量输入不正确";
                lblAmount.ForeColor = Color.Red;
            }
            else
            {
                float amount = Convert.ToSingle(txtBoxAmount.Text.Trim());
                int number = (int)numUDNum.Value;
                if (amount == 0 && number == 0)
                {
                    toolStriplbl.Text = "未使用药品";
                    lblNum.ForeColor = Color.Red;
                    lblAmount.ForeColor = Color.Red;
                }
                else
                {
                    DialogResult res = MessageBox.Show(string.Format("确定使用 {0} {1}{2}，产生{3}个空瓶？", chemName, amount, chemical.Unit.ToString(), number),
                        "确定使用？", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (res == DialogResult.OK)
                    {
                        Chemical newChem = chemical;
                        if (number >= chemical.Number)
                        {
                            amount = chemical.Residual;
                            MainView.listExhaChemID.Add(chemical._Id.ToString());
                        }
                        if (amount >= chemical.Residual)
                        {
                            number = chemical.Number;
                            MainView.listExhaChemID.Add(chemical._Id.ToString());
                        }
                        newChem.Number = chemical.Number - number;
                        newChem.Residual = chemical.Residual - amount;
                        newChem.LastUserId = (int)comboBoxUser.SelectedValue;

                        Record record = new Record();
                        record.Chemical = chemical;
                        record.Member = new Member();
                        record.Member.Id = (int)comboBoxUser.SelectedValue;
                        record.Type = RecordType.Use;
                        record.Date = DateTime.Now;
                        //record.OriLoc = new Location();
                        //record.OriLoc.LocId = chemical.LocId;
                        record.Number = number;
                        record.Amount = amount;

                        Task useChem = Task.Factory.StartNew(() => ChemicalDAL.ModifyChem(chemical._Id, newChem));
                        Task.WaitAll(useChem);
                        Task addRec = Task.Factory.StartNew(() => RecordDAL.AddRecord(record));
                        Task.WaitAll(addRec);
                        DialogResult = DialogResult.OK;
                        Dispose();
                    }
                }
            }
        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }

        private void lblAmount_Click(object sender, EventArgs e)
        {

        }

        private void lblNum_Click(object sender, EventArgs e)
        {

        }
    }
}
