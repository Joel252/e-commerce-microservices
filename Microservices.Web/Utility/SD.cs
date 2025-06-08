using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;

namespace Microservices.Web.Utility
{
    /// <summary>
    /// Auxiliary class for storing constants.
    /// </summary>
    public static class SD
    {
        // Auxiliary constants for API base URLs
        public static string AuthAPIBase { get; set; }
        public static string CouponAPIBase { get; set; }
        public static string ProductAPIBase { get; set; }

        // Auxiliary constants for cookies
        public const string TokenCookie = "JwtToken";

        // Auxiliary enum for RolesType
        public enum RoleType
        {
            Admin,
            Customer
        }

        // Auxiliary enum for RequestType
        public enum RequestType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}