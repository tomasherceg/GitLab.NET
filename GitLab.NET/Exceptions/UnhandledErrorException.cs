using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLab.NET.Exceptions
{
    [Serializable]
    public class UnhandledErrorException : Exception
    {
        public UnhandledErrorException(string message) : base(message) { }
    }
}
