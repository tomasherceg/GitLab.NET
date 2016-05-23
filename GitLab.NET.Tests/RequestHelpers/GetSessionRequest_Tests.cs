using GitLab.NET.RequestHelpers;
using System;
using Xunit;

namespace GitLab.NET.Tests.RequestHelpers
{
    public class GetSessionRequest_Tests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("\t")]
        public void Constructor_UserIsNullOrWhiteSpace_ThrowsArgumentNullException(string invalidUser)
        {
            Assert.Throws<ArgumentNullException>(() => new CreateSessionRequest(invalidUser, "validPassword"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("\t")]
        public void Constructor_PasswordIsNullOrWhiteSpace_ThrowsArgumentNullException(string invalidPassword)
        {
            Assert.Throws<ArgumentNullException>(() => new CreateSessionRequest("validUser", invalidPassword));
        }
    }
}
