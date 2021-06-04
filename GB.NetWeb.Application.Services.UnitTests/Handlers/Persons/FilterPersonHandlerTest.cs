using FluentAssertions;
using GB.NetWeb.Application.Services.DTOs;
using GB.NetWeb.Application.Services.Handlers.Persons;
using GB.NetWeb.Application.Services.UnitTests.DataFixtures;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace GB.NetWeb.Application.Services.UnitTests.Handlers.Persons
{
    public sealed class FilterPersonHandlerTest : IClassFixture<PersonDataFixture>
    {
        #region Fields

        private readonly PersonDataFixture Fixture;

        #endregion

        public FilterPersonHandlerTest(PersonDataFixture fixture) => Fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));

        [Fact]
        public void Providing_a_null_repository_in_constructor_throws_an_exception()
        {
            static void action() => _ = new FilterPersonHandler(null);
            var exception = Assert.Throws<ArgumentNullException>(action);

            exception.Should().NotBeNull();
        }

        [Fact]
        public async Task Providing_a_null_query_to_execute_throws_an_exception()
        {
            Task<IEnumerable<PersonDto>> function()
            {
                var handler = new FilterPersonHandler(Fixture.Dummy);

                return handler.ExecuteAsync(null);
            }
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(function).ConfigureAwait(false);

            exception.Should().NotBeNull();
        }

        [Fact]
        public async Task Successfully_executing_a_query_returns_the_expected_result()
        {
            var handler = new FilterPersonHandler(Fixture.Dummy);
            var result = await handler.ExecuteAsync(new()).ConfigureAwait(false);

            result.Should().NotBeNull().And.NotBeEmpty();
        }
    }
}
