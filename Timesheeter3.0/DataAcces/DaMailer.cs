using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheeter3_0.Classes;

namespace Timesheeter3._0.DataAcces
{
    class DaMailer
    {

        private void MakeClientHeader(StringBuilder aMsg, List<Ticket> aItem )
        {
            var tabstyle = @"bgcolor='#ececec' style='font-family:Arial; font-size:15px; color:#000000'";

        }

        public string GetTicketOverviewHTML(DateTime aStart, DateTime aEnd)
        {
            var message = new StringBuilder();
            message.AppendFormat("<strong style='font-family:Arial; font-size:25px'>Zendesk Overview from {0} to {1}</strong><br /><br />"
                , aStart, aEnd);

            var zones = DaExportDB.FetchTicketsByDate(aStart, aEnd, 1).OrderByDescending(x=> x.Value.Count());
          
            foreach (var zone in zones)
            {

                if (zone.Value.Count > 0)
                {
                    message.AppendFormat(@"<strong style='font-family:Arial; font-size:20px; color:red'>{0} total of {1} tickets</strong><br />", zone.Key, zone.Value.Count);

                }
                else
                {
                    message.AppendFormat(@"<strong style='font-family:Arial; font-size:20px; color:green'>{0}</strong><br />", zone.Key);

                }
                var items = zone.Value.OrderBy(x => x.status);
                message.Append(@"<table cellpadding='5' cellspacing='5' width='100%'>");
                MakeClientHeader(message, zone.Value);
                foreach (var item in items)
                {

                    AddToClient(message, item);

                }
                message.Append(@"</table> <br />");
            }
        

            return message.ToString();
        }


        private void AddToClient(StringBuilder aMsg, Ticket aTicket)
        {
            var tabstyle = "style='font-family:Arial; font-size:12px; color:#000000;'";
            
                var days = DateTime.Now - aTicket.created;
                aMsg.AppendFormat(@"<tr><td {0} width='40%'>{1}</td><td /><td {0} width='15%'>{2}</td><td {0} width='15%'>{3} days open</td><td {0} width='15%'><a href='{4}' target='_blank'>Link</a></td></tr>", tabstyle,
                    aTicket.subject.Trim(), aTicket.status, Math.Ceiling(days.TotalDays), aTicket.Link);
            
        }








    }
}
