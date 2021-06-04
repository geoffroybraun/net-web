using GB.NetWeb.Application.Services.Commands.Persons;
using GB.NetWeb.Application.Services.DTOs;
using GB.NetWeb.Application.Services.Queries.Persons;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GB.NetWeb.Application.Services.Interfaces.Repositories
{
    /// <summary>
    /// Represents a repository which executes an action on <see cref="PersonDto"/>
    /// </summary>
    public interface IPersonRepository
    {
        /// <summary>
        /// Create a new <see cref="PersonDto"/>
        /// </summary>
        /// <param name="command">The <see cref="CreatePersonCommand"/> command to use when creating the <see cref="PersonDto"/></param>
        /// <returns>True if the provided <see cref="CreatePersonCommand"/> command has been successfully run, otherwise false</returns>
        Task<bool> CreateAsync(CreatePersonCommand command);

        /// <summary>
        /// Delete an existing <see cref="PersonDto"/>
        /// </summary>
        /// <param name="command">The <see cref="DeletePersonCommand"/> command to use when deleting the <see cref="PersonDto"/></param>
        /// <returns>True if the provided <see cref="DeletePersonCommand"/> command has been successfully run, otherwise false</returns>
        Task<bool> DeleteAsync(DeletePersonCommand command);

        /// <summary>
        /// Filter all available <see cref="PersonDto"/> using the provided <see cref="FilterPersonQuery"/> query
        /// </summary>
        /// <param name="filter">The <see cref="FilterPersonQuery"/> query to use when filtering</param>
        /// <returns>All available and filtered <see cref="PersonDto"/></returns>
        Task<IEnumerable<PersonDto>> FilterAsync(FilterPersonQuery filter);

        /// <summary>
        /// Update an existing <see cref="PersonDto"/>
        /// </summary>
        /// <param name="command">The <see cref="UpdatePersonCommand"/> command to run when updating the <see cref="PersonDto"/></param>
        /// <returns>True if the provided <see cref="UpdatePersonCommand"/> comand has been successfully run, otherwise false</returns>
        Task<bool> UpdateAsync(UpdatePersonCommand command);
    }
}
