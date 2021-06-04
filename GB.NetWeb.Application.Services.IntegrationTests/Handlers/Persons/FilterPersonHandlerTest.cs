using FluentAssertions;
using GB.NetWeb.Application.Services.DTOs;
using GB.NetWeb.Application.Services.Handlers.Persons;
using GB.NetWeb.Application.Services.IntegrationTests.DataFixtures;
using GB.NetWeb.Application.Services.Queries.Persons;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace GB.NetWeb.Application.Services.IntegrationTests.Handlers.Persons
{
    public sealed class FilterPersonHandlerTest : IClassFixture<PersonDataFixture>
    {
        #region Fields

        private static readonly FilterPersonQuery Query = new();
        private readonly PersonDataFixture Fixture;

        #endregion

        public FilterPersonHandlerTest(PersonDataFixture fixture) => Fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));

        [Fact]
        public async Task Throwing_an_exception_when_executing_a_query_let_it_be_thrown()
        {
            Task<IEnumerable<PersonDto>> function()
            {
                var handler = new FilterPersonHandler(Fixture.Broken);

                return handler.ExecuteAsync(Query);
            }
            var exception = await Assert.ThrowsAsync<NotImplementedException>(function).ConfigureAwait(false);

            exception.Should().NotBeNull();
        }

        [Fact]
        public async Task Not_successfully_executing_a_query_returns_a_default_value()
        {
            var handler = new FilterPersonHandler(Fixture.Null);
            var result = await handler.ExecuteAsync(Query).ConfigureAwait(false);

            result.Should().BeNull();
        }
    }
}
