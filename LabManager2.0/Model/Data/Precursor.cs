using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabManager.Model
{
    public enum PrecursorType
    {
        第一类 = 1,
        第二类 = 2,
        第三类 = 3,
    }
    public class Precursor
    {
        public string CnName { get; set; }
        public string EnName { get; set; }
        public string CAS { get; set; }
        public PrecursorType Type { get; set; }
        public Precursor(string cnName,string enName,string CAS,PrecursorType type)
        {
            CnName = cnName;
            EnName = enName;
            this.CAS = CAS;
            Type = type;
        }
    }
}
