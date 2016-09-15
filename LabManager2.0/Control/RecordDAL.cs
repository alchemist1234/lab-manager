using LabManager.Model;
using LabManager.Util;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabManager.Util
{
    enum RecordIndexType
    {
        Id = 0,
        ChemId = 1,
        MemId = 2
    }
    class RecordDAL
    {
        static public List<Record> GetRecordList(RecordIndexType type, int Id = 0)
        {
            DataSet dsRecords = null;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT rec.id,date,mem_id,mem.name,type,chem_id,chem.cn_name," +
               "chem.en_name,chem.manufacturer,chem.unit,"+
               "des_lab.id,des_lab.name,des_loc.id,des_loc.name," +
               //"ori_lab.id,ori_lab.name,ori_loc.id,ori_loc.name," +
               "rec.number,rec.amount FROM record rec " +
               "LEFT JOIN member mem ON mem.id = rec.mem_id " +
               "LEFT JOIN chemical chem ON chem.id = rec.chem_id " +
               //"LEFT JOIN location ori_loc ON ori_loc.id = rec.ori_loc_id " +
               "LEFT JOIN location des_loc ON des_loc.id = chem.loc_id " +
               //"LEFT JOIN location ori_lab ON ori_lab.id = ori_loc.uid " +
               "LEFT JOIN location des_lab ON des_lab.id = des_loc.uid "
               );
            switch (type)
            {
                case RecordIndexType.Id:
                    sql.Append("WHERE id = @Id ORDER BY rec.id desc");
                    break;
                case RecordIndexType.ChemId:
                    sql.Append("WHERE chem_id = @chemId  ORDER BY rec.id desc");
                    break;
                case RecordIndexType.MemId:
                    sql.Append("WHERE mem_id = @memId ORDER BY rec.id desc");
                    break;
                default:
                    sql.Append("ORDER BY rec.id desc");
                    break;
            }
            MySqlParameter[] parameter =
            {
                new MySqlParameter("@Id", Id),
                new MySqlParameter("@memId", Id),
                new MySqlParameter("@chemId", Id),
            };
            try
            {
                dsRecords = SqlHelper.ExcuteDataTable(sql.ToString(), parameter);
            }
            catch (Exception ex)
            {
                Log.WriteLogFile("获取使用记录失败-->\n" + ex.Message);
                return null;
            }
            List<Record> listRecord = null;
            if (dsRecords.Tables.Count > 0)
            {
                listRecord = new List<Record>();
                DataTable dt = dsRecords.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Record record = new Record();
                    Member member = new Member();
                    Chemical chemical = new Chemical();
                    //Location oriLab = new Location();
                    //Location oriLoc = new Location();
                    Location desLab = new Location();
                    Location desLoc = new Location();
                    record.Id = Convert.ToInt32(dt.Rows[i][0]);
                    record.Date = ((DateTime)dt.Rows[i][1]);
                    member.Id = Convert.ToInt32(dt.Rows[i][2]);
                    member.Name = dt.Rows[i][3].ToString();
                    record.Member = member;
                    record.Type = (RecordType)Enum.Parse(typeof(RecordType), dt.Rows[i][4].ToString(), true);
                    chemical._Id = Convert.ToInt32(dt.Rows[i][5]);
                    chemical.CnName = dt.Rows[i][6].ToString();
                    chemical.EnName = dt.Rows[i][7].ToString();
                    chemical.Manufacturer = dt.Rows[i][8].ToString();
                    chemical.Unit = (Unit)Enum.Parse(typeof(Unit), dt.Rows[i][9].ToString(), true);
                    desLab.LocId = Convert.ToInt32(dt.Rows[i][10]);
                    desLab.LocName = dt.Rows[i][11].ToString();
                    chemical.Lab = desLab;
                    desLoc.LocId = Convert.ToInt32(dt.Rows[i][12]);
                    desLoc.LocName = dt.Rows[i][13].ToString();
                    chemical.Locaction = desLoc;
                    record.Chemical = chemical;
                    //oriLab.LocId = Convert.ToInt32(dt.Rows[i][14]);
                    //oriLab.LocName = dt.Rows[i][15].ToString();
                    //record.OriLab = oriLab;
                    //oriLoc.LocId = Convert.ToInt32(dt.Rows[i][16]);
                    //oriLoc.LocName = dt.Rows[i][17].ToString();
                    //record.OriLoc = oriLoc;
                    //record.Number = Convert.ToInt32(dt.Rows[i][18]);
                    //record.Amount = Convert.ToSingle(dt.Rows[i][19]);
                    record.Number = Convert.ToInt32(dt.Rows[i][14]);
                    record.Amount = Convert.ToSingle(dt.Rows[i][15]);
                    listRecord.Add(record);
                }
            }
            return listRecord;
        }
        public static int AddRecord(Record record)
        {
            int ret = 0;
            string sql = @"INSERT INTO record(type,date,mem_id,chem_id,number,amount) 
                VALUES(@type,@date,@memId,@chemId,@number,@amount)";
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@type", record.Type.ToString()),
                new MySqlParameter("@date", record.Date),
                new MySqlParameter("@memId", record.Member.Id),
                new MySqlParameter("@chemId", record.Chemical._Id),
                //new MySqlParameter("@OriLocId", record.OriLoc.LocId),
                new MySqlParameter("@number", record.Number),
                new MySqlParameter("@amount", record.Amount),
            };
            try
            {
                ret = SqlHelper.ExcuteNonQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                Log.WriteLogFile("添加使用记录失败-->\n" + ex.Message);
            }
            return ret;
        }
        public static int DelRecord(int chemId = 0, int memId = 0)
        {
            int ret = 0;
            if (chemId == 0 && memId == 0)
                return -1;
            if (chemId != 0 && memId != 0)
                return -1;
            StringBuilder sql = new StringBuilder();
            sql.Append("SET SQL_SAFE_UPDATES = 0;");
            sql.Append("Delete FROM record ");
            if (chemId != 0)
            {
                sql.Append("WHERE chem_id=@chemId;");
            }
            else if (memId != 0)
            {
                sql.Append("WHERE mem_id=@chemId;");
            }
            sql.Append("SET SQL_SAFE_UPDATES = 1;");
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@chemId",chemId),
                new MySqlParameter("@memId",memId),
            };
            try
            {
                ret = SqlHelper.ExcuteNonQuery(sql.ToString(), parameters);
            }
            catch (Exception ex)
            {
                Log.WriteLogFile("删除使用记录失败-->\n" + ex.Message);
            }            
         return ret;
        }
    }
}
