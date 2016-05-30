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

            Assert.Throws<ArgumentNullException>(() => sut.Create(Arg.Any<uint>(), null, Arg.Any<string>()));
        }

        [Fact]
        public void Create_ValueIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            Assert.Throws<ArgumentNullException>(() => sut.Create(Arg.Any<uint>(), Arg.Any<string>(), null));
        }

        [Fact]
        public void Create_ValidParameters_AddsProjectIdUrlSegment()
        {
            var expected = Arg.Any<uint>();
            var sut = new BuildVariableRepository(_requestFactory);

            sut.Create(expected, Arg.Any<string>(), Arg.Any<string>());

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public void Create_ValidParameters_AddsKeyParameter()
        {
            var expected = Arg.Any<string>();
            var sut = new BuildVariableRepository(_requestFactory);

            sut.Create(Arg.Any<uint>(), expected, Arg.Any<string>());

            _request.Received().AddParameter("key", expected);
        }

        [Fact]
        public void Create_ValidParameters_AddsValueParameter()
        {
            var expected = Arg.Any<string>();
            var sut = new BuildVariableRepository(_requestFactory);

            sut.Create(Arg.Any<uint>(), Arg.Any<string>(), expected);

            _request.Received().AddParameter("value", expected);
        }

        [Fact]
        public void Create_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            sut.Create(Arg.Any<uint>(), Arg.Any<string>(), Arg.Any<string>());

            _requestFactory.Received().Create("projects/{projectId}/variables", Method.Post);
        }

        [Fact]
        public async Task CreateAsync_KeyIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateAsync(Arg.Any<uint>(), null, Arg.Any<string>()));
        }

        [Fact]
        public async Task CreateAsync_ValueIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateAsync(Arg.Any<uint>(), Arg.Any<string>(), null));
        }

        [Fact]
        public async Task CreateAsync_ValidParameters_AddsProjectIdUrlSegment()
        {
            var expected = Arg.Any<uint>();
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.CreateAsync(expected, Arg.Any<string>(), Arg.Any<string>());

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task CreateAsync_ValidParameters_AddsKeyParameter()
        {
            var expected = Arg.Any<string>();
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.CreateAsync(Arg.Any<uint>(), expected, Arg.Any<string>());

            _request.Received().AddParameter("key", expected);
        }

        [Fact]
        public async Task CreateAsync_ValidParameters_AddsValueParameter()
        {
            var expected = Arg.Any<string>();
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.CreateAsync(Arg.Any<uint>(), Arg.Any<string>(), expected);

            _request.Received().AddParameter("value", expected);
        }

        [Fact]
        public async Task CreateAsync_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.CreateAsync(Arg.Any<uint>(), Arg.Any<string>(), Arg.Any<string>());

            _requestFactory.Received().Create("projects/{projectId}/variables", Method.Post);
        }
        #endregion

        #region Delete
        [Fact]
        public void Delete_KeyIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            Assert.Throws<ArgumentNullException>(() => sut.Delete(Arg.Any<uint>(), null));
        }

        [Fact]
        public void Delete_ValidParameters_AddsProjectIdUrlSegment()
        {
            var expected = Arg.Any<uint>();
            var sut = new BuildVariableRepository(_requestFactory);

            sut.Delete(expected, Arg.Any<string>());

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public void Delete_ValidParameters_AddsKeyUrlSegment()
        {
            var expected = Arg.Any<string>();
            var sut = new BuildVariableRepository(_requestFactory);

            sut.Delete(Arg.Any<uint>(), expected);

            _request.Received().AddUrlSegment("key", expected);
        }

        [Fact]
        public void Delete_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            sut.Delete(Arg.Any<uint>(), Arg.Any<string>());

            _requestFactory.Received().Create("projects/{projectId}/variables/{key}", Method.Delete);
        }

        [Fact]
        public async Task DeleteAsync_KeyIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.DeleteAsync(Arg.Any<uint>(), null));
        }

        [Fact]
        public async Task DeleteAsync_ValidParameters_AddsProjectIdUrlSegment()
        {
            var expected = Arg.Any<uint>();
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.DeleteAsync(expected, Arg.Any<string>());

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task DeleteAsync_ValidParameters_AddsKeyUrlSegment()
        {
            var expected = Arg.Any<string>();
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.DeleteAsync(Arg.Any<uint>(), expected);

            _request.Received().AddUrlSegment("key", expected);
        }

        [Fact]
        public async Task DeleteAsync_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.DeleteAsync(Arg.Any<uint>(), Arg.Any<string>());

            _requestFactory.Received().Create("projects/{projectId}/variables/{key}", Method.Delete);
        }
        #endregion

        #region Find
        [Fact]
        public void Find_KeyIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            Assert.Throws<ArgumentNullException>(() => sut.Find(Arg.Any<uint>(), null));
        }

        [Fact]
        public void Find_ValidParameters_AddsProjectIdUrlSegment()
        {
            var expected = Arg.Any<uint>();
            var sut = new BuildVariableRepository(_requestFactory);

            sut.Find(expected, Arg.Any<string>());

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public void Find_ValidParameters_AddsKeyUrlSegment()
        {
            var expected = Arg.Any<string>();
            var sut = new BuildVariableRepository(_requestFactory);

            sut.Find(Arg.Any<uint>(), expected);

            _request.Received().AddUrlSegment("key", expected);
        }

        [Fact]
        public void Find_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            sut.Find(Arg.Any<uint>(), Arg.Any<string>());

            _requestFactory.Received().Create("projects/{projectId}/variables/{key}", Method.Get);
        }

        [Fact]
        public async Task FindAsync_KeyIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.FindAsync(Arg.Any<uint>(), null));
        }

        [Fact]
        public async Task FindAsync_ValidParameters_AddsProjectIdUrlSegment()
        {
            var expected = Arg.Any<uint>();
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.FindAsync(expected, Arg.Any<string>());

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task FindAsync_ValidParameters_AddsKeyUrlSegment()
        {
            var expected = Arg.Any<string>();
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.FindAsync(Arg.Any<uint>(), expected);

            _request.Received().AddUrlSegment("key", expected);
        }

        [Fact]
        public async Task FindAsync_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.FindAsync(Arg.Any<uint>(), Arg.Any<string>());

            _requestFactory.Received().Create("projects/{projectId}/variables/{key}", Method.Get);
        }
        #endregion
        
        #region GetAll
        [Fact]
        public void GetAll_ValidParameters_AddsProjectIdUrlSegment()
        {
            var expected = Arg.Any<uint>();
            var sut = new BuildVariableRepository(_requestFactory);

            sut.GetAll(expected);

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public void GetAll_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            sut.GetAll(Arg.Any<uint>());

            _requestFactory.Received().Create("projects/{projectId}/variables", Method.Get);
        }

        [Fact]
        public async Task GetAllAsync_ValidParameters_AddsProjectIdUrlSegment()
        {
            var expected = Arg.Any<uint>();
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.GetAllAsync(expected);

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task GetAllAsync_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.GetAllAsync(Arg.Any<uint>());

            _requestFactory.Received().Create("projects/{projectId}/variables", Method.Get);
        }
        #endregion

        #region Update
        [Fact]
        public void Update_KeyIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            Assert.Throws<ArgumentNullException>(() => sut.Update(Arg.Any<uint>(), null, Arg.Any<string>()));
        }

        [Fact]
        public void Update_ValueIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            Assert.Throws<ArgumentNullException>(() => sut.Update(Arg.Any<uint>(), Arg.Any<string>(), null));
        }

        [Fact]
        public void Update_ValidParameters_AddsProjectIdUrlSegment()
        {
            var expected = Arg.Any<uint>();
            var sut = new BuildVariableRepository(_requestFactory);

            sut.Update(expected, Arg.Any<string>(), Arg.Any<string>());

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public void Update_ValidParameters_AddsKeyUrlSegment()
        {
            var expected = Arg.Any<string>();
            var sut = new BuildVariableRepository(_requestFactory);

            sut.Update(Arg.Any<uint>(), expected, Arg.Any<string>());

            _request.Received().AddUrlSegment("key", expected);
        }

        [Fact]
        public void Update_ValidParameters_AddsValueParameter()
        {
            var expected = Arg.Any<string>();
            var sut = new BuildVariableRepository(_requestFactory);

            sut.Update(Arg.Any<uint>(), Arg.Any<string>(), expected);

            _request.Received().AddParameter("value", expected);
        }

        [Fact]
        public void Update_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            sut.Update(Arg.Any<uint>(), Arg.Any<string>(), Arg.Any<string>());

            _requestFactory.Received().Create("projects/{projectId}/variables/{key}", Method.Put);
        }

        [Fact]
        public async Task UpdateAsync_KeyIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.UpdateAsync(Arg.Any<uint>(), null, Arg.Any<string>()));
        }

        [Fact]
        public async Task UpdateAsync_ValueIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.UpdateAsync(Arg.Any<uint>(), Arg.Any<string>(), null));
        }

        [Fact]
        public async Task UpdateAsync_ValidParameters_AddsProjectIdUrlSegment()
        {
            var expected = Arg.Any<uint>();
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.UpdateAsync(expected, Arg.Any<string>(), Arg.Any<string>());

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task UpdateAsync_ValidParameters_AddsKeyUrlSegment()
        {
            var expected = Arg.Any<string>();
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.UpdateAsync(Arg.Any<uint>(), expected, Arg.Any<string>());

            _request.Received().AddUrlSegment("key", expected);
        }

        [Fact]
        public async Task UpdateAsync_ValidParameters_AddsValueParameter()
        {
            var expected = Arg.Any<string>();
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.UpdateAsync(Arg.Any<uint>(), Arg.Any<string>(), expected);

            _request.Received().AddParameter("value", expected);
        }

        [Fact]
        public async Task UpdateAsync_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new BuildVariableRepository(_requestFactory);

            await sut.UpdateAsync(Arg.Any<uint>(), Arg.Any<string>(), Arg.Any<string>());

            _requestFactory.Received().Create("projects/{projectId}/variables/{key}", Method.Put);
        }
        #endregion
    }
}
