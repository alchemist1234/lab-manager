namespace LabManager.View
{
    partial class ChangeLogView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeLogView));
            this.rTxtBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rTxtBox
            // 
            this.rTxtBox.AutoWordSelection = true;
            this.rTxtBox.BackColor = System.Drawing.SystemColors.Window;
            this.rTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rTxtBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTxtBox.EnableAutoDragDrop = true;
            this.rTxtBox.Location = new System.Drawing.Point(0, 0);
            this.rTxtBox.Name = "rTxtBox";
            this.rTxtBox.ReadOnly = true;
            this.rTxtBox.Size = new System.Drawing.Size(582, 403);
            this.rTxtBox.TabIndex = 0;
            this.rTxtBox.Text = "";
            this.rTxtBox.WordWrap = false;
            // 
            // ChangeLogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 403);
            this.Controls.Add(this.rTxtBox);
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Icon = Properties.Resources.LogIco;
            this.Name = "ChangeLogView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "更新历史";
            this.Load += new System.EventHandler(this.ChangeLogView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rTxtBox;
    }
}