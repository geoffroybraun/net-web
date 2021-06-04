using MediatR;

namespace GB.NetWeb.Application.Services.Interfaces.CQRS
{
    /// <summary>
    /// Represents a command which matches a write action
    /// </summary>
    /// <typeparam name="TResult">The returned result type</typeparam>
    public interface ICommand<out TResult> : IRequest<TResult> { }
}
