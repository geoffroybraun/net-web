using GB.NetWeb.Application.Services.DTOs;
using GB.NetWeb.Application.Services.Exceptions;
using GB.NetWeb.Application.Services.Interfaces.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace GB.NetWeb.Application.WebPortal.Extensions
{
    /// <summary>
    /// Extends a <see cref="IMediator"/> implementation
    /// </summary>
    public static class IMediatorExtension
    {
        /// <summary>
        /// Executes the provided <see cref="IQuery{TResult}"/> implementation
        /// </summary>
        /// <typeparam name="TResult">The query result type</typeparam>
        /// <param name="mediator">The extended <see cref="IMediator"/> implementation</param>
        /// <param name="query">The <see cref="IQuery{TResult}"/> implementation to execute</param>
        /// <param name="modelState">The <see cref="ModelStateDictionary"/> where to add errors if any</param>
        /// <returns>The execute query result</returns>
        public static async Task<IMediatorResponseDto<TResult>> ExecuteAsync<TResult>(this IMediator mediator, IQuery<TResult> query, ModelStateDictionary modelState)
        {
            return await SafeSendAsync(mediator, query, modelState).ConfigureAwait(false);
        }

        /// <summary>
        /// Runs the provided <see cref="ICommand{TResult}"/> implementation
        /// </summary>
        /// <typeparam name="TResult">The command result type</typeparam>
        /// <param name="mediator">The extended <see cref="IMediator"/> implementation</param>
        /// <param name="command">The <see cref="ICommand{TResult}"/> implementation to run</param>
        /// <param name="modelState">The <see cref="ModelStateDictionary"/> where to add errors if any</param>
        /// <returns>The run command result</returns>
        public static async Task<IMediatorResponseDto<TResult>> RunAsync<TResult>(this IMediator mediator, ICommand<TResult> command, ModelStateDictionary modelState)
        {
            return await SafeSendAsync(mediator, command, modelState).ConfigureAwait(false);
        }

        #region Private methods

        private static async Task<IMediatorResponseDto<TResult>> SafeSendAsync<TResult>(IMediator mediator, IRequest<TResult> request, ModelStateDictionary modelState)
        {
            try
            {
                var result = await mediator.Send(request).ConfigureAwait(false);

                return new() { Result = result, HasSucceed = true };
            }
            catch (ErrorsHttpRequestException exception)
            {
                foreach (var error in exception.Errors)
                    modelState.AddModelError("", error);

                return new() { HasSucceed = false };
            }
            catch (Exception exception)
            {
                modelState.AddModelError("", GetExceptionMessage(exception));

                return new() { HasSucceed = false };
            }
        }

        private static string GetExceptionMessage(Exception exception)
        {
            return exception.InnerException is not null ? GetExceptionMessage(exception.InnerException) : exception.Message;
        }

        #endregion
    }
}
