using NSubstitute;
using System;
using System.Threading.Tasks;
using GitLab.NET.ResponseModels;
using Xunit;

namespace GitLab.NET.Tests
{
    public class ProjectSnippetRepositoryTests
    {
        [Fact]
        public void Create_TitleIsNull_ThrowsArgumentNullException()
        {
            var sut = new ProjectSnippetRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Create(0, null, "fileName", "code", VisibilityLevel.Public));
        }

        [Fact]
        public async Task CreateAsync_TitleIsNull_ThrowsArgumentNullException()
        {
            var sut = new ProjectSnippetRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateAsync(0, null, "fileName", "code", VisibilityLevel.Public));
        }

        [Fact]
        public void Create_FileNameIsNull_ThrowsArgumentNullException()
        {
            var sut = new ProjectSnippetRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Create(0, "title", null, "code", VisibilityLevel.Public));
        }

        [Fact]
        public async Task CreateAsync_FileNameIsNull_ThrowsArgumentNullException()
        {
            var sut = new ProjectSnippetRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateAsync(0, "title", null, "code", VisibilityLevel.Public));
        }

        [Fact]
        public void Create_CodeIsNull_ThrowsArgumentNullException()
        {
            var sut = new ProjectSnippetRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Create(0, "title", "fileName", null, VisibilityLevel.Public));
        }

        [Fact]
        public async Task CreateAsync_CodeIsNull_ThrowsArgumentNullException()
        {
            var sut = new ProjectSnippetRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateAsync(0, "title", "fileName", null, VisibilityLevel.Public));
        }
    }
}
