using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GitLab.NET.Tests
{
    public class DeployKeyRepositoryTests
    {
        [Fact]
        public void Create_TitleIsNull_ThrowsArgumentNullException()
        {
            var sut = new DeployKeyRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Create(0, null, "key"));
        }

        [Fact]
        public async Task CreateAsync_TitleIsNull_ThrowsArgumentNullException()
        {
            var sut = new DeployKeyRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateAsync(0, null, "key"));
        }

        [Fact]
        public void Create_KeyIsNull_ThrowsArgumentNullException()
        {
            var sut = new DeployKeyRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Create(0, "title", null));
        }

        [Fact]
        public async Task CreateAsync_KeyIsNull_ThrowsArgumentNullException()
        {
            var sut = new DeployKeyRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateAsync(0, "title", null));
        }
    }
}
