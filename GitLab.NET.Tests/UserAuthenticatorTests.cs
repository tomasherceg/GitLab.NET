using System;
using Xunit;

namespace GitLab.NET.Tests
{
    public class UserAuthenticatorTests
    {
        [Fact]
        public void Constructor_BaseUriIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>("hostUri", () => new UserAuthenticator(null));
        }
    }
}
