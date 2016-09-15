using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabManager.Model
{
    public class Member
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        internal Sex Sex { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Graduated { get; set; }
        public string Psw { get; set; }
        public LoginState Level { get; set; }
    }
}
