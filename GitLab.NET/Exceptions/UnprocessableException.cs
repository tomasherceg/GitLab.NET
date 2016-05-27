using System;

namespace GitLab.NET.Exceptions
{
    /// <summary> Thrown when an unprocessable error is encountered. </summary>
    [Serializable]
    public class UnprocessableException : Exception
    {
        /// <summary> Creates a new <see cref="UnprocessableException" /> instance. </summary>
        /// <param name="message"> The message to use for this instance. </param>
        public UnprocessableException(string message) : base(message) { }
    }
}