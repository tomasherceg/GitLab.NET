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
        public void Constructor_ValidParameters_SetsBuildTriggers()
        {
            var sut = new GitLabClient(ValidHostUri);

            Assert.NotNull(sut.BuildTriggers);
        }

        [Fact]
        public void Constructor_ValidParameters_SetsBuildVariables()
        {
            var sut = new GitLabClient(ValidHostUri);

            Assert.NotNull(sut.BuildVariables);
        }

        [Fact]
        public void Constructor_ValidParameters_SetsEmails()
        {
            var sut = new GitLabClient(ValidHostUri);

            Assert.NotNull(sut.Emails);
        }

        [Fact]
        public void Constructor_ValidParameters_SetsGitLabLicense()
        {
            var sut = new GitLabClient(ValidHostUri);

            Assert.NotNull(sut.GitLabLicense);
        }

        [Fact]
        public void Constructor_ValidParameters_SetsKeys()
        {
            var sut = new GitLabClient(ValidHostUri);

            Assert.NotNull(sut.Keys);
        }

        [Fact]
        public void Constructor_ValidParameters_SetsLicenses()
        {
            var sut = new GitLabClient(ValidHostUri);

            Assert.NotNull(sut.Licenses);
        }

        [Fact]
        public void Constructor_ValidParameters_SetsNamespaces()
        {
            var sut = new GitLabClient(ValidHostUri);

            Assert.NotNull(sut.Namespaces);
        }

        [Fact]
        public void Constructor_ValidParameters_SetsProjectSnippets()
        {
            var sut = new GitLabClient(ValidHostUri);

            Assert.NotNull(sut.ProjectSnippets);
        }

        [Fact]
        public void Constructor_ValidParameters_SetsRepositories()
        {
            var sut = new GitLabClient(ValidHostUri);

            Assert.NotNull(sut.Repositories);
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