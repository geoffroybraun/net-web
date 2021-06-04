using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GB.NetWeb.Application.WebPortal.Interfaces
{
    /// <summary>
    /// Represents a confguration of the Web portal
    /// </summary>
    public interface IWebPortalConfiguration
    {
        /// <summary>
        /// Uses both provided <see cref="IServiceCollection"/> and <see cref="IConfiguration"/> implementation to configure the Web API
        /// </summary>
        /// <param name="services">The current <see cref="IServiceCollection"/> implementation</param>
        /// <param name="configuration">The current <see cref="IConfiguration"/> implementation</param>
        void Configure(IServiceCollection services, IConfiguration configuration);
    }
}
