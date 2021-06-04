using GB.NetWeb.Application.Services.Resources;
using GB.NetWeb.Application.WebPortal.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System;

namespace GB.NetWeb.Application.WebPortal.Configurations
{
    /// <summary>
    /// Configure resources files for the application
    /// </summary>
    public sealed class LocalizationConfiguration : IWebPortalConfiguration
    {
        public void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddLocalization((options) => options.ResourcesPath = nameof(Resources));
            services.AddMvc().AddDataAnnotationsLocalization((options) => options.DataAnnotationLocalizerProvider = GetStringLocalizer);
        }

        #region Private methods

        private static IStringLocalizer GetStringLocalizer(Type type, IStringLocalizerFactory factory) => factory.Create(nameof(Resources), typeof(Resources).Assembly.FullName);

        #endregion
    }
}
