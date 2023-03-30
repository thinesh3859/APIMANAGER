using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections;
using System.Data;
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

               // ICollection keys = dr.GetColumnSchema;

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


        public string SelectSingletonStatement(string query, Hashtable input)
        {
            Hashtable ht = new Hashtable();
            List<Hashtable> listht = new List<Hashtable>();
            string output = null;
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
                output = (string)cmd.ExecuteScalar();
              
                conn.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
              
                conn = null;
            }


            return output;
        }

        public Outputenum ExecuteSP(Inputenum ie)
        {
            Outputenum oe = new Outputenum();
            SqlConnection conn = GetConnection();

            conn.Open();
            SqlCommand sql_cmnd = new SqlCommand("PROC_NAME", conn);
            sql_cmnd.CommandType = CommandType.StoredProcedure;
            sql_cmnd.Parameters.AddWithValue("@FIRST_NAME", SqlDbType.NVarChar).Value = "";
            sql_cmnd.Parameters.AddWithValue("@LAST_NAME", SqlDbType.NVarChar).Value = "";
            sql_cmnd.Parameters.AddWithValue("@AGE", SqlDbType.Int).Value = "";
            sql_cmnd.ExecuteNonQuery();

            //output valyes
            int contractID = Convert.ToInt32(sql_cmnd.Parameters["@NewId"].Value);

            conn.Close();

            return oe;

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
