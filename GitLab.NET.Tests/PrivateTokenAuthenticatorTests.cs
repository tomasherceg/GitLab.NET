using GitLab.NET.Tests.TestHelpers;
using System;
using Xunit;

namespace GitLab.NET.Tests
{
    public class PrivateTokenAuthenticatorTests
    {
        [Theory]
        [ClassData(typeof(EmptyOrWhiteSpace))]
        public void Constructor_PrivateTokenIsEmptyOrWhiteSpace_ThrowsArgumentException(string invalidToken)
        {
            Assert.Throws<ArgumentException>("privateToken", () => new PrivateTokenAuthenticator(invalidToken));
        }

        [Fact]
        public void Constructor_PrivateTokenIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>("privateToken", () => new PrivateTokenAuthenticator(null));
        }
    }
}
