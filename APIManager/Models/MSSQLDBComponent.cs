using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace APIManager.Models
{
    public class MSSQLDBComponent
    {
       // public static string conStr = "Server=localhost;Database=APIHome;User ID=sa;Password=Sun$h!n3EW8aj8Wm;Trusted_Connection=True;MultipleActiveResultSets=true";
        public static string HomeconStr = "Server=localhost;Database=APIHome;User ID=sa;Password=Sun$h!n3EW8aj8Wm;Trusted_Connection=True;MultipleActiveResultSets=true";

        //public  MSSQLDBComponent()
        //{
        //    conStr = "";
        //}

        

        public List<Hashtable> SelectStatement(string query,Hashtable input,DBServerenum de)
        {
            Hashtable ht = new Hashtable();
            List<Hashtable> listht = new List<Hashtable>();
            SqlDataReader dr;
            SqlConnection conn;

            try
            {
                conn = GetConnection(de);

                SqlCommand cmd = new SqlCommand(query, conn);

                foreach (DictionaryEntry item in input)
                {
                    cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                }

                conn.Open();
                dr = cmd.ExecuteReader();

                var columns = Enumerable.Range(0, dr.FieldCount).Select(dr.GetName).ToList();

                while (dr.Read())
                {
                    ht = new Hashtable();

                    foreach (var columnname in columns)
                    {
                        ht.Add(columnname.ToString(), dr[columnname.ToString()]);
                    }

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


        public string SelectSingletonStatement(string query, Hashtable input,DBServerenum de)
        {
            Hashtable ht = new Hashtable();
            List<Hashtable> listht = new List<Hashtable>();
            string output = null;
            SqlConnection conn;

            try
            {
                conn = GetConnection(de);

                SqlCommand cmd = new SqlCommand(query, conn);

                foreach (DictionaryEntry item in input)
                {
                    cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                }

                conn.Open();
                output = cmd.ExecuteScalar().ToString();
              
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

        public Outputenum ExecuteSP(DBServerenum de)
        {
            Outputenum oe = new Outputenum();
            SqlConnection conn = GetConnection(de);

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

        private static SqlConnection GetConnection(DBServerenum de)
        {
            try
            {
               
                string conStr = "Server="+de.HOST_NAME.ToString()+";Database="+ de.DBNAME.ToString() +";User ID="+ de.USER_NAME.ToString() +";Password="+de.PASSWORD.ToString()+";Trusted_Connection=True;MultipleActiveResultSets=true";
                SqlConnection dbconnection = new SqlConnection(conStr);

                return dbconnection;
            }
            catch (Exception e)
            {
               // Console.WriteLine(e);
                throw;
            }
        }
    }
}
