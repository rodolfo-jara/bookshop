namespace Bookshop.Web.Utility
{
    public class SD
    {

        //ALMACENA LA URL DE APICPONES
        public static string CuponApiBase { get; set; }
        public static string ProductApiBase { get; set; }
        public static string ShoppinCartApiBase { get; set; }
        public static string OrderApiBase { get; set; }
        //ALMACENA LA URL DE AUTH
        public static string AuthAPIBase { get; set; }
        public const string RolAdmin = "ADMIN";
        public const string RolCustomer = "CUSTOMER";
        public const string TokenCookie = "JwtToken";
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
