using GB.NetWeb.Application.Services.DTOs;
using GB.NetWeb.Application.Services.Interfaces.Repositories;
using GB.NetWeb.Application.Services.Queries.Authentications;
using System;
using System.Threading.Tasks;

namespace GB.NetWeb.Application.Services.Handlers.Authentications
{
    /// <summary>
    /// Represents a handler which executes a <see cref="AuthenticateUserQuery"/> query
    /// </summary>
    public sealed class AuthenticateUserHandler : BaseQueryHandler<AuthenticateUserQuery, AuthenticationResponseDto>
    {
        #region Fields

        private readonly IAuthenticationRepository Repository;

        #endregion

        public AuthenticateUserHandler(IAuthenticationRepository repository) => Repository = repository ?? throw new ArgumentNullException(nameof(repository));

        public override async Task<AuthenticationResponseDto> ExecuteAsync(AuthenticateUserQuery query)
        {
            if (query is null)
                throw new ArgumentNullException(nameof(query));

            return await Repository.LoginAsync(query).ConfigureAwait(false);
        }
    }
}
