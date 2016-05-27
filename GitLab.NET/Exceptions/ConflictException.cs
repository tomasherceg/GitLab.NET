using System;

namespace GitLab.NET.Exceptions
{
    /// <summary> Thrown when a conflict error is encountered. </summary>
    [Serializable]
    public class ConflictException : Exception
    {
        /// <summary> Creates a new <see cref="ConflictException" /> instance. </summary>
        /// <param name="message"> The message to use for this instance. </param>
        public ConflictException(string message) : base(message) { }
    }
}