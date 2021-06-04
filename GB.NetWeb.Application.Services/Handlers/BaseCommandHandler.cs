using GB.NetWeb.Application.Services.Interfaces.CQRS;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GB.NetWeb.Application.Services.Handlers
{
    /// <summary>
    /// Represents an abstract handler which runs a command
    /// </summary>
    /// <typeparam name="TCommand">The command type to execute</typeparam>
    /// <typeparam name="TResult">The returned result type</typeparam>
    public abstract class BaseCommandHandler<TCommand, TResult> : IRequestHandler<TCommand, TResult> where TCommand : ICommand<TResult>
    {
        /// <summary>
        /// Run the provided <see cref="TCommand"/> command
        /// </summary>
        /// <param name="request">The <see cref="TCommand"/> command to run</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use when running the command</param>
        /// <returns>The command result</returns>
        public async Task<TResult> Handle(TCommand request, CancellationToken cancellationToken)
        {
            return await RunAsync(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Delegate the method implementation to the deriving class
        /// </summary>
        /// <param name="query">The <see cref="TCommand"/> command to run</param>
        /// <returns>The command result</returns>
        public abstract Task<TResult> RunAsync(TCommand command);
    }
}
