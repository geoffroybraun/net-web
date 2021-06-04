using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Net.Http.Headers;

namespace GB.NetWeb.Application.WebPortal.Middlewares
{
    /// <summary>
    /// Defines the response cache header for static files
    /// </summary>
    public static class StaticFilesMiddleware
    {
        #region Fields

        private const int CacheDurationInSeconds = 60 * 60 * 24;

        #endregion

        public static void Handle(StaticFileResponseContext context)
        {
            context.Context.Response.Headers[HeaderNames.CacheControl] = $"public, max-age={CacheDurationInSeconds}";
        }
    }
}
