using GitLab.NET.Factories;
using GitLab.NET.RestHelpers;
using System;
using Xunit;

namespace GitLab.NET.Tests.Helpers
{
    public class RestExecutorTests
    {
        [Fact]
        public void Constructor_BaseUriIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>("baseUri", () => new RestExecutor(new RestClientFactory(), null));
        }

        [Fact]
        public void Constructor_RestClientFactoryIsNull_ThrowsArgumentNullException()
        {
            var baseUri = new Uri("https://host.com");

            Assert.Throws<ArgumentNullException>("restClientFactory", () => new RestExecutor(null, baseUri));
        }
    }
}
