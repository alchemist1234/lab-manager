namespace LabManager.View
{
    partial class UpdateMemView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateMemView));
            this.lblNum = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblPsw = new System.Windows.Forms.Label();
            this.lblLv = new System.Windows.Forms.Label();
            this.txtBoxNum = new System.Windows.Forms.TextBox();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.comboBoxSex = new System.Windows.Forms.ComboBox();
            this.chkBoxGrad = new System.Windows.Forms.CheckBox();
            this.txtBoxPhone = new System.Windows.Forms.TextBox();
            this.txtBoxMail = new System.Windows.Forms.TextBox();
            this.txtBoxPsw = new System.Windows.Forms.TextBox();
            this.comboBoxLv = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNum.Location = new System.Drawing.Point(14, 26);
            this.lblNum.Margin = new System.Windows.Forms.Padding(5);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(37, 15);
            this.lblNum.TabIndex = 0;
            this.lblNum.Text = "学号";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.Location = new System.Drawing.Point(14, 61);
            this.lblName.Margin = new System.Windows.Forms.Padding(5);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(37, 15);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "姓名";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSex.Location = new System.Drawing.Point(14, 95);
            this.lblSex.Margin = new System.Windows.Forms.Padding(5);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(37, 15);
            this.lblSex.TabIndex = 0;
            this.lblSex.Text = "性别";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPhone.Location = new System.Drawing.Point(14, 129);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(5);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(37, 15);
            this.lblPhone.TabIndex = 0;
            this.lblPhone.Text = "电话";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMail.Location = new System.Drawing.Point(14, 164);
            this.lblMail.Margin = new System.Windows.Forms.Padding(5);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(37, 15);
            this.lblMail.TabIndex = 0;
            this.lblMail.Text = "邮箱";
            // 
            // lblPsw
            // 
            this.lblPsw.AutoSize = true;
            this.lblPsw.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPsw.Location = new System.Drawing.Point(14, 199);
            this.lblPsw.Margin = new System.Windows.Forms.Padding(5);
            this.lblPsw.Name = "lblPsw";
            this.lblPsw.Size = new System.Drawing.Size(37, 15);
            this.lblPsw.TabIndex = 0;
            this.lblPsw.Text = "密码";
            // 
            // lblLv
            // 
            this.lblLv.AutoSize = true;
            this.lblLv.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLv.Location = new System.Drawing.Point(14, 233);
            this.lblLv.Margin = new System.Windows.Forms.Padding(5);
            this.lblLv.Name = "lblLv";
            this.lblLv.Size = new System.Drawing.Size(37, 15);
            this.lblLv.TabIndex = 0;
            this.lblLv.Text = "级别";
            // 
            // txtBoxNum
            // 
            this.txtBoxNum.Location = new System.Drawing.Point(61, 21);
            this.txtBoxNum.Margin = new System.Windows.Forms.Padding(5);
            this.txtBoxNum.Name = "txtBoxNum";
            this.txtBoxNum.Size = new System.Drawing.Size(207, 25);
            this.txtBoxNum.TabIndex = 1;
            this.txtBoxNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxNum_KeyPress);
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(61, 56);
            this.txtBoxName.Margin = new System.Windows.Forms.Padding(5);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(207, 25);
            this.txtBoxName.TabIndex = 2;
            this.txtBoxName.TextChanged += new System.EventHandler(this.txtBoxName_TextChanged);
            // 
            // comboBoxSex
            // 
            this.comboBoxSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSex.FormattingEnabled = true;
            this.comboBoxSex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.comboBoxSex.Location = new System.Drawing.Point(61, 91);
            this.comboBoxSex.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxSex.Name = "comboBoxSex";
            this.comboBoxSex.Size = new System.Drawing.Size(108, 23);
            this.comboBoxSex.TabIndex = 3;
            this.comboBoxSex.SelectedIndexChanged += new System.EventHandler(this.comboBoxSex_SelectedIndexChanged);
            // 
            // chkBoxGrad
            // 
            this.chkBoxGrad.AutoSize = true;
            this.chkBoxGrad.Location = new System.Drawing.Point(179, 93);
            this.chkBoxGrad.Margin = new System.Windows.Forms.Padding(5);
            this.chkBoxGrad.Name = "chkBoxGrad";
            this.chkBoxGrad.Size = new System.Drawing.Size(89, 19);
            this.chkBoxGrad.TabIndex = 4;
            this.chkBoxGrad.Text = "是否毕业";
            this.chkBoxGrad.UseVisualStyleBackColor = true;
            // 
            // txtBoxPhone
            // 
            this.txtBoxPhone.Location = new System.Drawing.Point(61, 124);
            this.txtBoxPhone.Margin = new System.Windows.Forms.Padding(5);
            this.txtBoxPhone.Name = "txtBoxPhone";
            this.txtBoxPhone.Size = new System.Drawing.Size(207, 25);
            this.txtBoxPhone.TabIndex = 5;
            this.txtBoxPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxPhone_KeyPress);
            // 
            // txtBoxMail
            // 
            this.txtBoxMail.Location = new System.Drawing.Point(61, 159);
            this.txtBoxMail.Margin = new System.Windows.Forms.Padding(5);
            this.txtBoxMail.Name = "txtBoxMail";
            this.txtBoxMail.Size = new System.Drawing.Size(207, 25);
            this.txtBoxMail.TabIndex = 6;
            this.txtBoxMail.TextChanged += new System.EventHandler(this.txtBoxMail_TextChanged);
            // 
            // txtBoxPsw
            // 
            this.txtBoxPsw.Location = new System.Drawing.Point(61, 194);
            this.txtBoxPsw.Margin = new System.Windows.Forms.Padding(5);
            this.txtBoxPsw.Name = "txtBoxPsw";
            this.txtBoxPsw.Size = new System.Drawing.Size(207, 25);
            this.txtBoxPsw.TabIndex = 7;
            this.txtBoxPsw.TextChanged += new System.EventHandler(this.txtBoxPsw_TextChanged);
            // 
            // comboBoxLv
            // 
            this.comboBoxLv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLv.FormattingEnabled = true;
            this.comboBoxLv.Items.AddRange(new object[] {
            "管理员",
            "教师",
            "学生"});
            this.comboBoxLv.Location = new System.Drawing.Point(61, 229);
            this.comboBoxLv.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxLv.Name = "comboBoxLv";
            this.comboBoxLv.Size = new System.Drawing.Size(207, 23);
            this.comboBoxLv.TabIndex = 8;
            this.comboBoxLv.SelectedIndexChanged += new System.EventHandler(this.comboBoxLv_SelectedIndexChanged);
            // 
            // btnOK
            // 
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(61, 275);
            this.btnOK.Margin = new System.Windows.Forms.Padding(5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 27);
            this.btnOK.TabIndex = 9;
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
            this.btnCancel.Location = new System.Drawing.Point(146, 275);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLbl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 313);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(282, 24);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = false;
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(220, 19);
            this.statusLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UpdateMemView
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(282, 337);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.comboBoxLv);
            this.Controls.Add(this.chkBoxGrad);
            this.Controls.Add(this.comboBoxSex);
            this.Controls.Add(this.txtBoxPsw);
            this.Controls.Add(this.txtBoxMail);
            this.Controls.Add(this.txtBoxPhone);
            this.Controls.Add(this.txtBoxName);
            this.Controls.Add(this.txtBoxNum);
            this.Controls.Add(this.lblLv);
            this.Controls.Add(this.lblPsw);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblNum);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Icon = Properties.Resources.UserIco;
            this.Name = "UpdateMemView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UpdateMember";
            this.Load += new System.EventHandler(this.UpdateMember_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblPsw;
        private System.Windows.Forms.Label lblLv;
        private System.Windows.Forms.TextBox txtBoxNum;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.ComboBox comboBoxSex;
        private System.Windows.Forms.CheckBox chkBoxGrad;
        private System.Windows.Forms.TextBox txtBoxPhone;
        private System.Windows.Forms.TextBox txtBoxMail;
        private System.Windows.Forms.TextBox txtBoxPsw;
        private System.Windows.Forms.ComboBox comboBoxLv;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLbl;
        private System.Windows.Forms.Timer timer1;
    }
}