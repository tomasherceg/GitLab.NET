using System;

namespace GitLab.NET.Exceptions
{
    [Serializable]
    public class MethodNotAllowedException : Exception
    {
        public MethodNotAllowedException(string message) : base(message) { }
    }
}