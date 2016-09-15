namespace LabManager.View
{
    partial class ConfigView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigView));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxIP = new System.Windows.Forms.TextBox();
            this.txtBoxUser = new System.Windows.Forms.TextBox();
            this.txtBoxPsw = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器地址";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "服务器用户";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "服务器密码";
            // 
            // txtBoxIP
            // 
            this.txtBoxIP.Location = new System.Drawing.Point(135, 23);
            this.txtBoxIP.Margin = new System.Windows.Forms.Padding(5);
            this.txtBoxIP.Name = "txtBoxIP";
            this.txtBoxIP.Size = new System.Drawing.Size(153, 25);
            this.txtBoxIP.TabIndex = 1;
            // 
            // txtBoxUser
            // 
            this.txtBoxUser.Location = new System.Drawing.Point(135, 58);
            this.txtBoxUser.Margin = new System.Windows.Forms.Padding(5);
            this.txtBoxUser.Name = "txtBoxUser";
            this.txtBoxUser.Size = new System.Drawing.Size(153, 25);
            this.txtBoxUser.TabIndex = 2;
            // 
            // txtBoxPsw
            // 
            this.txtBoxPsw.Location = new System.Drawing.Point(135, 93);
            this.txtBoxPsw.Margin = new System.Windows.Forms.Padding(5);
            this.txtBoxPsw.Name = "txtBoxPsw";
            this.txtBoxPsw.PasswordChar = '*';
            this.txtBoxPsw.Size = new System.Drawing.Size(153, 25);
            this.txtBoxPsw.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.AutoSize = true;
            this.btnOK.Location = new System.Drawing.Point(62, 137);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(186, 137);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ConfigView
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(322, 177);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtBoxPsw);
            this.Controls.Add(this.txtBoxUser);
            this.Controls.Add(this.txtBoxIP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Icon = Properties.Resources.ServerSetupIco;
            this.MaximizeBox = false;
            this.Name = "ConfigView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "服务器设置";
            this.Load += new System.EventHandler(this.ConfigView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxIP;
        private System.Windows.Forms.TextBox txtBoxUser;
        private System.Windows.Forms.TextBox txtBoxPsw;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}