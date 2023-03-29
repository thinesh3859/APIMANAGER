using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Collections;
using System.Data.Common;
using System.Data.SqlClient;

namespace APIManager.Models
{
    public class MSSQLDBComponent
    {
        public static string conStr = "";

        public  MSSQLDBComponent()
        {
            conStr = "";
        }

        

        public List<Hashtable> SelectStatement(string query,Hashtable input)
        {
            Hashtable ht = new Hashtable();
            List<Hashtable> listht = new List<Hashtable>();
            SqlDataReader dr;
            SqlConnection conn;

            try
            {
                conn = GetConnection();

                SqlCommand cmd = new SqlCommand(query, conn);

                foreach (DictionaryEntry item in input)
                {
                    cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                }

                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ht = new Hashtable();
                    ht.Add("COMPANY_ID", dr["COMPANY_ID"]);
                    ht.Add("ORGANIZATION_NAME", dr["ORGANIZATION_NAME"]);
                    ht.Add("CURRENT_COMPANY", dr["CurrentCompany"]);
                    listht.Add(ht);
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                dr = null;
                conn = null;
            }
         

            return listht;
        }


        private static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection connection = new SqlConnection(conStr);
                return connection;
            }
            catch (Exception e)
            {
               // Console.WriteLine(e);
                throw;
            }
        }
    }
}
