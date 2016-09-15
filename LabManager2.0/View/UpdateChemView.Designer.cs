namespace LabManager.View
{
    partial class UpdateChemView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateChemView));
            this.lblCnName = new System.Windows.Forms.Label();
            this.txtBoxCnName = new System.Windows.Forms.TextBox();
            this.txtBoxEnName = new System.Windows.Forms.TextBox();
            this.lblEnName = new System.Windows.Forms.Label();
            this.lblAbbr = new System.Windows.Forms.Label();
            this.txtBoxAbbr = new System.Windows.Forms.TextBox();
            this.txtBoxCAS = new System.Windows.Forms.TextBox();
            this.lblCAS = new System.Windows.Forms.Label();
            this.chkBoxPrec = new System.Windows.Forms.CheckBox();
            this.txtBoxCapa = new System.Windows.Forms.TextBox();
            this.comboBoxUnit = new System.Windows.Forms.ComboBox();
            this.lblCapa = new System.Windows.Forms.Label();
            this.numUpDown = new System.Windows.Forms.NumericUpDown();
            this.lblNum = new System.Windows.Forms.Label();
            this.txtBoxResi = new System.Windows.Forms.TextBox();
            this.lblResi = new System.Windows.Forms.Label();
            this.comboBoxLab = new System.Windows.Forms.ComboBox();
            this.comboBoxLoc = new System.Windows.Forms.ComboBox();
            this.lblLab = new System.Windows.Forms.Label();
            this.lblLoc = new System.Windows.Forms.Label();
            this.comboBoxMem = new System.Windows.Forms.ComboBox();
            this.lblMem = new System.Windows.Forms.Label();
            this.lblManu = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.richTxtBoxRemark = new System.Windows.Forms.RichTextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerLbl = new System.Windows.Forms.Timer(this.components);
            this.comboBoxManu = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCnName
            // 
            this.lblCnName.AutoSize = true;
            this.lblCnName.Location = new System.Drawing.Point(14, 19);
            this.lblCnName.Margin = new System.Windows.Forms.Padding(5);
            this.lblCnName.Name = "lblCnName";
            this.lblCnName.Size = new System.Drawing.Size(67, 15);
            this.lblCnName.TabIndex = 0;
            this.lblCnName.Text = "中文名称";
            this.lblCnName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBoxCnName
            // 
            this.txtBoxCnName.Location = new System.Drawing.Point(91, 14);
            this.txtBoxCnName.Margin = new System.Windows.Forms.Padding(5);
            this.txtBoxCnName.Name = "txtBoxCnName";
            this.txtBoxCnName.Size = new System.Drawing.Size(277, 25);
            this.txtBoxCnName.TabIndex = 1;
            this.txtBoxCnName.TextChanged += new System.EventHandler(this.txtBoxCnName_TextChanged);
            // 
            // txtBoxEnName
            // 
            this.txtBoxEnName.Location = new System.Drawing.Point(90, 49);
            this.txtBoxEnName.Margin = new System.Windows.Forms.Padding(5);
            this.txtBoxEnName.Name = "txtBoxEnName";
            this.txtBoxEnName.Size = new System.Drawing.Size(278, 25);
            this.txtBoxEnName.TabIndex = 2;
            this.txtBoxEnName.TextChanged += new System.EventHandler(this.txtBoxCnName_TextChanged);
            // 
            // lblEnName
            // 
            this.lblEnName.AutoSize = true;
            this.lblEnName.Location = new System.Drawing.Point(14, 54);
            this.lblEnName.Name = "lblEnName";
            this.lblEnName.Size = new System.Drawing.Size(67, 15);
            this.lblEnName.TabIndex = 0;
            this.lblEnName.Text = "英文名称";
            this.lblEnName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAbbr
            // 
            this.lblAbbr.AutoSize = true;
            this.lblAbbr.Location = new System.Drawing.Point(14, 89);
            this.lblAbbr.Margin = new System.Windows.Forms.Padding(5);
            this.lblAbbr.Name = "lblAbbr";
            this.lblAbbr.Size = new System.Drawing.Size(53, 15);
            this.lblAbbr.TabIndex = 0;
            this.lblAbbr.Text = "缩  写";
            this.lblAbbr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBoxAbbr
            // 
            this.txtBoxAbbr.Location = new System.Drawing.Point(91, 84);
            this.txtBoxAbbr.Margin = new System.Windows.Forms.Padding(5);
            this.txtBoxAbbr.Name = "txtBoxAbbr";
            this.txtBoxAbbr.Size = new System.Drawing.Size(277, 25);
            this.txtBoxAbbr.TabIndex = 3;
            // 
            // txtBoxCAS
            // 
            this.txtBoxCAS.Location = new System.Drawing.Point(91, 119);
            this.txtBoxCAS.Margin = new System.Windows.Forms.Padding(5);
            this.txtBoxCAS.Name = "txtBoxCAS";
            this.txtBoxCAS.Size = new System.Drawing.Size(169, 25);
            this.txtBoxCAS.TabIndex = 4;
            this.txtBoxCAS.TextChanged += new System.EventHandler(this.txtBoxCAS_TextChanged);
            this.txtBoxCAS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxCAS_KeyPress);
            this.txtBoxCAS.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxCAS_Validating);
            // 
            // lblCAS
            // 
            this.lblCAS.AutoSize = true;
            this.lblCAS.Location = new System.Drawing.Point(14, 124);
            this.lblCAS.Margin = new System.Windows.Forms.Padding(5);
            this.lblCAS.Name = "lblCAS";
            this.lblCAS.Size = new System.Drawing.Size(31, 15);
            this.lblCAS.TabIndex = 0;
            this.lblCAS.Text = "CAS";
            this.lblCAS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkBoxPrec
            // 
            this.chkBoxPrec.Enabled = false;
            this.chkBoxPrec.Location = new System.Drawing.Point(271, 119);
            this.chkBoxPrec.Margin = new System.Windows.Forms.Padding(5);
            this.chkBoxPrec.Name = "chkBoxPrec";
            this.chkBoxPrec.Size = new System.Drawing.Size(97, 25);
            this.chkBoxPrec.TabIndex = 2;
            this.chkBoxPrec.Text = "易制毒";
            this.chkBoxPrec.UseVisualStyleBackColor = true;
            // 
            // txtBoxCapa
            // 
            this.txtBoxCapa.Location = new System.Drawing.Point(91, 154);
            this.txtBoxCapa.Margin = new System.Windows.Forms.Padding(5);
            this.txtBoxCapa.Name = "txtBoxCapa";
            this.txtBoxCapa.Size = new System.Drawing.Size(169, 25);
            this.txtBoxCapa.TabIndex = 5;
            this.txtBoxCapa.TextChanged += new System.EventHandler(this.txtBoxCapa_TextChanged);
            this.txtBoxCapa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxCapa_KeyPress);
            // 
            // comboBoxUnit
            // 
            this.comboBoxUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUnit.FormattingEnabled = true;
            this.comboBoxUnit.Location = new System.Drawing.Point(271, 155);
            this.comboBoxUnit.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxUnit.Name = "comboBoxUnit";
            this.comboBoxUnit.Size = new System.Drawing.Size(97, 23);
            this.comboBoxUnit.TabIndex = 6;
            // 
            // lblCapa
            // 
            this.lblCapa.AutoSize = true;
            this.lblCapa.Location = new System.Drawing.Point(14, 159);
            this.lblCapa.Margin = new System.Windows.Forms.Padding(5);
            this.lblCapa.Name = "lblCapa";
            this.lblCapa.Size = new System.Drawing.Size(53, 15);
            this.lblCapa.TabIndex = 0;
            this.lblCapa.Text = "规  格";
            this.lblCapa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numUpDown
            // 
            this.numUpDown.Location = new System.Drawing.Point(91, 189);
            this.numUpDown.Margin = new System.Windows.Forms.Padding(5);
            this.numUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUpDown.Name = "numUpDown";
            this.numUpDown.Size = new System.Drawing.Size(93, 25);
            this.numUpDown.TabIndex = 7;
            this.numUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Location = new System.Drawing.Point(14, 194);
            this.lblNum.Margin = new System.Windows.Forms.Padding(5);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(53, 15);
            this.lblNum.TabIndex = 0;
            this.lblNum.Text = "数  量";
            this.lblNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBoxResi
            // 
            this.txtBoxResi.Location = new System.Drawing.Point(271, 189);
            this.txtBoxResi.Margin = new System.Windows.Forms.Padding(5);
            this.txtBoxResi.Name = "txtBoxResi";
            this.txtBoxResi.Size = new System.Drawing.Size(97, 25);
            this.txtBoxResi.TabIndex = 8;
            this.txtBoxResi.TextChanged += new System.EventHandler(this.txtBoxResi_TextChanged);
            this.txtBoxResi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxResi_KeyPress);
            // 
            // lblResi
            // 
            this.lblResi.AutoSize = true;
            this.lblResi.Location = new System.Drawing.Point(194, 194);
            this.lblResi.Margin = new System.Windows.Forms.Padding(5);
            this.lblResi.Name = "lblResi";
            this.lblResi.Size = new System.Drawing.Size(52, 15);
            this.lblResi.TabIndex = 0;
            this.lblResi.Text = "剩余量";
            this.lblResi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxLab
            // 
            this.comboBoxLab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLab.FormattingEnabled = true;
            this.comboBoxLab.Location = new System.Drawing.Point(91, 224);
            this.comboBoxLab.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxLab.Name = "comboBoxLab";
            this.comboBoxLab.Size = new System.Drawing.Size(93, 23);
            this.comboBoxLab.TabIndex = 9;
            this.comboBoxLab.SelectedIndexChanged += new System.EventHandler(this.comboBoxLab_SelectedIndexChanged);
            // 
            // comboBoxLoc
            // 
            this.comboBoxLoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLoc.FormattingEnabled = true;
            this.comboBoxLoc.Location = new System.Drawing.Point(271, 224);
            this.comboBoxLoc.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxLoc.Name = "comboBoxLoc";
            this.comboBoxLoc.Size = new System.Drawing.Size(97, 23);
            this.comboBoxLoc.TabIndex = 10;
            this.comboBoxLoc.SelectedIndexChanged += new System.EventHandler(this.comboBoxLoc_SelectedIndexChanged);
            // 
            // lblLab
            // 
            this.lblLab.AutoSize = true;
            this.lblLab.Location = new System.Drawing.Point(14, 227);
            this.lblLab.Margin = new System.Windows.Forms.Padding(5);
            this.lblLab.Name = "lblLab";
            this.lblLab.Size = new System.Drawing.Size(52, 15);
            this.lblLab.TabIndex = 0;
            this.lblLab.Text = "实验室";
            this.lblLab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLoc
            // 
            this.lblLoc.AutoSize = true;
            this.lblLoc.Location = new System.Drawing.Point(193, 227);
            this.lblLoc.Margin = new System.Windows.Forms.Padding(5);
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.Size = new System.Drawing.Size(67, 15);
            this.lblLoc.TabIndex = 0;
            this.lblLoc.Text = "存放位置";
            this.lblLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxMem
            // 
            this.comboBoxMem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMem.FormattingEnabled = true;
            this.comboBoxMem.Location = new System.Drawing.Point(271, 295);
            this.comboBoxMem.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxMem.Name = "comboBoxMem";
            this.comboBoxMem.Size = new System.Drawing.Size(97, 23);
            this.comboBoxMem.TabIndex = 13;
            // 
            // lblMem
            // 
            this.lblMem.Location = new System.Drawing.Point(214, 294);
            this.lblMem.Margin = new System.Windows.Forms.Padding(5);
            this.lblMem.Name = "lblMem";
            this.lblMem.Size = new System.Drawing.Size(60, 25);
            this.lblMem.TabIndex = 0;
            this.lblMem.Text = "购买人";
            this.lblMem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblManu
            // 
            this.lblManu.AutoSize = true;
            this.lblManu.Location = new System.Drawing.Point(14, 264);
            this.lblManu.Margin = new System.Windows.Forms.Padding(5);
            this.lblManu.Name = "lblManu";
            this.lblManu.Size = new System.Drawing.Size(67, 15);
            this.lblManu.TabIndex = 0;
            this.lblManu.Text = "生产厂家";
            this.lblManu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(14, 299);
            this.lblDate.Margin = new System.Windows.Forms.Padding(5);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(67, 15);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "购买日期";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(14, 334);
            this.lblRemark.Margin = new System.Windows.Forms.Padding(5);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(53, 15);
            this.lblRemark.TabIndex = 0;
            this.lblRemark.Text = "备  注";
            this.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // richTxtBoxRemark
            // 
            this.richTxtBoxRemark.Location = new System.Drawing.Point(90, 329);
            this.richTxtBoxRemark.Margin = new System.Windows.Forms.Padding(5);
            this.richTxtBoxRemark.Name = "richTxtBoxRemark";
            this.richTxtBoxRemark.Size = new System.Drawing.Size(278, 69);
            this.richTxtBoxRemark.TabIndex = 14;
            this.richTxtBoxRemark.Text = "";
            // 
            // btnOK
            // 
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(95, 416);
            this.btnOK.Margin = new System.Windows.Forms.Padding(5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 27);
            this.btnOK.TabIndex = 15;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(213, 416);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // datePicker
            // 
            this.datePicker.CustomFormat = "yyyy-MM-dd";
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePicker.Location = new System.Drawing.Point(90, 294);
            this.datePicker.Margin = new System.Windows.Forms.Padding(5);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(120, 25);
            this.datePicker.TabIndex = 12;
            this.datePicker.Value = new System.DateTime(2016, 5, 11, 22, 32, 13, 0);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLbl});
            this.statusStrip.Location = new System.Drawing.Point(0, 456);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(382, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 18;
            this.statusStrip.Text = "statusStrip";
            // 
            // StatusLbl
            // 
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(367, 17);
            this.StatusLbl.Spring = true;
            this.StatusLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerLbl
            // 
            this.timerLbl.Enabled = true;
            this.timerLbl.Interval = 500;
            // 
            // comboBoxManu
            // 
            this.comboBoxManu.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxManu.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBoxManu.FormattingEnabled = true;
            this.comboBoxManu.Location = new System.Drawing.Point(91, 260);
            this.comboBoxManu.Name = "comboBoxManu";
            this.comboBoxManu.Size = new System.Drawing.Size(277, 23);
            this.comboBoxManu.TabIndex = 11;
            // 
            // UpdateChemView
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(382, 478);
            this.Controls.Add(this.comboBoxManu);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.richTxtBoxRemark);
            this.Controls.Add(this.comboBoxMem);
            this.Controls.Add(this.comboBoxLoc);
            this.Controls.Add(this.comboBoxLab);
            this.Controls.Add(this.numUpDown);
            this.Controls.Add(this.comboBoxUnit);
            this.Controls.Add(this.chkBoxPrec);
            this.Controls.Add(this.txtBoxResi);
            this.Controls.Add(this.txtBoxCapa);
            this.Controls.Add(this.txtBoxCAS);
            this.Controls.Add(this.txtBoxAbbr);
            this.Controls.Add(this.txtBoxEnName);
            this.Controls.Add(this.lblMem);
            this.Controls.Add(this.lblLoc);
            this.Controls.Add(this.lblResi);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblManu);
            this.Controls.Add(this.lblLab);
            this.Controls.Add(this.lblNum);
            this.Controls.Add(this.lblCapa);
            this.Controls.Add(this.txtBoxCnName);
            this.Controls.Add(this.lblCAS);
            this.Controls.Add(this.lblAbbr);
            this.Controls.Add(this.lblEnName);
            this.Controls.Add(this.lblCnName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Icon = Properties.Resources.ChemicalIco;
            this.Name = "UpdateChemView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UpdateChem";
            this.Load += new System.EventHandler(this.UpdateChem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCnName;
        private System.Windows.Forms.TextBox txtBoxCnName;
        private System.Windows.Forms.TextBox txtBoxEnName;
        private System.Windows.Forms.Label lblEnName;
        private System.Windows.Forms.Label lblAbbr;
        private System.Windows.Forms.TextBox txtBoxAbbr;
        private System.Windows.Forms.TextBox txtBoxCAS;
        private System.Windows.Forms.Label lblCAS;
        private System.Windows.Forms.CheckBox chkBoxPrec;
        private System.Windows.Forms.TextBox txtBoxCapa;
        private System.Windows.Forms.ComboBox comboBoxUnit;
        private System.Windows.Forms.Label lblCapa;
        private System.Windows.Forms.NumericUpDown numUpDown;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.TextBox txtBoxResi;
        private System.Windows.Forms.Label lblResi;
        private System.Windows.Forms.ComboBox comboBoxLab;
        private System.Windows.Forms.ComboBox comboBoxLoc;
        private System.Windows.Forms.Label lblLab;
        private System.Windows.Forms.Label lblLoc;
        private System.Windows.Forms.ComboBox comboBoxMem;
        private System.Windows.Forms.Label lblMem;
        private System.Windows.Forms.Label lblManu;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.RichTextBox richTxtBoxRemark;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusLbl;
        private System.Windows.Forms.Timer timerLbl;
        private System.Windows.Forms.ComboBox comboBoxManu;
    }
}