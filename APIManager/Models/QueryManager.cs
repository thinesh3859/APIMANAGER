namespace APIManager.Models
{
    public class QueryManager
    {
        public static string MSSQL = "MSSQL";
        public static string ORACLE = "ORACLE";
        public static string MYSQL = "MYSQL";


        public static string VALIDATE_UC_ID = "SELECT count(1) FROM TBL_USECASE_MST WHERE UC_ID=@UC_ID AMD MODULE=@MODULE";
        public static string GET_UC_METHOD_NAME = "select IS_METHOD,METHOD_NAME FROM TBL_USECASE_MST WHERE UC_ID=@UC_ID AMD MODULE=@MODULE";
        public static string GET_UC_SP_NAME = "select IS_SP,SP_NAME FROM TBL_USECASE_MST WHERE UC_ID=@UC_ID AMD MODULE=@MODULE";


    }
}
