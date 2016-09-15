using LabManager.Model;
using LabManager.Util;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace LabManager.Util
{
    class MemberDAL
    {
        /// <summary>
        /// 获取成员信息
        /// </summary>
        /// <param name="loginState">enum，用户级别</param>
        /// <param name="showGraduated">bool，是否毕业</param>
        /// <param name="orderColOfMem">string，排序列名</param>
        /// <param name="sortOrder">SortOrder，排序顺序</param>
        /// <returns>DataSet</returns>
        static public DataSet GetMemberInfo(bool showGraduated, string orderColOfMem = null, SortOrder sortOrder = SortOrder.None)
        {
            DataSet dsMembers = null;
            StringBuilder sql = new StringBuilder();
            sql.Append("select id,number, name, sex, phone, email, password, level from member ");
            if (!showGraduated)
            {
                sql.Append("where graduated = @graduted ");
            }
            if (orderColOfMem != null && orderColOfMem != "")
            {
                if (orderColOfMem != "name")
                {
                    sql.Append("order by " + orderColOfMem);
                }
                else
                {
                    //中文排序方法
                    //order by用参数化查询无法实现？
                    sql.Append("order by convert(" + orderColOfMem + " using gbk)");
                }
                if (sortOrder == SortOrder.Descending)
                {
                    sql.Append(" desc");
                }
            }
            MySqlParameter[] parameters = {
                new MySqlParameter("@graduted", showGraduated.ToString()),
                //new MySqlParameter("@orderOfMem", orderOfMem)
            };
            try
            {
                dsMembers = SqlHelper.ExcuteDataTable(sql.ToString(), parameters);
            }
            catch (Exception ex)
            {
                Log.WriteLogFile("获取成员信息失败-->\n" + ex.Message);
            }
            return dsMembers;
        }
        /// <summary>
        /// 获得所有已毕业学生学号
        /// 用于在显示毕业学生信息时以其它颜色显示
        /// </summary>
        /// <returns>List集合</returns>
        static public List<string> GetGraduatedMemNum()
        {
            string sql = "select number from member where graduated=@graduated";
            MySqlParameter parameters = new MySqlParameter("@graduated", Boolean.TrueString);
            DataSet dsGraMemNum = null;
            try
            {
                dsGraMemNum = SqlHelper.ExcuteDataTable(sql, parameters);
            }
            catch (Exception ex)
            {
                Log.WriteLogFile("获取所有毕业学生学号失败-->\n" + ex.Message);
                return null;
            }
            List<string> listGraMemNum = null;
            if (dsGraMemNum.Tables.Count > 0)
            {
                listGraMemNum = new List<string>();
                DataTable dt = dsGraMemNum.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    listGraMemNum.Add(dt.Rows[i][0].ToString());
                }
            }
            return listGraMemNum;
        }
        /// <summary>
        /// 获取所有可以登录的用户
        /// </summary>
        /// <returns></returns>
        static public List<Member> GetAllUser()
        {
            string sql = "select id, number, name, password, level from member where graduated='false'";
            DataSet dsMem = null;
            try
            {
                dsMem = SqlHelper.ExcuteDataTable(sql);
            }
            catch (Exception ex)
            {
                Log.WriteLogFile("获取所有未毕业用户失败-->\n" + ex.Message);
            }
            List<Member> listUser = null;
            if (dsMem.Tables.Count > 0)
            {
                listUser = new List<Member>();
                DataTable dt = dsMem.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Member user = new Member();
                    user.Id = (int)dt.Rows[i][0];
                    user.Number = dt.Rows[i][1].ToString();
                    user.Name = dt.Rows[i][2].ToString();
                    user.Psw = dt.Rows[i][3].ToString();
                    user.Level = (LoginState)Enum.Parse(typeof(LoginState), dt.Rows[i][4].ToString());
                    listUser.Add(user);
                }
            }
            return listUser;
        }
        /// <summary>
        /// 获取单个成员信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Member GetSingleMem(int id)
        {
            Member member = new Member();
            string sql = "SELECT * FROM member WHERE id=@id";
            MySqlParameter param = new MySqlParameter("@id", id);
            DataSet DSMem = null;
            try
            {
                DSMem = SqlHelper.ExcuteDataTable(sql, param);
            }
            catch (Exception ex)
            {
                Log.WriteLogFile("获取单个成员信息失败-->\n" + ex.Message);
                return null;
            }
            member.Number = DSMem.Tables[0].Rows[0][1].ToString();
            member.Name = DSMem.Tables[0].Rows[0][2].ToString();
            member.Sex = (Sex)Enum.Parse(typeof(Sex), DSMem.Tables[0].Rows[0][3].ToString());
            member.Phone = DSMem.Tables[0].Rows[0][4].ToString();
            member.Email = DSMem.Tables[0].Rows[0][5].ToString();
            member.Graduated = bool.Parse(DSMem.Tables[0].Rows[0][6].ToString());
            member.Psw = DSMem.Tables[0].Rows[0][7].ToString();
            member.Level = (LoginState)Enum.Parse(typeof(LoginState), DSMem.Tables[0].Rows[0][8].ToString());
            return member;
        }
        public static int AddMem(Member member)
        {
            int ret = 0;
            string sql = "INSERT INTO member(number,name,sex,phone,email,graduated,password,level) " +
                "VALUES(@number,@name,@sex,@phone,@email,@graduated,@password,@level)";
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@number",member.Number),
                new MySqlParameter("@name",member.Name),
                new MySqlParameter("@sex",member.Sex.ToString()),
                new MySqlParameter("@phone",member.Phone),
                new MySqlParameter("@email",member.Email),
                new MySqlParameter("@graduated",member.Graduated.ToString()),
                new MySqlParameter("@password",member.Psw),
                new MySqlParameter("@level",(int)member.Level),
            };
            try
            {
                ret = SqlHelper.ExcuteNonQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                Log.WriteLogFile("添加成员失败-->\n" + ex.Message);
            }

            return ret;
        }
        public static int ModifyMem(Member member, int id)
        {
            int ret = 0;
            string sql = "UPDATE member SET number=@number,name=@name,sex=@sex,phone=@phone," +
                "email=@email,graduated=@graduated,password=@password,level=@level WHERE id=@id";
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@number",member.Number),
                new MySqlParameter("@name",member.Name),
                new MySqlParameter("@sex",member.Sex.ToString()),
                new MySqlParameter("@phone",member.Phone),
                new MySqlParameter("@email",member.Email),
                new MySqlParameter("@graduated",member.Graduated.ToString()),
                new MySqlParameter("@password",member.Psw),
                new MySqlParameter("@level",(int)member.Level),
                new MySqlParameter("@id",id),
            };
            try
            {
                ret = SqlHelper.ExcuteNonQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                Log.WriteLogFile("修改成员失败-->\n" + ex.Message);
            }

            return ret;
        }
        public static int DeleteMem(int id)
        {
            int ret = 0;
            string sql = "DELETE FROM member WHERE id=@id";
            MySqlParameter param = new MySqlParameter("@id", id);
            try
            {
                ret = SqlHelper.ExcuteNonQuery(sql, param);
            }
            catch (Exception ex)
            {
                Log.WriteLogFile("删除成员失败-->\n" + ex.Message);
            }       
            return ret;
        }
    }
}
