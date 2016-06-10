using System;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NUnit.Framework;

namespace GitLab.NET.Tests.Repositories
{
    public class RepositoryBaseTests
    {
        private class TestRepository : RepositoryBase
        {
            public TestRepository(IRequestFactory requestFactory) : base(requestFactory) { }
        }

        [Test]
        public void Constructor_RequestFactoryIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new TestRepository(null));
        }
    }
}