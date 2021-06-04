using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GB.NetWeb.Application.Services.Exceptions
{
    /// <summary>
    /// Represents an exception to throw in case of bad request response
    /// </summary>
    [Serializable]
    public sealed class ErrorsHttpRequestException : Exception
    {
        #region Properties

        public readonly IEnumerable<string> Errors;

        #endregion

        public ErrorsHttpRequestException() : base() { }

        public ErrorsHttpRequestException(string message) : base(message) { }

        public ErrorsHttpRequestException(string message, Exception innerException) : base(message, innerException) { }

        public ErrorsHttpRequestException(IEnumerable<string> errors) => Errors = errors;

        private ErrorsHttpRequestException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
