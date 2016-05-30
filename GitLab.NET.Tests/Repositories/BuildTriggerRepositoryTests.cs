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
        private readonly IRequest _request;
        private readonly IRequestFactory _requestFactory;

        public BuildTriggerRepositoryTests()
        {
            _request = Substitute.For<IRequest>();
            _requestFactory = Substitute.For<IRequestFactory>();
            _requestFactory.Create(Arg.Any<string>(), Arg.Any<Method>(), Arg.Any<bool>()).Returns(_request);
        }

        #region Create
        [Fact]
        public void Create_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 5;
            var sut = new BuildTriggerRepository(_requestFactory);

            sut.Create(expected);

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task CreateAsync_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 5;
            var sut = new BuildTriggerRepository(_requestFactory);

            await sut.CreateAsync(expected);

            _request.Received().AddUrlSegment("projectId", expected);
        }
        #endregion

        #region Delete
        [Fact]
        public void Delete_TokenIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildTriggerRepository(Substitute.For<IRequestFactory>());

            Assert.Throws<ArgumentNullException>(() => sut.Delete(0, null));
        }

        [Fact]
        public void Delete_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 5;
            var sut = new BuildTriggerRepository(_requestFactory);

            sut.Delete(expected, Arg.Any<string>());

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public void Delete_ValidParameters_AddsTokenUrlSegment()
        {
            const string expected = "token";
            var sut = new BuildTriggerRepository(_requestFactory);

            sut.Delete(0, expected);

            _request.Received().AddUrlSegment("token", expected);
        }

        [Fact]
        public async Task DeleteAsync_TokenIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildTriggerRepository(Substitute.For<IRequestFactory>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.DeleteAsync(0, null));
        }

        [Fact]
        public async Task DeleteAsync_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 5;
            var sut = new BuildTriggerRepository(_requestFactory);

            await sut.DeleteAsync(expected, Arg.Any<string>());

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task DeleteAsync_ValidParameters_AddsTokenUrlSegment()
        {
            const string expected = "token";
            var sut = new BuildTriggerRepository(_requestFactory);

            await sut.DeleteAsync(0, expected);

            _request.Received().AddUrlSegment("token", expected);
        }
        #endregion

        #region GetAll
        [Fact]
        public void GetAll_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 5;
            var sut = new BuildTriggerRepository(_requestFactory);

            sut.GetAll(expected);

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task GetAllAsync_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 5;
            var sut = new BuildTriggerRepository(_requestFactory);

            await sut.GetAllAsync(expected);

            _request.Received().AddUrlSegment("projectId", expected);
        }
        #endregion

        #region Get
        [Fact]
        public void Get_TokenIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildTriggerRepository(Substitute.For<IRequestFactory>());

            Assert.Throws<ArgumentNullException>(() => sut.Get(0, null));
        }

        [Fact]
        public void Get_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 5;
            var sut = new BuildTriggerRepository(_requestFactory);

            sut.Get(expected, Arg.Any<string>());

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public void Get_ValidParameters_AddsTokenUrlSegment()
        {
            const string expected = "token";
            var sut = new BuildTriggerRepository(_requestFactory);

            sut.Get(Arg.Any<uint>(), expected);

            _request.Received().AddUrlSegment("token", expected);
        }

        [Fact]
        public async Task GetAsync_TokenIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildTriggerRepository(Substitute.For<IRequestFactory>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.GetAsync(0, null));
        }

        [Fact]
        public async Task GetAsync_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 5;
            var sut = new BuildTriggerRepository(_requestFactory);

            await sut.GetAsync(expected, Arg.Any<string>());

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task GetAsync_ValidParameters_AddsTokenUrlSegment()
        {
            const string expected = "token";
            var sut = new BuildTriggerRepository(_requestFactory);

            await sut.GetAsync(Arg.Any<uint>(), expected);

            _request.Received().AddUrlSegment("token", expected);
        }
        #endregion
    }
}
