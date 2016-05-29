using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NSubstitute;
using Xunit;

namespace GitLab.NET.Tests.Repositories
{
    public class RepositoryRepositoryTests
    {
        [Fact]
        public void Compare_FromIsNull_ThrowsArgumentNullException()
        {
            var sut = new RepositoryRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Compare(0, null, "to"));
        }

        [Fact]
        public async Task CompareAsync_FromIsNull_ThrowsArgumentNullException()
        {
            var sut = new RepositoryRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CompareAsync(0, null, "to"));
        }

        [Fact]
        public void Compare_ToIsNull_ThrowsArgumentNullException()
        {
            var sut = new RepositoryRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Compare(0, "from", null));
        }

        [Fact]
        public async Task CompareAsync_ToIsNull_ThrowsArgumentNullException()
        {
            var sut = new RepositoryRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CompareAsync(0, "from", null));
        }

        [Fact]
        public void GetBlobContent_ShaIsNull_ThrowsArgumentNullException()
        {
            var sut = new RepositoryRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.GetBlobContent(0, null));
        }

        [Fact]
        public async Task GetBlobContentAsync_ShaIsNull_ThrowsArgumentNullException()
        {
            var sut = new RepositoryRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.GetBlobContentAsync(0, null));
        }

        [Fact]
        public void GetFileContent_ShaIsNull_ThrowsArgumentNullException()
        {
            var sut = new RepositoryRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.GetFileContent(0, null, "filePath"));
        }

        [Fact]
        public async Task GetFileContentAsync_ShaIsNull_ThrowsArgumentNullException()
        {
            var sut = new RepositoryRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.GetFileContentAsync(0, null, "filePath"));
        }

        [Fact]
        public void GetFileContent_FilePathIsNull_ThrowsArgumentNullException()
        {
            var sut = new RepositoryRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.GetFileContent(0, "sha", null));
        }

        [Fact]
        public async Task GetFileContentAsync_FilePathIsNull_ThrowsArgumentNullException()
        {
            var sut = new RepositoryRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.GetFileContentAsync(0, "sha", null));
        }
    }
}
