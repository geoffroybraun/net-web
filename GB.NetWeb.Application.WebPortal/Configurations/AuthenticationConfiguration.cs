using GB.NetWeb.Application.WebPortal.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GB.NetWeb.Application.WebPortal.Configurations
{
    /// <summary>
    /// Configure the authentication for the application
    /// </summary>
    public sealed class AuthenticationConfiguration : IWebPortalConfiguration
    {
        public void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication((options) =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie((options) =>
            {
                options.Cookie.Name = "GB.NetWeb.Session";
                options.Cookie.HttpOnly = true;
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.IsEssential = true;
                options.Cookie.Domain = "localhost";
                options.LoginPath = new("/");
                options.LogoutPath = new("/Authentication/Logout");
                options.AccessDeniedPath = new("/Error/AccessDenied");
            });
        }
    }
}
