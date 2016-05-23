using GitLab.NET.Factories;
using GitLab.NET.Helpers;
using System;
using Xunit;

namespace GitLab.NET.Tests.Helpers
{
    public class RestExecutor_Tests
    {
        [Fact]
        public void Constructor_BaseUriNull_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new RestExecutor(new RestClientFactory(), null));
        }

        [Fact]
        public void Constructor_RestClientFactoryNull_ArgumentNullException()
        {
            var baseUri = new Uri("https://host.com");

            Assert.Throws<ArgumentNullException>(() => new RestExecutor(null, baseUri));
        }
    }
}
