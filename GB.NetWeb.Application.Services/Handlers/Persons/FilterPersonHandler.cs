using GB.NetWeb.Application.Services.DTOs;
using GB.NetWeb.Application.Services.Interfaces.Repositories;
using GB.NetWeb.Application.Services.Queries.Persons;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GB.NetWeb.Application.Services.Handlers.Persons
{
    /// <summary>
    /// Represents a handler which executes a <see cref="FilterPersonQuery"/> query
    /// </summary>
    public sealed class FilterPersonHandler : BaseQueryHandler<FilterPersonQuery, IEnumerable<PersonDto>>
    {
        #region Fields

        private readonly IPersonRepository Repository;

        #endregion

        public FilterPersonHandler(IPersonRepository repository) => Repository = repository ?? throw new ArgumentNullException(nameof(repository));

        public override async Task<IEnumerable<PersonDto>> ExecuteAsync(FilterPersonQuery query)
        {
            if (query is null)
                throw new ArgumentNullException(nameof(query));

            return await Repository.FilterAsync(query).ConfigureAwait(false);
        }
    }
}
