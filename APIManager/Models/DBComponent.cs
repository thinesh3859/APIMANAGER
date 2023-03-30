using System.Collections;
using System.Reflection.Metadata;

namespace APIManager.Models
{
    public class DBComponent
    {
        public List< Hashtable> SelectStatement(string query,string DBServer)
        {
            Hashtable ht = new Hashtable();
            List< Hashtable> listht = new List< Hashtable>();


            switch (DBServer)
            {
                case "MSSQL":
                    MSSQLDBComponent msql = new MSSQLDBComponent();
                    listht = msql.SelectStatement("", ht);
                    msql = null;
                    break;
                case "ORACLE":
                    break;
             
            }

           
         


            return listht;
        }

        public string SelectSingletonStatement(string query, string DBServer)
        {
            Hashtable ht = new Hashtable();
            List<Hashtable> listht = new List<Hashtable>();
            string output = null;

            switch (DBServer)
            {
                case "MSSQL":
                    MSSQLDBComponent msql = new MSSQLDBComponent();
                    output = msql.SelectSingletonStatement("", ht);
                    msql = null;
                    break;
                case "ORACLE":
                    break;

            }





            return output;
        }

    }
}
