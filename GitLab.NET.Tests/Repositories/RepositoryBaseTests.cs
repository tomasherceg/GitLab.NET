using System;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using Xunit;

namespace GitLab.NET.Tests.Repositories
{
    public class RepositoryBaseTests
    {
        private class TestRepository : RepositoryBase
        {
            public TestRepository(IRequestFactory requestFactory) : base(requestFactory) { }
        }

        [Fact]
        public void Constructor_RequestFactoryIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new TestRepository(null));
        }
    }
}