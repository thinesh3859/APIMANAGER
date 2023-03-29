namespace APIManager.Models
{
    public class QueryManager
    {
        public static string MSSQL = "MSSQL";
        public static string ORACLE = "ORACLE";
        public static string MYSQL = "MYSQL";


        public static string VALIDATE_UC_ID = "SELECT * FROM TBL_USECASE_MST WHERE UC_ID=@UC_ID AMD MODULE=@MODULE";
    }
}
