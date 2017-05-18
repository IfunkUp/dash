using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheeter3._0.Classes;
using Timesheeter3_0.Classes;

namespace Timesheeter3._0.DataAcces
{
    class DaList
    {

        



        public static List<User> GetUserList(string Query)
        {
            User U;
            var Userlist = new List<User>();
            var con = FireBird.Openconnection(FireBird.Connectionstring());
            
            using (con)
            {
                FbCommand cmd = new FbCommand(Query, con);

                using (FbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        U = new User();
                        U.id = (long)reader["f_us_id"];
                        U.name = (string) reader["f_us_name"];
                        U.mail = reader["f_us_email"].ToString();
                        U.org_id = (long)reader["f_org_id"];
                        U.phone = reader["f_us_phone"].ToString();
                        U.role = reader["f_us_role"].ToString();
                        Userlist.Add(U);
                    }
                    return Userlist;
                }
            }


        }
        public static List<Organization> GetOrganizationList(string Query)
        {
            Organization O;
            var OrganizationList = new List<Organization>();
            var con = FireBird.Openconnection(FireBird.Connectionstring());

            using (con)
            {
                FbCommand cmd = new FbCommand(Query, con);
                using (FbDataReader reader = cmd.ExecuteReader())
                {
                    //hier nog de organisatie implementeren
                    O = new Organization();
                    O.id = (long)reader["f_org_id"];
                    O.name = (string)reader["f_org_name"];
                    O.region = (string)reader["f_org_region"];
                    O.created = (DateTime)reader["f_org_created"];
                    OrganizationList.Add(O);
                }
                return OrganizationList;
            }
        }
        public static List<Ticket> GetTicketList(string Query)
        {
            Ticket T;
            var TicketList = new List<Ticket>();
            var con = FireBird.Openconnection(FireBird.Connectionstring());
            using (con)
            {
                FbCommand cmd = new FbCommand(Query, con);
                using (FbDataReader reader = cmd.ExecuteReader())
                {
                    T = new Ticket();
                    T.id = (long)reader["f_tk_id"];
                    T.assigneeId = (long)reader["f_tk_ass_id"];
                    T.created = (DateTime)reader["f_tk_created"];
                    T.updated = (DateTime)reader["f_tk_updated"];
                    T.subject = (string)reader["f_tk_subject"];
                    

                    TicketList.Add(T);
                }
                return TicketList;
            }
        }












    }
}
