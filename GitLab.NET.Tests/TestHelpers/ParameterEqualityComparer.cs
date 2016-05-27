using System;
using RestSharp;
using System.Collections.Generic;

namespace GitLab.NET.Tests.TestHelpers
{
    public class ParameterEqualityComparer : IEqualityComparer<Parameter>
    {
        public bool Equals(Parameter x, Parameter y)
        {
            if (x.Name != y.Name)
                return false;

            if (!x.Value.Equals(y.Value))
                return false;

            if (x.Type != y.Type)
                return false;

            return true;
        }

        public int GetHashCode(Parameter obj)
        {
            throw new NotImplementedException();
        }
    }
}
