using System;
using System.Runtime.Serialization;
using System.Security;

namespace Helpers.Common.Data
{
    /// <summary>
    /// The exception that is thrown when either an Storage initialization error occurs or related one (<see cref="StorageBase"/>).
    /// </summary>
    [Serializable]
    public sealed class StorageInitializationException : DataException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StorageInitializationException"/> class.
        /// </summary>
        public StorageInitializationException() {}

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageInitializationException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">the error message that explains the reason for the exception</param>
        public StorageInitializationException(string message) : base(message) {}

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageInitializationException"/> class with a specified error message
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">he error message that explains the reason for the exception</param>
        /// <param name="innerException">
        /// the exception that is the cause of the current exception;
        /// if the <paramref name="innerException"/> parameter is not a null reference,
        /// the current exception is raised in a catch block that handles the inner exception
        /// </param>
        public StorageInitializationException(string message, Exception innerException) : base(message, innerException) {}

        /// <summary>
        /// Initializes a new instance of the <see cref="DataException"/> class with serialized data.
        /// </summary>
        /// <param name="info">the object that holds the serialized object data</param>
        /// <param name="context">the contextual information about the source or destination</param>
        [SecuritySafeCritical]
        private StorageInitializationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
    }
}