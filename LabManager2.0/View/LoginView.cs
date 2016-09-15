using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LabManager.Util;
using LabManager.Model;

namespace LabManager.View
{ 
    public partial class LoginView : Form
    {
        public LoginView()
        {
            InitializeComponent();
            
        }
        /// <summary>
        /// 确定按钮被点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            string userNum = txtBoxUser.Text.Trim();
            string userPsw = txtBoxPsw.Text.Trim();
            if (userNum == "")
            {
                MessageBox.Show("请输入用户名","警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else if (userPsw == "")
            {
                MessageBox.Show("请输入密码", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Member user;
                LoginState loginState = LoginCheck(userNum, userPsw, out user);
                if (loginState == LoginState.UserNotExits)
                {
                    MessageBox.Show("该用户不存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (loginState == LoginState.WrongPassword)
                {
                    MessageBox.Show("密码错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MainView.loginState = loginState;
                    MainView.user = user;
                    //owner.SetControl();
                    DialogResult = DialogResult.OK;
                    Dispose();
                }
            }
        }
        /// <summary>
        /// 检查用户名密码是否正确
        /// </summary>
        /// <param name="userNum">string，用户名（学号）</param>
        /// <param name="userPsw">string，密码</param>
        /// <param name="_user">out User，返回登录的用户</param>
        /// <returns></returns>
        private LoginState LoginCheck(string userNum, string userPsw, out Member _user)
        {
            foreach (Member user in MainView.ListUser)
            {
                if (user.Number == userNum)
                {
                    if (user.Psw == userPsw)
                    {
                        _user = user;
                        return user.Level;
                    }
                    else
                    {
                        _user = null;
                        return LoginState.WrongPassword;
                    }
                }
            }
            _user = null;
            return LoginState.UserNotExits;
        }
    }
}
