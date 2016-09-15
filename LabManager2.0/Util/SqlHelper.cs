using LabManager.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;


namespace LabManager.Util
{
    public class SqlHelper
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        public static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LabMan"].ConnectionString;
        static int subStart1 = connectionString.IndexOf('=');
        static int subEnd1 = connectionString.IndexOf(';');
        static int subStart2 = connectionString.IndexOf('=', subEnd1 + 1);
        static int subEnd2 = connectionString.IndexOf(';', subEnd1 + 1);
        static int subStart3 = connectionString.IndexOf('=', subEnd2 + 1);
        static int subEnd3 = connectionString.IndexOf(';', subEnd2 + 1);
        public static string IP = connectionString.Substring(subStart1 + 1, subEnd1 - subStart1 - 1);
        public static string user = connectionString.Substring(subStart2 + 1, subEnd2 - subStart2 - 1);
        public static string psw = connectionString.Substring(subStart3 + 1, subEnd3 - subStart3 - 1);
        public static void ResetConnectionStr(string connStr)
        {
            connectionString = connStr;
            subStart1 = connectionString.IndexOf('=');
            subEnd1 = connectionString.IndexOf(';');
            subStart2 = connectionString.IndexOf('=', subEnd1 + 1);
            subEnd2 = connectionString.IndexOf(';', subEnd1 + 1);
            subStart3 = connectionString.IndexOf('=', subEnd2 + 1);
            subEnd3 = connectionString.IndexOf(';', subEnd2 + 1);
            IP = connectionString.Substring(subStart1 + 1, subEnd1 - subStart1 - 1);
            user = connectionString.Substring(subStart2 + 1, subEnd2 - subStart2 - 1);
            psw = connectionString.Substring(subStart3 + 1, subEnd3 - subStart3 - 1);
        }
        /// <summary>
        /// 检查数据库是否可以连接
        /// </summary>
        /// <returns>bool</returns>
        public static bool isDataBaseConnectable()
        {
            Console.WriteLine(connectionString);
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                Log.WriteLogFile("SqlHelper--检查数据库是否能够连接：数据库连接异常！");
                return false;
            }
            finally
            {
                conn.Close();
            }
            Log.WriteLogFile("SqlHelper--检查数据库是否能够连接：数据库连接成功！");
            return true;
        }
        /// <summary>
        /// 获取DataSet
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL语句参数</param>
        /// <returns></returns>
        public static DataSet ExcuteDataTable(string sql, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd))
                    {
                        DataSet dataset = null;
                        try
                        {
                            dataset = new DataSet();
                            dataAdapter.Fill(dataset);
                            //MainView.connectable = true;
                            //Log.WriteLogFile("SqlHelper--查询DataTable：查询成功！");
                        }
                        catch (Exception)
                        {
                            //MainView.connectable = false;
                            //Log.WriteLogFile("SqlHelper--查询DataTable：查询失败！");
                            //Log.WriteLogFile("失败原因：" + ex.Message);
                        }
                        return dataset;
                    }
                }
            }
        }
        /// <summary>
        /// 执行非查询SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL语句参数</param>
        /// <returns></returns>
        public static int ExcuteNonQuery(string sql, params MySqlParameter[] parameters)
        {
            int res = -1;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    try
                    {
                        conn.Open();
                        res = cmd.ExecuteNonQuery();
                        //MainView.connectable = true;
                        //Log.WriteLogFile("SqlHelper--执行NonQuery：成功！");
                    }
                    catch (Exception)
                    {
                        //MainView.connectable = false;
                        //Log.WriteLogFile("SqlHelper--执行NonQuery：失败！");
                        //Log.WriteLogFile(sql);
                        //Log.WriteLogFile("失败原因：" + ex.Message);
                    }

                    return res;
                }
            }
        }
        /// <summary>
        /// 获取结果集第一行第一列数据
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL语句参数</param>
        /// <returns></returns>
        public static object ExcuteScalar(string sql, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    try
                    {
                        conn.Open();
                        //MainView.connectable = true;
                        //Log.WriteLogFile("SqlHelper--执行Scalar：成功！");
                    }
                    catch (Exception)
                    {
                        //MainView.connectable = false;
                        //Log.WriteLogFile("SqlHelper--执行Scalar：失败！");
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}
