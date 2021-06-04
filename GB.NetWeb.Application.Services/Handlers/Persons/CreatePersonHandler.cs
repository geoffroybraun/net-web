using GB.NetWeb.Application.Services.Commands.Persons;
using GB.NetWeb.Application.Services.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace GB.NetWeb.Application.Services.Handlers.Persons
{
    /// <summary>
    /// Represents a handler which runs a <see cref="CreatePersonCommand"/> command
    /// </summary>
    public sealed class CreatePersonHandler : BaseCommandHandler<CreatePersonCommand, bool>
    {
        #region Fields

        private readonly IPersonRepository Repository;

        #endregion

        public CreatePersonHandler(IPersonRepository repository) => Repository = repository ?? throw new ArgumentNullException(nameof(repository));

        public override async Task<bool> RunAsync(CreatePersonCommand command)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            return await Repository.CreateAsync(command).ConfigureAwait(false);
        }
    }
}
