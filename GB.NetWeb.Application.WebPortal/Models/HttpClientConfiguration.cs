namespace GB.NetWeb.Application.WebPortal.Models
{
    /// <summary>
    /// Represents a <see cref="System.Net.Http.HttpClient"/> configuration
    /// </summary>
    public sealed record HttpClientConfiguration
    {
        public string BaseAddress { get; init; }

        public string AcceptHeaderValue { get; init; }
    }
}
