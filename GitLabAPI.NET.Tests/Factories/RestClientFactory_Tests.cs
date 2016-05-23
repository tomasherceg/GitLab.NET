using GitLabAPI.NET.Factories;
using System;
using Xunit;

namespace GitLabAPI.NET.Tests.Factories
{
    public class RestClientFactory_Tests
    {
        [Fact]
        public void Create_BaseUriNull_ThrowsArgumentNullException()
        {
            var sut = new RestClientFactory();

            Assert.Throws<ArgumentNullException>(() => sut.Create(null));
        }
    }
}
