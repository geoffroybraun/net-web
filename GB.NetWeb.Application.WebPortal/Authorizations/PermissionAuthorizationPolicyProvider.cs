using GB.NetWeb.Application.Services.Statics;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace GB.NetWeb.Application.WebPortal.Authorizations
{
    /// <summary>
    /// Represents a policy provider which uses permissions
    /// </summary>
    public sealed class PermissionAuthorizationPolicyProvider : IAuthorizationPolicyProvider
    {
        #region Fields

        private const string Scheme = CookieAuthenticationDefaults.AuthenticationScheme;

        #endregion

        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            var policy = new AuthorizationPolicyBuilder(Scheme).RequireAuthenticatedUser();

            return Task.FromResult(policy.Build());
        }

        public Task<AuthorizationPolicy> GetFallbackPolicyAsync() => Task.FromResult<AuthorizationPolicy>(null);

        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            if (!policyName.StartsWith(AuthorizationClaims.Permission))
                return Task.FromResult<AuthorizationPolicy>(null);

            var permissionName = policyName.Replace(AuthorizationClaims.Permission, string.Empty);
            var policy = new AuthorizationPolicyBuilder(Scheme);
            policy.AddRequirements(new PermissionAuthorizationRequirement(permissionName));

            return Task.FromResult(policy.Build());
        }
    }
}
