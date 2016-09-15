using LabManager.Util;
using System;
using System.Windows.Forms;
using LabManager.View;

namespace LabManager.View
{
    public partial class ConfigView : Form
    {
        MainView mainView;
        public ConfigView(bool showWarning)
        {
            InitializeComponent();
            if (showWarning)
            {
                MessageBox.Show("无法连接服务器，请检查服务器是否开启，以及服务器设置是否正确，" +
                "点击确定将进入服务器连接参数设置，误操作可能导致严重后果，如有问题请联系管理员",
                "警告：无法连接服务器", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string IP = txtBoxIP.Text.Trim();
            string user = txtBoxUser.Text.Trim();
            string psw = txtBoxPsw.Text.Trim();
            if (IP == "" || user == "" || psw == "")
            {
                MessageBox.Show("参数不完整，请重新输入","警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                string connectionString = string.Format("server={0};Uid={1};Pwd={2};Database=lab_manager;Connection Timeout=10;Charset=utf8", IP,user,psw);
                //SqlHelper.connectionString = connectionString;
                SqlHelper.ResetConnectionStr(connectionString);
                Config.updateConnectionString("LabMan", connectionString);
                mainView._Load();
                Dispose();
            }
        }

        private void ConfigView_Load(object sender, EventArgs e)
        {
            mainView = (MainView)Owner;
            //string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LabMan"].ConnectionString;
            //string connectionString = SqlHelper.connectionString;
            //int subStart1 = connectionString.IndexOf('=');
            //int subEnd1 = connectionString.IndexOf(';');
            //int subStart2 = connectionString.IndexOf('=', subEnd1 + 1);
            //int subEnd2 = connectionString.IndexOf(';', subEnd1 + 1);
            //int subStart3 = connectionString.IndexOf('=', subEnd2 + 1);
            //int subEnd3 = connectionString.IndexOf(';', subEnd2 + 1);
            //string IP = connectionString.Substring(subStart1 + 1, subEnd1 - subStart1 - 1);
            //string user = connectionString.Substring(subStart2 + 1, subEnd2 - subStart2 - 1);
            //string psw = connectionString.Substring(subStart3 + 1, subEnd3 - subStart3 - 1);
            txtBoxIP.Text = SqlHelper.IP;
            txtBoxUser.Text = SqlHelper.user;
            txtBoxPsw.Text = SqlHelper.psw;
        }
    }
}
