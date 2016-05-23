using System;

namespace GitLabAPI.NET.Exceptions
{
    public class ServerErrorException : Exception
    {
        public ServerErrorException(string message) : base(message) { }
    }
}
