using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;

namespace Microservices.Web.Utility
{
    public class SD
    {
        public static string CouponAPIBase { get; set; }
        public static string AuthAPIBase { get; set; }

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