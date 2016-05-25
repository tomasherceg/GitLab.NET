using System;

namespace GitLab.NET.Exceptions
{
    [Serializable]
    public class ForbiddenException : Exception
    {
        public ForbiddenException(string message) : base(message) { }
    }
}