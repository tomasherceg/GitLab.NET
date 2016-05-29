using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GitLab.NET.Tests
{
    public class SystemHookRepositoryTests
    {
        [Fact]
        public void Create_UrlIsNull_ThrowsArgumentNullException()
        {
            var sut = new SystemHookRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Create(null));
        }

        [Fact]
        public async Task CreateAsync_UrlIsNull_ThrowsArgumentNullException()
        {
            var sut = new SystemHookRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateAsync(null));
        }
    }
}
