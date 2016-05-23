using GitLab.NET.RequestHelpers;
using System;
using Xunit;

namespace GitLab.NET.Tests.RequestHelpers
{
    public class GetUserRequest_Tests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("\t")]
        public void Constructor_UsernameIsNullOrWhiteSpace_ThrowsArgumentNullException(string invalidUsername)
        {
            Assert.Throws<ArgumentNullException>(() => new GetUserRequest(invalidUsername));
        }
    }
}
