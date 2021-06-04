using GB.NetWeb.Application.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GB.NetWeb.Application.Services.Repositories
{
    /// <summary>
    /// Represents an abstract Web API repository which provides useful methods to deriving classes
    /// </summary>
    public abstract class BaseWebApiRepository
    {
        #region Fields

        private static readonly JsonSerializerOptions Options = new JsonSerializerOptions()
        {
            IgnoreNullValues = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false
        };
        private readonly HttpClient Client;

        #endregion

        protected BaseWebApiRepository(HttpClient client) => Client = client ?? throw new ArgumentNullException(nameof(client));

        /// <summary>
        /// Executes a <see cref="HttpMethod.Delete"/> call to the requested URI
        /// </summary>
        /// <param name="requestUri">The URI to request</param>
        /// <returns>An exception if the response is not successful</returns>
        protected async Task DeleteAsync(string requestUri)
        {
            var response = await Client.DeleteAsync(requestUri).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
                throw await ThrowsExceptionAsync(response).ConfigureAwait(false);
        }

        /// <summary>
        /// Executes a <see cref="HttpMethod.Get"/> call to the requested URI
        /// </summary>
        /// <typeparam name="TResult">The returned result type</typeparam>
        /// <param name="requestUri">The URI to request</param>
        /// <returns>The request result</returns>
        protected async Task<TResult> GetAsync<TResult>(string requestUri)
        {
            var response = await Client.GetAsync(requestUri).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
                return await DeserializeContentAsync<TResult>(response.Content).ConfigureAwait(false);

            throw await ThrowsExceptionAsync(response).ConfigureAwait(false);
        }

        /// <summary>
        /// Executes a <see cref="HttpMethod.Post"/> call to the requested URI
        /// </summary>
        /// <typeparam name="TResult">The returned result type</typeparam>
        /// <param name="requestUri">The URI to request</param>
        /// <param name="content">The content to send within the request</param>
        /// <returns>The request result</returns>
        protected async Task<TResult> PostAsync<TResult>(string requestUri, object content)
        {
            using var stringContent = SerializeContent(content);
            var response = await Client.PostAsync(requestUri, stringContent).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
                return await DeserializeContentAsync<TResult>(response.Content).ConfigureAwait(false);

            throw await ThrowsExceptionAsync(response).ConfigureAwait(false);
        }

        /// <summary>
        /// Executes a <see cref="HttpMethod.Put"/> call to the requested URI
        /// </summary>
        /// <param name="requestUri">The URI to request</param>
        /// <param name="content">The content to send within the request</param>
        /// <returns>An exception if the response is not successful</returns>
        protected async Task PutAsync(string requestUri, object content)
        {
            using var stringContent = SerializeContent(content);
            var response = await Client.PutAsync(requestUri, stringContent).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
                throw await ThrowsExceptionAsync(response).ConfigureAwait(false);
        }

        #region Private methods

        private static StringContent SerializeContent(object content)
        {
            var serializedContent = JsonSerializer.Serialize(content, typeof(object), Options);

            return new(serializedContent, Encoding.UTF8, "application/json");
        }

        private static async Task<Exception> ThrowsExceptionAsync(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                var errors = await DeserializeContentAsync<string[]>(response.Content).ConfigureAwait(false);

                return new ErrorsHttpRequestException(errors);
            }

            var error = await DeserializeContentAsync<string>(response.Content).ConfigureAwait(false);

            return new HttpRequestException(error);
        }

        private static async Task<TResult> DeserializeContentAsync<TResult>(HttpContent content)
        {
            using var stream = await content.ReadAsStreamAsync().ConfigureAwait(false);
            var result = await JsonSerializer.DeserializeAsync(stream, typeof(TResult), Options).ConfigureAwait(false);

            if (EqualityComparer<object>.Default.Equals(result, default))
                return default;

            return (TResult)result;
        }

        #endregion
    }
}
