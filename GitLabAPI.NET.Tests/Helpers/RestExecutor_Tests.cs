using GitLabAPI.NET.Factories;
using System;
using Xunit;

namespace GitLabAPI.NET.Helpers.Tests
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
