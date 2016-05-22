using System;
using Xunit;

namespace GitLabAPI.NET.Tests
{
    public class GitLabAPI_Tests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Constructor_PrivateTokenNullOrEmpty_ThrowsArgumentNullException(string privateToken)
        {
            Assert.Throws<ArgumentNullException>(() => new GitLabAPI(privateToken));
        }
    }
}
