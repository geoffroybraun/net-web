using GB.NetWeb.Application.Services.Queries.Authentications;

namespace GB.NetWeb.Application.WebPortal.ViewModels.Authentication
{
    /// <summary>
    /// Represents a view model for the <see cref="Controllers.AuthenticationController.Login"/> controller action
    /// </summary>
    public sealed record LoginViewModel
    {
        public AuthenticateUserQuery Query { get; set; }
    }
}
