using FluentAssertions;
using GB.NetWeb.Application.Services.DTOs;
using GB.NetWeb.Application.Services.Handlers.Authentications;
using GB.NetWeb.Application.Services.IntegrationTests.DataFixtures;
using GB.NetWeb.Application.Services.Queries.Authentications;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GB.NetWeb.Application.Services.IntegrationTests.Handlers.Authentications
{
    public sealed class AuthenticateUserHandlerTest : IClassFixture<AuthenticationDataFixture>
    {
        #region Fields

        private static readonly AuthenticateUserQuery Query = new()
        {
            Email = "Email",
            Password = "Password"
        };
        private readonly AuthenticationDataFixture Fixture;

        #endregion

        public AuthenticateUserHandlerTest(AuthenticationDataFixture fixture) => Fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));

        [Fact]
        public async Task Throwing_an_exception_when_executing_a_query_let_it_be_thrown()
        {
            Task<AuthenticationResponseDto> function()
            {
                var handler = new AuthenticateUserHandler(Fixture.Broken);

                return handler.ExecuteAsync(Query);
            }
            var exception = await Assert.ThrowsAsync<NotImplementedException>(function).ConfigureAwait(false);

            exception.Should().NotBeNull();
        }

        [Fact]
        public async Task Not_successfully_executing_a_query_returns_a_default_value()
        {
            var handler = new AuthenticateUserHandler(Fixture.Null);
            var result = await handler.ExecuteAsync(Query).ConfigureAwait(false);

            result.Should().BeNull();
        }
    }
}
