
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


        public object InvokeFunction(String UC_ID)
        {
            string methodName = "TestMethod";
            string ClassName = "CommonFunction";
            string[] sParam = {"MODULE1" };
            
            //Class Having the function to trigger
            FunctionTrigger fi = new FunctionTrigger();

            //Get the method information using the method info class
            MethodInfo mi = fi.GetType().GetMethod(methodName);

            //Invoke the method
            // (null- no parameter for the method call
            // or you can pass the array of parameters...)
            //   mi.Invoke(this, null);
          //  return mi.Invoke(this, sParam);
            return mi.Invoke(fi, null);
        }

        public object InvokeSP(String UC_ID)
        {
           
            return "";
        }

    }
}
