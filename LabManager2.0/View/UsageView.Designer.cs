namespace LabManager.View
{
    partial class UsageView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsageView));
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblNum = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.numUDNum = new System.Windows.Forms.NumericUpDown();
            this.txtBoxAmount = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStriplbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.comboBoxUser = new System.Windows.Forms.ComboBox();
            this.lblUser = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numUDNum)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.AutoEllipsis = true;
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(114, 23);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(55, 15);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "label1";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Location = new System.Drawing.Point(30, 80);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(97, 15);
            this.lblNum.TabIndex = 1;
            this.lblNum.Text = "产生空瓶数量";
            this.lblNum.Click += new System.EventHandler(this.lblNum_Click);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(30, 115);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(52, 15);
            this.lblAmount.TabIndex = 2;
            this.lblAmount.Text = "使用量";
            this.lblAmount.Click += new System.EventHandler(this.lblAmount_Click);
            // 
            // numUDNum
            // 
            this.numUDNum.Location = new System.Drawing.Point(133, 76);
            this.numUDNum.Margin = new System.Windows.Forms.Padding(5);
            this.numUDNum.Name = "numUDNum";
            this.numUDNum.Size = new System.Drawing.Size(120, 25);
            this.numUDNum.TabIndex = 3;
            this.numUDNum.ValueChanged += new System.EventHandler(this.numUDNum_ValueChanged);
            // 
            // txtBoxAmount
            // 
            this.txtBoxAmount.Location = new System.Drawing.Point(133, 111);
            this.txtBoxAmount.Margin = new System.Windows.Forms.Padding(5);
            this.txtBoxAmount.Name = "txtBoxAmount";
            this.txtBoxAmount.Size = new System.Drawing.Size(120, 25);
            this.txtBoxAmount.TabIndex = 4;
            this.txtBoxAmount.TextChanged += new System.EventHandler(this.txtBoxAmount_TextChanged);
            this.txtBoxAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxAmount_KeyPress);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStriplbl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 221);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(282, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStriplbl
            // 
            this.toolStriplbl.Name = "toolStriplbl";
            this.toolStriplbl.Size = new System.Drawing.Size(0, 17);
            // 
            // btnOK
            // 
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(52, 184);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 27);
            this.btnOK.TabIndex = 6;
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
            this.btnCancel.Location = new System.Drawing.Point(155, 184);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // comboBoxUser
            // 
            this.comboBoxUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUser.FormattingEnabled = true;
            this.comboBoxUser.Location = new System.Drawing.Point(132, 146);
            this.comboBoxUser.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxUser.Name = "comboBoxUser";
            this.comboBoxUser.Size = new System.Drawing.Size(121, 23);
            this.comboBoxUser.TabIndex = 8;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(30, 150);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(52, 15);
            this.lblUser.TabIndex = 9;
            this.lblUser.Text = "使用者";
            this.lblUser.Click += new System.EventHandler(this.lblUser_Click);
            // 
            // UsageView
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(282, 243);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.comboBoxUser);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtBoxAmount);
            this.Controls.Add(this.numUDNum);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblNum);
            this.Controls.Add(this.lblInfo);
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Icon = Properties.Resources.usageIco;
            this.Name = "UsageView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "使用药品";
            this.Load += new System.EventHandler(this.UsageView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUDNum)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.NumericUpDown numUDNum;
        private System.Windows.Forms.TextBox txtBoxAmount;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStriplbl;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox comboBoxUser;
        private System.Windows.Forms.Label lblUser;
    }
}