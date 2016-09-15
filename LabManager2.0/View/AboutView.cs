using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabManager.View
{
    public partial class AboutView : Form
    {
        int clicks = 0;
        private Point ClickPoint;
        public AboutView(Form owner)
        {
            Owner = owner;
            InitializeComponent();
            lblVer.Text = "Version: " + Application.ProductVersion;
        }

        private void timer_Opacity_Tick(object sender, EventArgs e)
        {
            Opacity -= 0.01;
            if (Opacity < 0.02)
                Dispose();
        }

        private void AboutView_Load(object sender, EventArgs e)
        {
            Left = Owner.Left + (Owner.Width - Width) / 2;
            Top = Owner.Top + (Owner.Height - Height) / 2;
            timer_Wait.Tick += (a, b) => { timer_Wait.Stop(); timer_Opacity.Start(); };
        }
        private Color ChangeColor(Color oldColor)
        {
            float h = oldColor.GetHue();
            byte r = oldColor.R;
            byte g = oldColor.G;
            byte b = oldColor.B;
            byte max = Math.Max(r, Math.Max(g, b));
            byte min = Math.Min(r, Math.Min(g, b));
            byte step = 5;
            if (oldColor.GetSaturation() == 0)
            {
                return oldColor;
            }
            if (h >= 0 && h < 60)
            {
                if (g + step > max)
                {
                    r -= (byte)(step - max + g);
                    g = max;
                }
                else
                    g += step;
            }
            else if (h >= 60 && h < 120)
            {
                if (r - step < min)
                {
                    b += (byte)(step - r + min);
                    r = min;
                }
                else
                    r -= step;
            }
            else if (h >= 120 && h < 180)
            {
                if (b + step > max)
                {
                    g -= (byte)(step - max + g);
                    b = max;
                }
                else
                    b += step;
            }
            else if (h >= 180 && h < 240)
            {
                if (g - step < min)
                {
                    r += (byte)(step - r + min);
                    g = min;
                }
                else
                    g -= step;
            }
            else if (h >= 240 && h < 300)
            {
                if (r + step > max)
                {
                    b -= (byte)(step - max + g);
                    r = max;
                }
                else
                    r += step;
            }
            else if (h >= 300 && h < 360)
            {
                if (b - step < min)
                {
                    g += (byte)(step - r + min);
                    b = min;
                }
                else
                    b -= step;
            }
            return Color.FromArgb(oldColor.A, r, g, b);
        }

        private void timer_Color_Tick(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(picBox.Image);
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color oldColor = bitmap.GetPixel(x, y);
                    Color newColor = ChangeColor(oldColor);
                    bitmap.SetPixel(x, y, newColor);
                }
            }
            picBox.Image = bitmap;
        }

        private void AboutView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ClickPoint = new Point(e.X, e.Y);
            }
        }

        private void AboutView_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(e.X - ClickPoint.X + this.Location.X, e.Y - ClickPoint.Y + this.Location.Y);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(lLblMail.Text.Split(':')[1]);
            MessageBox.Show("作者邮箱地址已复制到剪贴版", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picBox_Click(object sender, EventArgs e)
        {
            if (++clicks >= 5)
            {
                MainView mainView = (MainView)Owner;
                mainView.egg1();
            }
        }
    }
}
