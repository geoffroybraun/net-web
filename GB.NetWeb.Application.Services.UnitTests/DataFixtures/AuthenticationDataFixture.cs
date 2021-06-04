using GB.NetWeb.Application.Services.DTOs;
using GB.NetWeb.Application.Services.Interfaces.Repositories;
using GB.NetWeb.Application.Services.Queries.Authentications;
using Moq;

namespace GB.NetWeb.Application.Services.UnitTests.DataFixtures
{
    /// <summary>
    /// Represents a dummy <see cref="IAuthenticationRepository"/> implementation
    /// </summary>
    public sealed class AuthenticationDataFixture : BaseDataFixture<IAuthenticationRepository>
    {
        #region Fields

        private static readonly AuthenticationResponseDto JwtLoginResponse = new()
        {
            Permissions = new[] { "PermissionA", "PermissionB", "PermissionC" },
            Token = "Token"
        };

        #endregion

        protected override Mock<IAuthenticationRepository> InitializeDummyMock(Mock<IAuthenticationRepository> mock)
        {
            mock.Setup(m => m.LoginAsync(It.IsAny<AuthenticateUserQuery>())).ReturnsAsync(JwtLoginResponse);

            return mock;
        }
    }
}
