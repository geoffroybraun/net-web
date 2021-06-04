using GB.NetWeb.Application.Services.Statics;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.Text;
using System.Threading.Tasks;

namespace GB.NetWeb.Application.WebPortal.Middlewares
{
    /// <summary>
    /// Configure all required headers for a response
    /// </summary>
    public static class ResponseHeadersMiddleware
    {
        public static async Task Handle(HttpContext context, Func<Task> next)
        {
            context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
            context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
            context.Response.Headers.Add("Referrer-Policy", "strict-origin");
            context.Response.Headers[HeaderNames.ContentSecurityPolicy] = GetCspHeaderContent();
            context.Response.Headers[HeaderNames.XFrameOptions] = "SAMEORIGIN";
            context.Response.Headers[HeaderNames.StrictTransportSecurity] = "max-age=31536000; includeSubDomains";
            context.Response.Headers[HeaderNames.CacheControl] = "no-cache, no-store, must-revalidate";
            context.Response.Headers[HeaderNames.Pragma] = "no-cache";
            context.Response.Headers[HeaderNames.Expires] = "0";

            await next().ConfigureAwait(false);
        }

        #region Private methods

        private static string GetCspHeaderContent()
        {
            var result = new StringBuilder();
            result.Append("base-uri 'self';");
            result.Append("connect-src 'self' https://cdn.datatables.net;");
            result.Append("default-src 'none';");
            result.Append("font-src * data:;");
            result.Append("form-action 'self';");
            result.Append("frame-ancestors 'self';");
            result.Append("img-src 'self' data:;");
            result.Append("object-src 'none';");
            result.Append(GetCspHeaderScriptContent());
            result.Append(GetCspHeaderStyleContent());

            return result.ToString();
        }

        private static string GetCspHeaderScriptContent()
        {
            var result = new StringBuilder();
            result.Append("script-src 'self'");
            result.Append($" {JsFiles.JQuery.Item1}");
            result.Append($" {JsFiles.BootstrapBundle.Item1}");
            result.Append($" {JsFiles.DataTables.Item1}");
            result.Append($" {JsFiles.DataTablesFrenchPlugin.Item1}");
            result.Append($" {JsFiles.BootstrapDatePicker.Item1}");
            result.Append(" 'nonce-TmV0V2ViQ3NwSGVhZGVyTm9uY2U='");
            result.Append(" 'unsafe-eval';");

            return result.ToString();   
        }

        private static string GetCspHeaderStyleContent()
        {
            var result = new StringBuilder();
            result.Append("style-src 'self'");
            result.Append($" {CssFiles.BootstrapBundle.Item1}");
            result.Append($" {CssFiles.Datatables.Item1}");
            result.Append($" {CssFiles.BootstrapDatePicker.Item1}");
            result.Append($" {CssFiles.FontAwesome.Item1}");
            result.Append(" 'unsafe-inline';");

            return result.ToString();
        }

        #endregion
    }
}
