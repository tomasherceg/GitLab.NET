﻿using System;
using Xunit;

namespace GitLab.NET.Tests
{
    public class GitLabAPI_Tests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Constructor_PrivateTokenNullOrEmpty_ThrowsArgumentNullException(string privateToken)
        {
            var baseUri = new Uri("https://host.com");

            Assert.Throws<ArgumentNullException>(() => new GitLabAPISubClass(privateToken, baseUri));
        }

        [Fact]
        public void Constructor_BaseUriNull_ThrowsArgumentNullException()
        {
            var privateToken = "privateToken";

            Assert.Throws<ArgumentNullException>(() => new GitLabAPISubClass(privateToken, null));
        }

        private class GitLabAPISubClass : GitLabAPI
        {
            public GitLabAPISubClass(string privateToken, Uri hostUri) : base(privateToken, hostUri) { }
        }
    }
}
