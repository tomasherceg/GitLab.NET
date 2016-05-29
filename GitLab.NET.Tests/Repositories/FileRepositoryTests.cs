using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NSubstitute;
using NSubstitute.Exceptions;
using Xunit;

namespace GitLab.NET.Tests.Repositories
{
    public class FileRepositoryTests
    {
        [Fact]
        public void Create_FilePathIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Create(0, null, "branchName", "content", "commitMessage"));
        }

        [Fact]
        public async Task CreateAsync_FilePathIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateAsync(0, null, "branchName", "content", "commitMessage"));
        }

        [Fact]
        public void Delete_FilePathIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Delete(0, null, "branchName", "commitMessage"));
        }

        [Fact]
        public async Task DeleteAsync_FilePathIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.DeleteAsync(0, null, "branchName", "commitMessage"));
        }

        [Fact]
        public void Delete_BranchNameIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Delete(0, "filePath", null, "commitMessage"));
        }

        [Fact]
        public async Task DeleteAsync_BranchNameIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.DeleteAsync(0, "filePath", null, "commitMessage"));
        }

        [Fact]
        public void Delete_CommitMessageIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Delete(0, "filePath", "branchName", null));
        }

        [Fact]
        public async Task DeleteAsync_CommitMessageIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.DeleteAsync(0, "filePath", "branchName", null));
        }

        [Fact]
        public void Create_BranchNameIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Create(0, "filePath", null, "content", "commitMessage"));
        }

        [Fact]
        public async Task CreateAsync_BranchNameIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateAsync(0, "filePath", null, "content", "commitMessage"));
        }

        [Fact]
        public void Create_ContentIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Create(0, "filePath", "branchName", null, "commitMessage"));
        }

        [Fact]
        public async Task CreateAsync_ContentIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateAsync(0, "filePath", "branchName", null, "commitMessage"));
        }

        [Fact]
        public void Create_CommitMessageIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Create(0, "filePath", "branchName", "content", null));
        }

        [Fact]
        public async Task CreateAsync_CommitMessageIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateAsync(0, "filePath", "branchName", "content", null));
        }

        [Fact]
        public void GetByPath_FilePathIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Get(0, null, "refName"));
        }

        [Fact]
        public void GetByPath_RefNameIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Get(0, "filePath", null));
        }

        [Fact]
        public async Task GetByPathAsync_FilePathIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.GetAsync(0, null, "refName"));
        }

        [Fact]
        public async Task GetByPathAsync_RefNameIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.GetAsync(0, "fiePath", null));
        }

        [Fact]
        public void Update_FilePathIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Update(0, null, "branchName", "content", "commitMessage"));
        }

        [Fact]
        public async Task UpdateAsync_FilePathIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.UpdateAsync(0, null, "branchName", "content", "commitMessage"));
        }

        [Fact]
        public void Update_BranchNameIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Update(0, "filePath", null, "content", "commitMessage"));
        }

        [Fact]
        public async Task UpdateAsync_BranchNameIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.UpdateAsync(0, "filePath", null, "content", "commitMessage"));
        }

        [Fact]
        public void Update_ContentIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Update(0, "filePath", "branchName", null, "commitMessage"));
        }

        [Fact]
        public async Task UpdateAsync_ContentIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.UpdateAsync(0, "filePath", "branchName", null, "commitMessage"));
        }

        [Fact]
        public void Update_CommitMessageIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Update(0, "filePath", "branchName", "content", null));
        }

        [Fact]
        public async Task UpdateAsync_CommitMessageIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.UpdateAsync(0, "filePath", "branchName", "content", null));
        }
    }
}