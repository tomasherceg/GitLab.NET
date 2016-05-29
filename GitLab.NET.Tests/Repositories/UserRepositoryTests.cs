using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NSubstitute;
using Xunit;

namespace GitLab.NET.Tests.Repositories
{
    public class UserRepositoryTests
    {
        [Fact]
        public void Create_EmailIsNull_ThrowsArgumentNullException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Create(null, "password", "username", "name"));
        }

        [Fact]
        public void Create_NameIsNull_ThrowsArgumentNullException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Create("email", "password", "username", null));
        }

        [Fact]
        public void Create_PasswordIsNull_ThrowsArgumentNullException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Create("email", null, "username", "name"));
        }

        [Fact]
        public void Create_UsernameIsNull_ThrowsArgumentNullException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Create("email", "password", null, "name"));
        }

        [Fact]
        public async Task CreateAsync_EmailIsNull_ThrowsArgumentNullException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateAsync(null, "password", "username", "name"));
        }

        [Fact]
        public async Task CreateAsync_NameIsNull_ThrowsArgumentNullException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateAsync("email", "password", "username", null));
        }

        [Fact]
        public async Task CreateAsync_PasswordIsNull_ThrowsArgumentNullException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateAsync("email", null, "username", "name"));
        }

        [Fact]
        public async Task CreateAsync_UsernameIsNull_ThrowsArgumentNullException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateAsync("email", "password", null, "name"));
        }

        [Fact]
        public void GetAll_PageIsLessThanDefault_ThrowsArgumentOutOfRangeException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.GetAll(0));
        }

        [Fact]
        public void GetAll_ResultsPerPageIsGreaterThanMinimum_ThrowsArgumentOutOfRangeException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.GetAll(resultsPerPage: uint.MaxValue));
        }

        [Fact]
        public void GetAll_ResultsPerPageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.GetAll(resultsPerPage: 0));
        }

        [Fact]
        public async Task GetAllAsync_PageIsLessThanDefault_ThrowsArgumentOutOfRangeException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.GetAllAsync(0));
        }

        [Fact]
        public async Task GetAllAsync_ResultsPerPageIsGreaterThanMinimum_ThrowsArgumentOutOfRangeException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.GetAllAsync(resultsPerPage: uint.MaxValue));
        }

        [Fact]
        public async Task GetAllAsync_ResultsPerPageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.GetAllAsync(resultsPerPage: 0));
        }

        [Fact]
        public void GetByUsername_UsernameIsNull_ThrowsArgumentNullException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.GetByUsername(null));
        }

        [Fact]
        public async Task GetByUsernameAsync_UsernameIsNull_ThrowsArgumentNullException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.GetByUsernameAsync(null));
        }

        [Fact]
        public void Search_PageIsLessThanDefault_ThrowsArgumentOutOfRangeException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.Search("searchQuery", 0));
        }

        [Fact]
        public void Search_ResultsPerPageIsGreaterThanMinimum_ThrowsArgumentOutOfRangeException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.Search("searchQuery", resultsPerPage: uint.MaxValue));
        }

        [Fact]
        public void Search_ResultsPerPageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.Search("searchQuery", resultsPerPage: 0));
        }

        [Fact]
        public void Search_SearchQueryIsNull_ThrowsArgumentNullException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Search(null));
        }

        [Fact]
        public async Task SearchAsync_PageIsLessThanDefault_ThrowsArgumentOutOfRangeException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.SearchAsync("searchQuery", 0));
        }

        [Fact]
        public async Task SearchAsync_ResultsPerPageIsGreaterThanMinimum_ThrowsArgumentOutOfRangeException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.SearchAsync("searchQuery", resultsPerPage: uint.MaxValue));
        }

        [Fact]
        public async Task SearchAsync_ResultsPerPageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.SearchAsync("searchQuery", resultsPerPage: 0));
        }

        [Fact]
        public async Task SearchAsync_SearchQueryIsNull_ThrowsArgumentNullException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.SearchAsync(null));
        }
    }
}