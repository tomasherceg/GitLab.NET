using System;

namespace GitLab.NET.Exceptions
{
    /// <summary> Thrown when an unhandled error has been encountered. </summary>
    [Serializable]
    public class UnhandledErrorException : Exception
    {
        /// <summary> Creates a new <see cref="UnhandledErrorException" /> instance. </summary>
        /// <param name="message"> The message to be used for this instance. </param>
        public UnhandledErrorException(string message) : base(message) { }
    }
}