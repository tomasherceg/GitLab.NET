using System;
using System.Threading.Tasks;
using GitLab.NET.RequestModels;
using GitLab.NET.ResponseModels;
using NSubstitute;
using RestSharp;
using RestSharp.Authenticators;
using Xunit;

namespace GitLab.NET.Tests
{
    public class UserRepositoryTests
    {
        [Fact]
        public void FindByUsername_UsernameIsNull_ThrowsArgumentNullException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.FindByUsername(null));
        }

        [Fact]
        public async Task FindByUsernameAsync_UsernameIsNull_ThrowsArgumentNullException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.FindByUsernameAsync(null));
        }

        [Fact]
        public void GetAll_PageIsLessThanDefault_ThrowsArgumentOutOfRangeException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.GetAll(page: 0));
        }

        [Fact]
        public async Task GetAllAsync_PageIsLessThanDefault_ThrowsArgumentOutOfRangeException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.GetAllAsync(page: 0));
        }

        [Fact]
        public void GetAll_ResultsPerPageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.GetAll(resultsPerPage: 0));
        }

        [Fact]
        public async Task GetAllAsync_ResultsPerPageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.GetAllAsync(resultsPerPage: 0));
        }

        [Fact]
        public void GetAll_ResultsPerPageIsGreaterThanMinimum_ThrowsArgumentOutOfRangeException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.GetAll(resultsPerPage: uint.MaxValue));
        }

        [Fact]
        public async Task GetAllAsync_ResultsPerPageIsGreaterThanMinimum_ThrowsArgumentOutOfRangeException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.GetAllAsync(resultsPerPage: uint.MaxValue));
        }

        [Fact]
        public void Search_SearchQueryIsNull_ThrowsArgumentNullException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Search(null));
        }

        [Fact]
        public void Search_PageIsLessThanDefault_ThrowsArgumentOutOfRangeException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.Search("searchQuery", page: 0));
        }

        [Fact]
        public void Search_ResultsPerPageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.Search("searchQuery", resultsPerPage: 0));
        }

        [Fact]
        public void Search_ResultsPerPageIsGreaterThanMinimum_ThrowsArgumentOutOfRangeException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.Search("searchQuery", resultsPerPage: uint.MaxValue));
        }

        [Fact]
        public async Task SearchAsync_SearchQueryIsNull_ThrowsArgumentNullException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.SearchAsync(null));
        }

        [Fact]
        public async Task SearchAsync_PageIsLessThanDefault_ThrowsArgumentOutOfRangeException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.SearchAsync("searchQuery", page: 0));
        }

        [Fact]
        public async Task SearchAsync_ResultsPerPageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.SearchAsync("searchQuery", resultsPerPage: 0));
        }

        [Fact]
        public async Task SearchAsync_ResultsPerPageIsGreaterThanMinimum_ThrowsArgumentOutOfRangeException()
        {
            var sut = new UserRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.SearchAsync("searchQuery", resultsPerPage: uint.MaxValue));
        }
    }
}