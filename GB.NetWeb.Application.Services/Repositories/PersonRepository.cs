using GB.NetWeb.Application.Services.Commands.Persons;
using GB.NetWeb.Application.Services.DTOs;
using GB.NetWeb.Application.Services.Interfaces.Repositories;
using GB.NetWeb.Application.Services.Queries.Persons;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GB.NetWeb.Application.Services.Repositories
{
    public sealed class PersonRepository : BaseWebApiRepository, IPersonRepository
    {
        #region Fields

        private const string BaseUri = "persons";

        #endregion

        public PersonRepository(HttpClient client) : base(client) { }

        public async Task<bool> CreateAsync(CreatePersonCommand command)
        {
            await PutAsync(BaseUri, command).ConfigureAwait(false);

            return true;
        }

        public async Task<bool> DeleteAsync(DeletePersonCommand command)
        {
            await DeleteAsync($"{BaseUri}/{command.Id}").ConfigureAwait(false);

            return true;
        }

        public async Task<IEnumerable<PersonDto>> FilterAsync(FilterPersonQuery filter) => await PostAsync<IEnumerable<PersonDto>>(BaseUri, filter).ConfigureAwait(false);

        public async Task<bool> UpdateAsync(UpdatePersonCommand command)
        {
            await PutAsync($"{BaseUri}/{command.Id}", command).ConfigureAwait(false);

            return true;
        }
    }
}
