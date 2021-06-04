using System;
using System.Collections.Generic;

namespace GB.NetWeb.Application.Services.DTOs
{
    /// <summary>
    /// Represents a response related to user authentication
    /// </summary>
    [Serializable]
    public sealed record AuthenticationResponseDto
    {
        public string Token { get; init; }

        public IEnumerable<string> Permissions { get; init; }
    }
}
