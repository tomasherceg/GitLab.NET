using System;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;

namespace GitLab.NET.Tests
{
    public class NamespaceRepositoryTests
    {
        [Fact]
        public void Search_SearchIsNull_ThrowsArgumentNullException()
        {
            var sut = new NamespaceRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Search(null));
        }

        [Fact]
        public async Task SearchAsync_SearchIsNull_ThrowsArgumentNullException()
        {
            var sut = new NamespaceRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.SearchAsync(null));
        }
    }
}