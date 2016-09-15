using LabManager.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabManager.Properties;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using LabManager.Model;

namespace LabManager.Util
{
    class ChemicalDAL
    {
        /// <summary>
        /// 获取相应参数下的药品信息
        /// </summary>
        /// <param name="showExhausted">bool，是否显示已用完药品</param>
        /// <param name="chemType">ChemType，显示普通or易制毒or全部药品</param>
        /// <param name="queryStr">string，查询字符串</param>
        /// <param name="labId">int，实验室Id</param>
        /// <param name="locId">int，存放位置Id</param>
        /// <param name="orderColOfChem">string，按照哪一列排序</param>
        /// <param name="sortOrder">SortOrder，顺序or倒序</param>
        /// <returns></returns>
        public static DataSet GetChem(bool showExhausted = false, ChemType chemType = ChemType.All, string queryStr = null, int labId = 0, int locId = 0, string orderColOfChem = null, SortOrder sortOrder = SortOrder.None)
        {
            //Log.WriteLogFile("ChemicalDAL--获取药品信息");
            DataSet dsChem = null;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ch.id,cn_name,en_name,abbr,CAS,capacity,unit,ch.number,residual,lab.name as lab," +
                "loc.name as loc,manufacturer,mem_u.name as lastUser,mem_p.name as purchaser,purchase_date,remark " +
                "From chemical ch JOIN location loc on ch.loc_id=loc.id JOIN location lab on lab.id=loc.uid " +
                "LEFT JOIN member mem_p on ch.purchaser_id=mem_p.id LEFT JOIN member mem_u on ch.last_user_id=mem_u.id where 1=1 ");
            if (queryStr.Trim() != "" && queryStr.Trim() != null)
            {
                sql.Append("and (cn_name like @queryStr or en_name like @queryStr or abbr like @queryStr or CAS like @queryStr) ");
            }
            if (labId != 0)
            {
                sql.Append("and lab.id=@labID ");
            }
            if (locId != 0)
            {
                sql.Append("and loc.id=@locID ");
            }
            switch (chemType)
            {
                case ChemType.Common:
                    sql.Append("and is_precursor='false' ");
                    break;
                case ChemType.Precursor:
                    sql.Append("and is_precursor='true' ");
                    break;
                default:
                    break;
            }
            if (!showExhausted)
            {
                sql.Append("and ch.number<>0 and residual<>0 ");
            }
            if (orderColOfChem != null)
            {
                if (orderColOfChem != "cn_name" && orderColOfChem != "lab"
                    && orderColOfChem != "manufacturer" && orderColOfChem != "loc"
                    && orderColOfChem != "remark" && orderColOfChem != "lastUser"
                    && orderColOfChem != "purchaser")
                {
                    sql.Append("order by " + orderColOfChem);
                }
                else
                {
                    sql.Append("order by convert(" + orderColOfChem + " using gbk)");
                }
                if (sortOrder == SortOrder.Descending)
                {
                    sql.Append(" desc");
                }
            }
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@queryStr","%"+queryStr+"%"),
                new MySqlParameter("@labID",labId),
                new MySqlParameter("@locID",locId.ToString()),
            };
            try
            {
                dsChem = SqlHelper.ExcuteDataTable(sql.ToString(), parameters);
            }
            catch (Exception ex)
            {
                Log.WriteLogFile("获取药品信息失败-->\n" + ex.Message);
            }
            return dsChem;
        }
        /// <summary>
        /// 获取所有已用完药品Id
        /// </summary>
        /// <returns>字符串List</returns>
        public static List<string> GetExhaustedChemId()
        {
            string sql = "select id from chemical where number=0 and residual=0";
            DataSet dsExhaChemID = SqlHelper.ExcuteDataTable(sql);
            List<string> listExhaChemID = null;
            if (dsExhaChemID.Tables.Count > 0)
            {
                listExhaChemID = new List<string>();
                DataTable dt = dsExhaChemID.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    listExhaChemID.Add(dt.Rows[i][0].ToString());
                }
            }
            return listExhaChemID;
        }
        /// <summary>
        /// 添加药品
        /// </summary>
        /// <param name="chemical">Chemical，被添加的药品</param>
        /// <returns></returns>
        public static int AddChem(Chemical chemical)
        {
            int res = 0;
            string sql = "insert into chemical(cn_name,en_name,abbr,cas,is_precursor," +
                "capacity,unit,number,residual,loc_id,purchaser_id,last_user_id,manufacturer," +
                "purchase_date,remark) values(@cnName,@enName,@abbr,@cas," +
                "@isPrecursor,@capacity,@unit,@number,@residual,@locID,@purchaserID," +
                "@purchaserID,@manufacturer,@purchaseDate,@remark)";
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@cnName",chemical.CnName),
                new MySqlParameter("@enName",chemical.EnName),
                new MySqlParameter("@abbr",chemical.Abbr),
                new MySqlParameter("@cas",chemical._CAS),
                new MySqlParameter("@isPrecursor",chemical.IsPrecursor.ToString()),
                new MySqlParameter("@capacity",chemical.Capacity),
                new MySqlParameter("@unit",chemical.Unit.ToString()),
                new MySqlParameter("@number",chemical.Number),
                new MySqlParameter("@residual",chemical.Residual),
                new MySqlParameter("@locID",chemical.LocId),
                new MySqlParameter("@purchaserID",chemical.PurchaserId),
                new MySqlParameter("@manufacturer",chemical.Manufacturer),
                new MySqlParameter("@purchaseDate",chemical.PurchaseDate),
                new MySqlParameter("@remark",chemical.Remark),
            };
            try
            {
                res = SqlHelper.ExcuteNonQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                Log.WriteLogFile("添加药品失败-->\n" + ex.Message);
            }

            return res;
        }
        /// <summary>
        /// 根据Id获取单个药品
        /// </summary>
        /// <param name="chemId">int，药品Id</param>
        /// <returns></returns>     
        public static Chemical GetSingleChem(int chemId)
        {
            DataSet ds = null;
            Chemical chemical = new Chemical();
            string sql = "SELECT cn_name,en_name,abbr,CAS,is_precursor,capacity,unit," +
                "ch.number,residual,lab.id,lab.name,loc_id,loc.name,ch.purchaser_id,mem_p.name," +
                "ch.last_user_id,mem_u.name,manufacturer,purchase_date,remark FROM chemical ch " +
                "JOIN location loc ON loc_id = loc.id " +
                "JOIN location lab ON lab.id = loc.uid LEFT JOIN member mem_p ON ch.purchaser_id = mem_p.id " +
                "LEFT JOIN member mem_u ON ch.last_user_id = mem_u.id WHERE ch.id=@chemId";
            MySqlParameter param = new MySqlParameter("@chemId", chemId);
            try
            {
                ds = SqlHelper.ExcuteDataTable(sql, param);
            }
            catch (Exception ex)
            {
                Log.WriteLogFile("获取单个药品信息失败-->\n" + ex.Message);
                return null;
            }
            chemical._Id = chemId;
            chemical.CnName = ds.Tables[0].Rows[0][0].ToString();
            chemical.EnName = ds.Tables[0].Rows[0][1].ToString();
            chemical.Abbr = ds.Tables[0].Rows[0][2].ToString();
            chemical._CAS = ds.Tables[0].Rows[0][3].ToString();
            chemical.IsPrecursor = bool.Parse(ds.Tables[0].Rows[0][4].ToString());
            chemical.Capacity = (int)ds.Tables[0].Rows[0][5];
            chemical.Unit = (Unit)Enum.Parse(typeof(Unit), ds.Tables[0].Rows[0][6].ToString());
            chemical.Number = (int)ds.Tables[0].Rows[0][7];
            chemical.Residual = (float)ds.Tables[0].Rows[0][8];
            chemical.Lab = new Location();
            chemical.Lab.LocId = (int)ds.Tables[0].Rows[0][9];
            chemical.Lab.LocName = ds.Tables[0].Rows[0][10].ToString();
            chemical.Lab.Uid = 0;
            chemical.Locaction = new Location();
            chemical.LocId = (int)ds.Tables[0].Rows[0][11];
            chemical.Locaction.LocId = (int)ds.Tables[0].Rows[0][11];
            chemical.Locaction.LocName = ds.Tables[0].Rows[0][12].ToString();
            chemical.Locaction.Uid = (int)ds.Tables[0].Rows[0][9];
            chemical.PurchaserId = (int)ds.Tables[0].Rows[0][13];
            if (ds.Tables[0].Rows[0][14].ToString() != "")
            {
                Member purchaser = new Member();
                purchaser.Id = (int)ds.Tables[0].Rows[0][13];
                purchaser.Name = ds.Tables[0].Rows[0][14].ToString();
                chemical.Purchaser = purchaser;
            }
            chemical.LastUserId = (int)ds.Tables[0].Rows[0][15];
            if (ds.Tables[0].Rows[0][16].ToString() != "")
            {
                Member lastUser = new Member();
                lastUser.Id = (int)ds.Tables[0].Rows[0][15];
                lastUser.Name = ds.Tables[0].Rows[0][16].ToString();
                chemical.LastUser = lastUser;
            }
            chemical.Manufacturer = ds.Tables[0].Rows[0][17].ToString();
            if (ds.Tables[0].Rows[0][18].ToString() == "")
            {
                chemical.PurchaseDate = DateTime.Today;
            }
            else
            {
                chemical.PurchaseDate = (DateTime)ds.Tables[0].Rows[0][18];
            }
            chemical.Remark = ds.Tables[0].Rows[0][19].ToString();

            return chemical;
        }
        /// <summary>
        /// 根据药品获取Id（查找重复药品）
        /// </summary>
        /// <param name="chemical">Chemical，被查找的药品</param>
        /// <returns></returns>
        public static int GetReChemId(Chemical chemical)
        {
            int chemId = 0;
            string sql = "SELECT id FROM chemical WHERE cas=@cas AND capacity=@capacity " +
                "AND unit=@unit AND loc_id=@locId AND manufacturer=@manufacturer";
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@cas",chemical._CAS),
                new MySqlParameter("@capacity",chemical.Capacity.ToString()),
                new MySqlParameter("@unit", chemical.Unit.ToString()),
                new MySqlParameter("@locId",chemical.Locaction.LocId.ToString()),
                new MySqlParameter("@manufacturer",chemical.Manufacturer),
            };
            try
            {
                chemId = Convert.ToInt32(SqlHelper.ExcuteScalar(sql, parameters));
            }
            catch (Exception ex)
            {
                Log.WriteLogFile("获取重复ID失败-->\n" + ex.Message);
            }
            return chemId;
        }
        /// <summary>
        /// 修改药品
        /// </summary>
        /// <param name="chemId">int，被修改的药品Id</param>
        /// <param name="chemical">Chemical，修改后的药品</param>
        /// <returns></returns>
        public static int ModifyChem(int chemId, Chemical chemical)
        {
            string sql = "UPDATE chemical SET cn_name=@cnName, en_name=@enName," +
                "abbr=@abbr,cas=@cas,is_precursor=@isPrecursor,capacity=@capacity," +
                "unit=@unit,number=@number,residual=@residual,loc_id=@locId," +
                "purchaser_id=@purchaserId,last_user_id=@lastUserId," +
                "manufacturer=@manufacturer,purchase_date=@purchaseDate," +
                "remark=@remark WHERE id=@chemId";
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@cnName",chemical.CnName),
                new MySqlParameter("@enName",chemical.EnName),
                new MySqlParameter("@abbr",chemical.Abbr),
                new MySqlParameter("@cas",chemical._CAS),
                new MySqlParameter("@isPrecursor",chemical.IsPrecursor.ToString()),
                new MySqlParameter("@capacity",chemical.Capacity),
                new MySqlParameter("@unit",chemical.Unit.ToString()),
                new MySqlParameter("@number",chemical.Number),
                new MySqlParameter("@residual",chemical.Residual),
                new MySqlParameter("@locId",chemical.LocId),
                new MySqlParameter("@purchaserId",chemical.PurchaserId),
                new MySqlParameter("@lastUserId",chemical.LastUserId),
                new MySqlParameter("@manufacturer",chemical.Manufacturer),
                new MySqlParameter("@purchaseDate",chemical.PurchaseDate),
                new MySqlParameter("@remark",chemical.Remark),
                new MySqlParameter("@chemId",chemId),
            };
            int ret = 0;
            try
            {
                ret = SqlHelper.ExcuteNonQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                Log.WriteLogFile("修改药品失败-->\n" + ex.Message);
            }
            return ret;
        }
        public static int DelChem(int ChemId)
        {
            //先删除相关记录
            string sql = "DELETE FROM record WHERE chem_id=@id";
            MySqlParameter param = new MySqlParameter("@id", ChemId);
            SqlHelper.ExcuteNonQuery(sql, param);

            //删除药品
            sql = "DELETE FROM chemical WHERE id=@id";
            int ret = 0;
            try
            {
                ret = SqlHelper.ExcuteNonQuery(sql, param);
            }
            catch (Exception ex)
            {
                Log.WriteLogFile("删除药品失败-->\n" + ex.Message);
            }
            return ret;
        }
        public static List<string> GetAllManu()
        {
            string sql = "SELECT manufacturer FROM chemical WHERE manufacturer<>'' GROUP BY manufacturer ";
            DataSet DSManu = null;
            List<string> listManu = null;
            try
            {
                DSManu = SqlHelper.ExcuteDataTable(sql);
            }
            catch (Exception ex)
            {
                Log.WriteLogFile("获取所有生产厂家失败-->\n" + ex.Message);
            }
            if (DSManu.Tables.Count > 0)
            {
                DataTable DT = DSManu.Tables[0];
                listManu = new List<string>();
                foreach (DataRow row in DT.Rows)
                {
                    listManu.Add(row[0].ToString());
                }
            }
            return listManu;
        }
        public static int GetMaxId()
        {
            string sql = "SELECT MAX(id) from chemical";
            int maxId = 0;
            try
            {
                maxId = Convert.ToInt32(SqlHelper.ExcuteScalar(sql));
            }
            catch (Exception ex)
            {
                Log.WriteLogFile("获取最大药品ID号失败-->\n" + ex.Message);
            }

            return maxId;
        }
    }
}
