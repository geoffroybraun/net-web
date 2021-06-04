using System;

namespace GB.NetWeb.Application.Services.DTOs
{
    /// <summary>
    /// Represents a response returned by a <see cref="MediatR.IMediator"/> implementation which retrieves a command/query result
    /// </summary>
    /// <typeparam name="TResult">The command/query result type</typeparam>
    [Serializable]
    public sealed record IMediatorResponseDto<TResult>
    {
        public bool HasSucceed { get; set; }

        public TResult Result { get; set; }
    }
}
