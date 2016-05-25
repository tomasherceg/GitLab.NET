using System;

namespace GitLab.NET.Exceptions
{
    [Serializable]
    public class ServerErrorException : Exception
    {
        public ServerErrorException(string message) : base(message) { }
    }
}