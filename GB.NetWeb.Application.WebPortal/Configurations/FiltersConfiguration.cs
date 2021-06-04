using GB.NetWeb.Application.WebPortal.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GB.NetWeb.Application.WebPortal.Configurations
{
    /// <summary>
    /// Configure all required filters for the application
    /// </summary>
    public sealed class FiltersConfiguration : IWebPortalConfiguration
    {
        public void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc((options) => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));
        }
    }
}
