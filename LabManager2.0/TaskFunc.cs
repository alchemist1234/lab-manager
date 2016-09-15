using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LabManager.View;
using System.Threading;

namespace LabManager.Util
{
    /// <summary>
    /// 耗时操作多线程任务
    /// </summary>
    class TaskFunc
    {
        static ConnectingView connView;
        /// <summary>
        /// 进行耗时操作前委托父窗口显示ConnectingView，并禁用父窗口
        /// </summary>
        /// <param name="owner">父窗口</param>
        /// <param name="connView">要显示的ConnectingView</param>
        public static void BeginTaskShowView(Form owner)
        {         
                owner.Invoke(new Action(() =>
                {

                    { 
                        connView = new ConnectingView();
                        connView.Show();
                        owner.Enabled = false;
                      }
                }));

        }
        /// <summary>
        /// 耗时操作结束后委托父窗口重新启用父窗口，并隐藏ConnectingView
        /// </summary>
        /// <param name="owner">父窗口</param>
        /// <param name="connView">要隐藏的ConnectingView</param>
        public static void EndTaskHideView(Form owner)
        {
            //owner.Invoke(new Action(() =>
            //{
            owner.Enabled = true;
            connView.Dispose();
            //connView = null;
            //}));

        }
        /// <summary>
        /// 耗时操作同时在ToolStripLable上显示动态文字
        /// </summary>
        /// 
        /// <param name="lable"></param>
        public static void BeginTaskLable(Form owner, ToolStripLabel lable, string str, System.Windows.Forms.Timer timer)
        {

            //string str1 = "正在连接数据库";
            string[] dynamicStr = { ".", "..", "...", "...." };
            int i = 0;
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 500;
            timer.Tick += (sender, e) =>
            {
                lable.Text = str + dynamicStr[i % dynamicStr.Length];
                i++;
            };
            timer.Start();
        }
        public static void EndTaskLable(Form owner, ToolStripLabel lable, System.Windows.Forms.Timer timer)
        {
            lable.Text = "";
            timer.Stop();
        }
    }
}
