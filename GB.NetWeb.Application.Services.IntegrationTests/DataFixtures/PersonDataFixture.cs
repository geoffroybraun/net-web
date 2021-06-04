using GB.NetWeb.Application.Services.Commands.Persons;
using GB.NetWeb.Application.Services.DTOs;
using GB.NetWeb.Application.Services.Interfaces.Repositories;
using GB.NetWeb.Application.Services.Queries.Persons;
using Moq;
using System;

namespace GB.NetWeb.Application.Services.IntegrationTests.DataFixtures
{
    /// <summary>
    /// Represents a dummy <see cref="IPersonRepository"/> implementation
    /// </summary>
    public sealed class PersonDataFixture : BaseDataFixture<IPersonRepository>
    {
        protected override Mock<IPersonRepository> InitializeBrokenMock(Mock<IPersonRepository> mock)
        {
            mock.Setup((m) => m.CreateAsync(It.IsAny<CreatePersonCommand>())).ThrowsAsync(new NotImplementedException());
            mock.Setup((m) => m.DeleteAsync(It.IsAny<DeletePersonCommand>())).ThrowsAsync(new NotImplementedException());
            mock.Setup((m) => m.FilterAsync(It.IsAny<FilterPersonQuery>())).ThrowsAsync(new NotImplementedException());
            mock.Setup((m) => m.UpdateAsync(It.IsAny<UpdatePersonCommand>())).ThrowsAsync(new NotImplementedException());

            return mock;
        }

        protected override Mock<IPersonRepository> InitializeNullMock(Mock<IPersonRepository> mock)
        {
            mock.Setup((m) => m.CreateAsync(It.IsAny<CreatePersonCommand>())).ReturnsAsync(false);
            mock.Setup((m) => m.DeleteAsync(It.IsAny<DeletePersonCommand>())).ReturnsAsync(false);
            mock.Setup((m) => m.FilterAsync(It.IsAny<FilterPersonQuery>())).ReturnsAsync(default(PersonDto[]));
            mock.Setup((m) => m.UpdateAsync(It.IsAny<UpdatePersonCommand>())).ReturnsAsync(false);

            return mock;
        }
    }
}
