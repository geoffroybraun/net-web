using GB.NetWeb.Application.WebPortal.Authorizations;
using GB.NetWeb.Application.WebPortal.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GB.NetWeb.Application.WebPortal.Configurations
{
    /// <summary>
    /// Configure all required authorizations for the application
    /// </summary>
    public sealed class AuthorizationConfiguration : IWebPortalConfiguration
    {
        public void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();
            services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
        }
    }
}
