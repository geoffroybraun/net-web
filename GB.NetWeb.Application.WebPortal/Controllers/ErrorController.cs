using GB.NetWeb.Application.Services.Statics;
using GB.NetWeb.Application.WebPortal.Authorizations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GB.NetWeb.Application.WebPortal.Controllers
{
    /// <summary>
    /// Regroups all error views of the application
    /// </summary>
    [Permission(Permissions.AccessApplication)]
    public class ErrorController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index() => View();

        [HttpGet]
        [AllowAnonymous]
        public IActionResult PageNotFound() => View();

        [HttpGet]
        public IActionResult AccessDenied() => View();
    }
}
