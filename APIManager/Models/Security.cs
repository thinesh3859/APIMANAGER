namespace APIManager.Models
{
    public class Security
    {

        public bool IsValidIpAddress(string ipAddress)
        {

            string[] IpAddress = { "127.0.0.1", "::1" };
            

         //   return (ipAddress == "127.0.0.1");
            return true;
        }


    }
}
