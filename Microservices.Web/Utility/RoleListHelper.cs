using Microsoft.AspNetCore.Mvc.Rendering;

namespace Microservices.Web.Utility
{
    /// <summary>
    /// Auxiliary class for populating role lists.
    /// </summary>
    public static class RoleListHelper
    {
        // Method to return a list of roles mapped to SelectListItem objects
        public static IEnumerable<SelectListItem> GetRoleList()
        {
            return Enum.GetNames(typeof(SD.RoleType))
                .Select(role => new SelectListItem
                {
                    Text = role,
                    Value = role
                });
        }
    }
}