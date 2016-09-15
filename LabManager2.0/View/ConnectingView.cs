using System.Drawing;
using System.Windows.Forms;

namespace LabManager.View
{
    public partial class ConnectingView : Form
    {
        private Point ClickPoint;
        public ConnectingView()
        {
            InitializeComponent();
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ClickPoint = new Point(e.X, e.Y);
            }
        }
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(e.X - ClickPoint.X + this.Location.X, e.Y - ClickPoint.Y + this.Location.Y);  
            }
        }
    }
}
