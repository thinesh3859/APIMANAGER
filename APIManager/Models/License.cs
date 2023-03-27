using System.Collections;

namespace APIManager.Models
{
    public class License
    {
        public static ArrayList LicenseModule()
        {
            String[] str = { } ;
            ArrayList arrayList = new ArrayList();

            str[0] = "MODULE1";
            str[1] = "10";
            arrayList.Add(str);
            str[0] = "MODULE2";
            str[1] = "8";
            arrayList.Add(str);
            return arrayList;
        }
    }
}
