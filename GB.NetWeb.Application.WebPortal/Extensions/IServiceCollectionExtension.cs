using GB.NetWeb.Application.WebPortal.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace GB.NetWeb.Application.WebPortal.Extensions
{
    /// <summary>
    /// Extends a <see cref="IServiceCollection"/> implementation
    /// </summary>
    public static class IServiceCollectionExtension
    {
        /// <summary>
        /// Look for every <see cref="IWebPortalConfiguration"/> interface implementation within the assembly to call them
        /// </summary>
        /// <param name="services">The extended <see cref="IServiceCollection"/> implementation</param>
        /// <param name="configuration">The current <see cref="IConfiguration"/> implemetation</param>
        public static void ConfigureWebPortal(this IServiceCollection services, IConfiguration configuration)
        {
            var webPortalConfigurations = typeof(Startup).Assembly.DefinedTypes
                .Where((dt) => !dt.IsInterface && !dt.IsAbstract && dt.ImplementedInterfaces.Contains(typeof(IWebPortalConfiguration)))
                .Select(Activator.CreateInstance)
                .Cast<IWebPortalConfiguration>();

            foreach (var webPortalConfiguration in webPortalConfigurations)
                webPortalConfiguration.Configure(services, configuration);
        }
    }
}
