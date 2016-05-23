using System.Collections;
using System.Collections.Generic;

namespace GitLab.NET.Tests.TestHelpers
{
    public class EmptyOrWhiteSpace : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            // ...
            yield return new object[] { 8, 21 };
            yield return new object[] { 16, 987 };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
