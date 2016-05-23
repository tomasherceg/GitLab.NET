using System;

namespace GitLab.NET.Exceptions
{
    [Serializable]
    public class UnprocessableException : Exception
    {
        public UnprocessableException(string message) : base(message) { }
    }
}
