namespace Microservices.Web.Utility
{
    public class SD
    {
        public static string CouponAPIBase { get; set; }
        public static string AuthAPIBase { get; set; }

        public enum RequestType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
