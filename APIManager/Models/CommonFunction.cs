
using System.Collections;
using System.Reflection;

namespace APIManager.Models
{
    public class CommonFunction
    {
        public string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes); // .NET 5 +

                // Convert the byte array to hexadecimal string prior to .NET 5
                // StringBuilder sb = new System.Text.StringBuilder();
                // for (int i = 0; i < hashBytes.Length; i++)
                // {
                //     sb.Append(hashBytes[i].ToString("X2"));
                // }
                // return sb.ToString();
            }
        }


        public Outputenum InvokeFunction(string methodname)
        {
            string methodName = methodname;
            string ClassName = "CommonFunction";
           
            //Class Having the function to trigger
            FunctionTrigger fi = new FunctionTrigger();

            //Get the method information using the method info class
            MethodInfo mi = fi.GetType().GetMethod(methodName);

            //Invoke the method
            // (null- no parameter for the method call
            // or you can pass the array of parameters...)
            //   mi.Invoke(this, null);
          //  return mi.Invoke(this, sParam);
            return (Outputenum)mi.Invoke(fi, null);
        }

        public object InvokeSP(String UC_ID)
        {
           
            return "";
        }

        public Outputenum ValidateRequest(Inputenum ie)
        {
            Outputenum oe = new Outputenum();

            if (ie.UC_ID == "" || ie.UC_ID == null)
            {
                oe.STATUS = "F";
                oe.StatusMessage = "UC_ID can't be empty";
                oe.output = new System.Text.Json.Nodes.JsonArray();
            }
            else if (ie.Module == "" || ie.Module == null)
            {
                oe.STATUS = "F";
                oe.StatusMessage = "Module can't be empty";
                oe.output = new System.Text.Json.Nodes.JsonArray();
            }
            else if (!ValidateUC_ID(ie.UC_ID,ie.Module))
            {
                oe.STATUS = "F";
                oe.StatusMessage = "Invalid UC_ID";
                oe.output = new System.Text.Json.Nodes.JsonArray();
            }



            return oe;
        }


        public bool ValidateUC_ID(string uc_id, string module)
        {
            DBComponent db = new DBComponent();
            List<Hashtable> lht = new List<Hashtable>();
            string  uc_count = null;
             uc_count  = db.SelectSingletonStatement(QueryManager.VALIDATE_UC_ID, GetUsecaseDatabase(uc_id, module));

            if (uc_count != null)
                if (int.Parse(uc_count) == 1)
                    return true;
                else
                    return false;
            else
                return false;
        }

        public string GetUsecaseDatabase(string uc_id, string module)
        {

            if (uc_id == "UC_001" && module == "M001")
                return QueryManager.MSSQL;
            else
                return QueryManager.MSSQL;
        }

        public Outputenum InvokeRequest(Inputenum ie)
        {
            Outputenum oe = new Outputenum();
            DBComponent db = new DBComponent();
            List<Hashtable> lht = new List<Hashtable>();
            Hashtable ht = new Hashtable();
            lht = db.SelectStatement(QueryManager.GET_UC_METHOD_NAME, GetUsecaseDatabase(ie.UC_ID, ie.Module)); ;
            ht = lht[0];

            if (ht["IS_METHOD"] == "Y")
            {
                string sMethodName = ht["METHOD_NAME"].ToString();
               oe = InvokeFunction(sMethodName);
            }
            else
            {
                lht = db.SelectStatement(QueryManager.GET_UC_SP_NAME, GetUsecaseDatabase(ie.UC_ID, ie.Module));
            }
            

            oe.STATUS = "S";
            oe.StatusMessage = "Success";
            return oe;

        }


    }
}
