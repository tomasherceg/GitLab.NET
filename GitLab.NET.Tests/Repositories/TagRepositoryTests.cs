using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NSubstitute;
using Xunit;

namespace GitLab.NET.Tests.Repositories
{
    public class TagRepositoryTests
    {
        [Fact]
        public void Create_RefNameIsNull_ThrowsArgumentNullException()
        {
            var sut = new TagRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Create(0, "tagName", null));
        }

        [Fact]
        public void Create_TagNameIsNull_ThrowsArgumentNullException()
        {
            var sut = new TagRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Create(0, null, "refName"));
        }

        [Fact]
        public async Task CreateAsync_RefNameIsNull_ThrowsArgumentNullException()
        {
            var sut = new TagRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateAsync(0, "tagName", null));
        }

        [Fact]
        public async Task CreateAsync_TagNameIsNull_ThrowsArgumentNullException()
        {
            var sut = new TagRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateAsync(0, null, "refName"));
        }

        [Fact]
        public void CreateRelease_DescriptionIsNull_ThrowsArgumentNullException()
        {
            var sut = new TagRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.CreateRelease(0, "tagName", null));
        }

        [Fact]
        public void CreateRelease_TagNameIsNull_ThrowsArgumentNullException()
        {
            var sut = new TagRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.CreateRelease(0, null, "description"));
        }

        [Fact]
        public async Task CreateReleaseAsync_DescriptionIsNull_ThrowsArgumentNullException()
        {
            var sut = new TagRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateReleaseAsync(0, "tagName", null));
        }

        [Fact]
        public async Task CreateReleaseAsync_TagNameIsNull_ThrowsArgumentNullException()
        {
            var sut = new TagRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateReleaseAsync(0, null, "description"));
        }

        [Fact]
        public void Delete_TagNameIsNull_ThrowsArgumentNullException()
        {
            var sut = new TagRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Delete(0, null));
        }

        [Fact]
        public async Task DeleteAsync_TagNameIsNull_ThrowsArgumentNullException()
        {
            var sut = new TagRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.DeleteAsync(0, null));
        }

        [Fact]
        public void GetByName_TagNameIsNull_ThrowsArgumentNullException()
        {
            var sut = new TagRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.GetByName(0, null));
        }

        [Fact]
        public async Task GetByNameAsync_TagNameIsNull_ThrowsArgumentNullException()
        {
            var sut = new TagRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.GetByNameAsync(0, null));
        }

        [Fact]
        public void UpdateRelease_DescriptionIsNull_ThrowsArgumentNullException()
        {
            var sut = new TagRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.UpdateRelease(0, "tagName", null));
        }

        [Fact]
        public void UpdateRelease_TagNameIsNull_ThrowsArgumentNullException()
        {
            var sut = new TagRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.UpdateRelease(0, null, "description"));
        }

        [Fact]
        public async Task UpdateReleaseAsync_DescriptionIsNull_ThrowsArgumentNullException()
        {
            var sut = new TagRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.UpdateReleaseAsync(0, "tagName", null));
        }

        [Fact]
        public async Task UpdateReleaseAsync_TagNameIsNull_ThrowsArgumentNullException()
        {
            var sut = new TagRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.UpdateReleaseAsync(0, null, "description"));
        }
    }
}