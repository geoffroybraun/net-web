using GB.NetWeb.Application.Services.DTOs;
using GB.NetWeb.Application.Services.Interfaces.CQRS;
using System;
using System.ComponentModel.DataAnnotations;

namespace GB.NetWeb.Application.Services.Queries.Authentications
{
    /// <summary>
    /// Represents a query to authenticate a user
    /// </summary>
    [Serializable]
    public sealed record AuthenticateUserQuery : IQuery<AuthenticationResponseDto>
    {
        [Required(ErrorMessage = "FieldRequired")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; init; }

        [Required(ErrorMessage = "FieldRequired")]
        [DataType(DataType.Password)]
        public string Password { get; init; }
    }
}
