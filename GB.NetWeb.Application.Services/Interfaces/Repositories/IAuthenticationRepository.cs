using GB.NetWeb.Application.Services.DTOs;
using GB.NetWeb.Application.Services.Queries.Authentications;
using System.Threading.Tasks;

namespace GB.NetWeb.Application.Services.Interfaces.Repositories
{
    /// <summary>
    /// Represents a repository which executes an action related to an authentication process
    /// </summary>
    public interface IAuthenticationRepository
    {
        /// <summary>
        /// Execute a <see cref="AuthenticateUserQuery"/> query
        /// </summary>
        /// <param name="query">The <see cref="AuthenticateUserQuery"/> query to execute</param>
        /// <returns>The JWT token</returns>
        Task<AuthenticationResponseDto> LoginAsync(AuthenticateUserQuery query);
    }
}
