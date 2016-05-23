using System;

namespace GitLab.NET.Exceptions
{
    public class MethodNotAllowedException : Exception
    {
        public MethodNotAllowedException(string message) : base(message) { }
    }
}
