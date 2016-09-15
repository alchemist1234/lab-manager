namespace LabManager.View
{
    partial class AboutView
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
            this.picBox = new System.Windows.Forms.PictureBox();
            this.timer_Opacity = new System.Windows.Forms.Timer(this.components);
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lLblMail = new System.Windows.Forms.LinkLabel();
            this.timer_Wait = new System.Windows.Forms.Timer(this.components);
            this.timer_Color = new System.Windows.Forms.Timer(this.components);
            this.lblVer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // picBox
            // 
            this.picBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.picBox.Image = global::LabManager.Properties.Resources.icon_MainWindow;
            this.picBox.Location = new System.Drawing.Point(0, 0);
            this.picBox.Margin = new System.Windows.Forms.Padding(5);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(280, 185);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox.TabIndex = 1;
            this.picBox.TabStop = false;
            this.picBox.Click += new System.EventHandler(this.picBox_Click);
            this.picBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AboutView_MouseDown);
            this.picBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AboutView_MouseMove);
            // 
            // timer_Opacity
            // 
            this.timer_Opacity.Interval = 50;
            this.timer_Opacity.Tick += new System.EventHandler(this.timer_Opacity_Tick);
            // 
            // lblAuthor
            // 
            this.lblAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.BackColor = System.Drawing.SystemColors.Control;
            this.lblAuthor.Font = new System.Drawing.Font("Old English Text MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthor.Location = new System.Drawing.Point(75, 222);
            this.lblAuthor.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(130, 19);
            this.lblAuthor.TabIndex = 2;
            this.lblAuthor.Text = "Author: ZhanChen";
            this.lblAuthor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AboutView_MouseDown);
            this.lblAuthor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AboutView_MouseMove);
            // 
            // lLblMail
            // 
            this.lLblMail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lLblMail.AutoSize = true;
            this.lLblMail.BackColor = System.Drawing.SystemColors.Control;
            this.lLblMail.Font = new System.Drawing.Font("Old English Text MT", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lLblMail.Location = new System.Drawing.Point(39, 247);
            this.lLblMail.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lLblMail.Name = "lLblMail";
            this.lLblMail.Size = new System.Drawing.Size(203, 19);
            this.lLblMail.TabIndex = 3;
            this.lLblMail.TabStop = true;
            this.lLblMail.Text = "E-Mail: zhanchen@tju.edu.cn";
            this.lLblMail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            this.lLblMail.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AboutView_MouseDown);
            this.lLblMail.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AboutView_MouseMove);
            // 
            // timer_Wait
            // 
            this.timer_Wait.Enabled = true;
            this.timer_Wait.Interval = 3000;
            // 
            // timer_Color
            // 
            this.timer_Color.Interval = 50;
            this.timer_Color.Tick += new System.EventHandler(this.timer_Color_Tick);
            // 
            // lblVer
            // 
            this.lblVer.AutoSize = true;
            this.lblVer.Font = new System.Drawing.Font("Old English Text MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVer.Location = new System.Drawing.Point(79, 197);
            this.lblVer.Name = "lblVer";
            this.lblVer.Size = new System.Drawing.Size(122, 19);
            this.lblVer.TabIndex = 4;
            this.lblVer.Text = "Version: 1.0.0.0";
            // 
            // AboutView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 275);
            this.ControlBox = false;
            this.Controls.Add(this.lblVer);
            this.Controls.Add(this.lLblMail);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.picBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "关于";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Load += new System.EventHandler(this.AboutView_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AboutView_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AboutView_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Timer timer_Opacity;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.LinkLabel lLblMail;
        private System.Windows.Forms.Timer timer_Wait;
        private System.Windows.Forms.Timer timer_Color;
        private System.Windows.Forms.Label lblVer;
    }
}