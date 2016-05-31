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
        public async Task Create_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new BuildTriggerRepository(_requestFactory);

            await sut.Create(expected);

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task Create_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildTriggerRepository(_requestFactory);

            await sut.Create(0);

            _requestFactory.Received().Create("projects/{projectId}/triggers", Method.Post);
        }
        #endregion

        #region Delete
        [Fact]
        public async Task Delete_TokenIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildTriggerRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Delete(0, null));
        }

        [Fact]
        public async Task Delete_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new BuildTriggerRepository(_requestFactory);

            await sut.Delete(expected, "token");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task Delete_ValidParameters_AddsTokenUrlSegment()
        {
            const string expected = "token";
            var sut = new BuildTriggerRepository(_requestFactory);

            await sut.Delete(0, expected);

            _request.Received().AddUrlSegment("token", expected);
        }

        [Fact]
        public async Task Delete_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildTriggerRepository(_requestFactory);

            await sut.Delete(0, "token");

            _requestFactory.Received().Create("projects/{projectId}/triggers/{token}", Method.Delete);
        }
        #endregion

        #region Find
        [Fact]
        public async Task Find_TokenIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildTriggerRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Find(0, null));
        }

        [Fact]
        public async Task Find_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new BuildTriggerRepository(_requestFactory);

            await sut.Find(expected, "token");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task Find_ValidParameters_AddsTokenUrlSegment()
        {
            const string expected = "token";
            var sut = new BuildTriggerRepository(_requestFactory);

            await sut.Find(0, expected);

            _request.Received().AddUrlSegment("token", expected);
        }

        [Fact]
        public async Task Find_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildTriggerRepository(_requestFactory);

            await sut.Find(0, "token");

            _requestFactory.Received().Create("projects/{projectId}/triggers/{token}", Method.Get);
        }
        #endregion

        #region GetAll
        [Fact]
        public async Task GetAll_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new BuildTriggerRepository(_requestFactory);

            await sut.GetAll(expected);

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task GetAll_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildTriggerRepository(_requestFactory);

            await sut.GetAll(0);

            _requestFactory.Received().Create("projects/{projectId}/triggers", Method.Get);
        }
        #endregion
    }
}
