using System;

namespace GitLab.NET.Exceptions
{
    public class ServerErrorException : Exception
    {
        public ServerErrorException(string message) : base(message) { }
    }
}
