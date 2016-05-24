using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using System;
using Xunit;

namespace GitLab.NET.Tests.RequestHelpers
{
    public class CreateSessionTests
    {
        [Theory]
        [ClassData(typeof(EmptyOrWhiteSpace))]
        public void Constructor_UserIsEmptyOrWhiteSpace_ThrowsArgumentException(string invalidUser)
        {
            Assert.Throws<ArgumentException>("user", () => new CreateSession(invalidUser, "validPassword"));
        }

        [Fact]
        public void Constructor_UserIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>("user", () => new CreateSession(null, "validPassword"));
        }

        [Theory]
        [ClassData(typeof(EmptyOrWhiteSpace))]
        public void Constructor_PasswordIsEmptyOrWhiteSpace_ThrowsArgumentException(string invalidPassword)
        {
            Assert.Throws<ArgumentException>("password", () => new CreateSession("validUser", invalidPassword));
        }

        [Fact]
        public void Constructor_PasswordIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>("password", () => new CreateSession("validUser", null));
        }
    }
}
