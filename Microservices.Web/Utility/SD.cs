namespace Microservices.Web.Utility
{
    /// <summary>
    /// Auxiliary class for storing constants.
    /// </summary>
    public static class SD
    {
        // Auxiliary constants for API base URLs
        public static string AuthApiBase { get; set; } = string.Empty;
        public static string CouponApiBase { get; set; } = string.Empty;
        public static string ProductApiBase { get; set; } = string.Empty;

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
            Get,
            Post,
            Put,
            Delete
        }
    }
}