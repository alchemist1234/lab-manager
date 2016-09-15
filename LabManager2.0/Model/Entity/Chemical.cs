using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabManager.Model
{
    public class Chemical
    {
        public int _Id { get; set; }

        public string CnName { get; set; }

        public string EnName { get; set; }

        public string Abbr { get; set; }

        public string _CAS { get; set; }

        public bool IsPrecursor { get; set; }

        public int Capacity { get; set; }

        internal Unit Unit { get; set; }

        public int Number { get; set; }

        public float Residual { get; set; }

        public int LocId { get; set; }

        public  Location Lab { get; set; }

        public  Location Locaction { get; set; }

        public int PurchaserId { get; set; }

        public Member Purchaser { get; set; }

        public int LastUserId { get; set; }

        public Member LastUser { get; set; }

        public string Manufacturer { get; set; }

        public DateTime PurchaseDate { get; set; }

        public string Remark { get; set; }
    }
}
