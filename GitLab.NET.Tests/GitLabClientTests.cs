using System;
using Xunit;

namespace GitLab.NET.Tests
{
    public class GitLabClientTests
    {
        private static readonly Uri ValidHostUri = new Uri("https://host.com");

        [Fact]
        public void Constructor_BaseUriIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new GitLabClient(null));
        }

        [Fact]
        public void Constructor_ValidParameters_SetsEmails()
        {
            var sut = new GitLabClient(ValidHostUri);

            Assert.NotNull(sut.Emails);
        }

        [Fact]
        public void Constructor_ValidParameters_SetsKeys()
        {
            var sut = new GitLabClient(ValidHostUri);

            Assert.NotNull(sut.Keys);
        }

        [Fact]
        public void Constructor_ValidParameters_SetsSession()
        {
            var sut = new GitLabClient(ValidHostUri);

            Assert.NotNull(sut.Session);
        }

        [Fact]
        public void Constructor_ValidParameters_SetsUsers()
        {
            var sut = new GitLabClient(ValidHostUri);

            Assert.NotNull(sut.Users);
        }

        [Fact]
        public void PrivateToken_ReturnsCorrectValue()
        {
            const string privateToken = "privateToken";
            var sut = new GitLabClient(ValidHostUri)
            {
                PrivateToken = privateToken
            };

            Assert.Equal(privateToken, sut.PrivateToken);
        }

        [Fact]
        public void SetPrivateToken_ValueIsNull_ThrowsArgumentNullException()
        {
            var sut = new GitLabClient(ValidHostUri);

            Assert.Throws<ArgumentNullException>(() => sut.PrivateToken = null);
        }
    }
}