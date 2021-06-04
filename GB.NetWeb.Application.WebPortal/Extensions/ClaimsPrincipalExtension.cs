using GB.NetWeb.Application.Services.Statics;
using System.Linq;
using System.Security.Claims;

namespace GB.NetWeb.Application.WebPortal.Extensions
{
    /// <summary>
    /// Extends a <see cref="ClaimsPrincipal"/>
    /// </summary>
    public static class ClaimsPrincipalExtension
    {
        /// <summary>
        /// Indicates if the extended <see cref="ClaimsPrincipal"/> contains the requested permission
        /// </summary>
        /// <param name="principal">The extended <see cref="ClaimsPrincipal"/> to check</param>
        /// <param name="permissionName">The permission to look for</param>
        /// <returns>True if the extended <see cref="ClaimsPrincipal"/> contains the requested permission, otherwise false</returns>
        public static bool HasPermission(this ClaimsPrincipal principal, string permissionName)
        {
            if (principal is null || principal.Claims is null)
                return false;

            return principal.Claims.Any((c) => c.Type == AuthorizationClaims.Permission && c.Value == permissionName);
        }
    }
}
