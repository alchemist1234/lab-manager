using LabManager.Util;
using LabManager.Model;
using LabManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace LabManager.View
{
    public partial class UpdateChemView : Form
    {
        List<Location> listLab;
        List<Location> listLoc;
        List<Member> listUser;
        Chemical chemical;
        int modifiedChemId;
        AutoCompleteStringCollection manuSource;
        List<string> listManu = new List<string>();
        string strPre = "";
        Member delUser;
        //string strTypedCAS="";
        internal Chemical Chemical
        {
            get { return chemical; }
            set { chemical = value; }
        }
        public UpdateChemView(Chemical chemical = null)
        {
            InitializeComponent();
            Text = "添加药品";
            datePicker.Value = DateTime.Today;
            if (chemical != null)
            {
                Text = "修改药品";
                Chemical = chemical;
                delUser = new Member() { Id = chemical.PurchaserId, Name = "未知用户" };
            }
        }
        private void UpdateChem_Load(object sender, EventArgs e)
        {
            manuSource = new AutoCompleteStringCollection();
            listManu = ChemicalDAL.GetAllManu();
            manuSource.AddRange(listManu.ToArray());
            comboBoxManu.AutoCompleteCustomSource = manuSource;
            comboBoxManu.DataSource = listManu;
            comboBoxManu.SelectedIndex = -1;

            comboBoxUnit.DataSource = Enum.GetNames(typeof(Unit));
            listLab = MainView.ListLab;
            Location loc0 = new Location();
            loc0.LocId = 0;
            loc0.LocName = "请选择";
            loc0.Uid = -1;
            listLab.RemoveAt(0);
            listLab.Insert(0, loc0);
            comboBoxLab.DisplayMember = "locName";
            comboBoxLab.ValueMember = "locId";
            comboBoxLab.DataSource = listLab;

            listLoc = new List<Location>();
            listLoc.Insert(0, loc0);
            comboBoxLoc.DisplayMember = "locName";
            comboBoxLoc.ValueMember = "locId";
            comboBoxLoc.DataSource = listLoc;

            comboBoxMem.DisplayMember = "Name";
            comboBoxMem.ValueMember = "Id";
            if (chemical == null)
            {
                if (MainView.loginState == LoginState.管理员 || MainView.loginState == LoginState.教师)
                {
                    listUser = new List<Member>(MainView.ListUser.ToArray());
                }
                else
                {
                    listUser = new List<Member>();
                    listUser.Add(MainView.user);
                }
                comboBoxMem.DataSource = listUser;
                comboBoxMem.SelectedItem = MainView.user;
            }
            else
            {
                if (chemical.Purchaser == null)
                {


                    listUser = new List<Member>(MainView.ListUser.ToArray());
                    listUser.Add(delUser);

                    comboBoxMem.DataSource = listUser;
                    comboBoxMem.SelectedItem = delUser;
                }
                else
                {
                    listUser = new List<Member>(MainView.ListUser.ToArray());
                    comboBoxMem.DataSource = listUser;
                    comboBoxMem.SelectedItem = chemical.Purchaser;
                }
            }

            comboBoxLoc.SelectedItem = MainView.user;
            if (Chemical != null)
            {
                FillBlanks(Chemical);
            }
        }
        private void FillBlanks(Chemical chemical)
        {
            modifiedChemId = chemical._Id;
            txtBoxCnName.Text = chemical.CnName ?? "";
            txtBoxEnName.Text = chemical.EnName ?? "";
            txtBoxAbbr.Text = chemical.Abbr ?? "";
            txtBoxCAS.Text = chemical._CAS ?? "";
            chkBoxPrec.Checked = chemical.IsPrecursor;
            txtBoxCapa.Text = chemical.Capacity.ToString();
            comboBoxUnit.Text = chemical.Unit.ToString();
            numUpDown.Value = chemical.Number;
            txtBoxResi.Text = chemical.Residual.ToString();
            comboBoxLab.SelectedValue = chemical.Lab.LocId;
            comboBoxLoc.SelectedValue = chemical.Locaction.LocId;
            comboBoxManu.Text = chemical.Manufacturer ?? "";
            datePicker.Value = chemical.PurchaseDate;
            if (chemical.Purchaser != null)
            {
                comboBoxMem.Text = chemical.Purchaser.Name;
            }
            richTxtBoxRemark.Text = chemical.Remark ?? "";
        }
        private Chemical GetChem()
        {
            Chemical chemical = new Chemical();
            chemical.CnName = txtBoxCnName.Text.Trim();
            chemical.EnName = txtBoxEnName.Text.Trim();
            chemical.Abbr = txtBoxAbbr.Text.Trim();
            chemical._CAS = txtBoxCAS.Text.Trim();
            chemical.IsPrecursor = chkBoxPrec.Checked;
            chemical.Capacity = Convert.ToInt32(txtBoxCapa.Text.Trim());
            chemical.Unit = (Unit)Enum.Parse(typeof(Unit), comboBoxUnit.SelectedItem.ToString(), false);
            chemical.Number = (int)numUpDown.Value;
            chemical.Residual = Convert.ToSingle(txtBoxResi.Text.Trim());
            chemical.LocId = (int)comboBoxLoc.SelectedValue;
            chemical.Lab = (Location)comboBoxLab.SelectedItem;
            chemical.Locaction = (Location)comboBoxLoc.SelectedItem;
            chemical.PurchaseDate = datePicker.Value;
            if (this.chemical == null)
            {
                chemical.PurchaserId = (int)comboBoxMem.SelectedValue;
                chemical.LastUserId = chemical.PurchaserId;
            }
            else
            {
                if (this.chemical.Purchaser != null || comboBoxMem.SelectedItem != delUser)
                    chemical.PurchaserId = (int)comboBoxMem.SelectedValue;
                else
                    chemical.PurchaserId = this.chemical.PurchaserId;
                chemical.LastUserId = this.chemical.LastUserId;
            }
            chemical.Manufacturer = comboBoxManu.Text.Trim();
            chemical.Remark = richTxtBoxRemark.Text.Trim();
            return chemical;
        }
        private Record GetRecord(int chemId, Chemical chemical)
        {
            Record record = new Record();
            record.Member = new Member();
            record.Chemical = new Chemical();
            //record.OriLoc = new Location();
            record.Date = datePicker.Value;
            record.Type = RecordType.Add;

            record.Member.Id = (int)comboBoxMem.SelectedValue;
            record.Chemical = chemical;
            record.Chemical._Id = chemId;
            //record.OriLoc.LocId = chemical.LocId;
            record.Number = (int)numUpDown.Value;
            record.Amount = Convert.ToSingle(txtBoxResi.Text.Trim());
            return record;
        }
        private bool CheckFilling()
        {
            bool isParaOK = true;
            if (txtBoxCnName.Text.Trim() == "" && txtBoxEnName.Text.Trim() == "")
            {
                lblCnName.ForeColor = Color.Red;
                lblEnName.ForeColor = Color.Red;
                isParaOK = false;
            }
            if (txtBoxCAS.Text.Trim() == "")
            {
                lblCAS.ForeColor = Color.Red;
                isParaOK = false;
            }
            if (txtBoxCapa.Text.Trim() == "")
            {
                lblCapa.ForeColor = Color.Red;
                isParaOK = false;
            }
            if (txtBoxResi.Text.Trim() == "" || txtBoxResi.Text.Trim() == ".")
            {
                lblResi.ForeColor = Color.Red;
                isParaOK = false;
            }
            if (comboBoxLab.SelectedIndex < 1)
            {
                lblLab.ForeColor = Color.Red;
                isParaOK = false;
            }
            if (comboBoxLoc.SelectedIndex < 1)
            {
                lblLoc.ForeColor = Color.Red;
                isParaOK = false;
            }
            if (!isParaOK)
            {
                StatusLbl.Text = "参数不完整";
            }
            return isParaOK;
        }

        private void comboBoxLab_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((int)comboBoxLab.SelectedValue == 0)
            {
                listLoc = new List<Location>();
                Location loc0 = new Location();
                loc0.LocId = 0;
                loc0.LocName = "请选择";
                loc0.Uid = -1;
                listLoc.Add(loc0);
                comboBoxLoc.DisplayMember = "locName";
                comboBoxLoc.ValueMember = "locID";
                comboBoxLoc.DataSource = listLoc;
            }
            else
            {
                listLoc = LocationDAL.GetLoc((int)comboBoxLab.SelectedValue);
                Location loc0 = new Location();
                loc0.LocId = 0;
                loc0.LocName = "请选择";
                loc0.Uid = -1;
                listLoc.Insert(0, loc0);
                comboBoxLoc.DisplayMember = "locName";
                comboBoxLoc.ValueMember = "locID";
                comboBoxLoc.DataSource = listLoc;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CheckFilling())
            {
                Chemical chemical = GetChem();
                LblConnected();
                Task<int> getReChemId = Task.Factory.StartNew(() => ChemicalDAL.GetReChemId(chemical));
                Task.WaitAll(getReChemId);
                int reChemId = getReChemId.Result;
                if (reChemId > 0 && reChemId != modifiedChemId)
                {
                    DialogResult res = MessageBox.Show(string.Format("与第{0}条记录重复，是否合并?", reChemId.ToString()), "重复记录", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (res == DialogResult.OK)
                    {
                        Task<Chemical> getReChem = Task.Factory.StartNew(() => ChemicalDAL.GetSingleChem(reChemId));
                        Task.WaitAll(getReChem);
                        Chemical reChemical = getReChem.Result;
                        reChemical.Number += chemical.Number;
                        reChemical.Residual += chemical.Residual;
                        reChemical.PurchaserId = chemical.PurchaserId;
                        reChemical.PurchaseDate = chemical.PurchaseDate;
                        reChemical.LastUserId = chemical.LastUserId;
                        reChemical.Remark = chemical.Remark;
                        Task modifyChem = Task.Factory.StartNew(() => ChemicalDAL.ModifyChem(reChemId, reChemical));
                        Task.WaitAll(modifyChem);

                        Task delChem = Task.Factory.StartNew(() => ChemicalDAL.DelChem(modifiedChemId));
                        Task.WaitAll(delChem);
                        MainView.selectedId = reChemId;
                    }
                    else
                        return;
                }
                else
                {
                    if (Text == "添加药品")
                    {
                        Task addChem = Task.Factory.StartNew(() => ChemicalDAL.AddChem(chemical));
                        Task.WaitAll(addChem);
                        Task<int> getMaxChemId = Task.Factory.StartNew(() => ChemicalDAL.GetMaxId());
                        Task.WaitAll(getMaxChemId);
                        Record record = GetRecord(getMaxChemId.Result, chemical);
                        Task addRec = Task.Factory.StartNew(() => RecordDAL.AddRecord(record));
                        Task.WaitAll(addRec);
                        MainView.selectedId = -1;
                    }
                    else
                    {
                        Task modifyChem = Task.Factory.StartNew(() => ChemicalDAL.ModifyChem(modifiedChemId, chemical));
                        Task.WaitAll(modifyChem);
                        MainView.selectedId = modifiedChemId;
                    }
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
                timerLbl.Tick += (sender, e) =>
                {
                    StatusLbl.Text = text + dynamicStr[i % dynamicStr.Length];
                    this.Enabled = false;
                    i++;
                };
                timerLbl.Start();
            }

        }
        public void LblConnected()
        {
            lock (this)
            {
                StatusLbl.Text = "";
                timerLbl.Stop();
            }
        }

        private void comboBoxLab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)comboBoxLab.SelectedValue == 0)
            {
                listLoc = new List<Location>();
                Location loc0 = new Location();
                loc0.LocId = 0;
                loc0.LocName = "请选择";
                loc0.Uid = -1;
                listLoc.Add(loc0);
                comboBoxLoc.DisplayMember = "locName";
                comboBoxLoc.ValueMember = "locID";
                comboBoxLoc.DataSource = listLoc;
            }
            else
            {
                lblLab.ForeColor = Color.Black;
                listLoc = LocationDAL.GetLoc((int)comboBoxLab.SelectedValue);
                Location loc0 = new Location();
                loc0.LocId = 0;
                loc0.LocName = "请选择";
                loc0.Uid = -1;
                listLoc.Insert(0, loc0);
                comboBoxLoc.DisplayMember = "locName";
                comboBoxLoc.ValueMember = "locID";
                comboBoxLoc.DataSource = listLoc;
            }
        }

        private void txtBoxCAS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != '-')
            {
                StatusLbl.Text = "请输入正确的CAS号";
                e.Handled = true;
            }
            else if (e.KeyChar == '-')
            {
                if (txtBoxCAS.Text.EndsWith("-") || txtBoxCAS.Text == "" || txtBoxCAS.Text.Length - txtBoxCAS.Text.Replace("-", "").Length >= 2)
                {
                    StatusLbl.Text = "请输入正确的CAS号";
                    e.Handled = true;
                }
            }
            else
            {
                StatusLbl.Text = "";
            }
        }
        private void txtBoxCapa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                StatusLbl.Text = string.Format("\"{0}\"不是一个数字", e.KeyChar);
                e.Handled = true;
            }
            else
            {
                StatusLbl.Text = strPre;
            }
        }
        private void txtBoxResi_KeyPress(object sender, KeyPressEventArgs e)
        {
            string text = txtBoxResi.Text.Trim();
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != '.')
            {
                StatusLbl.Text = string.Format("\"{0}{1}\"不是一个数字", text, e.KeyChar);
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                if (txtBoxResi.Text.Contains("."))
                {
                    StatusLbl.Text = string.Format("\"{0}{1}\"不是一个数字", text, e.KeyChar);
                    e.Handled = true;
                }
            }
            else
            {
                StatusLbl.Text = strPre;
            }
        }

        private void txtBoxCAS_TextChanged(object sender, EventArgs e)
        {
            lblCAS.ForeColor = Color.Black;
            //Regex regCAS = new Regex("\\d{2,6}-\\d{2}-\\d");
            //string strCAS = txtBoxCAS.Text.Trim();
            //if (regCAS.Match(strCAS).Success)
            //{
            //    strTypedCAS = regCAS.Match(strCAS).ToString();
            //}
            //txtBoxCAS.Text = strTypedCAS;
            foreach (var pre in MainView.ListPre)
            {
                if (pre.CAS == txtBoxCAS.Text)
                {
                    chkBoxPrec.Checked = true;
                    strPre = string.Format("易制毒：{0}（{1}）", pre.CnName, pre.Type.ToString());
                    StatusLbl.Text = strPre;
                    return;
                }
            }
            chkBoxPrec.Checked = false;
            strPre = "";
            StatusLbl.Text = strPre;
        }

        private void txtBoxCnName_TextChanged(object sender, EventArgs e)
        {
            lblCnName.ForeColor = Color.Black;
            lblEnName.ForeColor = Color.Black;
            StatusLbl.Text = "";
        }

        private void txtBoxCapa_TextChanged(object sender, EventArgs e)
        {
            lblCapa.ForeColor = Color.Black;
            StatusLbl.Text = "";
        }
        private void txtBoxResi_TextChanged(object sender, EventArgs e)
        {
            lblResi.ForeColor = Color.Black;
            StatusLbl.Text = "";
        }

        private void comboBoxLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLoc.SelectedIndex != 0)
            {
                lblLoc.ForeColor = Color.Black;
            }

        }
        private void txtBoxCAS_Validating(object sender, CancelEventArgs e)
        {
            string[] strCAS = txtBoxCAS.Text.Split('-');
            if (txtBoxCAS.Text.EndsWith("-") || strCAS[0].Length < 2 || strCAS[0].Length > 6 || strCAS[1].Length != 2 || strCAS[2].Length != 1)
            {
                StatusLbl.Text = "请输入正确的CAS号";
                lblCAS.ForeColor = Color.Red;
                e.Cancel = true;
            }
            else
            {
                int sum = 0;
                List<char> charList = strCAS[0].ToList();
                charList.AddRange(strCAS[1].ToList());
                for (int i = charList.Count - 1; i >= 0; i--)
                {
                    sum += Convert.ToInt32(charList[i].ToString()) * (charList.Count - i);
                }
                if (sum % 10 != Convert.ToInt32(strCAS[2].ToString()))
                {
                    StatusLbl.Text = "CAS号校验失败，请检查CAS号是否正确";
                    lblCAS.ForeColor = Color.Red;
                    e.Cancel = true;
                }
            }
        }
    }
}
