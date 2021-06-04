using FluentAssertions;
using GB.NetWeb.Application.Services.DTOs;
using GB.NetWeb.Application.Services.Handlers.Authentications;
using GB.NetWeb.Application.Services.Queries.Authentications;
using GB.NetWeb.Application.Services.UnitTests.DataFixtures;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GB.NetWeb.Application.Services.UnitTests.Handlers.Authentications
{
    public sealed class AuthenticateUserHandlerTest : IClassFixture<AuthenticationDataFixture>
    {
        #region Fields

        private const string Email = "Email";
        private const string Password = "Password";
        private readonly AuthenticationDataFixture Fixture;

        #endregion

        public AuthenticateUserHandlerTest(AuthenticationDataFixture fixture) => Fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));

        [Fact]
        public void Providing_a_null_repository_in_constructor_throws_an_exception()
        {
            static void action() => _ = new AuthenticateUserHandler(null);
            var exception = Assert.Throws<ArgumentNullException>(action);

            exception.Should().NotBeNull();
        }

        [Fact]
        public async Task Providing_a_null_query_to_execute_throws_an_exception()
        {
            Task<AuthenticationResponseDto> function()
            {
                var handler = new AuthenticateUserHandler(Fixture.Dummy);

                return handler.ExecuteAsync(null);
            }
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(function).ConfigureAwait(false);

            exception.Should().NotBeNull();
        }

        [Theory]
        [InlineData(null, Password)]
        [InlineData("", Password)]
        [InlineData(" ", Password)]
        [InlineData(Email, null)]
        [InlineData(Email, "")]
        [InlineData(Email, " ")]
        [InlineData(Email, Password)]
        public async Task Successfully_executing_a_query_regardless_of_its_properties_returns_the_expected_result(string email, string password)
        {
            var query = new AuthenticateUserQuery() { Email = email, Password = password };
            var handler = new AuthenticateUserHandler(Fixture.Dummy);
            var result = await handler.ExecuteAsync(query).ConfigureAwait(false);

            result.Should().NotBeNull();
        }
    }
}
