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
        private string MakeHead()
        {
            string header = @"<head><meta name='viewport' content='width=device-width,initial-scale = 1'>"+
                            @"<link rel='stylesheet' href='https://code.jquery.com/mobile/1.4.5/jquery.mobile-1.4.5.min.css'/>"+
                            "</head><body> ";
            return header;
        }
        private void MakeClientHeader(StringBuilder aMsg, List<Ticket> aItem )
        {
            var tabstyle = @"bgcolor='#ececec' style='font-family:Arial; font-size:15px; color:#000000'";

        }

        public string GetTicketOverviewHTML(DateTime aStart, DateTime aEnd)
        {
            var message = new StringBuilder();
            message.Append(MakeHead());
            message.AppendFormat("<strong style='font-family:Arial; font-size:25px'>Zendesk Overview from {0} to {1}</strong><br /><br />"
                , aStart.Date.ToShortDateString(), aEnd.Date.ToShortDateString());
            message.Append(@"<hr>");
            var zones = DaExportDB.FetchTicketsByDate(aStart, aEnd, 5).OrderByDescending(x=> x.Value.Count());
            foreach (var zone in zones)
            {
                var lstperRegion = zone.Value.GroupBy(x => x.Organisation_region);
                message.AppendFormat(@"<strong style='font-family:Arial; font-size:20px; color:red'>{0} total of {1} tickets</strong><br />", zone.Key.region, zone.Value.Count);
                message.Append(@"<table cellpadding='5' cellspacing='5' width='100%'>");
                var lstperCompany = zone.Value.GroupBy(x => x.organization_name);
                foreach (var item2 in lstperRegion)
                {
                    if (zone.Value.Count > 0)
                    {




                        foreach (var item1 in lstperCompany)
                        {
                            message.Append(item1.Key);
                            var items = zone.Value.OrderBy(x => x.status);
                            var openlst = items.Where(x => x.status == "5");
                            MakeClientHeader(message, zone.Value);
                            //   message.AppendFormat(@"<h3>{0}</h3>");
                            foreach (var item in items.OrderBy(x => x.organization_name))
                            {

                                AddToClient(message, item);

                            }
                            message.Append(@"</table> <br />");
                        }
                    }


                    else
                    {
                        message.AppendFormat(@"<strong style='font-family:Arial; font-size:20px; color:green'>{0}</strong><br />", zone.Key.region);

                    }
                }
               
            }

  
            return message.ToString();
        }


        private void AddToClient(StringBuilder aMsg, Ticket aTicket)
        {
            var tabstyle = "style ='font-family:Arial; font-size:12px; color:#000000;'";
            
                var days = DateTime.Now - aTicket.created;
                aMsg.AppendFormat(@"<tr><td {0} width='40%'>{1}</td><td /><td {0} width='15%'>{2}</td><td {0} width='15%'>{3} days open</td><td {0} width='15%'><a href='{4}' target='_blank'>Link</a></td></tr>", tabstyle,
                    aTicket.subject.Trim(), aTicket.status, Math.Ceiling(days.TotalDays), aTicket.Link);
            
        }








    }
}
