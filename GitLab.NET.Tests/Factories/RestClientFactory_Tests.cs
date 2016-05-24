using GitLab.NET.Factories;
using System;
using Xunit;

namespace GitLab.NET.Tests.Factories
{
    public class RestClientFactory_Tests
    {
        [Fact]
        public void Create_BaseUriIsNull_ThrowsArgumentNullException()
        {
            var sut = new RestClientFactory();

            Assert.Throws<ArgumentNullException>("baseUri", () => sut.Create(null));
        }
    }
}
