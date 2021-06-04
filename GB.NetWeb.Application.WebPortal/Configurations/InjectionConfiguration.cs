using GB.NetWeb.Application.Services.Interfaces.Repositories;
using GB.NetWeb.Application.Services.Repositories;
using GB.NetWeb.Application.Services.Resources;
using GB.NetWeb.Application.Services.Statics;
using GB.NetWeb.Application.WebPortal.Interfaces;
using GB.NetWeb.Application.WebPortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Net.Http.Headers;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace GB.NetWeb.Application.WebPortal.Configurations
{
    /// <summary>
    /// Configure all required interfaces and classes for dependency injection
    /// </summary>
    public sealed class InjectionConfiguration : IWebPortalConfiguration
    {
        #region Fields

        private const string DEFAULT_HTTP_CLIENT_NAME = "defaultHttpClient";

        #endregion

        public void Configure(IServiceCollection services, IConfiguration configuration)
        {
            var taskHandlerConfiguration = new TaskHandlerConfiguration();
            configuration.Bind(nameof(TaskHandlerConfiguration), taskHandlerConfiguration);

            services.AddHttpContextAccessor();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();

            services.AddHttpClient(DEFAULT_HTTP_CLIENT_NAME, (provider, client) => InitializeHttpClient(provider, client, configuration))
                .AddPolicyHandler(GetRetryPolicy(taskHandlerConfiguration))
                .AddPolicyHandler(GetCircuitBreakPolicy(taskHandlerConfiguration));
            services.AddScoped(GetHttpClient);

            services.AddSingleton(GetStringLocalizer);
        }

        #region Private methods

        private static void InitializeHttpClient(IServiceProvider provider, HttpClient client, IConfiguration configuration)
        {
            var httpClientConfiguration = new HttpClientConfiguration();
            configuration.Bind(nameof(HttpClientConfiguration), httpClientConfiguration);

            client.BaseAddress = new(httpClientConfiguration.BaseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(httpClientConfiguration.AcceptHeaderValue));

            var accessor = provider.GetRequiredService<IHttpContextAccessor>();
            var jwtToken = accessor.HttpContext.User?.Claims.SingleOrDefault((c) => c.Type == AuthorizationClaims.JwtToken);

            if (jwtToken is not null && !string.IsNullOrEmpty(jwtToken.Value))
            {
                client.DefaultRequestHeaders.Authorization = null;
                client.DefaultRequestHeaders.Add(HeaderNames.Authorization, $"Bearer {jwtToken.Value}");
            }
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(TaskHandlerConfiguration configuration)
        {
            static TimeSpan retryAttemptFunction(int retryAttempt) => TimeSpan.FromMilliseconds(Math.Pow(2, retryAttempt));

            return HttpPolicyExtensions.HandleTransientHttpError().WaitAndRetryAsync(configuration.MaxRetriesCount, retryAttemptFunction);
        }

        private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakPolicy(TaskHandlerConfiguration configuration)
        {
            var timeBetweenExceptionsTimeSpan = TimeSpan.FromMilliseconds(configuration.TimeBetweenBreaksInMilliseconds);

            return HttpPolicyExtensions.HandleTransientHttpError().CircuitBreakerAsync(configuration.MaxExceptionsCount, timeBetweenExceptionsTimeSpan);
        }

        private static HttpClient GetHttpClient(IServiceProvider provider)
        {
            var factory = provider.GetRequiredService<IHttpClientFactory>();

            return factory.CreateClient(DEFAULT_HTTP_CLIENT_NAME);
        }

        private static IStringLocalizer GetStringLocalizer(IServiceProvider provider)
        {
            var factory = provider.GetRequiredService<IStringLocalizerFactory>();
            var localizer = factory.Create(nameof(Resources), typeof(Resources).Assembly.FullName);

            return localizer;
        }

        #endregion
    }
}
