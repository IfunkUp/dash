using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheeter3._0.Classes;
using Timesheeter3_0.Classes;

namespace Timesheeter3._0.DataAcces
{
    class DaExportDB
    {
        public static DataTable UserTable(string Query)
        {       
            DataTable dt = new DataTable("Users");
            dt.Columns.Add(new DataColumn("id", typeof(Int64)));
            dt.Columns.Add(new DataColumn("name", typeof(string)));
            dt.Columns.Add(new DataColumn("email", typeof(string)));
            dt.Columns.Add(new DataColumn("org_id", typeof(Int64)));
            var con = FireBird.Openconnection(FireBird.Connectionstring());
            using (con)
            {
                FbCommand cmd = new FbCommand(Query, con);
                using (FbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //dt.Rows.Add((long)reader["f_us_id"], (string)reader["f_us_name"], reader["f_us_email"].ToString(), (long)reader["f_org_id"]);
                        DataRow dr = dt.NewRow();
                        dr["id"] = (long)reader["f_us_id"];
                        dr["name"] = (string)reader["f_us_name"];
                        dr["email"] = reader["f_us_email"].ToString();
                        dr["org_id"] = (long)reader["f_org_id"];
                        dt.Rows.Add(dr);
                    }
                }
            }
            return dt;
        }
        public static DataTable OrganizationTable(string Query)
        {
            DataTable dt = new DataTable("Organizations");
            dt.Columns.Add(new DataColumn("id", typeof(Int64)));
            dt.Columns.Add(new DataColumn("name", typeof(string)));
            dt.Columns.Add(new DataColumn("region", typeof(string)));
            var con = FireBird.Openconnection(FireBird.Connectionstring());

            using (con)
            {
                FbCommand cmd = new FbCommand(Query, con);
                using (FbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DataRow dr = dt.NewRow();
                        dr["id"] = (long)reader["f_org_id"];
                        dr["name"] = (string)reader["f_org_name"];
                        dr["region"] = reader["f_org_region"].ToString();
                        dt.Rows.Add(dr);
                    }
                }
            }
            return dt;
        }
        public static Dictionary<Organization, List<Ticket>> FetchTicketsByDate(DateTimeOffset? aStart, DateTimeOffset? aEnd, int status)
        {
            var con = FireBird.Openconnection(FireBird.Connectionstring());
            var companies = new Dictionary<Organization, List<Ticket>>();
            var tickets = new List<Ticket>();
            var organizations = new List<String>();
            foreach (var item in DaList.GetOrganizationList())
            {
                var s = $"select distinct t.f_tk_subject as \"subject\", count(t.f_tk_id) as \"id\", max(t.f_tk_id) as \"max_id\", "+
                    $" t.f_tk_status as \"status\", max(t.f_tk_created) as \"created\",max(t.f_tk_updated) as \"updated\", "+
                    $" max(o.f_org_name) as \"org_name\", " +
                    $" max(o.f_org_region) as \"org_region\" " +
                    $" from t_tickets t" +
                    $" inner join t_organization o on o.f_org_id = t.f_tk_organization_id " +
                    $" where ( t.f_tk_organization_id = '{item.id}') and " +
                    $"((t.f_tk_created between '{aStart.Value.DateTime.Date}' and '{aEnd.Value.DateTime.Date}') or " +
                    $"(t.f_tk_updated between '{aStart.Value.DateTime}' and '{aEnd.Value.DateTime}' ))" +
                    $"group by t.f_tk_subject ,t.f_tk_status";
                    
                    


                tickets = DaList.GetTicketList(s);
                
                if (!companies.ContainsKey(item))
                {
                    companies.Add(item, tickets);
                }
                else
                {
                    companies[item].AddRange(tickets);
                }
            }
            return companies;
        }
    }
    }

