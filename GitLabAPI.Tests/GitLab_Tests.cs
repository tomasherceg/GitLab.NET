using System;
using Xunit;

namespace GitLabAPI.Tests
{
    public class GitLab_Tests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Constructor_PrivateTokenNullOrEmpty_ThrowsArgumentNullException(string privateToken)
        {
            Assert.Throws<ArgumentNullException>(() => new GitLab(privateToken, new Uri("https://host.com")));
        }
    }
}
