using GitLab.NET.Tests.TestHelpers;
using System;
using Xunit;

namespace GitLab.NET.Tests
{
    public class GitLabClientTests
    {
        private static readonly Uri ValidHostUri = new Uri("https://host.com");
        private const string ValidToken = "privateToken";

        [Theory]
        [ClassData(typeof(EmptyOrWhiteSpace))]
        public void Constructor_PrivateTokenIsEmptyOrWhiteSpace_ThrowsArgumentException(string invalidToken)
        {
            Assert.Throws<ArgumentException>(ValidToken, () => new GitLabClient(invalidToken, ValidHostUri));
        }

        [Fact]
        public void Constructor_PrivateTokenIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(ValidToken, () => new GitLabClient(null, ValidHostUri));
        }

        [Fact]
        public void Constructor_BaseUriIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new GitLabClient(ValidToken, null));
        }

        [Fact]
        public void Constructor_ValidParameters_SetsUsers()
        {
            var sut = new GitLabClient(ValidToken, ValidHostUri);

            Assert.NotNull(sut.Users);
        }
    }
}
