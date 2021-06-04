using GB.NetWeb.Application.WebPortal.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GB.NetWeb.Application.WebPortal.Configurations
{
    /// <summary>
    /// Configure the anti-forgery process for the application
    /// </summary>
    public sealed class AntiforgeryConfiguration : IWebPortalConfiguration
    {
        public void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAntiforgery((options) =>
            {
                options.Cookie.Name = $"GB.NetWeb.Antiforgery";
                options.SuppressXFrameOptionsHeader = true;
                options.Cookie.HttpOnly = true;
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.IsEssential = true;
                options.Cookie.Domain = "localhost";
            });
        }
    }
}
