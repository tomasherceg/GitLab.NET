using System;
using Xunit;

namespace GitLab.NET.Tests
{
    public class UserAuthenticator_Tests
    {
        [Fact]
        public void Constructor_BaseUriNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>("hostUri", () => new UserAuthenticator(null));
        }
    }
}
