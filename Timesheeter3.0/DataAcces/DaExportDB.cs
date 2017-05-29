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
        public static Dictionary<string, List<Ticket>> FetchTicketsByDate(DateTime? aStart, DateTime? aEnd, string Query)
        {
            
            var con = FireBird.Openconnection(FireBird.Connectionstring());
            var companies = new Dictionary<string, List<Ticket>>();
            var tickets = new List<Ticket>();
            var organizations = new List<String>();
            foreach (var item in DaList.GetOrganizationList(Query))
            {
                tickets = DaList.GetTicketList(String.Format(@"select * from t_tickets where f_tk_organization_id = '{0}' and f_tk_created  between '{1}' and '{2}'",item.id, aStart.Value.ToLocalTime(), aEnd.Value.ToLocalTime()));
                
                if (!companies.ContainsKey(item.name))
                {
                    companies.Add(item.name, tickets);
                }
                else
                {
                    companies[item.name].AddRange(tickets);
                }
            }

            return companies;




        }
    }










    }

