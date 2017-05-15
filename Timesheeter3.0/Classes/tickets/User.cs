using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timesheeter3._0.Classes
{
    class User
    {
        public long id { get; set; }
        public string name { get; set; }
        public string mail { get; set; }
        public long org_id { get; set; }
        public string phone { get; set; }
        public string role { get; set; }

        public User() { }
    }
}
