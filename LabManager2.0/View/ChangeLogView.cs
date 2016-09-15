using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LabManager.Properties;

namespace LabManager.View
{
    public partial class ChangeLogView : Form
    {
        public ChangeLogView(Form owner)
        {
            InitializeComponent();
            Owner = owner;
        }

        private void ChangeLogView_Load(object sender, EventArgs e)
        {
            Left = Owner.Left + (Owner.Width - Width) / 2;
            Top = Owner.Top + (Owner.Height - Height) / 2;
            rTxtBox.Text = Resources.ChangeLog;
        }
    }
}
