namespace LabManager.View
{
    partial class MainView
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.conMnStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolMnitCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxQuery = new System.Windows.Forms.TextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mnitLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnitLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnitSet = new System.Windows.Forms.ToolStripMenuItem();
            this.mnitSetServer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnitExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnitBakeupDB = new System.Windows.Forms.ToolStripMenuItem();
            this.mnitRestoreDB = new System.Windows.Forms.ToolStripMenuItem();
            this.mnitShow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnitShowEn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnitShowAbbr = new System.Windows.Forms.ToolStripMenuItem();
            this.mnitShowPurchaser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnitShowDate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnitShowRemark = new System.Windows.Forms.ToolStripMenuItem();
            this.mnitHelpDown = new System.Windows.Forms.ToolStripMenuItem();
            this.mnitHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnitLog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnitAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.btnQuery = new System.Windows.Forms.Button();
            this.comboBoxLab = new System.Windows.Forms.ComboBox();
            this.comboBoxLoc = new System.Windows.Forms.ComboBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageChem = new System.Windows.Forms.TabPage();
            this.tbLayPanChem = new System.Windows.Forms.TableLayoutPanel();
            this.DGVChem = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkBoxExhuasted = new System.Windows.Forms.CheckBox();
            this.chkBoxPrec = new System.Windows.Forms.CheckBox();
            this.chkBoxComm = new System.Windows.Forms.CheckBox();
            this.tabPageAppa = new System.Windows.Forms.TabPage();
            this.DGVAppa = new System.Windows.Forms.DataGridView();
            this.tabPageMem = new System.Windows.Forms.TabPage();
            this.tbLayPanMem = new System.Windows.Forms.TableLayoutPanel();
            this.DGVMem = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkBoxShowGrad = new System.Windows.Forms.CheckBox();
            this.tabPageLoc = new System.Windows.Forms.TabPage();
            this.tbLayoutPanLoc = new System.Windows.Forms.TableLayoutPanel();
            this.treeView = new System.Windows.Forms.TreeView();
            this.toolStripLoc = new System.Windows.Forms.ToolStrip();
            this.toolBtnAdd = new System.Windows.Forms.ToolStripButton();
            this.toolBtnMod = new System.Windows.Forms.ToolStripButton();
            this.toolBtnDel = new System.Windows.Forms.ToolStripButton();
            this.toolBtnRedo = new System.Windows.Forms.ToolStripButton();
            this.toolBtnSave = new System.Windows.Forms.ToolStripButton();
            this.listBox = new System.Windows.Forms.ListBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLblCurrUser = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolLblState = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolLblTime = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolLblCount = new System.Windows.Forms.ToolStripLabel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnUse = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnShowRec = new System.Windows.Forms.Button();
            this.timerTime = new System.Windows.Forms.Timer(this.components);
            this.bkWork = new System.ComponentModel.BackgroundWorker();
            this.timerLbl = new System.Windows.Forms.Timer(this.components);
            this.login0 = new System.Windows.Forms.Button();
            this.imageListDrag = new System.Windows.Forms.ImageList(this.components);
            this.timerDrag = new System.Windows.Forms.Timer(this.components);
            this.conMnStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageChem.SuspendLayout();
            this.tbLayPanChem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVChem)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPageAppa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVAppa)).BeginInit();
            this.tabPageMem.SuspendLayout();
            this.tbLayPanMem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMem)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabPageLoc.SuspendLayout();
            this.tbLayoutPanLoc.SuspendLayout();
            this.toolStripLoc.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // conMnStrip
            // 
            this.conMnStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.conMnStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolMnitCopy});
            this.conMnStrip.Name = "conMnStrip";
            this.conMnStrip.Size = new System.Drawing.Size(109, 28);
            // 
            // toolMnitCopy
            // 
            this.toolMnitCopy.Name = "toolMnitCopy";
            this.toolMnitCopy.Size = new System.Drawing.Size(108, 24);
            this.toolMnitCopy.Text = "复制";
            // 
            // textBoxQuery
            // 
            this.textBoxQuery.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxQuery.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxQuery.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxQuery.Location = new System.Drawing.Point(216, 36);
            this.textBoxQuery.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxQuery.MaximumSize = new System.Drawing.Size(400, 25);
            this.textBoxQuery.MinimumSize = new System.Drawing.Size(100, 25);
            this.textBoxQuery.Name = "textBoxQuery";
            this.textBoxQuery.Size = new System.Drawing.Size(360, 25);
            this.textBoxQuery.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnitLogin,
            this.mnitLogout,
            this.mnitSet,
            this.mnitShow,
            this.mnitHelpDown});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Margin = new System.Windows.Forms.Padding(5);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(882, 28);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip";
            // 
            // mnitLogin
            // 
            this.mnitLogin.Name = "mnitLogin";
            this.mnitLogin.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.mnitLogin.Size = new System.Drawing.Size(51, 24);
            this.mnitLogin.Text = "登录";
            this.mnitLogin.Click += new System.EventHandler(this.mnitLogin_Click);
            // 
            // mnitLogout
            // 
            this.mnitLogout.Enabled = false;
            this.mnitLogout.Name = "mnitLogout";
            this.mnitLogout.Size = new System.Drawing.Size(51, 24);
            this.mnitLogout.Text = "注销";
            this.mnitLogout.Click += new System.EventHandler(this.mnitLogout_Click);
            // 
            // mnitSet
            // 
            this.mnitSet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnitSetServer,
            this.mnitExport,
            this.toolStripMenuItem1,
            this.mnitBakeupDB,
            this.mnitRestoreDB});
            this.mnitSet.Name = "mnitSet";
            this.mnitSet.Size = new System.Drawing.Size(51, 24);
            this.mnitSet.Text = "配置";
            // 
            // mnitSetServer
            // 
            this.mnitSetServer.Image = global::LabManager.Properties.Resources.ServerSetup;
            this.mnitSetServer.Name = "mnitSetServer";
            this.mnitSetServer.Size = new System.Drawing.Size(181, 26);
            this.mnitSetServer.Text = "服务器设置";
            this.mnitSetServer.Click += new System.EventHandler(this.mnitSetServer_Click);
            // 
            // mnitExport
            // 
            this.mnitExport.Image = global::LabManager.Properties.Resources.Excel;
            this.mnitExport.Name = "mnitExport";
            this.mnitExport.Size = new System.Drawing.Size(181, 26);
            this.mnitExport.Text = "导出Excel";
            this.mnitExport.Click += new System.EventHandler(this.mnitExport_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(178, 6);
            // 
            // mnitBakeupDB
            // 
            this.mnitBakeupDB.Enabled = false;
            this.mnitBakeupDB.Image = global::LabManager.Properties.Resources.Export;
            this.mnitBakeupDB.Name = "mnitBakeupDB";
            this.mnitBakeupDB.Size = new System.Drawing.Size(181, 26);
            this.mnitBakeupDB.Text = "备份数据库";
            this.mnitBakeupDB.Click += new System.EventHandler(this.mnitBakeupDB_Click);
            // 
            // mnitRestoreDB
            // 
            this.mnitRestoreDB.Enabled = false;
            this.mnitRestoreDB.Image = global::LabManager.Properties.Resources.Import;
            this.mnitRestoreDB.Name = "mnitRestoreDB";
            this.mnitRestoreDB.Size = new System.Drawing.Size(181, 26);
            this.mnitRestoreDB.Text = "还原数据库";
            this.mnitRestoreDB.Click += new System.EventHandler(this.mnitRestoreDB_Click);
            // 
            // mnitShow
            // 
            this.mnitShow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnitShowEn,
            this.mnitShowAbbr,
            this.mnitShowPurchaser,
            this.mnitShowDate,
            this.mnitShowRemark});
            this.mnitShow.Name = "mnitShow";
            this.mnitShow.Size = new System.Drawing.Size(51, 24);
            this.mnitShow.Text = "查看";
            // 
            // mnitShowEn
            // 
            this.mnitShowEn.Checked = global::LabManager.Properties.Settings.Default.ShowEnName;
            this.mnitShowEn.CheckOnClick = true;
            this.mnitShowEn.Name = "mnitShowEn";
            this.mnitShowEn.Size = new System.Drawing.Size(144, 26);
            this.mnitShowEn.Text = "英文名称";
            this.mnitShowEn.CheckedChanged += new System.EventHandler(this.mnitShowEn_CheckedChanged);
            // 
            // mnitShowAbbr
            // 
            this.mnitShowAbbr.Checked = global::LabManager.Properties.Settings.Default.ShowAbbr;
            this.mnitShowAbbr.CheckOnClick = true;
            this.mnitShowAbbr.Name = "mnitShowAbbr";
            this.mnitShowAbbr.Size = new System.Drawing.Size(144, 26);
            this.mnitShowAbbr.Text = "缩写";
            this.mnitShowAbbr.CheckedChanged += new System.EventHandler(this.mnitShowAbbr_CheckedChanged);
            // 
            // mnitShowPurchaser
            // 
            this.mnitShowPurchaser.Checked = global::LabManager.Properties.Settings.Default.ShowPurchaser;
            this.mnitShowPurchaser.CheckOnClick = true;
            this.mnitShowPurchaser.Name = "mnitShowPurchaser";
            this.mnitShowPurchaser.Size = new System.Drawing.Size(144, 26);
            this.mnitShowPurchaser.Text = "购买人";
            this.mnitShowPurchaser.CheckedChanged += new System.EventHandler(this.mnitShowPurchaser_CheckedChanged);
            // 
            // mnitShowDate
            // 
            this.mnitShowDate.Checked = global::LabManager.Properties.Settings.Default.ShowDate;
            this.mnitShowDate.CheckOnClick = true;
            this.mnitShowDate.Name = "mnitShowDate";
            this.mnitShowDate.Size = new System.Drawing.Size(144, 26);
            this.mnitShowDate.Text = "购买日期";
            this.mnitShowDate.CheckedChanged += new System.EventHandler(this.mnitShowDate_CheckedChanged);
            // 
            // mnitShowRemark
            // 
            this.mnitShowRemark.Checked = global::LabManager.Properties.Settings.Default.ShowRemark;
            this.mnitShowRemark.CheckOnClick = true;
            this.mnitShowRemark.Name = "mnitShowRemark";
            this.mnitShowRemark.Size = new System.Drawing.Size(144, 26);
            this.mnitShowRemark.Text = "备注";
            this.mnitShowRemark.CheckedChanged += new System.EventHandler(this.mnitShowRemark_CheckedChanged);
            // 
            // mnitHelpDown
            // 
            this.mnitHelpDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnitHelp,
            this.mnitLog,
            this.toolStripSeparator4,
            this.mnitAbout});
            this.mnitHelpDown.Name = "mnitHelpDown";
            this.mnitHelpDown.Size = new System.Drawing.Size(51, 24);
            this.mnitHelpDown.Text = "帮助";
            // 
            // mnitHelp
            // 
            this.mnitHelp.Image = global::LabManager.Properties.Resources.Help;
            this.mnitHelp.Name = "mnitHelp";
            this.mnitHelp.ShortcutKeyDisplayString = "";
            this.mnitHelp.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.mnitHelp.Size = new System.Drawing.Size(144, 26);
            this.mnitHelp.Text = "帮助";
            this.mnitHelp.Click += new System.EventHandler(this.mnitHelp_Click);
            // 
            // mnitLog
            // 
            this.mnitLog.Image = global::LabManager.Properties.Resources.Log;
            this.mnitLog.Name = "mnitLog";
            this.mnitLog.Size = new System.Drawing.Size(144, 26);
            this.mnitLog.Text = "更新历史";
            this.mnitLog.Click += new System.EventHandler(this.mnitLog_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(141, 6);
            // 
            // mnitAbout
            // 
            this.mnitAbout.Image = global::LabManager.Properties.Resources.About;
            this.mnitAbout.Name = "mnitAbout";
            this.mnitAbout.Size = new System.Drawing.Size(144, 26);
            this.mnitAbout.Text = "关于";
            this.mnitAbout.Click += new System.EventHandler(this.mnitAbout_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnQuery.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnQuery.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.btnQuery.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuery.Location = new System.Drawing.Point(586, 35);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(5);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(80, 27);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // comboBoxLab
            // 
            this.comboBoxLab.BackColor = System.Drawing.SystemColors.Control;
            this.comboBoxLab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLab.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxLab.FormattingEnabled = true;
            this.comboBoxLab.Location = new System.Drawing.Point(314, 2);
            this.comboBoxLab.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxLab.Name = "comboBoxLab";
            this.comboBoxLab.Size = new System.Drawing.Size(90, 23);
            this.comboBoxLab.TabIndex = 3;
            this.comboBoxLab.SelectionChangeCommitted += new System.EventHandler(this.comboBoxLab_SelectionChangeCommitted);
            // 
            // comboBoxLoc
            // 
            this.comboBoxLoc.BackColor = System.Drawing.SystemColors.Control;
            this.comboBoxLoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLoc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxLoc.FormattingEnabled = true;
            this.comboBoxLoc.Location = new System.Drawing.Point(414, 2);
            this.comboBoxLoc.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxLoc.Name = "comboBoxLoc";
            this.comboBoxLoc.Size = new System.Drawing.Size(90, 23);
            this.comboBoxLoc.TabIndex = 4;
            this.comboBoxLoc.SelectionChangeCommitted += new System.EventHandler(this.comboBoxLoc_SelectionChangeCommitted);
            // 
            // tabControl
            // 
            this.tabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageChem);
            this.tabControl.Controls.Add(this.tabPageAppa);
            this.tabControl.Controls.Add(this.tabPageMem);
            this.tabControl.Controls.Add(this.tabPageLoc);
            this.tabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl.HotTrack = true;
            this.tabControl.ItemSize = new System.Drawing.Size(72, 20);
            this.tabControl.Location = new System.Drawing.Point(0, 69);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(0, 0);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.ShowToolTips = true;
            this.tabControl.Size = new System.Drawing.Size(882, 410);
            this.tabControl.TabIndex = 5;
            this.tabControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl_DrawItem);
            this.tabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl_Selecting);
            this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl_Selected);
            // 
            // tabPageChem
            // 
            this.tabPageChem.Controls.Add(this.tbLayPanChem);
            this.tabPageChem.Location = new System.Drawing.Point(4, 4);
            this.tabPageChem.Name = "tabPageChem";
            this.tabPageChem.Size = new System.Drawing.Size(874, 382);
            this.tabPageChem.TabIndex = 0;
            this.tabPageChem.Text = "化学药品";
            this.tabPageChem.UseVisualStyleBackColor = true;
            // 
            // tbLayPanChem
            // 
            this.tbLayPanChem.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tbLayPanChem.ColumnCount = 1;
            this.tbLayPanChem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbLayPanChem.Controls.Add(this.DGVChem, 0, 0);
            this.tbLayPanChem.Controls.Add(this.panel1, 0, 1);
            this.tbLayPanChem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLayPanChem.Location = new System.Drawing.Point(0, 0);
            this.tbLayPanChem.Name = "tbLayPanChem";
            this.tbLayPanChem.RowCount = 2;
            this.tbLayPanChem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbLayPanChem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tbLayPanChem.Size = new System.Drawing.Size(874, 382);
            this.tbLayPanChem.TabIndex = 1;
            // 
            // DGVChem
            // 
            this.DGVChem.AllowUserToAddRows = false;
            this.DGVChem.AllowUserToDeleteRows = false;
            this.DGVChem.AllowUserToResizeRows = false;
            this.DGVChem.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVChem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVChem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVChem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVChem.Location = new System.Drawing.Point(4, 4);
            this.DGVChem.MultiSelect = false;
            this.DGVChem.Name = "DGVChem";
            this.DGVChem.ReadOnly = true;
            this.DGVChem.RowTemplate.Height = 27;
            this.DGVChem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVChem.ShowEditingIcon = false;
            this.DGVChem.ShowRowErrors = false;
            this.DGVChem.Size = new System.Drawing.Size(866, 346);
            this.DGVChem.TabIndex = 1;
            this.DGVChem.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVChem_ColumnHeaderMouseClick);
            this.DGVChem.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DGVChem_DataBindingComplete);
            this.DGVChem.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DGVChem_Scroll);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkBoxExhuasted);
            this.panel1.Controls.Add(this.chkBoxPrec);
            this.panel1.Controls.Add(this.chkBoxComm);
            this.panel1.Controls.Add(this.comboBoxLab);
            this.panel1.Controls.Add(this.comboBoxLoc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 354);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(872, 27);
            this.panel1.TabIndex = 2;
            // 
            // chkBoxExhuasted
            // 
            this.chkBoxExhuasted.AutoSize = true;
            this.chkBoxExhuasted.Checked = global::LabManager.Properties.Settings.Default.ShowExhausted;
            this.chkBoxExhuasted.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::LabManager.Properties.Settings.Default, "ShowExhausted", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkBoxExhuasted.Location = new System.Drawing.Point(152, 4);
            this.chkBoxExhuasted.Name = "chkBoxExhuasted";
            this.chkBoxExhuasted.Size = new System.Drawing.Size(134, 19);
            this.chkBoxExhuasted.TabIndex = 15;
            this.chkBoxExhuasted.Text = "显示已用完药品";
            this.chkBoxExhuasted.UseVisualStyleBackColor = true;
            this.chkBoxExhuasted.CheckedChanged += new System.EventHandler(this.chkBoxExhuasted_CheckedChanged);
            // 
            // chkBoxPrec
            // 
            this.chkBoxPrec.AutoSize = true;
            this.chkBoxPrec.Checked = true;
            this.chkBoxPrec.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxPrec.Location = new System.Drawing.Point(72, 4);
            this.chkBoxPrec.Name = "chkBoxPrec";
            this.chkBoxPrec.Size = new System.Drawing.Size(74, 19);
            this.chkBoxPrec.TabIndex = 13;
            this.chkBoxPrec.Text = "易制毒";
            this.chkBoxPrec.UseVisualStyleBackColor = true;
            this.chkBoxPrec.CheckedChanged += new System.EventHandler(this.chkBoxComm_CheckedChanged);
            // 
            // chkBoxComm
            // 
            this.chkBoxComm.AutoSize = true;
            this.chkBoxComm.Checked = true;
            this.chkBoxComm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxComm.Location = new System.Drawing.Point(7, 4);
            this.chkBoxComm.Name = "chkBoxComm";
            this.chkBoxComm.Size = new System.Drawing.Size(59, 19);
            this.chkBoxComm.TabIndex = 14;
            this.chkBoxComm.Text = "普通";
            this.chkBoxComm.UseVisualStyleBackColor = true;
            this.chkBoxComm.CheckedChanged += new System.EventHandler(this.chkBoxComm_CheckedChanged);
            // 
            // tabPageAppa
            // 
            this.tabPageAppa.Controls.Add(this.DGVAppa);
            this.tabPageAppa.ImeMode = System.Windows.Forms.ImeMode.On;
            this.tabPageAppa.Location = new System.Drawing.Point(4, 4);
            this.tabPageAppa.Name = "tabPageAppa";
            this.tabPageAppa.Size = new System.Drawing.Size(874, 382);
            this.tabPageAppa.TabIndex = 2;
            this.tabPageAppa.Text = "仪器设备";
            this.tabPageAppa.UseVisualStyleBackColor = true;
            // 
            // DGVAppa
            // 
            this.DGVAppa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVAppa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVAppa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVAppa.Location = new System.Drawing.Point(0, 0);
            this.DGVAppa.Name = "DGVAppa";
            this.DGVAppa.RowTemplate.Height = 27;
            this.DGVAppa.Size = new System.Drawing.Size(874, 382);
            this.DGVAppa.TabIndex = 0;
            // 
            // tabPageMem
            // 
            this.tabPageMem.Controls.Add(this.tbLayPanMem);
            this.tabPageMem.Location = new System.Drawing.Point(4, 4);
            this.tabPageMem.Name = "tabPageMem";
            this.tabPageMem.Size = new System.Drawing.Size(874, 382);
            this.tabPageMem.TabIndex = 3;
            this.tabPageMem.Text = "成员信息";
            this.tabPageMem.UseVisualStyleBackColor = true;
            // 
            // tbLayPanMem
            // 
            this.tbLayPanMem.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tbLayPanMem.ColumnCount = 1;
            this.tbLayPanMem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbLayPanMem.Controls.Add(this.DGVMem, 0, 0);
            this.tbLayPanMem.Controls.Add(this.panel2, 0, 1);
            this.tbLayPanMem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLayPanMem.Location = new System.Drawing.Point(0, 0);
            this.tbLayPanMem.Name = "tbLayPanMem";
            this.tbLayPanMem.RowCount = 2;
            this.tbLayPanMem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbLayPanMem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tbLayPanMem.Size = new System.Drawing.Size(874, 382);
            this.tbLayPanMem.TabIndex = 1;
            // 
            // DGVMem
            // 
            this.DGVMem.AllowUserToAddRows = false;
            this.DGVMem.AllowUserToDeleteRows = false;
            this.DGVMem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVMem.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVMem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVMem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVMem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVMem.Location = new System.Drawing.Point(4, 4);
            this.DGVMem.MultiSelect = false;
            this.DGVMem.Name = "DGVMem";
            this.DGVMem.ReadOnly = true;
            this.DGVMem.RowTemplate.Height = 27;
            this.DGVMem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVMem.ShowEditingIcon = false;
            this.DGVMem.ShowRowErrors = false;
            this.DGVMem.Size = new System.Drawing.Size(866, 346);
            this.DGVMem.TabIndex = 1;
            this.DGVMem.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVMem_ColumnHeaderMouseClick);
            this.DGVMem.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DGVMem_DataBindingComplete);
            this.DGVMem.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DGVMem_Scroll);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkBoxShowGrad);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 354);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(872, 27);
            this.panel2.TabIndex = 2;
            // 
            // chkBoxShowGrad
            // 
            this.chkBoxShowGrad.AutoSize = true;
            this.chkBoxShowGrad.Checked = global::LabManager.Properties.Settings.Default.ShowGraduated;
            this.chkBoxShowGrad.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::LabManager.Properties.Settings.Default, "ShowGraduated", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkBoxShowGrad.Location = new System.Drawing.Point(7, 4);
            this.chkBoxShowGrad.Name = "chkBoxShowGrad";
            this.chkBoxShowGrad.Size = new System.Drawing.Size(119, 19);
            this.chkBoxShowGrad.TabIndex = 13;
            this.chkBoxShowGrad.Text = "显示毕业成员";
            this.chkBoxShowGrad.UseVisualStyleBackColor = true;
            this.chkBoxShowGrad.CheckedChanged += new System.EventHandler(this.chkBoxShowGrad_CheckedChanged);
            // 
            // tabPageLoc
            // 
            this.tabPageLoc.Controls.Add(this.tbLayoutPanLoc);
            this.tabPageLoc.Location = new System.Drawing.Point(4, 4);
            this.tabPageLoc.Name = "tabPageLoc";
            this.tabPageLoc.Size = new System.Drawing.Size(874, 382);
            this.tabPageLoc.TabIndex = 4;
            this.tabPageLoc.Text = "存放位置";
            this.tabPageLoc.UseVisualStyleBackColor = true;
            // 
            // tbLayoutPanLoc
            // 
            this.tbLayoutPanLoc.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tbLayoutPanLoc.ColumnCount = 2;
            this.tbLayoutPanLoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbLayoutPanLoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbLayoutPanLoc.Controls.Add(this.treeView, 0, 0);
            this.tbLayoutPanLoc.Controls.Add(this.toolStripLoc, 0, 1);
            this.tbLayoutPanLoc.Controls.Add(this.listBox, 1, 0);
            this.tbLayoutPanLoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLayoutPanLoc.Location = new System.Drawing.Point(0, 0);
            this.tbLayoutPanLoc.Name = "tbLayoutPanLoc";
            this.tbLayoutPanLoc.RowCount = 2;
            this.tbLayoutPanLoc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbLayoutPanLoc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tbLayoutPanLoc.Size = new System.Drawing.Size(874, 382);
            this.tbLayoutPanLoc.TabIndex = 1;
            // 
            // treeView
            // 
            this.treeView.AllowDrop = true;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(4, 4);
            this.treeView.Name = "treeView";
            this.treeView.ShowNodeToolTips = true;
            this.treeView.Size = new System.Drawing.Size(429, 343);
            this.treeView.TabIndex = 0;
            this.treeView.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView_BeforeLabelEdit);
            this.treeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView_AfterLabelEdit);
            this.treeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView1_ItemDrag);
            this.treeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView1_DragDrop);
            this.treeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView1_DragEnter);
            this.treeView.DragOver += new System.Windows.Forms.DragEventHandler(this.treeView1_DragOver);
            this.treeView.DragLeave += new System.EventHandler(this.treeView1_DragLeave);
            this.treeView.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.treeView1_GiveFeedback);
            // 
            // toolStripLoc
            // 
            this.toolStripLoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripLoc.CanOverflow = false;
            this.tbLayoutPanLoc.SetColumnSpan(this.toolStripLoc, 2);
            this.toolStripLoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripLoc.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripLoc.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripLoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnAdd,
            this.toolBtnMod,
            this.toolBtnDel,
            this.toolBtnRedo,
            this.toolBtnSave});
            this.toolStripLoc.Location = new System.Drawing.Point(1, 351);
            this.toolStripLoc.Name = "toolStripLoc";
            this.toolStripLoc.Size = new System.Drawing.Size(872, 30);
            this.toolStripLoc.TabIndex = 1;
            this.toolStripLoc.Text = "toolStrip1";
            // 
            // toolBtnAdd
            // 
            this.toolBtnAdd.Image = global::LabManager.Properties.Resources.Add;
            this.toolBtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnAdd.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.toolBtnAdd.Name = "toolBtnAdd";
            this.toolBtnAdd.Size = new System.Drawing.Size(63, 27);
            this.toolBtnAdd.Text = "添加";
            this.toolBtnAdd.Click += new System.EventHandler(this.toolBtnAdd_Click);
            // 
            // toolBtnMod
            // 
            this.toolBtnMod.Image = global::LabManager.Properties.Resources.Edit;
            this.toolBtnMod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnMod.Name = "toolBtnMod";
            this.toolBtnMod.Size = new System.Drawing.Size(63, 27);
            this.toolBtnMod.Text = "修改";
            this.toolBtnMod.Click += new System.EventHandler(this.toolBtnMod_Click);
            // 
            // toolBtnDel
            // 
            this.toolBtnDel.Image = global::LabManager.Properties.Resources.Delete;
            this.toolBtnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnDel.Name = "toolBtnDel";
            this.toolBtnDel.Size = new System.Drawing.Size(63, 27);
            this.toolBtnDel.Text = "删除";
            this.toolBtnDel.Click += new System.EventHandler(this.toolBtnDel_Click);
            // 
            // toolBtnRedo
            // 
            this.toolBtnRedo.Enabled = false;
            this.toolBtnRedo.Image = global::LabManager.Properties.Resources.Redo;
            this.toolBtnRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnRedo.Name = "toolBtnRedo";
            this.toolBtnRedo.Size = new System.Drawing.Size(63, 27);
            this.toolBtnRedo.Text = "撤销";
            this.toolBtnRedo.Click += new System.EventHandler(this.toolBtnRedo_Click);
            // 
            // toolBtnSave
            // 
            this.toolBtnSave.Enabled = false;
            this.toolBtnSave.Image = global::LabManager.Properties.Resources.Save;
            this.toolBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnSave.Name = "toolBtnSave";
            this.toolBtnSave.Size = new System.Drawing.Size(63, 27);
            this.toolBtnSave.Text = "保存";
            this.toolBtnSave.Click += new System.EventHandler(this.toolBtnSave_Click);
            // 
            // listBox
            // 
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.FormattingEnabled = true;
            this.listBox.HorizontalScrollbar = true;
            this.listBox.ItemHeight = 15;
            this.listBox.Location = new System.Drawing.Point(440, 4);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(430, 343);
            this.listBox.TabIndex = 2;
            // 
            // toolStrip
            // 
            this.toolStrip.AllowMerge = false;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLblCurrUser,
            this.toolStripSeparator1,
            this.toolLblState,
            this.toolStripSeparator2,
            this.toolStripProgressBar1,
            this.toolLblTime,
            this.toolStripSeparator3,
            this.toolLblCount});
            this.toolStrip.Location = new System.Drawing.Point(0, 528);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(882, 25);
            this.toolStrip.TabIndex = 6;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripLblCurrUser
            // 
            this.toolStripLblCurrUser.Image = global::LabManager.Properties.Resources.User;
            this.toolStripLblCurrUser.Name = "toolStripLblCurrUser";
            this.toolStripLblCurrUser.Size = new System.Drawing.Size(104, 22);
            this.toolStripLblCurrUser.Text = "当前用户：";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolLblState
            // 
            this.toolLblState.AutoSize = false;
            this.toolLblState.Name = "toolLblState";
            this.toolLblState.Size = new System.Drawing.Size(150, 22);
            this.toolLblState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.AutoSize = false;
            this.toolStripProgressBar1.BackColor = System.Drawing.Color.White;
            this.toolStripProgressBar1.ForeColor = System.Drawing.Color.Red;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 19);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // toolLblTime
            // 
            this.toolLblTime.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolLblTime.Name = "toolLblTime";
            this.toolLblTime.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolLblCount
            // 
            this.toolLblCount.Name = "toolLblCount";
            this.toolLblCount.Size = new System.Drawing.Size(0, 22);
            this.toolLblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAdd.AutoSize = true;
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.Enabled = false;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAdd.Location = new System.Drawing.Point(234, 489);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 27);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "添 加";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnModify
            // 
            this.btnModify.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnModify.AutoSize = true;
            this.btnModify.Enabled = false;
            this.btnModify.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnModify.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.btnModify.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModify.Location = new System.Drawing.Point(319, 489);
            this.btnModify.Margin = new System.Windows.Forms.Padding(5);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 27);
            this.btnModify.TabIndex = 8;
            this.btnModify.Text = "修 改";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnUse
            // 
            this.btnUse.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUse.AutoSize = true;
            this.btnUse.Enabled = false;
            this.btnUse.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnUse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.btnUse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.btnUse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUse.Location = new System.Drawing.Point(404, 489);
            this.btnUse.Margin = new System.Windows.Forms.Padding(5);
            this.btnUse.Name = "btnUse";
            this.btnUse.Size = new System.Drawing.Size(75, 27);
            this.btnUse.TabIndex = 9;
            this.btnUse.Text = "使 用";
            this.btnUse.UseVisualStyleBackColor = true;
            this.btnUse.Click += new System.EventHandler(this.btnUse_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDelete.AutoSize = true;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(489, 489);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 27);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "删 除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnShowRec
            // 
            this.btnShowRec.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnShowRec.AutoSize = true;
            this.btnShowRec.Enabled = false;
            this.btnShowRec.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnShowRec.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.btnShowRec.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.btnShowRec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowRec.Location = new System.Drawing.Point(574, 489);
            this.btnShowRec.Margin = new System.Windows.Forms.Padding(5);
            this.btnShowRec.Name = "btnShowRec";
            this.btnShowRec.Size = new System.Drawing.Size(81, 27);
            this.btnShowRec.TabIndex = 10;
            this.btnShowRec.Text = "查看记录";
            this.btnShowRec.UseVisualStyleBackColor = true;
            this.btnShowRec.Click += new System.EventHandler(this.btnShowRec_Click);
            // 
            // timerTime
            // 
            this.timerTime.Enabled = true;
            this.timerTime.Interval = 1000;
            this.timerTime.Tick += new System.EventHandler(this.timerTime_Tick);
            // 
            // bkWork
            // 
            this.bkWork.WorkerReportsProgress = true;
            this.bkWork.WorkerSupportsCancellation = true;
            // 
            // timerLbl
            // 
            this.timerLbl.Enabled = true;
            this.timerLbl.Interval = 500;
            // 
            // login0
            // 
            this.login0.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.login0.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.login0.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.login0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.login0.Location = new System.Drawing.Point(674, 35);
            this.login0.Name = "login0";
            this.login0.Size = new System.Drawing.Size(75, 27);
            this.login0.TabIndex = 11;
            this.login0.Text = "登录0";
            this.login0.UseVisualStyleBackColor = true;
            this.login0.Visible = false;
            this.login0.Click += new System.EventHandler(this.login0_Click);
            // 
            // imageListDrag
            // 
            this.imageListDrag.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListDrag.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListDrag.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // timerDrag
            // 
            this.timerDrag.Enabled = true;
            this.timerDrag.Interval = 200;
            this.timerDrag.Tick += new System.EventHandler(this.timerDrag_Tick);
            // 
            // MainView
            // 
            this.AcceptButton = this.btnQuery;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.login0);
            this.Controls.Add(this.btnShowRec);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUse);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.textBoxQuery);
            this.Controls.Add(this.menuStrip);
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Icon = Properties.Resources.Main;
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "实验室管理系统V2.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainView_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.conMnStrip.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageChem.ResumeLayout(false);
            this.tbLayPanChem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVChem)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPageAppa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVAppa)).EndInit();
            this.tabPageMem.ResumeLayout(false);
            this.tbLayPanMem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVMem)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPageLoc.ResumeLayout(false);
            this.tbLayoutPanLoc.ResumeLayout(false);
            this.tbLayoutPanLoc.PerformLayout();
            this.toolStripLoc.ResumeLayout(false);
            this.toolStripLoc.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxQuery;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnitLogin;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ComboBox comboBoxLab;
        private System.Windows.Forms.ComboBox comboBoxLoc;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageChem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLblCurrUser;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnUse;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnShowRec;
        private System.Windows.Forms.TabPage tabPageAppa;
        private System.Windows.Forms.DataGridView DGVAppa;
        private System.Windows.Forms.TabPage tabPageMem;
        private System.Windows.Forms.TabPage tabPageLoc;
        private System.Windows.Forms.ToolStripMenuItem mnitLogout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripLabel toolLblState;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolLblTime;
        private System.Windows.Forms.Timer timerTime;
        private System.Windows.Forms.TableLayoutPanel tbLayPanMem;
        private System.Windows.Forms.DataGridView DGVMem;
        private System.Windows.Forms.TableLayoutPanel tbLayPanChem;
        private System.Windows.Forms.DataGridView DGVChem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkBoxPrec;
        private System.Windows.Forms.CheckBox chkBoxComm;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkBoxShowGrad;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolLblCount;
        private System.Windows.Forms.CheckBox chkBoxExhuasted;
        private System.ComponentModel.BackgroundWorker bkWork;
        private System.Windows.Forms.ToolStripMenuItem mnitShow;
        private System.Windows.Forms.ToolStripMenuItem mnitHelpDown;
        private System.Windows.Forms.ToolStripMenuItem mnitHelp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnitAbout;
        private System.Windows.Forms.ToolStripMenuItem mnitShowEn;
        private System.Windows.Forms.ToolStripMenuItem mnitShowAbbr;
        private System.Windows.Forms.ToolStripMenuItem mnitShowPurchaser;
        private System.Windows.Forms.ToolStripMenuItem mnitShowDate;
        private System.Windows.Forms.ToolStripMenuItem mnitShowRemark;
        private System.Windows.Forms.Timer timerLbl;
        private System.Windows.Forms.Button login0;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ContextMenuStrip conMnStrip;
        private System.Windows.Forms.ImageList imageListDrag;
        private System.Windows.Forms.Timer timerDrag;
        private System.Windows.Forms.TableLayoutPanel tbLayoutPanLoc;
        private System.Windows.Forms.ToolStrip toolStripLoc;
        private System.Windows.Forms.ToolStripButton toolBtnAdd;
        private System.Windows.Forms.ToolStripButton toolBtnMod;
        private System.Windows.Forms.ToolStripButton toolBtnDel;
        private System.Windows.Forms.ToolStripButton toolBtnSave;
        private System.Windows.Forms.ToolStripButton toolBtnRedo;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.ToolStripMenuItem mnitSet;
        private System.Windows.Forms.ToolStripMenuItem mnitSetServer;
        private System.Windows.Forms.ToolStripMenuItem mnitLog;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnitBakeupDB;
        private System.Windows.Forms.ToolStripMenuItem mnitRestoreDB;
        private System.Windows.Forms.ToolStripMenuItem toolMnitCopy;
        private System.Windows.Forms.ToolStripMenuItem mnitExport;
    }
}

