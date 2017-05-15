using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;

namespace Timesheeter3._0.Classes
{
    public static class FireBird
    {
        #region Connection
        // credentials of the database
        public static string Connectionstring()
        {
            FbConnectionStringBuilder csb = new FbConnectionStringBuilder();
            csb.Database = "localhost";
            csb.Port = 3050;
            csb.Database = @"C:\Users\steve\OneDrive\dag\stage\stageproject\ZENDESK.FDB"; //book
            csb.UserID = "SYSDBA";
            csb.Password = "masterkey";
            csb.ServerType = FbServerType.Default;
            return csb.ToString();
        }

        //establish connection with the database
        public static FbConnection Openconnection(string connectionstring)
        {
            FbConnection con = null;
            try
            {
                con = new FbConnection(connectionstring);
                con.Open();
                return con;
            }
            catch (Exception e)
            {
                if (con != null)
                {
                    Console.WriteLine(e);
                    con.Dispose();
                }
                throw;
            }
        }
        #endregion

        #region getLists






        #endregion


    }
}
