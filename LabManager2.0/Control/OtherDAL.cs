using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabManager.Util;

namespace LabManager.Util
{
    class OtherDAL
    {
        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        public static DateTime getServerTime()
        {
            DateTime time = DateTime.Parse("1990-03-14");
            string sql = "select now()";
            MySql.Data.MySqlClient.MySqlParameter parameters = new MySql.Data.MySqlClient.MySqlParameter();
            try
            {
                time = (DateTime)SqlHelper.ExcuteScalar(sql, parameters);
            }
            catch (Exception ex)
            {
                Log.WriteLogFile("获取服务器时间失败-->\n" + ex.Message);
            }
            return time;
        }
    }
}
