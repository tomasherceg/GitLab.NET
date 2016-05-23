using System;
using Xunit;

namespace GitLab.NET.Tests
{
    public class GitLabAPI_Tests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\t")]
        public void Constructor_PrivateTokenNullOrWhiteSpace_ThrowsArgumentNullException(string invalidToken)
        {
            var baseUri = new Uri("https://host.com");

            Assert.Throws<ArgumentNullException>("privateToken", () => new GitLabAPI(invalidToken, baseUri));
        }

        [Fact]
        public void Constructor_BaseUriNull_ThrowsArgumentNullException()
        {
            var privateToken = "privateToken";

            Assert.Throws<ArgumentNullException>("hostUri", () => new GitLabAPI(privateToken, null));
        }
    }
}
