using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GB.NetWeb.Application.Services.Handlers
{
    /// <summary>
    /// Represents an abstract handler which executes a query
    /// </summary>
    /// <typeparam name="TQuery">The query type to execute</typeparam>
    /// <typeparam name="TResult">The returned result type</typeparam>
    public abstract class BaseQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IRequest<TResult>
    {
        /// <summary>
        /// Execute the provided <see cref="TQuery"/> query
        /// </summary>
        /// <param name="request">The <see cref="TQuery"/> query to execute</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use when executing the query</param>
        /// <returns>The query result</returns>
        public async Task<TResult> Handle(TQuery request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Delegate the method implementation to the deriving class
        /// </summary>
        /// <param name="query">The <see cref="TQuery"/> query to execute</param>
        /// <returns>The query result</returns>
        public abstract Task<TResult> ExecuteAsync(TQuery query);
    }
}
