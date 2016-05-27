using System;

namespace GitLab.NET.Exceptions
{
    /// <summary> Thrown when a bad request error is encountered. </summary>
    [Serializable]
    public class BadRequestException : Exception
    {
        /// <summary> Creates a new <see cref="BadRequestException" /> instance. </summary>
        /// <param name="message"> The message to use for this instance. </param>
        public BadRequestException(string message) : base(message) { }
    }
}