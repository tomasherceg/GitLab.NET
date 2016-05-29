using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NSubstitute;
using Xunit;

namespace GitLab.NET.Tests.Repositories
{
    public class BuildTriggerRepositoryTests
    {
        [Fact]
        public void GetById_TokenIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildTriggerRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.GetById(0, null));
        }

        [Fact]
        public async Task GetByIdAsync_TokenIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildTriggerRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.GetByIdAsync(0, null));
        }

        [Fact]
        public void Delete_TokenIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildTriggerRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Delete(0, null));
        }

        [Fact]
        public async Task DeleteAsync_TokenIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildTriggerRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.DeleteAsync(0, null));
        }
    }
}
