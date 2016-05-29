using NSubstitute;
using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using Xunit;

namespace GitLab.NET.Tests.Repositories
{
    public class CommitRepositoryTests
    {
        [Fact]
        public void CreateComment_CommitShaIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.CreateComment(0, null, "note"));
        }

        [Fact]
        public async Task CreateCommentAsync_CommitShaIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateCommentAsync(0, null, "note"));
        }

        [Fact]
        public void CreateComment_NoteIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.CreateComment(0, "commitSha", null));
        }

        [Fact]
        public async Task CreateCommentAsync_NoteIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateCommentAsync(0, "commitSha", null));
        }

        [Fact]
        public void CreateStatus_CommitShaIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.CreateStatus(0, null, "state"));
        }

        [Fact]
        public async Task CreateStatusAsync_CommitShaIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateStatusAsync(0, null, "state"));
        }

        [Fact]
        public void CreateStatus_StateIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.CreateStatus(0, "commitSha", null));
        }

        [Fact]
        public async Task CreateStatusAsync_StateIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateStatusAsync(0, "commitSha", null));
        }

        [Fact]
        public void GetBySha_CommitShaIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.GetBySha(0, null));
        }

        [Fact]
        public async Task GetByShaAsync_CommitShaIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.GetByShaAsync(0, null));
        }

        [Fact]
        public void GetComments_CommitShaIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.GetComments(0, null));
        }

        [Fact]
        public async Task GetCommentsAsync_CommitShaIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.GetCommentsAsync(0, null));
        }

        [Fact]
        public void GetStatus_CommitShaIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.GetStatus(0, null));
        }

        [Fact]
        public async Task GetStatusAsync_CommitShaIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.GetStatusAsync(0, null));
        }

        [Fact]
        public void GetDiff_CommitShaIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.GetDiff(0, null));
        }

        [Fact]
        public async Task GetDiffAsync_CommitShaIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.GetDiffAsync(0, null));
        }

        [Fact]
        public void UpdateStatus_CommitShaIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.UpdateStatus(0, null, "state"));
        }

        [Fact]
        public async Task UpdateStatusAsync_CommitShaIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.UpdateStatusAsync(0, null, "state"));
        }

        [Fact]
        public void UpdateStatus_StateIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.UpdateStatus(0, "commitSha", null));
        }

        [Fact]
        public async Task UpdateStatusAsync_StateIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.UpdateStatusAsync(0, "commitSha", null));
        }
    }
}
