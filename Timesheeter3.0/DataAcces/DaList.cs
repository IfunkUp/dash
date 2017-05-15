using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheeter3._0.Classes;

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
                    //





                }
                return OrganizationList;
            }
        }








    }
}
