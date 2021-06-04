using GB.NetWeb.Application.Services.DTOs;
using GB.NetWeb.Application.Services.Interfaces.Repositories;
using GB.NetWeb.Application.Services.Queries.Authentications;
using Moq;
using System;

namespace GB.NetWeb.Application.Services.IntegrationTests.DataFixtures
{
    /// <summary>
    /// Represents a dummy <see cref="IAuthenticationRepository"/> implementation
    /// </summary>
    public sealed class AuthenticationDataFixture : BaseDataFixture<IAuthenticationRepository>
    {
        protected override Mock<IAuthenticationRepository> InitializeBrokenMock(Mock<IAuthenticationRepository> mock)
        {
            mock.Setup((m) => m.LoginAsync(It.IsAny<AuthenticateUserQuery>())).ThrowsAsync(new NotImplementedException());

            return mock;
        }

        protected override Mock<IAuthenticationRepository> InitializeNullMock(Mock<IAuthenticationRepository> mock)
        {
            mock.Setup((m) => m.LoginAsync(It.IsAny<AuthenticateUserQuery>())).ReturnsAsync(default(AuthenticationResponseDto));

            return mock;
        }
    }
}
