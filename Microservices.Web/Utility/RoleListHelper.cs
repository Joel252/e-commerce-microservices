using Microsoft.AspNetCore.Mvc.Rendering;

namespace Microservices.Web.Utility
{
    public static class RoleListHelper
    {
        // Auxiliary method to populate the role list for dropdowns
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
