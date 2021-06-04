using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace GB.NetWeb.Application.WebPortal.Middlewares
{
    /// <summary>
    /// Redirects to the appropriated endpoint based on the response status code
    /// </summary>
    public static class StatusCodePagesMiddleware
    {
        public static Task Handle(StatusCodeContext context)
        {
            var response = context.HttpContext.Response;

            switch (response.StatusCode)
            {
                case (int)HttpStatusCode.Unauthorized:
                    response.Redirect("/");
                    break;
                case (int)HttpStatusCode.NotFound:
                    response.Redirect("/Error/PageNotFound");
                    break;
                default:
                    response.Redirect("/Error");
                    break;
            }

            return Task.CompletedTask;
        }
    }
}
