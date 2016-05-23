using System;

namespace GitLab.NET.Exceptions
{
    public class UnprocessableException : Exception
    {
        public UnprocessableException(string message) : base(message) { }
    }
}
