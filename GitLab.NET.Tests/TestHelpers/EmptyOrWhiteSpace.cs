// ReSharper disable UnusedMember.Global
using System.Collections;
using System.Collections.Generic;

namespace GitLab.NET.Tests.TestHelpers
{
    public class EmptyOrWhiteSpace : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                ""
            };
            yield return new object[]
            {
                " "
            };
            yield return new object[]
            {
                "\t"
            };
            yield return new object[]
            {
                "\r"
            };
            yield return new object[]
            {
                "\n"
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}