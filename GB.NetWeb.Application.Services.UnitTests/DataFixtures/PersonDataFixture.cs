using GB.NetWeb.Application.Services.Commands.Persons;
using GB.NetWeb.Application.Services.DTOs;
using GB.NetWeb.Application.Services.Interfaces.Repositories;
using GB.NetWeb.Application.Services.Queries.Persons;
using Moq;
using System;
using System.Collections.Generic;

namespace GB.NetWeb.Application.Services.UnitTests.DataFixtures
{
    /// <summary>
    /// Represents a dummy <see cref="IPersonRepository"/> implementation
    /// </summary>
    public sealed class PersonDataFixture : BaseDataFixture<IPersonRepository>
    {
        #region Fields

        private static readonly PersonDto Person = new PersonDto()
        {
            Birthdate = DateTime.UtcNow,
            Firstname = "Firstname",
            Id = 1,
            Lastname = "Lastname"
        };
        private static readonly IEnumerable<PersonDto> Persons = new[] { Person };

        #endregion

        protected override Mock<IPersonRepository> InitializeDummyMock(Mock<IPersonRepository> mock)
        {
            mock.Setup((m) => m.CreateAsync(It.IsAny<CreatePersonCommand>())).ReturnsAsync(true);
            mock.Setup((m) => m.DeleteAsync(It.IsAny<DeletePersonCommand>())).ReturnsAsync(true);
            mock.Setup((m) => m.FilterAsync(It.IsAny<FilterPersonQuery>())).ReturnsAsync(Persons);
            mock.Setup((m) => m.UpdateAsync(It.IsAny<UpdatePersonCommand>())).ReturnsAsync(true);

            return mock;
        }
    }
}
