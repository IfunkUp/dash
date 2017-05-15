using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timesheeter3._0.Classes.knowledge_base
{
    class Article
    {
        public long id { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public long author_id { get; set; }
        public string htmlUrl
        {
            set
            {
                value = "https://support.sms-timing.com/hc/en-us/articles/" + id + "-" + title;
            }
            
        }

        public long section_id { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }

        public Article() { }



    }
}
