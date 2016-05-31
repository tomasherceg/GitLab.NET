using NSubstitute;
using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using Xunit;

namespace GitLab.NET.Tests.Repositories
{
    public class LabelRepositoryTests
    {
        public LabelRepositoryTests()
        {
            _request = Substitute.For<IRequest>();
            _requestFactory = Substitute.For<IRequestFactory>();
            _requestFactory.Create(Arg.Any<string>(), Arg.Any<Method>(), Arg.Any<bool>()).Returns(_request);
        }

        private readonly IRequest _request;
        private readonly IRequestFactory _requestFactory;

        [Fact]
        public async Task Create_NameIsNull_ThrowsArgumentNullException()
        {
            var sut = new LabelRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Create(0, null, "color"));
        }

        [Fact]
        public async Task Create_ColorIsNull_ThrowsArgumentNullException()
        {
            var sut = new LabelRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Create(0, "name", null));
        }

        [Fact]
        public async Task Create_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new LabelRepository(_requestFactory);

            await sut.Create(expected, "name", "color");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task Create_ValidParameters_AddsNameParameter()
        {
            const string expected = "name";
            var sut = new LabelRepository(_requestFactory);

            await sut.Create(0, expected, "color");

            _request.Received().AddParameter("name", expected);
        }

        [Fact]
        public async Task Create_ValidParameters_AddsColorParameter()
        {
            const string expected = "color";
            var sut = new LabelRepository(_requestFactory);

            await sut.Create(0, "name", expected);

            _request.Received().AddParameter("color", expected);
        }

        [Fact]
        public async Task Create_DescriptionIsSet_AddsDescriptionParameter()
        {
            const string expected = "description";
            var sut = new LabelRepository(_requestFactory);

            await sut.Create(0, "name", "color", expected);

            _request.Received().AddParameterIfNotNull("description", expected);
        }

        [Fact]
        public async Task Create_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new LabelRepository(_requestFactory);

            await sut.Create(0, "name", "color");

            _requestFactory.Received().Create("projects/{projectId}/labels", Method.Post);
        }

        [Fact]
        public async Task Delete_NameIsNull_ThrowsArgumentNullException()
        {
            var sut = new LabelRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Delete(0, null));
        }

        [Fact]
        public async Task Delete_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new LabelRepository(_requestFactory);

            await sut.Delete(expected, "name");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task Delete_ValidParameters_AddsNameParameter()
        {
            const string expected = "name";
            var sut = new LabelRepository(_requestFactory);

            await sut.Delete(0, expected);

            _request.Received().AddParameter("name", expected);
        }

        [Fact]
        public async Task Delete_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new LabelRepository(_requestFactory);

            await sut.Delete(0, "name");

            _requestFactory.Received().Create("projects/{projectId}/labels", Method.Delete);
        }

        [Fact]
        public async Task GetAll_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new LabelRepository(_requestFactory);

            await sut.GetAll(expected);

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task GetAll_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new LabelRepository(_requestFactory);

            await sut.GetAll(0);

            _requestFactory.Received().Create("projects/{projectId}/labels", Method.Get);
        }

        [Fact]
        public async Task Subscribe_NameIsNull_ThrowsArgumentNullException()
        {
            var sut = new LabelRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Subscribe(0, null));
        }

        [Fact]
        public async Task Subscribe_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new LabelRepository(_requestFactory);

            await sut.Subscribe(expected, "name");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task Subscribe_ValidParameters_AddsLabelIdUrlSegment()
        {
            const string expected = "name";
            var sut = new LabelRepository(_requestFactory);

            await sut.Subscribe(0, expected);

            _request.Received().AddUrlSegment("labelId", expected);
        }

        [Fact]
        public async Task Subscribe_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new LabelRepository(_requestFactory);

            await sut.Subscribe(0, "name");

            _requestFactory.Received().Create("projects/{projectId}/labels/{labelId}/subscription", Method.Post);
        }
        
        [Fact]
        public async Task Unsubscribe_NameIsNull_ThrowsArgumentNullException()
        {
            var sut = new LabelRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Unsubscribe(0, null));
        }

        [Fact]
        public async Task Unsubscribe_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new LabelRepository(_requestFactory);

            await sut.Unsubscribe(expected, "name");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task Unsubscribe_ValidParameters_AddsLabelIdUrlSegment()
        {
            const string expected = "name";
            var sut = new LabelRepository(_requestFactory);

            await sut.Unsubscribe(0, expected);

            _request.Received().AddUrlSegment("labelId", expected);
        }

        [Fact]
        public async Task Unsubscribe_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new LabelRepository(_requestFactory);

            await sut.Unsubscribe(0, "name");

            _requestFactory.Received().Create("projects/{projectId}/labels/{labelId}/subscription", Method.Delete);
        }

        [Fact]
        public async Task Update_NameIsNull_ThrowsArgumentNullException()
        {
            var sut = new LabelRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Update(0, null));
        }

        [Fact]
        public async Task Update_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new LabelRepository(_requestFactory);

            await sut.Update(expected, "name");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task Update_ValidParameters_AddsNameParameter()
        {
            const string expected = "name";
            var sut = new LabelRepository(_requestFactory);

            await sut.Update(0, expected);

            _request.Received().AddParameter("name", expected);
        }

        [Fact]
        public async Task Update_NewNameIsSet_AddsNewNameParameter()
        {
            const string expected = "newName";
            var sut = new LabelRepository(_requestFactory);

            await sut.Update(0, "name", newName: expected);

            _request.Received().AddParameterIfNotNull("new_name", expected);
        }

        [Fact]
        public async Task Update_ColorIsSet_AddsColorParameter()
        {
            const string expected = "color";
            var sut = new LabelRepository(_requestFactory);

            await sut.Update(0, "name", color: expected);

            _request.Received().AddParameterIfNotNull("color", expected);
        }

        [Fact]
        public async Task Update_DescriptionIsSet_AddsDescriptionParameter()
        {
            const string expected = "description";
            var sut = new LabelRepository(_requestFactory);

            await sut.Update(0, "name", description: expected);

            _request.Received().AddParameterIfNotNull("description", expected);
        }

        [Fact]
        public async Task Update_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new LabelRepository(_requestFactory);

            await sut.Update(0, "name");

            _requestFactory.Received().Create("projects/{projectId}/labels", Method.Put);
        }
    }
}
