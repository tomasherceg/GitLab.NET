using System.Collections.Generic;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests
{
    public class HeaderHelperTests
    {
        [Fact]
        public void GetAsUInt_HeaderExists_ReturnsCorrectValue()
        {
            uint? expected = 5;
            var headers = new List<Parameter>
            {
                new Parameter
                {
                    Name = "test",
                    Value = expected.ToString()
                }
            };

            var result = headers.GetAsUInt("test");

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetAsUInt_NoSuchHeader_ReturnsNull()
        {
            // ReSharper disable once CollectionNeverUpdated.Local
            var headers = new List<Parameter>();

            var result = headers.GetAsUInt("test");

            Assert.Equal(null, result);
        }

        [Fact]
        public void GetAsUInt_ValueIsWrongType_ReturnsNull()
        {
            var headers = new List<Parameter>
            {
                new Parameter
                {
                    Name = "test",
                    Value = "incorrect"
                }
            };

            var result = headers.GetAsUInt("test");

            Assert.Equal(null, result);
        }
    }
}