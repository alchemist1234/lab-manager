namespace LabManager.View
{
    partial class LoginView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginView));
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPsw = new System.Windows.Forms.Label();
            this.txtBoxUser = new System.Windows.Forms.TextBox();
            this.txtBoxPsw = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(50, 41);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(52, 15);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "用户名";
            // 
            // lblPsw
            // 
            this.lblPsw.AutoSize = true;
            this.lblPsw.Location = new System.Drawing.Point(50, 91);
            this.lblPsw.Name = "lblPsw";
            this.lblPsw.Size = new System.Drawing.Size(53, 15);
            this.lblPsw.TabIndex = 0;
            this.lblPsw.Text = "密  码";
            // 
            // txtBoxUser
            // 
            this.txtBoxUser.Location = new System.Drawing.Point(111, 36);
            this.txtBoxUser.Name = "txtBoxUser";
            this.txtBoxUser.Size = new System.Drawing.Size(121, 25);
            this.txtBoxUser.TabIndex = 1;
            // 
            // txtBoxPsw
            // 
            this.txtBoxPsw.Location = new System.Drawing.Point(111, 86);
            this.txtBoxPsw.Name = "txtBoxPsw";
            this.txtBoxPsw.PasswordChar = '*';
            this.txtBoxPsw.Size = new System.Drawing.Size(121, 25);
            this.txtBoxPsw.TabIndex = 2;
            // 
            // btnOK
            // 
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(53, 139);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 27);
            this.btnOK.TabIndex = 3;
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
            this.btnCancel.Location = new System.Drawing.Point(157, 139);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // LoginView
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(282, 193);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtBoxPsw);
            this.Controls.Add(this.txtBoxUser);
            this.Controls.Add(this.lblPsw);
            this.Controls.Add(this.lblUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Icon = Properties.Resources.LoginIco;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用户登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPsw;
        private System.Windows.Forms.TextBox txtBoxUser;
        private System.Windows.Forms.TextBox txtBoxPsw;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}