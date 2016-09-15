using LabManager.Util;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabManager.Model;

namespace LabManager.Util
{
    class LocationDAL
    {
        /// <summary>
        /// 获取所有实验室，或者某一实验室所有存放位置
        /// </summary>
        /// <param name="uid">int，实验室Id</param>
        /// <returns></returns>
        public static List<Location> GetLoc(int uid = -1)
        {
            StringBuilder sql = new StringBuilder("select id,name,uid from location");
            MySqlParameter parameters = null;
            DataSet dsLab = null;
            try
            {
                if (uid != -1)
                {
                    sql.Append(" where uid=@uid");
                    parameters = new MySqlParameter("@uid", uid);
                    dsLab = SqlHelper.ExcuteDataTable(sql.ToString(), parameters);
                }
                else
                {
                    dsLab = SqlHelper.ExcuteDataTable(sql.ToString());
                }
            }
            catch (Exception ex)
            {
                Log.WriteLogFile("获取实验室或存放位置失败-->\n" + ex.Message);
                return null;
            }
            List<Location> listLoc = new List<Location>();
            Location loc = new Location();
            if (dsLab.Tables.Count > 0)
            {
                DataTable dt = dsLab.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    loc = new Location();
                    loc.LocId = Convert.ToInt32(dt.Rows[i][0]);
                    loc.LocName = dt.Rows[i][1].ToString();
                    loc.Uid = Convert.ToInt32(dt.Rows[i][2]);
                    listLoc.Add(loc);
                }
            }
            return listLoc;
        }
        public static int UpdateLoc(LocOperation locOperation)
        {
            int ret = 0;
            string sql = null;
            MySqlParameter[] parameters = null;
            switch (locOperation.Operation)
            {
                case LocOperationType.无操作:
                    break;
                case LocOperationType.添加:
                    sql = "insert into location(id,name,uid) values(@id,@name,@uid)";
                    if (locOperation.OperationNodeLevel == 1)
                    {
                        parameters = new MySqlParameter[]
                        {
                            new MySqlParameter("@id",locOperation.OriLabNode.Tag),
                            new MySqlParameter("@name",locOperation.OriLabNode.Text),
                            new MySqlParameter("@uid","0"),
                        };
                    }
                    else
                    {
                        parameters = new MySqlParameter[]
                        {
                            new MySqlParameter("@id",locOperation.OriLocNode.Tag),
                            new MySqlParameter("@name",locOperation.OriLocNode.Text),
                            new MySqlParameter("@uid",locOperation.OriLabNode.Tag),
                        };
                    }
                    break;
                case LocOperationType.修改:
                    sql = "update location set name=@name where id=@id";
                    if (locOperation.OperationNodeLevel == 0)
                    {
                        parameters = new MySqlParameter[]
                        {
                            new MySqlParameter("@name",locOperation.DesLabNode.Text),
                            new MySqlParameter("@id","0"),
                        };
                    }
                    else if (locOperation.OperationNodeLevel == 1)
                    {
                        parameters = new MySqlParameter[]
                        {
                            new MySqlParameter("@name",locOperation.DesLabNode.Text),
                            new MySqlParameter("@id",locOperation.DesLabNode.Tag),
                        };
                    }
                    else
                    {
                        parameters = new MySqlParameter[]
                        {
                            new MySqlParameter("@name",locOperation.DesLocNode.Text),
                            new MySqlParameter("@id",locOperation.OriLocNode.Tag),
                        };
                    }
                    break;
                case LocOperationType.删除:
                    sql = "delete from location where id=@id";
                    if (locOperation.OperationNodeLevel == 1)
                    {
                        parameters = new MySqlParameter[]
                        {
                            new MySqlParameter("@id",locOperation.OriLabNode.Tag),
                        };
                    }
                    else
                    {
                        parameters = new MySqlParameter[]
                        {
                            new MySqlParameter("@id",locOperation.OriLocNode.Tag),
                        };
                    }

                    break;
                case LocOperationType.移动:
                    sql = "update location set uid=@uid where id=@id";
                    parameters = new MySqlParameter[]
                    {
                        new MySqlParameter("@uid",locOperation.DesLabNode.Tag),
                        new MySqlParameter("@id",locOperation.OriLocNode.Tag),
                    };
                    break;
                default:
                    break;
            }
            try
            {
                ret = SqlHelper.ExcuteNonQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                Log.WriteLogFile("更新存放位置失败-->\n" + ex.Message);
            }
            
            return ret;
        }
        public static int GetChemCountOfLoc(int locId)
        {
            object count = 0;
            string sql = "SELECT COUNT(id) FROM chemical WHERE loc_id=@locId";
            MySqlParameter para = new MySqlParameter("@locId", locId);
            try
            {
                count = SqlHelper.ExcuteScalar(sql, para);
            }
            catch (Exception ex)
            {
                Log.WriteLogFile("获取某存放位置药品数量失败-->\n" + ex.Message);
            }           
            return Convert.ToInt32(count);
        }

    }
}
