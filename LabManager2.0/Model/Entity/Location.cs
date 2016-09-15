using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabManager.Model
{
    public class Location
    {
        //int locId;
        //string locName;
        //int uid;

        public int LocId { get; set; }

        public string LocName { get; set; }

        public int Uid { get; set; }
        public void showLoc()
        {
            MessageBox.Show(string.Format("Id:{0} {1},uid:{2}", LocId, LocName, Uid));
        }
    }
}
