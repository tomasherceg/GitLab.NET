using System;

namespace GitLabAPI.NET.Exceptions
{
    public class UnprocessableException : Exception
    {
        public UnprocessableException(string message) : base(message) { }
    }
}
