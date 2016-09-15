using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabManager.Model
{
    public enum RecordType
    {
        Add = 1,
        Use = 2,
        //Transfer = 3,
    }
    public class Record
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Member Member { get; set; }
        public RecordType Type { get; set; }
        public Chemical Chemical { get; set; }
        //public Location OriLab { get; set; }
        //public Location OriLoc { get; set; }
        public int Number { get; set; }
        public float Amount { get; set; }
        public string GetRecInfo()
        {
            string info;
            switch (Type)
            {
                case RecordType.Add:
                    info = string.Format("{0}\t{1} 购买了{2}瓶{3}({4})共{5}{6}\t位置：{7}({8})",
                        Date.ToShortDateString(),
                        Member.Name != "" ? Member.Name : "未知用户",
                        //Member.Name ?? "未知用户",
                        Number,
                        Chemical.CnName ?? Chemical.EnName,
                        Chemical.Manufacturer,
                        Amount,
                        Chemical.Unit,
                        Chemical.Locaction.LocName,
                        Chemical.Lab.LocName);
                    break;
                case RecordType.Use:
                    info = string.Format("{0}\t{1} 使用了{2}瓶{3}({4})共{5}{6}\t位置：{7}({8})",
                        Date.ToShortDateString(),
                        Member.Name != "" ? Member.Name : "未知用户",
                        //Member.Name ?? "未知用户",
                        Number,
                        Chemical.CnName ?? Chemical.EnName,
                        Chemical.Manufacturer,
                        Amount,
                        Chemical.Unit,
                        Chemical.Locaction.LocName,
                        Chemical.Lab.LocName);
                    break;
                //case RecordType.Transfer:
                //    info = string.Format("{0}\t{1} 将{2}瓶{3}({4})共{5}{6}从{7}({8})转移到{9}({10})",
                //        Date.ToShortDateString(),
                //        Member.Name,
                //        Number,
                //        Chemical.CnName ?? Chemical.EnName,
                //        Chemical.Manufacturer,
                //        Amount,
                //        Chemical.Unit,
                //        OriLoc.LocName,
                //        OriLab.LocName,
                //        Chemical.Locaction.LocName,
                //        Chemical.Lab.LocName);
                //    break;
                default:
                    info = "未查询到使用记录";
                    break;
            }
            return info;
        }
    }
}

