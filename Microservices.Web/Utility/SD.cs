using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;

namespace Microservices.Web.Utility
{
    public static class SD
    {
        public static string CouponAPIBase { get; set; }
        public static string AuthAPIBase { get; set; }
        
        public const string TokenCookie = "JwtToken";

        public enum RoleType
        {
            Admin,
            Customer
        }

        public enum RequestType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}