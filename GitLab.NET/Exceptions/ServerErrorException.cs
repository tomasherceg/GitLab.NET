using System;

namespace GitLab.NET.Exceptions
{
    /// <summary> Thrown when a server error is encountered. </summary>
    [Serializable]
    public class ServerErrorException : Exception
    {
        /// <summary> Creates a new <see cref="ServerErrorException" /> instance. </summary>
        /// <param name="message"> The message to use for this instance. </param>
        public ServerErrorException(string message) : base(message) { }
    }
}