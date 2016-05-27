using System;

namespace GitLab.NET.Exceptions
{
    /// <summary> Thrown when an unauthorized error is encountered. </summary>
    [Serializable]
    public class UnauthorizedException : Exception
    {
        /// <summary> Creates a new <see cref="UnauthorizedException" /> instance. </summary>
        /// <param name="message"> The message to use for this instance. </param>
        public UnauthorizedException(string message) : base(message) { }
    }
}