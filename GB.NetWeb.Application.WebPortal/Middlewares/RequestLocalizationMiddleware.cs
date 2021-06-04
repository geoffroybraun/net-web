using Microsoft.AspNetCore.Builder;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace GB.NetWeb.Application.WebPortal.Middlewares
{
    /// <summary>
    /// COnfigure all available cultures for translations
    /// </summary>
    public static class RequestLocalizationMiddleware
    {
        public static void Handle(RequestLocalizationOptions options)
        {
            var cultures = new List<CultureInfo>()
            {
                new CultureInfo("en-US"),
                new CultureInfo("fr-FR"),
            };
            options.ApplyCurrentCultureToResponseHeaders = true;
            options.DefaultRequestCulture = new(cultures.First());
            options.SupportedCultures = cultures;
            options.SupportedUICultures = cultures;
        }
    }
}
