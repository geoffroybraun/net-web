using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GB.NetWeb.Application.WebPortal.Controllers
{
    /// <summary>
    /// Represents the main entrypoint of the application
    /// </summary>
    [AllowAnonymous]
    public sealed class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToRoute(new { controller = "Person", action = "Index" });

            return RedirectToRoute(new { controller = "Authentication", action = "Login" });
        }
    }
}
