using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timesheeter3._0.Classes.tickets
{
    class Satisfaction
    {
        public long id { get; set; }
        public int score { get; set; }
        public string comment { get; set; }
        public long assignee_id { get; set; }
        public DateTime created { get; set; }
        
        public Satisfaction() { }
    }
}
