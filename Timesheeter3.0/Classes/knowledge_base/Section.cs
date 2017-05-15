using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timesheeter3._0.Classes.knowledge_base
{
    class Section
    {

        public long id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public long category_id { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }

        public Section() { }



    }
}
