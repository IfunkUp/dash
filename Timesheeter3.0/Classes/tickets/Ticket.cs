using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timesheeter3_0.Classes
{
    class Ticket
    {
        public long id { get; set; }
        public long assigneeId { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public string subject { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public string tags { get; set; }
        public string url { get; set; }
        public string via { get; set; }
        public long organisationId { get; set; }

    }
}
