using System;

namespace GitLab.NET.Exceptions
{
    [Serializable]
    public class ConflictException : Exception
    {
        public ConflictException(string message) : base(message) { }
    }
}