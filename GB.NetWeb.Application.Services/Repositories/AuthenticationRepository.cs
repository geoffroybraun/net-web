using GB.NetWeb.Application.Services.DTOs;
using GB.NetWeb.Application.Services.Interfaces.Repositories;
using GB.NetWeb.Application.Services.Queries.Authentications;
using System.Net.Http;
using System.Threading.Tasks;

namespace GB.NetWeb.Application.Services.Repositories
{
    public sealed class AuthenticationRepository : BaseWebApiRepository, IAuthenticationRepository
    {
        #region Fields

        private const string LoginRequestUri = "login";

        #endregion

        public AuthenticationRepository(HttpClient client) : base(client) { }

        public async Task<AuthenticationResponseDto> LoginAsync(AuthenticateUserQuery query) => await PostAsync<AuthenticationResponseDto>(LoginRequestUri, query).ConfigureAwait(false);
    }
}
