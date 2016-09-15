namespace LabManager.View
{
    partial class RecordView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecordView));
            this.listBox_Record = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBox_Record
            // 
            this.listBox_Record.BackColor = System.Drawing.Color.White;
            this.listBox_Record.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Record.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox_Record.FormattingEnabled = true;
            this.listBox_Record.HorizontalScrollbar = true;
            this.listBox_Record.ItemHeight = 15;
            this.listBox_Record.Location = new System.Drawing.Point(0, 0);
            this.listBox_Record.Name = "listBox_Record";
            this.listBox_Record.Size = new System.Drawing.Size(582, 353);
            this.listBox_Record.TabIndex = 0;
            this.listBox_Record.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox_Record_DrawItem);
            // 
            // RecordView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 353);
            this.Controls.Add(this.listBox_Record);
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Icon = Properties.Resources.RecordIco;
            this.Name = "RecordView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "使用记录";
            this.Load += new System.EventHandler(this.RecordView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_Record;
    }
}