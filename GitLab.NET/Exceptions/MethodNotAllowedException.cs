using System;

namespace GitLab.NET.Exceptions
{
    /// <summary> Thrown when a method not allowed error is encountered. </summary>
    [Serializable]
    public class MethodNotAllowedException : Exception
    {
        /// <summary> Creates a new <see cref="MethodNotAllowedException" /> instance. </summary>
        /// <param name="message"> The message to use for this instance. </param>
        public MethodNotAllowedException(string message) : base(message) { }
    }
}