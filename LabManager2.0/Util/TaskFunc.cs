using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabManager.Util
{
    [Obsolete]
    public static class TaskFunc
    {
        public static object lockObj = new object();
        public static void Func1(Form form, System.Windows.Forms.Control label,string text = "连接数据库")
        {
            string[] dynamicStr = { ".", "..", "...", "...." };
            if (text == "" || text == null)
            {
                text = "连接数据库";
            }
            System.Windows.Forms.Timer timer = null;
            Task tBegin = new Task(() =>
            {
                lock (lockObj)
                {
                    form.Invoke(new Action(() =>
                    {
                        int i = 0;
                        timer = new System.Windows.Forms.Timer();
                        timer.Interval = 500;
                        timer.Tick += (sender, e) =>
                        {
                            label.Text = text + dynamicStr[i % dynamicStr.Length];
                            form.Enabled = false;
                            i++;
                        };
                        timer.Start();
                    }));
                }
            });

         }
    }
}
