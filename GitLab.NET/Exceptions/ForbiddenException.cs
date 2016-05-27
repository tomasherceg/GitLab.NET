using System;

namespace GitLab.NET.Exceptions
{
    /// <summary> Thrown when a forbidden error is encountered. </summary>
    [Serializable]
    public class ForbiddenException : Exception
    {
        /// <summary> Creates a new <see cref="ForbiddenException" /> instance. </summary>
        /// <param name="message"> The message to use for this instance. </param>
        public ForbiddenException(string message) : base(message) { }
    }
}