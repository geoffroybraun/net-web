namespace GB.NetWeb.Application.WebPortal.Models
{
    /// <summary>
    /// Represents a configuration used by task execution policies
    /// </summary>
    public sealed record TaskHandlerConfiguration
    {
        public int MaxRetriesCount { get; init; }

        public int MaxExceptionsCount { get; init; }

        public int TimeBetweenBreaksInMilliseconds { get; init; }
    }
}
