using MediatR;

namespace GB.NetWeb.Application.Services.Interfaces.CQRS
{
    /// <summary>
    /// Represents a query which matches a read action
    /// </summary>
    /// <typeparam name="TResult">The returned result type</typeparam>
    public interface IQuery<out TResult> : IRequest<TResult> { }
}
