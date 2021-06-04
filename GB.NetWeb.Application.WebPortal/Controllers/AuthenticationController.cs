using GB.NetWeb.Application.Services.DTOs;
using GB.NetWeb.Application.Services.Queries.Authentications;
using GB.NetWeb.Application.Services.Statics;
using GB.NetWeb.Application.WebPortal.Authorizations;
using GB.NetWeb.Application.WebPortal.Extensions;
using GB.NetWeb.Application.WebPortal.ViewModels.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GB.NetWeb.Application.WebPortal.Controllers
{
    /// <summary>
    /// Represents a controller which executes an action related to the authentication process
    /// </summary>
    [Permission(Permissions.AccessApplication)]
    public sealed class AuthenticationController : Controller
    {
        #region Fields

        private readonly IMediator Mediator;

        #endregion

        public AuthenticationController(IMediator mediator) => Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [AcceptVerbs("GET", "POST")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AuthenticateUserQuery query = null)
        {
            if (query is null)
                throw new ArgumentNullException(nameof(query));

            if (ModelState.IsValid)
            {
                var response = await Mediator.ExecuteAsync(query, ModelState).ConfigureAwait(true);

                if (response.HasSucceed)
                {
                    await SavePermissionsInCookieAsync(response.Result);

                    return RedirectToRoute(new { controller = "Person", action = "Index" });
                }
            }

            return View(new LoginViewModel() { Query = query ?? new() });
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).ConfigureAwait(true);

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        #region Private methods

        private async Task SavePermissionsInCookieAsync(AuthenticationResponseDto response)
        {
            var principal = GetPrincipal(response);
            var authenticationProperties = new AuthenticationProperties()
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(15),
                IsPersistent = true,
                IssuedUtc = DateTime.UtcNow
            };
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties).ConfigureAwait(true);
        }

        private static ClaimsPrincipal GetPrincipal(AuthenticationResponseDto response)
        {
            var claims = GetClaims(response);
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            return new ClaimsPrincipal(identity);
        }

        private static IEnumerable<Claim> GetClaims(AuthenticationResponseDto response)
        {
            var permissionClaims = response.Permissions.Select((p) => new Claim(AuthorizationClaims.Permission, p));
            var claims = new List<Claim>(permissionClaims)
            {
                new Claim(AuthorizationClaims.JwtToken, response.Token)
            };

            return claims;
        }

        #endregion
    }
}
