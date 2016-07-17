using System;
using System.Runtime.Serialization;
using System.Security;

namespace Helpers.Common
{
    /// <summary>
    /// The exception that is thrown when either an HTTP error occurs or related one (<see cref="IHttpHelper"/>).
    /// </summary>
    [Serializable]
    public class HttpException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpException"/> class.
        /// </summary>
        public HttpException() {}

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">the error message that explains the reason for the exception</param>
        public HttpException(string message) : base(message) {}

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpException"/> class with a specified error message
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">he error message that explains the reason for the exception</param>
        /// <param name="innerException">
        /// the exception that is the cause of the current exception;
        /// if the <paramref name="innerException"/> parameter is not a null reference,
        /// the current exception is raised in a catch block that handles the inner exception
        /// </param>
        public HttpException(string message, Exception innerException) : base(message, innerException) {}

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpException"/> class with serialized data.
        /// </summary>
        /// <param name="info">the object that holds the serialized object data</param>
        /// <param name="context">the contextual information about the source or destination</param>
        [SecuritySafeCritical]
        protected HttpException(SerializationInfo info, StreamingContext context) : base(info, context) {}
    }
}