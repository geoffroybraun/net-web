using FluentAssertions;
using GB.NetWeb.Application.Services.Handlers.Persons;
using GB.NetWeb.Application.Services.IntegrationTests.DataFixtures;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GB.NetWeb.Application.Services.IntegrationTests.Handlers.Persons
{
    public sealed class DeletePersonHandlerTest : IClassFixture<PersonDataFixture>
    {
        #region Fields

        private readonly PersonDataFixture Fixture;

        #endregion

        public DeletePersonHandlerTest(PersonDataFixture fixture) => Fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));

        [Fact]
        public async Task Throwing_an_exception_when_running_a_command_let_it_be_thrown()
        {
            Task<bool> function()
            {
                var handler = new DeletePersonHander(Fixture.Broken);

                return handler.RunAsync(new());
            }
            var exception = await Assert.ThrowsAsync<NotImplementedException>(function).ConfigureAwait(false);

            exception.Should().NotBeNull();
        }

        [Fact]
        public async Task Not_successfully_running_a_command_returns_false()
        {
            var handler = new DeletePersonHander(Fixture.Null);
            var result = await handler.RunAsync(new()).ConfigureAwait(false);

            result.Should().BeFalse();
        }
    }
}
