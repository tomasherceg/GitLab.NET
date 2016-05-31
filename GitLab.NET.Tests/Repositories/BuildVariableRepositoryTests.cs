using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NSubstitute;
using Xunit;

namespace GitLab.NET.Tests.Repositories
{
    public class BuildVariableRepositoryTests
    {
        private readonly IRequest _request;
        private readonly IRequestFactory _requestFactory;

        public BuildVariableRepositoryTests()
        {
            _request = Substitute.For<IRequest>();
            _requestFactory = Substitute.For<IRequestFactory>();
            _requestFactory.Create(Arg.Any<string>(), Arg.Any<Method>(), Arg.Any<bool>()).Returns(_request);
        }

        #region Create
        [Fact]
        public async Task Create_KeyIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Create(0, null, "value"));
        }

        [Fact]
        public async Task Create_ValueIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Create(0, "key", null));
        }

        [Fact]
        public async Task Create_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.Create(expected, "key", "value");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task Create_ValidParameters_AddsKeyParameter()
        {
            const string expected ="key";
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.Create(0, expected, "value");

            _request.Received().AddParameter("key", expected);
        }

        [Fact]
        public async Task Create_ValidParameters_AddsValueParameter()
        {
            const string expected = "value";
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.Create(0, "key", expected);

            _request.Received().AddParameter("value", expected);
        }

        [Fact]
        public async Task Create_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.Create(0, "key", "value");

            _requestFactory.Received().Create("projects/{projectId}/variables", Method.Post);
        }
        #endregion

        #region Delete
        [Fact]
        public async Task Delete_KeyIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Delete(0, null));
        }

        [Fact]
        public async Task Delete_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.Delete(expected, "key");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task Delete_ValidParameters_AddsKeyUrlSegment()
        {
            const string expected = "key";
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.Delete(0, expected);

            _request.Received().AddUrlSegment("key", expected);
        }

        [Fact]
        public async Task Delete_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.Delete(0, "key");

            _requestFactory.Received().Create("projects/{projectId}/variables/{key}", Method.Delete);
        }
        #endregion

        #region Find
        [Fact]
        public async Task Find_KeyIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Find(0, null));
        }

        [Fact]
        public async Task Find_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.Find(expected, "key");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task Find_ValidParameters_AddsKeyUrlSegment()
        {
            const string expected = "key";
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.Find(0, expected);

            _request.Received().AddUrlSegment("key", expected);
        }

        [Fact]
        public async Task Find_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.Find(0, "key");

            _requestFactory.Received().Create("projects/{projectId}/variables/{key}", Method.Get);
        }
        #endregion
        
        #region GetAll
        [Fact]
        public async Task GetAll_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.GetAll(expected);

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task GetAll_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.GetAll(0);

            _requestFactory.Received().Create("projects/{projectId}/variables", Method.Get);
        }
        #endregion

        #region Update
        [Fact]
        public async Task Update_KeyIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Update(0, null, "value"));
        }

        [Fact]
        public async Task Update_ValueIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Update(0, "key", null));
        }

        [Fact]
        public async Task Update_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.Update(expected, "key", "value");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task Update_ValidParameters_AddsKeyUrlSegment()
        {
            const string expected = "key";
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.Update(0, expected, "value");

            _request.Received().AddUrlSegment("key", expected);
        }

        [Fact]
        public async Task Update_ValidParameters_AddsValueParameter()
        {
            const string expected = "value";
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.Update(0, "key", expected);

            _request.Received().AddParameter("value", expected);
        }

        [Fact]
        public async Task Update_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.Update(0, "key", "value");

            _requestFactory.Received().Create("projects/{projectId}/variables/{key}", Method.Put);
        }
        #endregion
    }
}
