using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using System;
using Xunit;

namespace GitLab.NET.Tests.RequestHelpers
{
    public class GetUserTests
    {
        [Theory]
        [ClassData(typeof(EmptyOrWhiteSpace))]
        public void Constructor_UsernameIsEmptyOrWhiteSpace_ThrowsArgumentException(string invalidUsername)
        {
            Assert.Throws<ArgumentException>("username", () => new GetUser(invalidUsername));
        }

        [Fact]
        public void Constructor_UsernameIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>("username", () => new GetUser(null));
        }

        [Fact]
        public void GetRequest_UsernameValid_ReturnsCorrectRequest()
        {
            var sut = new GetUser("validUsername");

            var result = sut.GetRequest();

            Assert.Equal(GetUser.ByUsernameResource, result.Resource);
        }
    }
}
