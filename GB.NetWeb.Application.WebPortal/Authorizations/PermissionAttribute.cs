using GB.NetWeb.Application.Services.Statics;
using Microsoft.AspNetCore.Authorization;
using System;

namespace GB.NetWeb.Application.WebPortal.Authorizations
{
    /// <summary>
    /// Represents an authorization attribute which uses permissions
    /// </summary>
    public sealed class PermissionAttribute : AuthorizeAttribute
    {
        public PermissionAttribute(string permissionName)
        {
            if (string.IsNullOrEmpty(permissionName) || string.IsNullOrWhiteSpace(permissionName))
                throw new ArgumentNullException(permissionName);

            Policy = $"{AuthorizationClaims.Permission}{permissionName}";
        }
    }
}
