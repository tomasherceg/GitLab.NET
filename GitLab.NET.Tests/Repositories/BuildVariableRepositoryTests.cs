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
        public void Create_KeyIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            Assert.Throws<ArgumentNullException>(() => sut.Create(0, null, "value"));
        }

        [Fact]
        public void Create_ValueIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            Assert.Throws<ArgumentNullException>(() => sut.Create(0, "key", null));
        }

        [Fact]
        public void Create_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new BuildVariableRepository(_requestFactory);

            sut.Create(expected, "key", "value");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public void Create_ValidParameters_AddsKeyParameter()
        {
            const string expected ="key";
            var sut = new BuildVariableRepository(_requestFactory);

            sut.Create(0, expected, "value");

            _request.Received().AddParameter("key", expected);
        }

        [Fact]
        public void Create_ValidParameters_AddsValueParameter()
        {
            const string expected = "value";
            var sut = new BuildVariableRepository(_requestFactory);

            sut.Create(0, "key", expected);

            _request.Received().AddParameter("value", expected);
        }

        [Fact]
        public void Create_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            sut.Create(0, "key", "value");

            _requestFactory.Received().Create("projects/{projectId}/variables", Method.Post);
        }

        [Fact]
        public async Task CreateAsync_KeyIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateAsync(0, null, "value"));
        }

        [Fact]
        public async Task CreateAsync_ValueIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateAsync(0, "key", null));
        }

        [Fact]
        public async Task CreateAsync_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.CreateAsync(expected, "key", "value");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task CreateAsync_ValidParameters_AddsKeyParameter()
        {
            const string expected = "key";
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.CreateAsync(0, expected, "value");

            _request.Received().AddParameter("key", expected);
        }

        [Fact]
        public async Task CreateAsync_ValidParameters_AddsValueParameter()
        {
            const string expected = "value";
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.CreateAsync(0, "key", expected);

            _request.Received().AddParameter("value", expected);
        }

        [Fact]
        public async Task CreateAsync_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.CreateAsync(0, "key", "value");

            _requestFactory.Received().Create("projects/{projectId}/variables", Method.Post);
        }
        #endregion

        #region Delete
        [Fact]
        public void Delete_KeyIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            Assert.Throws<ArgumentNullException>(() => sut.Delete(0, null));
        }

        [Fact]
        public void Delete_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new BuildVariableRepository(_requestFactory);

            sut.Delete(expected, "key");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public void Delete_ValidParameters_AddsKeyUrlSegment()
        {
            const string expected = "key";
            var sut = new BuildVariableRepository(_requestFactory);

            sut.Delete(0, expected);

            _request.Received().AddUrlSegment("key", expected);
        }

        [Fact]
        public void Delete_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            sut.Delete(0, "key");

            _requestFactory.Received().Create("projects/{projectId}/variables/{key}", Method.Delete);
        }

        [Fact]
        public async Task DeleteAsync_KeyIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.DeleteAsync(0, null));
        }

        [Fact]
        public async Task DeleteAsync_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.DeleteAsync(expected, "key");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task DeleteAsync_ValidParameters_AddsKeyUrlSegment()
        {
            const string expected = "key";
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.DeleteAsync(0, expected);

            _request.Received().AddUrlSegment("key", expected);
        }

        [Fact]
        public async Task DeleteAsync_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.DeleteAsync(0, "key");

            _requestFactory.Received().Create("projects/{projectId}/variables/{key}", Method.Delete);
        }
        #endregion

        #region Find
        [Fact]
        public void Find_KeyIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            Assert.Throws<ArgumentNullException>(() => sut.Find(0, null));
        }

        [Fact]
        public void Find_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new BuildVariableRepository(_requestFactory);

            sut.Find(expected, "key");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public void Find_ValidParameters_AddsKeyUrlSegment()
        {
            const string expected = "key";
            var sut = new BuildVariableRepository(_requestFactory);

            sut.Find(0, expected);

            _request.Received().AddUrlSegment("key", expected);
        }

        [Fact]
        public void Find_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            sut.Find(0, "key");

            _requestFactory.Received().Create("projects/{projectId}/variables/{key}", Method.Get);
        }

        [Fact]
        public async Task FindAsync_KeyIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.FindAsync(0, null));
        }

        [Fact]
        public async Task FindAsync_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.FindAsync(expected, "key");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task FindAsync_ValidParameters_AddsKeyUrlSegment()
        {
            const string expected = "key";
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.FindAsync(0, expected);

            _request.Received().AddUrlSegment("key", expected);
        }

        [Fact]
        public async Task FindAsync_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.FindAsync(0, "key");

            _requestFactory.Received().Create("projects/{projectId}/variables/{key}", Method.Get);
        }
        #endregion
        
        #region GetAll
        [Fact]
        public void GetAll_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new BuildVariableRepository(_requestFactory);

            sut.GetAll(expected);

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public void GetAll_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            sut.GetAll(0);

            _requestFactory.Received().Create("projects/{projectId}/variables", Method.Get);
        }

        [Fact]
        public async Task GetAllAsync_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.GetAllAsync(expected);

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task GetAllAsync_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.GetAllAsync(0);

            _requestFactory.Received().Create("projects/{projectId}/variables", Method.Get);
        }
        #endregion

        #region Update
        [Fact]
        public void Update_KeyIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            Assert.Throws<ArgumentNullException>(() => sut.Update(0, null, "value"));
        }

        [Fact]
        public void Update_ValueIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            Assert.Throws<ArgumentNullException>(() => sut.Update(0, "key", null));
        }

        [Fact]
        public void Update_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new BuildVariableRepository(_requestFactory);

            sut.Update(expected, "key", "value");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public void Update_ValidParameters_AddsKeyUrlSegment()
        {
            const string expected = "key";
            var sut = new BuildVariableRepository(_requestFactory);

            sut.Update(0, expected, "value");

            _request.Received().AddUrlSegment("key", expected);
        }

        [Fact]
        public void Update_ValidParameters_AddsValueParameter()
        {
            const string expected = "value";
            var sut = new BuildVariableRepository(_requestFactory);

            sut.Update(0, "key", expected);

            _request.Received().AddParameter("value", expected);
        }

        [Fact]
        public void Update_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            sut.Update(0, "key", "value");

            _requestFactory.Received().Create("projects/{projectId}/variables/{key}", Method.Put);
        }

        [Fact]
        public async Task UpdateAsync_KeyIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.UpdateAsync(0, null, "value"));
        }

        [Fact]
        public async Task UpdateAsync_ValueIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.UpdateAsync(0, "key", null));
        }

        [Fact]
        public async Task UpdateAsync_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.UpdateAsync(expected, "key", "value");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task UpdateAsync_ValidParameters_AddsKeyUrlSegment()
        {
            const string expected = "key";
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.UpdateAsync(0, expected, "value");

            _request.Received().AddUrlSegment("key", expected);
        }

        [Fact]
        public async Task UpdateAsync_ValidParameters_AddsValueParameter()
        {
            const string expected = "value";
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.UpdateAsync(0, "key", expected);

            _request.Received().AddParameter("value", expected);
        }

        [Fact]
        public async Task UpdateAsync_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.UpdateAsync(0, "key", "value");

            _requestFactory.Received().Create("projects/{projectId}/variables/{key}", Method.Put);
        }
        #endregion
    }
}
