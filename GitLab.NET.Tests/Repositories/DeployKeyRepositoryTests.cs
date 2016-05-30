using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NSubstitute;
using Xunit;

namespace GitLab.NET.Tests.Repositories
{
    public class DeployKeyRepositoryTests
    {
        private readonly IRequest _request;
        private readonly IRequestFactory _requestFactory;

        public DeployKeyRepositoryTests()
        {
            _request = Substitute.For<IRequest>();
            _requestFactory = Substitute.For<IRequestFactory>();
            _requestFactory.Create(Arg.Any<string>(), Arg.Any<Method>(), Arg.Any<bool>()).Returns(_request);
        }

        #region Create
        [Fact]
        public void Create_TitleIsNull_ThrowsArgumentNullException()
        {
            var sut = new DeployKeyRepository(_requestFactory);

            Assert.Throws<ArgumentNullException>(() => sut.Create(0, null, "key"));
        }

        [Fact]
        public void Create_KeyIsNull_ThrowsArgumentNullException()
        {
            var sut = new DeployKeyRepository(_requestFactory);

            Assert.Throws<ArgumentNullException>(() => sut.Create(0, "title", null));
        }

        [Fact]
        public void Create_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new DeployKeyRepository(_requestFactory);

            sut.Create(expected, "title", "key");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public void Create_ValidParameters_AddsTitleParameter()
        {
            const string expected = "title";
            var sut = new DeployKeyRepository(_requestFactory);

            sut.Create(0, expected, "key");

            _request.Received().AddParameter("title", expected);
        }

        [Fact]
        public void Create_ValidParameters_AddsKeyParameter()
        {
            const string expected = "key";
            var sut = new DeployKeyRepository(_requestFactory);

            sut.Create(0, "title", expected);

            _request.Received().AddParameter("key", expected);
        }

        [Fact]
        public void Create_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new DeployKeyRepository(_requestFactory);

            sut.Create(0, "title", "key");

            _requestFactory.Received().Create("projects/{projectId}/keys", Method.Post);
        }

        [Fact]
        public async Task CreateAsync_TitleIsNull_ThrowsArgumentNullException()
        {
            var sut = new DeployKeyRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateAsync(0, null, "key"));
        }

        [Fact]
        public async Task CreateAsync_KeyIsNull_ThrowsArgumentNullException()
        {
            var sut = new DeployKeyRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateAsync(0, "title", null));
        }

        [Fact]
        public async Task CreateAsync_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new DeployKeyRepository(_requestFactory);

            await sut.CreateAsync(expected, "title", "key");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task CreateAsync_ValidParameters_AddsTitleParameter()
        {
            const string expected = "title";
            var sut = new DeployKeyRepository(_requestFactory);

            await sut.CreateAsync(0, expected, "key");

            _request.Received().AddParameter("title", expected);
        }

        [Fact]
        public async Task CreateAsync_ValidParameters_AddsKeyParameter()
        {
            const string expected = "key";
            var sut = new DeployKeyRepository(_requestFactory);

            await sut.CreateAsync(0, "title", expected);

            _request.Received().AddParameter("key", expected);
        }

        [Fact]
        public async Task CreateAsync_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new DeployKeyRepository(_requestFactory);

            await sut.CreateAsync(0, "title", "key");

            _requestFactory.Received().Create("projects/{projectId}/keys", Method.Post);
        }
        #endregion

        #region Delete
        [Fact]
        public void Delete_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new DeployKeyRepository(_requestFactory);

            sut.Delete(expected, 0);

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public void Delete_ValidParameters_AddsKeyIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new DeployKeyRepository(_requestFactory);

            sut.Delete(0, expected);

            _request.Received().AddUrlSegment("keyId", expected);
        }

        [Fact]
        public void Delete_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new DeployKeyRepository(_requestFactory);

            sut.Delete(0, 0);

            _requestFactory.Received().Create("projects/{projectId}/keys/{keyId}", Method.Delete);
        }

        [Fact]
        public async Task DeleteAsync_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new DeployKeyRepository(_requestFactory);

            await sut.DeleteAsync(expected, 0);

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task DeleteAsync_ValidParameters_AddsKeyIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new DeployKeyRepository(_requestFactory);

            await sut.DeleteAsync(0, expected);

            _request.Received().AddUrlSegment("keyId", expected);
        }

        [Fact]
        public async Task DeleteAsync_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new DeployKeyRepository(_requestFactory);

            await sut.DeleteAsync(0, 0);

            _requestFactory.Received().Create("projects/{projectId}/keys/{keyId}", Method.Delete);
        }
        #endregion

        #region Find
        [Fact]
        public void Find_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new DeployKeyRepository(_requestFactory);

            sut.Find(expected, 0);

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public void Find_ValidParameters_AddsKeyIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new DeployKeyRepository(_requestFactory);

            sut.Find(0, expected);

            _request.Received().AddUrlSegment("keyId", expected);
        }

        [Fact]
        public void Find_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new DeployKeyRepository(_requestFactory);

            sut.Find(0, 0);

            _requestFactory.Received().Create("projects/{projectId}/keys/{keyId}", Method.Get);
        }

        [Fact]
        public async Task FindAsync_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new DeployKeyRepository(_requestFactory);

            await sut.FindAsync(expected, 0);

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task FindAsync_ValidParameters_AddsKeyIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new DeployKeyRepository(_requestFactory);

            await sut.FindAsync(0, expected);

            _request.Received().AddUrlSegment("keyId", expected);
        }

        [Fact]
        public async Task FindAsync_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new DeployKeyRepository(_requestFactory);

            await sut.FindAsync(0, 0);

            _requestFactory.Received().Create("projects/{projectId}/keys/{keyId}", Method.Get);
        }
        #endregion

        #region GetAll
        [Fact]
        public void GetAll_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new DeployKeyRepository(_requestFactory);

            sut.GetAll(expected);

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public void GetAll_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new DeployKeyRepository(_requestFactory);

            sut.GetAll(0);

            _requestFactory.Received().Create("projects/{projectId}/keys", Method.Get);
        }

        [Fact]
        public async Task GetAllAsync_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new DeployKeyRepository(_requestFactory);

            await sut.GetAllAsync(expected);

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task GetAllAsync_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new DeployKeyRepository(_requestFactory);

            await sut.GetAllAsync(0);

            _requestFactory.Received().Create("projects/{projectId}/keys", Method.Get);
        }
        #endregion
    }
}
