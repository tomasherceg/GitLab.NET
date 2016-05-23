using System;
using Xunit;

namespace GitLab.NET.Tests
{
    public class PrivateTokenAuthenticator_Tests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\t")]
        public void Constructor_PrivateTokenIsNullOrWhiteSpace_ThrowsArgumentNullException(string invalidToken)
        {
            Assert.Throws<ArgumentNullException>("privateToken", () => new PrivateTokenAuthenticator(invalidToken));
        }
    }
}
