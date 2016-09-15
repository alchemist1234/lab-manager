using LabManager.Model;
using LabManager.Properties;
using LabManager.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
//using IWshRuntimeLibrary;

namespace LabManager.View
{
    public delegate void Operation();
    public partial class MainView : Form
    {
        //存放所有已毕业学生学号
        List<string> listGraMemNum;
        //登录状态
        public static LoginState loginState;
        //是否可以连接数据库
        public static bool connectable;
        //当前用户
        public static Member user;
        //窗口
        private ConnectingView connView = new ConnectingView();
        private LoginView logView;
        private AboutView aboutView;
        private ChangeLogView changeLogView;
        //查询参数:药品
        public static List<string> listExhaChemID;
        string queryStr = "";
        int labID = 0;
        int locID = 0;
        ChemType chemType = ChemType.All;
        string orderColOfChem = null;
        SortOrder orderOfChem = SortOrder.None;
        int scrollValueChem = 0;
        public static int selectedIndex = 0;
        public static int selectedId = 0;

        //参数：成员
        string orderColOfMem = null;
        SortOrder orderOfMem = SortOrder.None;
        int scrollValueMem = 0;
        //int selectIndex;
        //彩蛋图片
        List<Image> imageList;

        AutoCompleteStringCollection querySource;
        const int querySourceLength = 10;
        string copyingText;
        Version currentVer;
        public List<Location> ListAllLoc { get; set; }
        public static List<Location> ListLab { get; set; }
        public static List<Location> ListLoc { get; set; }
        public static List<Member> ListUser { get; set; }
        private void GetLocList()
        {
            ListLab = LocationDAL.GetLoc(0);
            ListLoc = new List<Location>();
            Location loc0 = new Location();
            loc0.LocId = 0;
            loc0.LocName = "全部";
            loc0.Uid = -1;
            ListLab.Insert(0, loc0);
            ListLoc.Add(loc0);
        }
        private void SetLoc()
        {
            this.Invoke(new Action(() =>
            {
                comboBoxLab.DisplayMember = "locName";
                comboBoxLab.ValueMember = "locID";
                comboBoxLab.DataSource = ListLab;
                comboBoxLoc.DisplayMember = "locName";
                comboBoxLoc.ValueMember = "locID";
                comboBoxLoc.DataSource = ListLoc;
            }));
        }
        private bool SetChem(DataSet DSChem)
        {
            bool ret = false;
            //Invoke(new Action(() =>
            //{
            if (DSChem.Tables.Count > 0)
            {
                foreach (DataRow item in DSChem.Tables[0].Rows)
                {
                    if (item["purchaser"].ToString() == "")
                        item["purchaser"] = "未知用户";
                    if (item["lastUser"].ToString() == "")
                        item["lastUser"] = "未知用户";
                }
                DGVChem.DataSource = DSChem.Tables[0];
                toolLblCount.Text = string.Format("查询到{0}条记录", DSChem.Tables[0].Rows.Count.ToString());
                DGVChem.Columns["id"].HeaderText = "ID";
                DGVChem.Columns["cn_name"].HeaderText = "中文名称";
                DGVChem.Columns["en_name"].HeaderText = "英文名称";
                DGVChem.Columns["abbr"].HeaderText = "缩写";
                DGVChem.Columns["CAS"].HeaderText = "CAS";
                DGVChem.Columns["capacity"].HeaderText = "规格";
                DGVChem.Columns["unit"].HeaderText = "单位";
                DGVChem.Columns["number"].HeaderText = "数量";
                DGVChem.Columns["residual"].HeaderText = "剩余量";
                DGVChem.Columns["lab"].HeaderText = "实验室";
                DGVChem.Columns["loc"].HeaderText = "存放位置";
                DGVChem.Columns["manufacturer"].HeaderText = "生产厂家";
                DGVChem.Columns["lastUser"].HeaderText = "最后使用";
                DGVChem.Columns["purchaser"].HeaderText = "购买人";
                DGVChem.Columns["purchase_date"].HeaderText = "购买日期";
                DGVChem.Columns["remark"].HeaderText = "备注";
                DGVChem.Columns["en_name"].Visible = Settings.Default.ShowEnName;
                DGVChem.Columns["abbr"].Visible = Settings.Default.ShowAbbr;
                DGVChem.Columns["purchaser"].Visible = Settings.Default.ShowPurchaser;
                DGVChem.Columns["purchase_date"].Visible = Settings.Default.ShowDate;
                DGVChem.Columns["remark"].Visible = Settings.Default.ShowRemark;
                ret = true;
            }
            //}));
            return ret;
        }
        private bool SetMem(DataSet DSMem)
        {
            if (DSMem.Tables.Count > 0)
            {
                DGVMem.DataSource = DSMem.Tables[0];
                DGVMem.Columns[0].Visible = false;
                DGVMem.Columns[1].HeaderText = "学号";
                DGVMem.Columns[2].HeaderText = "姓名";
                DGVMem.Columns[3].HeaderText = "姓别";
                DGVMem.Columns[4].HeaderText = "电话号码";
                DGVMem.Columns[5].HeaderText = "邮箱";
                DGVMem.Columns[6].HeaderText = "密码";
                DGVMem.Columns[7].HeaderText = "级别";
                if (loginState != LoginState.管理员 && loginState != LoginState.教师)
                {
                    DGVMem.Columns[6].Visible = false;
                    DGVMem.Columns[7].Visible = false;
                }
                else
                {
                    DGVMem.Columns[6].Visible = true;
                    DGVMem.Columns[7].Visible = true;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        private void AddTree(int pid, TreeNode pnode = null)
        {
            foreach (Location loc in ListAllLoc)
            {
                if (loc.Uid == pid)
                {
                    TreeNode tnode = new TreeNode();
                    tnode.Text = loc.LocName;
                    tnode.Tag = loc.LocId;
                    if (pnode == null)
                    {
                        treeView.Nodes.Add(tnode);////////////
                    }
                    else
                    {
                        pnode.Nodes.Add(tnode);
                    }
                    AddTree(loc.LocId, tnode);
                }
            }
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public MainView()
        {
            //检查配置文件是否存在
            string configPath = Application.ExecutablePath + ".config";
            //string configPath = "LabManager.config";
            if (!File.Exists(configPath))
            {
                using (FileStream fs = new FileStream(configPath, FileMode.Create))
                {
                    //using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("LabManager.Resourse.Text.App.config"))
                    //{
                    //byte[] data = new byte[stream.Length];
                    //stream.Read(data, 0, data.Length);
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(Resources.exe_config);
                    }
                    //}
                }
            }
            InitializeComponent();
        }
        /// <summary>
        /// 载入窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Load(object sender, EventArgs e)
        {
            //加载Dll文件
            AppDomain.CurrentDomain.AssemblyResolve += (_sender, args) =>
            {
                string resourceName = new AssemblyName(args.Name).Name + ".dll";
                string resource = Array.Find(this.GetType().Assembly.GetManifestResourceNames(), element => element.EndsWith(resourceName));
                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
                {
                    byte[] assemblyData = new byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };
            querySource = new AutoCompleteStringCollection();
            querySource.Add(Settings.Default.QueryText1);
            querySource.Add(Settings.Default.QueryText2);
            querySource.Add(Settings.Default.QueryText3);
            querySource.Add(Settings.Default.QueryText4);
            querySource.Add(Settings.Default.QueryText5);
            querySource.Add(Settings.Default.QueryText6);
            querySource.Add(Settings.Default.QueryText7);
            querySource.Add(Settings.Default.QueryText8);
            querySource.Add(Settings.Default.QueryText9);
            querySource.Add(Settings.Default.QueryText10);
            textBoxQuery.AutoCompleteCustomSource = querySource;
            _Load();
            //删除old文件
            if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "LabManager.exe.old"))
            {
                System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + "LabManager.exe.old");
            }
        }
        public void CheckUpdate(string IP, string port, string addr = "/LabManager/update")
        {
            string updateUrl = string.Format("http://{0}:{1}{2}/update.xml", IP, port, addr);
            currentVer = new Version(Application.ProductVersion);
            string download = "";
            Version newVer = currentVer;
            WebClient wc = new WebClient();
            try
            {
                Stream stream = wc.OpenRead(updateUrl);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(stream);
                XmlNode nodeList = xmlDoc.SelectSingleNode("update");
                foreach (XmlNode node in nodeList)
                {
                    if (node.Name == "version")
                        newVer = new Version(node.InnerText);//该句会在调试时会出现一个System.InvalidOperationException
                    else
                        download = string.Format("http://{0}:{1}{2}/{3}", IP, port, addr, node.InnerText);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLogFile("获取软件更新信息失败-->\n" + ex.Message);
            }
            if (newVer > currentVer)
            {
                DialogResult res = MessageBox.Show(this, string.Format("发现新版本：{0}\n点击确定更新", newVer), "发现新版本", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    //string downloadFileName = string.Format("LabManager_V{0}.{1}.exe", newVer.Major, newVer.Minor);
                    string downloadFileName = "LabManager.exe.tmp";
                    string downloadFilePath = Environment.CurrentDirectory + "\\" + downloadFileName;
                    try
                    {
                        wc.DownloadFile(download, downloadFileName);
                        System.IO.File.Move(Application.ExecutablePath, "LabManager.exe.old");
                        System.IO.File.Move("LabManager.exe.tmp", "LabManager.exe");
                        Log.WriteLogFile("软件更新成功-- >\n当前版本：" + newVer);
                        MessageBox.Show(this, string.Format("已更新软件版本\n原版本：{0}\n新版本：{1}\n新版位置：{2}\n点击确定运行新版程序", currentVer, newVer,
                            Environment.CurrentDirectory + "\\" + "LabManager.exe"), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Restart();
                    }
                    catch (Exception ex)
                    {
                        Log.WriteLogFile("下载新版软件失败-->\n" + ex.Message);
                    }
                    //if (System.IO.File.Exists(downloadFilePath))
                    //{
                    //    //得到桌面文件夹
                    //    string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    //    WshShell shell = new WshShell();
                    //    IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(DesktopPath + "\\实验室管理系统.lnk");
                    //    shortcut.TargetPath = Environment.CurrentDirectory + "\\" + downloadFileName;
                    //    shortcut.Arguments = "";// 参数
                    //    shortcut.Description = "实验室管理系统";
                    //    shortcut.WorkingDirectory = Environment.CurrentDirectory;
                    //    shortcut.IconLocation = Environment.CurrentDirectory + "\\" + downloadFileName + ",0";
                    //    //shortcut.Hotkey = "CTRL+SHIFT+Z";//热键
                    //    //shortcut.WindowStyle = 1;
                    //    shortcut.Save();
                    //    Log.WriteLogFile("软件更新成功-- >\n当前版本：" + newVer);
                    //    MessageBox.Show(string.Format("已更新软件版本\n原版本：{0}\n新版本：{1}\n新版位置：{2}", currentVer, newVer, downloadFilePath), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                }
                else
                {
                    Log.WriteLogFile("取消更新到V" + newVer);
                }
            }
            else
            {
                Log.WriteLogFile("已是最新版软件");
            }
        }
        public void _Load()
        {
            #region Task方法
            Task task1 = new Task(() =>
            {
                Invoke(new Action(() => { timerTime.Stop(); connView.Show(); Enabled = false; }));
                try
                {
                    connectable = SqlHelper.isDataBaseConnectable();
                }
                catch (Exception ex)
                {
                    Log.WriteLogFile("连接数据库出错-->\n" + ex.Message);
                }
            });
            task1.ContinueWith((idontknow) =>
            {
                if (connectable)
                {
                    Invoke(new Action(() => { timerTime.Start(); }));
                    loginState = LoginState.访客;
                    user = new Member() { Name = "访客", Level = LoginState.访客 };
                    listGraMemNum = MemberDAL.GetGraduatedMemNum();
                    listExhaChemID = ChemicalDAL.GetExhaustedChemId();
                    GetLocList();
                    SetLoc();
                    Invoke(new Action(() => SetChem(ChemicalDAL.GetChem(Settings.Default.ShowExhausted, chemType, queryStr, labID, locID, orderColOfChem, orderOfChem))));
                    Invoke(new Action(() => SetMem(MemberDAL.GetMemberInfo(chkBoxShowGrad.Checked))));
                    ListUser = MemberDAL.GetAllUser();
                    ListAllLoc = LocationDAL.GetLoc();

                    BeginInvoke(new Action(() => { treeView.Nodes.Clear(); AddTree(-1); }));
                    SetListPre();
                    BeginInvoke(new Action(() => InitialControl()));
                    Invoke(new Action(() =>
                    {
                        Enabled = true;
                        connView.Hide();
                        mnitLogin.Enabled = true;
                        mnitLogout.Enabled = false;
                        tabControl.SelectedTab = tabPageChem;
                        SetControl(tabControl.SelectedTab);
                        tabControl.Refresh();
                    }));
                    //检查软件更新
                    CheckUpdate(SqlHelper.IP, "8080");
                }
                else
                {
                    Invoke(new Action(() => { Enabled = true; connView.Hide(); }));
                    Invoke(new Action(() =>
                    {
                        ConfigView configView = new ConfigView(true);
                        configView.ShowDialog(this);
                    }));
                }

            });
            task1.Start();
            #endregion
            #region Thread方法
            //Thread Initial = new Thread(new ThreadStart(() =>
            //{
            //    this.Invoke(new Action(() => { timerTime.Stop(); connView.Show(); Enabled = false; }));

            //    connectable = SqlHelper.isDataBaseConnectable();
            //    if (connectable)
            //    {
            //        Invoke(new Action(() => { timerTime.Start(); }));
            //        loginState = LoginState.访客;
            //        user = new User() { UserName = "访客", UserLv = LoginState.访客 };
            //        //*************
            //        //Task<List<string>> getGradMemNum = Task.Factory.StartNew(() => MemberDAL.GetGraduatedMemNum());
            //        //Task.WaitAll(getGradMemNum);
            //        //listGraMemNum = getGradMemNum.Result;
            //        listGraMemNum = MemberDAL.GetGraduatedMemNum();
            //        //*************
            //        //**********
            //        //Task<List<string>> getExhaChemId = Task.Factory.StartNew(() => ChemicalDAL.GetExhaustedChemId());
            //        //Task.WaitAll(getExhaChemId);
            //        //listExhaChemID = getExhaChemId.Result;
            //        listExhaChemID = ChemicalDAL.GetExhaustedChemId();
            //        //**********
            //        //**********
            //        //Task getLocList = Task.Factory.StartNew(() => GetLocList());
            //        //Task.WaitAll(getLocList);
            //        //Task setLoc = Task.Factory.StartNew(() => SetLoc());
            //        GetLocList();
            //        SetLoc();
            //        //**********
            //        //**********
            //        //Task<DataSet>[] getDS = 
            //        //{
            //        //    Task.Factory.StartNew(() => ChemicalDAL.GetChem(Settings.Default.ShowExhausted, chemType, queryStr, labID, locID, orderColOfChem, orderOfChem)),
            //        //    Task.Factory.StartNew(() => MemberDAL.GetMemberInfo(chkBoxShowGrad.Checked)),
            //        //};
            //        //Task.WaitAll(getDS);
            //        //BeginInvoke(new Action(() => SetChem(getDS[0].Result)));
            //        //BeginInvoke(new Action(() => SetMem(getDS[1].Result)));
            //        Invoke(new Action(() => SetChem(ChemicalDAL.GetChem(Settings.Default.ShowExhausted, chemType, queryStr, labID, locID, orderColOfChem, orderOfChem))));
            //        Invoke(new Action(() => SetMem(MemberDAL.GetMemberInfo(chkBoxShowGrad.Checked))));
            //        //**********
            //        //**********
            //        //Task<List<User>> getAllUser = Task.Factory.StartNew(() => MemberDAL.GetAllUser());
            //        //Task.WaitAll(getAllUser);
            //        //ListUser = getAllUser.Result;
            //        ListUser = MemberDAL.GetAllUser();
            //        //**********
            //        //**********
            //        //Task<List<Location>> getAllLoc = Task.Factory.StartNew(() => LocationDAL.GetLoc());
            //        //Task.WaitAll(getAllLoc);
            //        //ListAllLoc = getAllLoc.Result;
            //        ListAllLoc = LocationDAL.GetLoc();
            //        /*********
            //        Invoke(new Action(() => AddTree(-1)));
            //        SetListPre();
            //        Invoke(new Action(() => InitialControl()));
            //    }
            //    else
            //    {
            //        Invoke(new Action(() =>
            //        {
            //            ConfigView configView = new ConfigView(true);
            //            configView.ShowDialog(this);
            //        }));
            //    }
            //    this.Invoke(new Action(() => { connView.Hide(); Enabled = true; }));

            //}));
            //Initial.Start();
            #endregion
        }
        /// <summary>
        /// 初始化窗口组件
        /// </summary>
        public void InitialControl()
        {
            mnitLogout.Enabled = false;
            toolStripLblCurrUser.Text = string.Format("当前用户：{0}({1})", user.Name, user.Level.ToString());
            if (treeView.Nodes.Count > 0)
            {
                treeView.Nodes[0].Expand();
                treeView.Nodes[0].EnsureVisible();
                treeView.SelectedNode = treeView.Nodes[0];
            }
        }
        /// <summary>
        /// 根据当前用户级别设置窗口控件
        /// </summary>
        public void SetControl(TabPage tabPage)
        {
            toolStripLblCurrUser.Text = string.Format("当前用户：{0}({1})", user.Name, user.Level.ToString());
            //设置全局组件
            switch (loginState)
            {
                case LoginState.访客:
                    mnitBakeupDB.Enabled = false;
                    mnitRestoreDB.Enabled = false;
                    break;
                case LoginState.管理员:
                    mnitBakeupDB.Enabled = true;
                    mnitRestoreDB.Enabled = true;
                    break;
                case LoginState.学生:
                    mnitBakeupDB.Enabled = false;
                    mnitRestoreDB.Enabled = false;
                    break;
                case LoginState.教师:
                    mnitBakeupDB.Enabled = true;
                    mnitRestoreDB.Enabled = true;
                    break;
                default:
                    break;
            }
            //设置tabPageChem组件
            #region 设置tabPageChem组件
            if (tabPage == tabPageChem)
            {
                //btnUse.Visible = true;
                btnModify.Text = "修 改";
                switch (loginState)
                {
                    case LoginState.访客:
                        btnAdd.Enabled = false;
                        btnModify.Enabled = false;
                        btnDelete.Enabled = false;
                        btnUse.Enabled = false;
                        btnShowRec.Enabled = false;
                        break;
                    case LoginState.管理员:
                        btnAdd.Enabled = true;
                        btnModify.Enabled = true;
                        btnDelete.Enabled = true;
                        btnUse.Enabled = true;
                        btnShowRec.Enabled = true;
                        break;
                    case LoginState.学生:
                        btnAdd.Enabled = true;
                        btnModify.Enabled = false;
                        btnDelete.Enabled = false;
                        btnUse.Enabled = true;
                        btnShowRec.Enabled = true;
                        break;
                    case LoginState.教师:
                        btnAdd.Enabled = true;
                        btnModify.Enabled = true;
                        btnDelete.Enabled = true;
                        btnUse.Enabled = true;
                        btnShowRec.Enabled = true;
                        break;
                    default:
                        break;
                }
            }
            #endregion
            //设置tabPageAppa组件
            #region 设置tabPageAppa组件
            else if (tabPage == tabPageAppa)
            {

            }
            #endregion
            //设置tabPageMem组件
            #region 设置tabPageMem组件
            else if (tabPage == tabPageMem)
            {
                btnUse.Enabled = false;
                switch (loginState)
                {
                    case LoginState.管理员:
                        btnModify.Text = "修 改";
                        btnAdd.Enabled = true;
                        btnModify.Enabled = true;
                        btnDelete.Enabled = true;
                        break;
                    case LoginState.教师:
                        btnModify.Text = "修 改";
                        btnAdd.Enabled = true;
                        btnModify.Enabled = true;
                        btnDelete.Enabled = true;
                        break;
                    case LoginState.学生:
                        btnModify.Text = "修改个人";
                        btnAdd.Enabled = false;
                        btnModify.Enabled = true;
                        btnDelete.Enabled = false;
                        break;
                    default:
                        break;
                }
            }
            #endregion
            else if (tabPage == tabPageLoc)
            {
                btnAdd.Enabled = false;
                btnModify.Enabled = false;
                btnUse.Enabled = false;
                btnDelete.Enabled = false;
                btnShowRec.Enabled = false;
                btnModify.Text = "修 改";
            }
        }
        /// <summary>
        /// 初始化Loc和Lab两个ComboBox
        /// </summary>
        private void InitialComboBox()
        {
            comboBoxLab.DisplayMember = "locName";
            comboBoxLab.ValueMember = "locID";
            comboBoxLab.DataSource = ListLab;
            comboBoxLoc.DisplayMember = "locName";
            comboBoxLoc.ValueMember = "locID";
            comboBoxLoc.DataSource = ListLoc;
        }
        /// <summary>
        /// 点击登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnitLogin_Click(object sender, EventArgs e)
        {
            logView = new LoginView();
            DialogResult res = logView.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                //MessageBox.Show(string.Format("{0}({1}) 登录成功", user.Name, user.Level.ToString()), "登录成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Log.WriteLogFile(string.Format("{0}({1}) 登录系统", user.Name, user.Level.ToString()));
                mnitLogout.Enabled = true;
                mnitLogin.Enabled = false;

                SetControl(tabPageChem);
                refreshMem();
                tabControl.Refresh();
            }
        }

        /// <summary>
        /// 点击注销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnitLogout_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("注销？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.OK)
            {
                Log.WriteLogFile(string.Format("{0}({1}) 退出登录", user.Name, user.Level.ToString()));
                loginState = LoginState.访客;
                user = new Member() { Name = "访客", Level = LoginState.访客 };
                tabControl.SelectedTab = tabPageChem;
                SetControl(tabPageChem);
                mnitLogin.Enabled = true;
                mnitLogout.Enabled = false;
                tabControl.Refresh();
            }
        }

        /// <summary>
        /// 显示毕业成员复选框状态改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkBoxShowGrad_CheckedChanged(object sender, EventArgs e)
        {
            refreshMem();
        }
        /// <summary>
        /// 药品信息数据绑定完成，用以将已用完药品以其它颜色显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGVChem_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < DGVChem.RowCount; i++)
            {
                DataGridViewRow DGVR = DGVChem.Rows[i];
                if (listExhaChemID.Contains(DGVR.Cells["id"].Value.ToString()))
                {
                    DGVR.DefaultCellStyle.ForeColor = Color.LightGray;
                    DGVR.DefaultCellStyle.SelectionForeColor = Color.LightGray;
                }
            }
            //if (scrollValueChem != 0)
            //{
            //    DGVChem.FirstDisplayedScrollingRowIndex = scrollValueChem;
            //    DGVChem.Refresh();
            //}
        }
        /// <summary>
        /// 成员信息数据绑定完成
        /// 用于将已毕业学生信息以红色显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGVMem_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < DGVMem.RowCount; i++)
            {
                DataGridViewRow DGVR = DGVMem.Rows[i];
                if (listGraMemNum.Contains(DGVR.Cells["number"].Value.ToString()))
                {
                    DGVR.DefaultCellStyle.ForeColor = Color.LightGray;
                    DGVR.DefaultCellStyle.SelectionForeColor = Color.LightGray;
                }
            }
            //DGVMem.FirstDisplayedScrollingRowIndex = scrollValueMem;
        }
        /// <summary>
        /// 切换选项卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            SetControl(tabControl.SelectedTab);
        }
        /// <summary>
        /// timerTime到期，获取当前服务器时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerTime_Tick(object sender, EventArgs e)
        {
            toolLblTime.Text = OtherDAL.getServerTime().ToString();
        }
        /// <summary>
        /// 用户信息表头被点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGVMem_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView DGV = (DataGridView)sender;
                orderColOfMem = DGV.SortedColumn.Name;
                orderOfMem = DGV.SortOrder;
            }
        }
        /// <summary>
        /// 化学药品表头被点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGVChem_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView DGV = (DataGridView)sender;
                orderColOfChem = DGV.SortedColumn.Name;
                orderOfChem = DGV.SortOrder;
            }
        }
        /// <summary>
        /// Lab ComboBox下拉框被提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxLab_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((int)comboBoxLab.SelectedValue == 0)
            {
                ListLoc = new List<Location>();
                Location loc0 = new Location();
                loc0.LocId = 0;
                loc0.LocName = "全部";
                loc0.Uid = -1;
                ListLoc.Add(loc0);
                comboBoxLoc.DisplayMember = "locName";
                comboBoxLoc.ValueMember = "locID";
                comboBoxLoc.DataSource = ListLoc;
            }
            else
            {
                ListLoc = LocationDAL.GetLoc((int)comboBoxLab.SelectedValue);
                Location loc0 = new Location();
                loc0.LocId = 0;
                loc0.LocName = "全部";
                loc0.Uid = -1;
                ListLoc.Insert(0, loc0);
                comboBoxLoc.DisplayMember = "locName";
                comboBoxLoc.ValueMember = "locID";
                comboBoxLoc.DataSource = ListLoc;
            }
            locID = 0;
            labID = (int)comboBoxLab.SelectedValue;
            refreshChem();
        }
        /// <summary>
        /// Loc ComboBox下拉框被提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxLoc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            locID = (int)comboBoxLoc.SelectedValue;
            refreshChem();
        }
        /// <summary>
        /// 查询被点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            queryStr = textBoxQuery.Text.Trim();
            querySource.RemoveAt(querySourceLength - 1);
            querySource.Insert(0, queryStr);
            toolStripProgressBar1.Value = 0;
            Settings.Default.QueryText1 = querySource[0];
            Settings.Default.QueryText2 = querySource[1];
            Settings.Default.QueryText3 = querySource[2];
            Settings.Default.QueryText4 = querySource[3];
            Settings.Default.QueryText5 = querySource[4];
            Settings.Default.QueryText6 = querySource[5];
            Settings.Default.QueryText7 = querySource[6];
            Settings.Default.QueryText8 = querySource[7];
            Settings.Default.QueryText9 = querySource[8];
            Settings.Default.QueryText10 = querySource[9];
            refreshChem();
        }
        /// <summary>
        /// 普通药品CheckBox被点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkBoxComm_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkBox = (CheckBox)sender;
            chemType = checkChemType();
            if (chemType == ChemType.None)
            {
                chkBox.Checked = true;
                return;
            }
            refreshChem();
        }
        /// <summary>
        /// 确定当前需要显示的药品类型
        /// </summary>
        /// <returns>ChemType</returns>
        private ChemType checkChemType()
        {
            if (chkBoxComm.Checked && chkBoxPrec.Checked)
            {
                return ChemType.All;
            }
            else if (chkBoxComm.Checked && !chkBoxPrec.Checked)
            {
                return ChemType.Common;
            }
            else if (!chkBoxComm.Checked && chkBoxPrec.Checked)
            {
                return ChemType.Precursor;
            }
            else
            {
                return ChemType.None;
            }
        }
        /// <summary>
        /// 显示已用完药品被点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkBoxExhuasted_CheckedChanged(object sender, EventArgs e)
        {
            //Settings.Default.ShowExhausted = chkBoxExhuasted.Checked;
            refreshChem();
        }
        /// <summary>
        /// 用户信息滑块事件，用于记录当前滑块所在位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGVMem_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                scrollValueMem = e.NewValue;
            }
        }
        /// <summary>
        /// 药品信息滑块事件，用于记录当前滑块所在位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGVChem_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                scrollValueChem = e.NewValue;
            }
        }

        #region “显示”菜单各CheckBox被点击
        private void mnitShowEn_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem mnit = (ToolStripMenuItem)sender;
            Settings.Default.ShowEnName = mnit.Checked;
            //refreshChem();
            DGVChem.Columns["en_name"].Visible = mnit.Checked;
        }

        private void mnitShowAbbr_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem mnit = (ToolStripMenuItem)sender;
            Settings.Default.ShowAbbr = mnit.Checked;
            //refreshChem();
            DGVChem.Columns["abbr"].Visible = mnit.Checked;
        }

        private void mnitShowPurchaser_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem mnit = (ToolStripMenuItem)sender;
            Settings.Default.ShowPurchaser = mnit.Checked;
            //refreshChem();
            DGVChem.Columns["purchaser"].Visible = mnit.Checked;
        }

        private void mnitShowDate_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem mnit = (ToolStripMenuItem)sender;
            Settings.Default.ShowDate = mnit.Checked;
            //refreshChem();
            DGVChem.Columns["purchase_date"].Visible = mnit.Checked;
        }

        private void mnitShowRemark_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem mnit = (ToolStripMenuItem)sender;
            Settings.Default.ShowRemark = mnit.Checked;
            //refreshChem();
            DGVChem.Columns["remark"].Visible = mnit.Checked;
        }
        #endregion
        /// <summary>
        /// 点击添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabPageChem)
            {
                UpdateChemView updateChemView = new UpdateChemView();
                DialogResult res = updateChemView.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    Task<List<string>> getExhaChemId = Task.Factory.StartNew(() => ChemicalDAL.GetExhaustedChemId());
                    Task.WaitAll(getExhaChemId);
                    listExhaChemID = getExhaChemId.Result;
                    refreshChem();
                    if (selectedId == -1)
                    {
                        DGVChem.Rows[DGVChem.Rows.Count - 1].Selected = true;
                        DGVChem.FirstDisplayedScrollingRowIndex = DGVChem.Rows.Count - 1;
                    }
                    else
                    {
                        foreach (DataGridViewRow row in DGVChem.Rows)
                        {
                            if ((int)row.Cells[0].Value == selectedId)
                            {
                                row.Selected = true;
                                DGVChem.FirstDisplayedScrollingRowIndex = selectedId;
                                break;
                            }
                        }
                    }
                }
            }
            else if (tabControl.SelectedTab == tabPageMem)
            {
                UpdateMemView updateMemView = new UpdateMemView(loginState);
                DialogResult res = updateMemView.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    Task<List<string>> getGradMemNum = Task.Factory.StartNew(() => MemberDAL.GetGraduatedMemNum());
                    Task.WaitAll(getGradMemNum);
                    listGraMemNum = getGradMemNum.Result;
                    refreshMem();
                    DGVMem.Rows[DGVMem.Rows.Count - 1].Selected = true;
                    DGVMem.FirstDisplayedScrollingRowIndex = DGVMem.Rows.Count - 1;
                }
            }
        }
        /// <summary>
        /// 点击修改按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabPageChem)
            {
                int selectIndex = (int)DGVChem.SelectedRows[0].Cells["id"].Value;
                Task<Chemical> getModifiedChem = Task.Factory.StartNew(() => ChemicalDAL.GetSingleChem(selectIndex));
                Task.WaitAll(getModifiedChem);
                Chemical modifiedChem = getModifiedChem.Result;
                UpdateChemView updateChemView = new UpdateChemView(modifiedChem);
                DialogResult res = updateChemView.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    Task<List<string>> getExhaChemId = Task.Factory.StartNew(() => ChemicalDAL.GetExhaustedChemId());
                    Task.WaitAll(getExhaChemId);
                    listExhaChemID = getExhaChemId.Result;
                    refreshChem();
                    foreach (DataGridViewRow row in DGVChem.Rows)
                    {
                        if ((int)row.Cells[0].Value == selectedId)
                        {
                            row.Selected = true;
                            break;
                        }
                    }
                }
            }
            else if (tabControl.SelectedTab == tabPageMem)
            {
                int memId;
                int memIndex = 0;
                Member member;
                if (loginState == LoginState.管理员 || loginState == LoginState.教师)
                {
                    memId = (int)DGVMem.SelectedRows[0].Cells["id"].Value;
                    memIndex = DGVMem.SelectedRows[0].Index;
                    member = MemberDAL.GetSingleMem(memId);
                }
                else
                {
                    memId = user.Id;
                    member = MemberDAL.GetSingleMem(memId);
                    foreach (DataGridViewRow row in DGVMem.Rows)
                    {
                        if ((int)row.Cells["id"].Value == memId)
                        {
                            memIndex = row.Index;
                            break;
                        }
                    }

                }
                UpdateMemView updateMemView = new UpdateMemView(loginState, member);
                updateMemView.id = memId;
                DialogResult res = updateMemView.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    Task<List<string>> getGradMemNum = Task.Factory.StartNew(() => MemberDAL.GetGraduatedMemNum());
                    Task.WaitAll(getGradMemNum);
                    listGraMemNum = getGradMemNum.Result;
                    refreshMem();
                    DGVMem.Rows[memIndex].Selected = true;
                    DGVMem.FirstDisplayedScrollingRowIndex = memIndex;
                }

            }
        }
        private void btnShowRec_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabPageChem)
            {
                int selectChemId = (int)DGVChem.SelectedRows[0].Cells["id"].Value;
                List<Record> listRec = RecordDAL.GetRecordList(RecordIndexType.ChemId, selectChemId);
                RecordView recView = new RecordView(listRec);
                recView.ShowDialog(this);
            }
            else if (tabControl.SelectedTab == tabPageMem)
            {
                int selectMemId = (int)DGVMem.SelectedRows[0].Cells["id"].Value;
                List<Record> listRec = RecordDAL.GetRecordList(RecordIndexType.MemId, selectMemId);
                RecordView recView = new RecordView(listRec);
                recView.ShowDialog(this);
            }

        }

        private void btnUse_Click(object sender, EventArgs e)
        {
            int selectChemId = (int)DGVChem.SelectedRows[0].Cells["id"].Value;
            int selectChemIndex = DGVChem.SelectedRows[0].Index;
            Task<Chemical> getChem = Task<Chemical>.Factory.StartNew(() => ChemicalDAL.GetSingleChem(selectChemId));
            Task.WaitAll(getChem);
            Chemical chemical = getChem.Result;
            if (chemical.Number == 0 && chemical.Residual == 0)
            {
                MessageBox.Show("已用完药品不可再次使用", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                UsageView usageView = new UsageView(chemical);
                DialogResult res = usageView.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    refreshChem();
                    DGVChem.Rows[selectChemIndex].Selected = true;
                }
            }
        }
        /// <summary>
        /// 点击删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabPageChem)
            {
                int selectChemId = (int)DGVChem.SelectedRows[0].Cells["id"].Value;
                selectedIndex = DGVChem.SelectedRows[0].Index;
                string chemName = DGVChem.SelectedRows[0].Cells["cn_name"].Value.ToString();
                string labName = DGVChem.SelectedRows[0].Cells["lab"].Value.ToString();
                string locName = DGVChem.SelectedRows[0].Cells["loc"].Value.ToString();
                DialogResult res = MessageBox.Show(string.Format("此操作不可恢复，请谨慎操作\n\n是否删除第{0}条记录:\n{1} {2} {3}", selectChemId.ToString(), chemName, labName, locName), "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (res == DialogResult.OK)
                {
                    Task delChem = Task.Factory.StartNew(() => ChemicalDAL.DelChem(selectChemId));
                    Task.WaitAll(delChem);


                    refreshChem();
                    if (selectChemId > 0)
                    {
                        DGVChem.Rows[selectedIndex - 1].Selected = true;
                        DGVChem.FirstDisplayedCell = DGVChem.Rows[selectedIndex - 1].Cells[0];
                    }
                    else
                    {
                        DGVChem.Rows[0].Selected = true;
                        DGVChem.FirstDisplayedCell = DGVChem.Rows[0].Cells[0];
                    }
                }
            }
            else if (tabControl.SelectedTab == tabPageMem)
            {
                int memId = (int)DGVMem.SelectedRows[0].Cells["id"].Value;
                int memIndex = DGVMem.SelectedRows[0].Index;
                string memName = DGVMem.SelectedRows[0].Cells["name"].Value.ToString();
                DialogResult res = MessageBox.Show(string.Format("此操作不可恢复，请谨慎操作\n\n是否删除 {0}?", memName), "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (res == DialogResult.OK)
                {
                    Task delMem = Task.Factory.StartNew(() => MemberDAL.DeleteMem(memId));
                    Task.WaitAll(delMem);
                    refreshMem();
                    if (memIndex == 0)
                    {
                        DGVMem.Rows[0].Selected = true;
                    }
                    else
                    {
                        DGVMem.Rows[memIndex - 1].Selected = true;
                    }
                }
            }
        }
        /// <summary>
        /// 主窗口关闭时保存当前配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }
        /// <summary>
        /// 耗时操作开始时禁用主窗口并在状态栏动态显示文字
        /// </summary>
        /// <param name="text">需要显示在状态栏的文字</param>
        public void LblConnecting(string text = "连接数据库")
        {
            toolLblState.ForeColor = Color.Blue;
            string[] dynamicStr = { ".", "..", "...", "...." };
            lock (this)
            {
                int i = 0;
                timerLbl.Tick += (sender, e) =>
                {
                    toolLblState.Text = text + dynamicStr[i % dynamicStr.Length];
                    i++;
                    Console.WriteLine(toolLblState.Text);
                };
                Enabled = false;
                timerLbl.Start();
            }
        }
        /// <summary>
        /// 耗时操作结束时恢复主窗口并清空状态栏文字
        /// </summary>
        public void LblConnected(string text = "")
        {
            lock (this)
            {
                toolLblState.ForeColor = Color.Red;
                toolLblState.Text = text;
                Enabled = true;
                timerLbl.Stop();
            }
        }
        /// <summary>
        /// 刷新成员信息
        /// </summary>
        public void refreshMem()
        {
            Task refreshMem = new Task(() =>
            {
                Invoke(new Action(() => LblConnecting()));
                Task<DataSet> getMemDS = Task.Factory.StartNew(() => MemberDAL.GetMemberInfo(chkBoxShowGrad.Checked, orderColOfMem, orderOfMem));
                Task.WaitAll(getMemDS);
                //IAsyncResult ar = BeginInvoke(new Func<bool>(() => SetMem(getMemDS.Result)));
                //while (!ar.IsCompleted) { }
                //if (bool.Parse(EndInvoke(ar).ToString()))
                //    Invoke(new Action(() => LblConnected()));
                //else
                //    Invoke(new Action(() => LblConnected("连接数据库失败")));
                Invoke(new Action(() =>
                {
                    if (SetMem(getMemDS.Result))
                        LblConnected();
                    else
                        LblConnected("连接数据库失败");
                    if (scrollValueMem != 0)
                    {
                        DGVMem.FirstDisplayedScrollingRowIndex = scrollValueMem;
                        //DGVMem.Refresh();
                    }
                }));
            });
            refreshMem.Start();
            //Task connectingLbl = Task.Factory.StartNew(() => LblConnecting());
            //Task<DataSet> getMemDS = Task.Factory.StartNew(() => MemberDAL.GetMemberInfo(chkBoxShowGrad.Checked, orderColOfMem, orderOfMem));
            //Task.WaitAll(getMemDS);
            //Invoke(new Action(() => SetMem(getMemDS.Result)));
            //Task<List<User>> getAllUser = Task.Factory.StartNew(() => MemberDAL.GetAllUser());
            //Task.WaitAll(getAllUser);
            //ListUser = getAllUser.Result;
            //Task connectedLbl = Task.Factory.StartNew(() => LblConnected());
        }
        /// <summary>
        /// 刷新药品信息
        /// </summary>
        public void refreshChem()
        {
            Task refreshChem = new Task(() =>
            {
                Invoke(new Action(() => LblConnecting()));
                Task<DataSet> getChemDS = Task.Factory.StartNew(() => ChemicalDAL.GetChem(chkBoxExhuasted.Checked, chemType, queryStr, labID, locID, orderColOfChem, orderOfChem));
                Task.WaitAll(getChemDS);
                //IAsyncResult ar = BeginInvoke(new Func<DataSet>(() => ChemicalDAL.GetChem(chkBoxExhuasted.Checked, chemType, queryStr, labID, locID, orderColOfChem, orderOfChem)));
                //while (!ar.IsCompleted) { }


                //IAsyncResult ar = BeginInvoke(new Func<bool>(() => SetChem(getChemDS.Result)));
                //while (!ar.IsCompleted) { }
                //if (bool.Parse(EndInvoke(ar).ToString()))
                //    Invoke(new Action(() => LblConnected()));
                //else
                //    Invoke(new Action(() => LblConnected("连接数据库失败")));
                //*****************************************
                /*Task<bool> setChem = /*Task.Factory.StartNew(() => { SetChem(getChemDS.Result); Invoke(new Action(() => LblConnected())); });*/
                //Task.WaitAll(setChem);
                //if (setChem.Result)
                //Invoke(new Action(() => LblConnected()));
                //else
                //    Invoke(new Action(() => LblConnected("连接数据库失败")));
                Task setChem = Task.Factory.StartNew(() =>
                 {
                     Invoke(new Action(() =>
                     {
                         SetChem(getChemDS.Result);
                         LblConnected();
                     }));
                 });
                //Invoke(new Action(() =>
                //{
                //    //if (SetChem(getChemDS.Result))
                //    if (SetChem((DataSet)EndInvoke(ar)))
                //        LblConnected();
                //    else
                //        LblConnected("连接数据库失败");
                //    if (scrollValueChem != 0)
                //    {
                //        DGVChem.FirstDisplayedScrollingRowIndex = scrollValueChem;
                //        //DGVChem.Refresh();
                //    }
                //}));
            });
            refreshChem.Start();
            //Task<DataSet> getChemDS = Task.Factory.StartNew(() => ChemicalDAL.GetChem(chkBoxExhuasted.Checked, chemType, queryStr, labID, locID, orderColOfChem, orderOfChem));
            //Task connectingLbl = Task.Factory.StartNew(() => LblConnecting());
            //Task.WaitAll(getChemDS);
            //Invoke(new Action(() => SetChem(getChemDS.Result)));
            //Task connectedLbl = Task.Factory.StartNew(() => LblConnected());
        }
        /// <summary>
        /// 快捷登录（测试用）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void login0_Click(object sender, EventArgs e)
        {
            MainView.loginState = LoginState.管理员;
            Member user = new Member() { Id = 0, Name = "詹宸测试", Level = LoginState.管理员 };
            MainView.user = user;
            mnitLogin.Enabled = false;
            mnitLogout.Enabled = true;
            refreshMem();
            SetControl(tabPageChem);
            tabControl.Refresh();
        }
        /// <summary>
        /// 自定义TabControl样式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            string tabName = tabControl.TabPages[e.Index].Text;

            Font font;
            Brush brush;
            Rectangle txtRec = e.Bounds;
            Rectangle fillRec;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                fillRec = new Rectangle(txtRec.X, txtRec.Y + 1, txtRec.Width, txtRec.Height - 1);
                //e.Graphics.FillRectangle(new LinearGradientBrush(fillRec, Color.LawnGreen, Color.Azure, 90f), fillRec);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(170, 245, 137)), fillRec);
                font = new Font(e.Font, FontStyle.Bold);
                brush = new SolidBrush(Color.Black);
                txtRec = new Rectangle(txtRec.X, txtRec.Y + 6, txtRec.Width, txtRec.Height - 6);
            }
            else
            {
                fillRec = new Rectangle(txtRec.X, txtRec.Y - 2, txtRec.Width, txtRec.Height + 2);
                font = e.Font;
                if ((loginState == LoginState.访客 && e.Index > 1) || (loginState == LoginState.学生 && e.Index > 2))
                {
                    e.Graphics.FillRectangle(new LinearGradientBrush(fillRec, Color.LightGray, Color.WhiteSmoke, 90f), fillRec);
                    brush = new SolidBrush(Color.Gray);
                }
                else
                {
                    //e.Graphics.FillRectangle(new LinearGradientBrush(fillRec, Color.LightGreen, Color.Azure, 90f), fillRec);
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(203, 238, 164)), fillRec);
                    brush = new SolidBrush(Color.Black);
                }
            }
            e.Graphics.DrawString(tabName, font, brush, txtRec, stringFormat);
        }
        /// <summary>
        /// 限制tabPage选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if ((loginState == LoginState.学生 && e.TabPageIndex > 2) || (loginState == LoginState.访客 && e.TabPageIndex > 1))
            {
                e.Cancel = true;
            }
        }

        private void mnitSetServer_Click(object sender, EventArgs e)
        {
            ConfigView configView = new ConfigView(false);
            configView.ShowDialog(this);
        }
        /// <summary>
        /// 关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnitAbout_Click(object sender, EventArgs e)
        {
            Console.WriteLine(DGVChem.FirstDisplayedScrollingRowIndex);
            if (aboutView == null || aboutView.IsDisposed)
            {
                aboutView = new AboutView(this);
            }
            aboutView.Show();
        }
        /// <summary>
        /// 更新历史
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnitLog_Click(object sender, EventArgs e)
        {
            if (changeLogView == null || changeLogView.IsDisposed)
            {
                changeLogView = new ChangeLogView(this);
            }
            changeLogView.Show();
        }
        /// <summary>
        /// 备份数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnitBakeupDB_Click(object sender, EventArgs e)
        {
            string thisFileName = System.IO.Path.GetFileName(Application.ExecutablePath);
            Configuration config = ConfigurationManager.OpenExeConfiguration(thisFileName);
            string connectionString = config.ConnectionStrings.ConnectionStrings["LabMan"].ConnectionString;
            //string connectionString = ConfigurationManager.ConnectionStrings["LabMan"].ConnectionString;
            string[] str = connectionString.Split(';', '=');
            string host = str[1];
            string user = str[3];
            string psw = str[5];
            string database = str[7];
            string charset = str[11];
            StringBuilder fileName = new StringBuilder();
            fileName.Append("lab_bakeup_" + DateTime.Now + ".sql").Replace("/", "").Replace(":", "").Replace(" ", "");
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.AddExtension = false;
            saveFileDialog.CheckFileExists = false;
            saveFileDialog.CheckPathExists = false;
            saveFileDialog.Filter = "sql脚本文件|*.sql";
            saveFileDialog.FileName = fileName.ToString();
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string directory = saveFileDialog.FileName;
                    string command = string.Format("mysqldump --host={0} --default-character-set={1} --user={2} --password={3} {4}>{5}", host, charset, user, psw, database, directory);
                    Cmd.StartCmd(command);
                    Log.WriteLogFile("数据库成功备份到" + directory);
                    MessageBox.Show("数据库成功备份到" + directory, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLogFile("数据库备份失败-->\n" + ex.Message);
                MessageBox.Show("数据库备份失败！请查看日志文件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 还原数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnitRestoreDB_Click(object sender, EventArgs e)
        {
            string thisFileName = System.IO.Path.GetFileName(Application.ExecutablePath);
            Configuration config = ConfigurationManager.OpenExeConfiguration(thisFileName);
            string connectionString = config.ConnectionStrings.ConnectionStrings["LabMan"].ConnectionString;
            //string connectionString = ConfigurationManager.ConnectionStrings["LabMan"].ConnectionString;
            string[] str = connectionString.Split(';', '=');
            string host = str[1];
            string user = str[3];
            string psw = str[5];
            string database = str[7];
            string charset = str[11];
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "sql脚本文件|*.sql|所有文件|*.*";
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string directory = openFileDialog.FileName;
                    string command = string.Format("mysql --host={0} --default-character-set={1} --user={2} --password={3} {4}<\"{5}\"", host, charset, user, psw, database, directory);
                    DialogResult result = MessageBox.Show("确定覆盖当前数据库？此操作不可恢复！！！", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        Cmd.StartCmd(command);
                        Log.WriteLogFile("数据库成功还原，还原文件为：" + directory);
                        MessageBox.Show("数据库还原成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLogFile("数据库还原失败-->\n" + ex.Message);
                MessageBox.Show("数据库还原失败！请查看日志文件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// 帮助
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnitHelp_Click(object sender, EventArgs e)
        {
            if (!File.Exists("help.chm"))
            {
                FileStream fs = new FileStream("help.chm", FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(Resources.chm);
                bw.Close();
                fs.Close();
            }
            Help.ShowHelp(this, "help.chm");
        }
        /// <summary>
        /// 彩蛋1
        /// </summary>
        public void egg1()
        {
            if (tabControl.TabPages.Count < 5)
            {
                imageList = new List<Image>();
                imageList.Add(Resources.pic1);
                imageList.Add(Resources.pic2);
                imageList.Add(Resources.pic3);
                imageList.Add(Resources.pic4);
                imageList.Add(Resources.pic5);
                imageList.Add(Resources.pic6);
                imageList.Add(Resources.pic7);
                imageList.Add(Resources.pic8);
                imageList.Add(Resources.pic9);
                imageList.Add(Resources.pic10);
                TabPage tabPageEgg = new TabPage("彩蛋");
                tabPageEgg.AutoScroll = true;
                tabControl.TabPages.Add(tabPageEgg);
                PictureBox picBox = new PictureBox();
                picBox.Image = imageList[0];
                picBox.Tag = 0;
                tabPageEgg.Controls.Add(picBox);
                picBox.SizeMode = PictureBoxSizeMode.AutoSize;
                picBox.Click += new System.EventHandler(picBox_Click);
            }
        }

        private void picBox_Click(object sender, EventArgs e)
        {
            PictureBox picBox = (PictureBox)sender;
            if ((int)picBox.Tag == imageList.Count - 1)
            {
                picBox.Parent.Dispose();
            }
            else
            {
                picBox.Tag = (int)picBox.Tag + 1;
                picBox.Image = imageList[(int)picBox.Tag];
            }

        }
        /// <summary>
        /// 右键点击DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGVChem_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                DataGridView dgv = (DataGridView)sender;
                dgv.Rows[e.RowIndex].Selected = true;
                toolMnitCopy.Text = "复制" + dgv.Columns[e.ColumnIndex].HeaderText;
                copyingText = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                conMnStrip.Show(MousePosition.X, MousePosition.Y);
            }
        }
        /// <summary>
        /// 点击复制单元格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolMnitCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(copyingText);
            copyingText = "";
            MessageBox.Show("已复制到剪贴版", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// 导出为Excel
        /// </summary>
        /// <param name="dgv"></param>
        private void ExportToExcel(DataGridView dgv)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Execl files (*.xls)|*.xls";
            dlg.FilterIndex = 0;
            dlg.RestoreDirectory = true;
            dlg.CreatePrompt = true;
            dlg.Title = "保存为Excel文件";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Stream myStream;
                myStream = dlg.OpenFile();
                StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(0));
                StringBuilder sb = new StringBuilder();
                try
                {
                    //写入列标题     
                    for (int i = 0; i < dgv.ColumnCount; i++)
                    {
                        sb.Append(dgv.Columns[i].HeaderText.ToLower() + "\t");
                    }
                    sb.Append(Environment.NewLine);
                    //写入列内容     
                    for (int j = 0; j < dgv.Rows.Count; j++)
                    {
                        toolStripProgressBar1.Value = Convert.ToInt32(Convert.ToSingle(j) / dgv.RowCount * toolStripProgressBar1.Maximum);
                        for (int k = 0; k < dgv.Columns.Count; k++)
                        {
                            sb.Append(dgv.Rows[j].Cells[k].Value.ToString().Trim() + "\t");
                        }
                        sb.Append(Environment.NewLine);
                    }
                    sw.WriteLine(sb);
                    sw.Close();
                    myStream.Close();
                    MessageBox.Show("已将数据导出到" + dlg.FileName, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Log.WriteLogFile("导出Excel成功");
                }
                catch (Exception ex)
                {
                    Log.WriteLogFile("导出Excel失败-->\n" + ex.Message);
                }
                finally
                {
                    sw.Close();
                    myStream.Close();
                }
            }
        }
        /// <summary>
        /// 点击导出按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnitExport_Click(object sender, EventArgs e)
        {
            ExportToExcel(DGVChem);
        }
    }
}
