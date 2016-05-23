using System;
using Xunit;

namespace GitLab.NET.Tests
{
    public class GitLabAPI_Tests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Constructor_PrivateTokenNullOrEmpty_ThrowsArgumentNullException(string privateToken)
        {
            var baseUri = new Uri("https://host.com");

            Assert.Throws<ArgumentNullException>(() => new GitLabAPI(privateToken, baseUri));
        }

        [Fact]
        public void Constructor_BaseUriNull_ThrowsArgumentNullException()
        {
            var privateToken = "privateToken";

            Assert.Throws<ArgumentNullException>(() => new GitLabAPI(privateToken, null));
        }
    }
}
