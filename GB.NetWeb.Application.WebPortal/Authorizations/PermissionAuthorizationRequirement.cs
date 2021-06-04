using Microsoft.AspNetCore.Authorization;
using System;

namespace GB.NetWeb.Application.WebPortal.Authorizations
{
    /// <summary>
    /// Represents an authorization requirement which uses permissions
    /// </summary>
    public sealed class PermissionAuthorizationRequirement : IAuthorizationRequirement
    {
        #region Properties

        public readonly string PermissionName;

        #endregion

        public PermissionAuthorizationRequirement(string permissionName)
        {
            if (string.IsNullOrEmpty(permissionName) || string.IsNullOrWhiteSpace(permissionName))
                throw new ArgumentNullException(nameof(permissionName));

            PermissionName = permissionName;
        }
    }
}
