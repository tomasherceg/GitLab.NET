using GitLab.NET.Tests.TestHelpers;
using System;
using Xunit;

namespace GitLab.NET.Tests
{
    public class GitLabClientTests
    {
        [Theory]
        [ClassData(typeof(EmptyOrWhiteSpace))]
        public void Constructor_PrivateTokenIsEmptyOrWhiteSpace_ThrowsArgumentException(string invalidToken)
        {
            var baseUri = new Uri("https://host.com");

            Assert.Throws<ArgumentException>("privateToken", () => new GitLabClient(invalidToken, baseUri));
        }

        [Fact]
        public void Constructor_PrivateTokenIsNull_ThrowsArgumentNullException()
        {
            var baseUri = new Uri("https://host.com");

            Assert.Throws<ArgumentNullException>("privateToken", () => new GitLabClient(null, baseUri));
        }

        [Fact]
        public void Constructor_BaseUriIsNull_ThrowsArgumentNullException()
        {
            var privateToken = "privateToken";

            Assert.Throws<ArgumentNullException>("hostUri", () => new GitLabClient(privateToken, null));
        }
    }
}
