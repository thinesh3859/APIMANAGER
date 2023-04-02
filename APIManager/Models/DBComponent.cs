using System.Collections;
using System.Reflection.Metadata;

namespace APIManager.Models
{
    public class DBComponent
    {
        public List< Hashtable> SelectStatement(string query, Hashtable ht, string DBServer,Inputenum ie)
        {
           // Hashtable ht = new Hashtable();
            List< Hashtable> listht = new List< Hashtable>();


            switch (DBServer)
            {
                case "MSSQL":
                    MSSQLDBComponent msql = new MSSQLDBComponent();
                    listht = msql.SelectStatement(query, ht,ie);
                    msql = null;
                    break;
                case "ORACLE":
                    break;
             
            }
            return listht;
        }

        public string SelectSingletonStatement(string query,Hashtable ht, string DBServer,Inputenum ie)
        {
           // Hashtable ht = new Hashtable();
            List<Hashtable> listht = new List<Hashtable>();
            string output = null;

            switch (DBServer)
            {
                case "MSSQL":
                    MSSQLDBComponent msql = new MSSQLDBComponent();
                    output = msql.SelectSingletonStatement(query, ht,ie);
                    msql = null;
                    break;
                case "ORACLE":
                    break;

            }
            return output;
        }


        public Outputenum ExecuteSP(Inputenum ie, string DBServer)
        {

            Outputenum oe = new Outputenum();

            switch (DBServer)
            {
                case "MSSQL":
                    MSSQLDBComponent msql = new MSSQLDBComponent();
                    oe = msql.ExecuteSP(ie);
                    msql = null;
                    break;
                case "ORACLE":
                    break;

            }

            return oe;
        }

    }
}
