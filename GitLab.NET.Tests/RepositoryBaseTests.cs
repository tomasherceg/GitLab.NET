using System;
using NSubstitute;
using Xunit;

namespace GitLab.NET.Tests
{
    public class RepositoryBaseTests
    {
        private class RepositoryBaseInstance : RepositoryBase
        {
            public IRequestExecutor RestExecutorProp => RequestExecutor;

            public RepositoryBaseInstance(IRequestExecutor restExecutor) : base(restExecutor) { }
        }

        [Fact]
        public void Constructor_RestExecutorIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new RepositoryBaseInstance(null));
        }

        [Fact]
        public void Constructor_RestExecutorNotNull_SetsRestExecutor()
        {
            var sut = new RepositoryBaseInstance(Substitute.For<IRequestExecutor>());

            Assert.NotNull(sut.RestExecutorProp);
        }
    }
}