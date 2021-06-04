using GB.NetWeb.Application.Services.Commands.Persons;
using GB.NetWeb.Application.Services.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace GB.NetWeb.Application.Services.Handlers.Persons
{
    /// <summary>
    /// Represents a handler which runs a <see cref="UpdatePersonCommand"/> command
    /// </summary>
    public sealed class UpdatePersonHandler : BaseCommandHandler<UpdatePersonCommand, bool>
    {
        #region Fields

        private readonly IPersonRepository Repository;

        #endregion

        public UpdatePersonHandler(IPersonRepository repository) => Repository = repository ?? throw new ArgumentNullException(nameof(repository));

        public override async Task<bool> RunAsync(UpdatePersonCommand command)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            return await Repository.UpdateAsync(command).ConfigureAwait(false);
        }
    }
}
