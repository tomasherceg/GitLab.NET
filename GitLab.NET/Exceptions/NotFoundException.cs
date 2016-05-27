using System;

namespace GitLab.NET.Exceptions
{
    /// <summary> Thrown when a not found error is encountered. </summary>
    [Serializable]
    public class NotFoundException : Exception
    {
        /// <summary> Creates a new <see cref="NotFoundException" /> instance. </summary>
        /// <param name="message"> The message to be used for this instance. </param>
        public NotFoundException(string message) : base(message) { }
    }
}