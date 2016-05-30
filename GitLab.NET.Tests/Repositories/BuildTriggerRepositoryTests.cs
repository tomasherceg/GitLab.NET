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
            const uint expected = 0;
            var sut = new BuildTriggerRepository(_requestFactory);

            sut.Create(expected);

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public void Create_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildTriggerRepository(_requestFactory);

            sut.Create(0);

            _requestFactory.Received().Create("projects/{projectId}/triggers", Method.Post);
        }

        [Fact]
        public async Task CreateAsync_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new BuildTriggerRepository(_requestFactory);

            await sut.CreateAsync(expected);

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task CreateAsync_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildTriggerRepository(_requestFactory);

            await sut.CreateAsync(0);

            _requestFactory.Received().Create("projects/{projectId}/triggers", Method.Post);
        }
        #endregion

        #region Delete
        [Fact]
        public void Delete_TokenIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildTriggerRepository(_requestFactory);

            Assert.Throws<ArgumentNullException>(() => sut.Delete(0, null));
        }

        [Fact]
        public void Delete_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new BuildTriggerRepository(_requestFactory);

            sut.Delete(expected, "token");

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
        public void Delete_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildTriggerRepository(_requestFactory);

            sut.Delete(0, "token");

            _requestFactory.Received().Create("projects/{projectId}/triggers/{token}", Method.Delete);
        }

        [Fact]
        public async Task DeleteAsync_TokenIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildTriggerRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.DeleteAsync(0, null));
        }

        [Fact]
        public async Task DeleteAsync_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new BuildTriggerRepository(_requestFactory);

            await sut.DeleteAsync(expected, "token");

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

        [Fact]
        public async Task DeleteAsync_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildTriggerRepository(_requestFactory);

            await sut.DeleteAsync(0, "token");

            _requestFactory.Received().Create("projects/{projectId}/triggers/{token}", Method.Delete);
        }
        #endregion

        #region Find
        [Fact]
        public void Find_TokenIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildTriggerRepository(_requestFactory);

            Assert.Throws<ArgumentNullException>(() => sut.Find(0, null));
        }

        [Fact]
        public void Find_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new BuildTriggerRepository(_requestFactory);

            sut.Find(expected, "token");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public void Find_ValidParameters_AddsTokenUrlSegment()
        {
            const string expected = "token";
            var sut = new BuildTriggerRepository(_requestFactory);

            sut.Find(0, expected);

            _request.Received().AddUrlSegment("token", expected);
        }

        [Fact]
        public void Find_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildTriggerRepository(_requestFactory);

            sut.Find(0, "token");

            _requestFactory.Received().Create("projects/{projectId}/triggers/{token}", Method.Get);
        }

        [Fact]
        public async Task FindAsync_TokenIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildTriggerRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.FindAsync(0, null));
        }

        [Fact]
        public async Task FindAsync_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new BuildTriggerRepository(_requestFactory);

            await sut.FindAsync(expected, "token");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task FindAsync_ValidParameters_AddsTokenUrlSegment()
        {
            const string expected = "token";
            var sut = new BuildTriggerRepository(_requestFactory);

            await sut.FindAsync(0, expected);

            _request.Received().AddUrlSegment("token", expected);
        }

        [Fact]
        public async Task FindAsync_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildTriggerRepository(_requestFactory);

            await sut.FindAsync(0, "token");

            _requestFactory.Received().Create("projects/{projectId}/triggers/{token}", Method.Get);
        }
        #endregion

        #region GetAll
        [Fact]
        public void GetAll_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new BuildTriggerRepository(_requestFactory);

            sut.GetAll(expected);

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public void GetAll_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildTriggerRepository(_requestFactory);

            sut.GetAll(0);

            _requestFactory.Received().Create("projects/{projectId}/triggers", Method.Get);
        }

        [Fact]
        public async Task GetAllAsync_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new BuildTriggerRepository(_requestFactory);

            await sut.GetAllAsync(expected);

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task GetAllAsync_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildTriggerRepository(_requestFactory);

            await sut.GetAllAsync(0);

            _requestFactory.Received().Create("projects/{projectId}/triggers", Method.Get);
        }
        #endregion
    }
}
