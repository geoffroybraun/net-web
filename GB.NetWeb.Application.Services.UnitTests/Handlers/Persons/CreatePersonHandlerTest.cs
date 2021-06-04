using FluentAssertions;
using GB.NetWeb.Application.Services.Handlers.Persons;
using GB.NetWeb.Application.Services.UnitTests.DataFixtures;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GB.NetWeb.Application.Services.UnitTests.Handlers.Persons
{
    public sealed class CreatePersonHandlerTest : IClassFixture<PersonDataFixture>
    {
        #region Fields

        private readonly PersonDataFixture Fixture;

        #endregion

        public CreatePersonHandlerTest(PersonDataFixture fixture) => Fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));

        [Fact]
        public void Providing_a_null_repository_in_constructor_throws_an_exception()
        {
            static void action() => _ = new CreatePersonHandler(null);
            var exception = Assert.Throws<ArgumentNullException>(action);

            exception.Should().NotBeNull();
        }

        [Fact]
        public async Task Providing_a_null_command_to_run_throws_an_exception()
        {
            Task<bool> function()
            {
                var handler = new CreatePersonHandler(Fixture.Dummy);

                return handler.RunAsync(null);
            }
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(function).ConfigureAwait(false);

            exception.Should().NotBeNull();
        }

        [Fact]
        public async Task Successfully_running_a_command_returns_true()
        {
            var handler = new CreatePersonHandler(Fixture.Dummy);
            var result = await handler.RunAsync(new()).ConfigureAwait(false);

            result.Should().BeTrue();
        }
    }
}
