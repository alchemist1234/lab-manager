using LabManager.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabManager.Model
{
    public enum LoginState
    {
        UserNotExits = -1,
        WrongPassword = -2,
        访客 = 0,
        管理员 = 1,
        教师 = 2,
        学生 = 3,
    };
}
