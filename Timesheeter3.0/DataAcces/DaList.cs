using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheeter3._0.Classes;
using Timesheeter3._0.Classes.tickets;
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
        public static List<Organization> GetOrganizationList()
        {
            String Query = "select * from T_organization";
            Organization O;
            var OrganizationList = new List<Organization>();
            var con = FireBird.Openconnection(FireBird.Connectionstring());

            using (con)
            {
                FbCommand cmd = new FbCommand(Query, con);
                using (FbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        O = new Organization();
                        O.id = (long)reader["f_org_id"];
                        O.name = (string)reader["f_org_name"];

                        if (!string.IsNullOrEmpty((string)reader["f_org_region"]))
                        {
                            var String = (string)reader["f_org_region"];
                            string[] subString = String.Split(',');
                            String = subString[0].Trim();
                            O.region = String;
                        }
                        else
                        {
                            O.region = "X";
                        }


                        //O.region = (string)reader["f_org_region"];
                        //O.created = (DateTime)reader["f_org_created"];
                        OrganizationList.Add(O);
                    }
 
                  
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
                   
                    while (reader.Read())
                    {
                        T = new Ticket();
                        T.id = (long)reader["max_id"];
                      
                        T.created = (DateTime)reader["created"];
                        T.updated = (DateTime)reader["updated"];
                        T.organization_name = (string)reader["org_name"];
                        if (!string.IsNullOrEmpty((string)reader["org_region"]))
                        {
                            var String = (string)reader["org_region"];
                            string[] subString = String.Split(',');
                            String = subString[0].Trim();
                            T.Organisation_region = String;
                        }
                        //T.Organisation_region = (string)reader["org_region"];
                        if (!string.IsNullOrWhiteSpace(reader["subject"].ToString()))
                        {
                            T.subject = (string)reader["subject"];
                        }
                        T.status = (string)reader["status"];
                       // T.assignee_name = (string)reader["user_name"];
                        //T.subject = (string)reader["f_tk_subject"];
                        TicketList.Add(T);







                    }
                    return TicketList;
                }
               
            }
        }
        public static List<Satisfaction> GetSatisfactionList (string Query)
        {
            Satisfaction S;
            var SatisfactionList = new List<Satisfaction>();
            var con = FireBird.Openconnection(FireBird.Connectionstring());
            using (con)
            {
                FbCommand cmd = new FbCommand(Query, con);
                using (FbDataReader reader = cmd.ExecuteReader())
                {
                    S = new Satisfaction();
                    S.id = (long)reader["f_sat_id"];
                    S.score = (int)reader["f_sat_score"];
                    S.comment = (string)reader["f_sat_comment"];
                    S.assignee_id = (long)reader["f_sat_assignee_id"];
                    S.created = (DateTime)reader["f_sat_created"];
                    SatisfactionList.Add(S);
                }
                return SatisfactionList;
            }





            
        }












    }
}
