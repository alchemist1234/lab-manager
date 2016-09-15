using LabManager.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace LabManager.View
{
    public partial class RecordView : Form
    {
        public List<Record> listRec;
        public RecordView(List<Record> listRec)
        {
            InitializeComponent();
            this.listRec = listRec;
        }

        private void RecordView_Load(object sender, EventArgs e)
        {
            if (listRec.Count == 0)
            {
                listBox_Record.Items.Add("未查询到任何记录");
            }
            foreach (Record rec in listRec)
            {
                string info = rec.GetRecInfo();
                listBox_Record.Items.Add(info);
                listBox_Record.HorizontalExtent = Math.Max(listBox_Record.HorizontalExtent,
                    (int)listBox_Record.CreateGraphics().MeasureString(info, listBox_Record.Font).Width + 10);
            }
            
            //if (listRec.Count == 0)
            //{
            //    listRec.Add(new Record());
            //}
        }

        private void listBox_Record_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index != -1)
            {               
                string info = listBox_Record.Items[e.Index].ToString();
                Font font = e.Font;
                SolidBrush brush = new SolidBrush(Color.Black);
                Rectangle bounds = e.Bounds;
                
                Color oddBackColor = Color.BlanchedAlmond;
                Color evenBackColor = Color.White;
                LinearGradientBrush oddBackBrush = new LinearGradientBrush(bounds, oddBackColor, Color.White, 0f);
                if (e.Index % 2 == 0)
                {
                    e.Graphics.FillRectangle(new SolidBrush(evenBackColor), bounds);
                }
                else
                {
                    //e.Graphics.FillRectangle(new SolidBrush(oddBackColor), bounds);
                    e.Graphics.FillRectangle(oddBackBrush, bounds);
                }
                e.Graphics.DrawString(info, font, brush, bounds);
                e.DrawFocusRectangle();
                //if (e.State == DrawItemState.Focus)
                //{
                //    Console.WriteLine("selected Index:" + e.Index);
                //    Pen pen = new Pen(Color.Black);
                //    pen.DashStyle = DashStyle.Dash;
                //    e.Graphics.DrawRectangle(pen, bounds);
                //}
            }

        }
    }
}
