using GitLab.NET.Tests.TestHelpers;
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
        public void Constructor_ValidParameters_SetsUsers()
        {
            var sut = new GitLabClient(ValidHostUri);

            Assert.NotNull(sut.Users);
        }

        [Fact]
        public void Constructor_ValidParameters_SetsSession()
        {
            var sut = new GitLabClient(ValidHostUri);

            Assert.NotNull(sut.Session);
        }
    }
}
