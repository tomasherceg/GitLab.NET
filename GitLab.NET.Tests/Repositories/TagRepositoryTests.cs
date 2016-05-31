using NSubstitute;
using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using Xunit;

namespace GitLab.NET.Tests.Repositories
{
    public class TagRepositoryTests
    {
        public TagRepositoryTests()
        {
            _request = Substitute.For<IRequest>();
            _requestFactory = Substitute.For<IRequestFactory>();
            _requestFactory.Create(Arg.Any<string>(), Arg.Any<Method>(), Arg.Any<bool>()).Returns(_request);
        }

        private readonly IRequest _request;
        private readonly IRequestFactory _requestFactory;

        [Fact]
        public async Task Create_TagNameIsNull_ThrowsArgumentNullException()
        {
            var sut = new TagRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Create(0, null, "refName"));
        }

        [Fact]
        public async Task Create_RefNameIsNull_ThrowsArgumentNullException()
        {
            var sut = new TagRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Create(0, "tagName", null));
        }

        [Fact]
        public async Task Create_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new TagRepository(_requestFactory);

            await sut.Create(expected, "tagName", "refName");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task Create_ValidParameters_AddsTagNameParameter()
        {
            const string expected = "tagName";
            var sut = new TagRepository(_requestFactory);

            await sut.Create(0, expected, "refName");

            _request.Received().AddParameter("tag_name", expected);
        }

        [Fact]
        public async Task Create_ValidParameters_AddsRefParameter()
        {
            const string expected = "refName";
            var sut = new TagRepository(_requestFactory);

            await sut.Create(0, "tagName", expected);

            _request.Received().AddParameter("ref", expected);
        }

        [Fact]
        public async Task Create_MessageIsSet_AddsMessageParameter()
        {
            const string expected = "message";
            var sut = new TagRepository(_requestFactory);

            await sut.Create(0, "tagName", "refName", message: expected);

            _request.Received().AddParameterIfNotNull("message", expected);
        }

        [Fact]
        public async Task Create_ReleaseDescriptionIsSet_AddsReleaseDescriptionParameter()
        {
            const string expected = "releaseDescription";
            var sut = new TagRepository(_requestFactory);

            await sut.Create(0, "tagName", "refName", releaseDescription: expected);

            _request.Received().AddParameterIfNotNull("release_description", expected);
        }

        [Fact]
        public async Task Create_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new TagRepository(_requestFactory);

            await sut.Create(0, "tagName", "refName");

            _requestFactory.Received().Create("projects/{projectId}/repository/tags", Method.Post);
        }

        [Fact]
        public async Task CreateRelease_TagNameIsNull_ThrowsArgumentNullException()
        {
            var sut = new TagRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateRelease(0, null, "description"));
        }

        [Fact]
        public async Task CreateRelease_DescriptionIsNull_ThrowsArgumentNullException()
        {
            var sut = new TagRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateRelease(0, "tagName", null));
        }

        [Fact]
        public async Task CreateRelease_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new TagRepository(_requestFactory);

            await sut.CreateRelease(expected, "tagName", "description");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task CreateRelease_ValidParameters_AddsTagNameUrlSegment()
        {
            const string expected = "tagName";
            var sut = new TagRepository(_requestFactory);

            await sut.CreateRelease(0, expected, "description");

            _request.Received().AddUrlSegment("tagName", expected);
        }

        [Fact]
        public async Task CreateRelease_ValidParameters_AddsDescriptionParameter()
        {
            const string expected = "description";
            var sut = new TagRepository(_requestFactory);

            await sut.CreateRelease(0, "tagName", expected);

            _request.Received().AddParameter("description", expected);
        }

        [Fact]
        public async Task CreateRelease_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new TagRepository(_requestFactory);

            await sut.CreateRelease(0, "tagName", "description");

            _requestFactory.Received().Create("projects/{projectId}/repository/tags/{tagName}/release", Method.Post);
        }

        [Fact]
        public async Task Delete_TagNameIsNull_ThrowsArgumentNullException()
        {
            var sut = new TagRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Delete(0, null));
        }

        [Fact]
        public async Task Delete_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new TagRepository(_requestFactory);

            await sut.Delete(expected, "tagName");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task Delete_ValidParameters_AddsTagNameUrlSegment()
        {
            const string expected = "tagName";
            var sut = new TagRepository(_requestFactory);

            await sut.Delete(0, expected);

            _request.Received().AddUrlSegment("tagName", expected);
        }

        [Fact]
        public async Task Delete_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new TagRepository(_requestFactory);

            await sut.Delete(0, "tagName");

            _requestFactory.Received().Create("projects/{projectId}/repository/tags/{tagName}", Method.Delete);
        }

        [Fact]
        public async Task Find_TagNameIsNull_ThrowsArgumentNullException()
        {
            var sut = new TagRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Find(0, null));
        }

        [Fact]
        public async Task Find_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new TagRepository(_requestFactory);

            await sut.Find(expected, "tagName");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task Find_ValidParameters_AddsTagNameUrlSegment()
        {
            const string expected = "tagName";
            var sut = new TagRepository(_requestFactory);

            await sut.Find(0, expected);

            _request.Received().AddUrlSegment("tagName", expected);
        }

        [Fact]
        public async Task Find_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new TagRepository(_requestFactory);

            await sut.Find(0, "tagName");

            _requestFactory.Received().Create("projects/{projectId}/repository/tags/{tagName}", Method.Get);
        }

        [Fact]
        public async Task GetAll_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new TagRepository(_requestFactory);

            await sut.GetAll(expected);

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task GetAll_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new TagRepository(_requestFactory);

            await sut.GetAll(0);

            _requestFactory.Received().Create("projects/{projectId}/repository/tags", Method.Get);
        }

        [Fact]
        public async Task UpdateRelease_TagNameIsNull_ThrowsArgumentNullException()
        {
            var sut = new TagRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.UpdateRelease(0, null, "description"));
        }

        [Fact]
        public async Task UpdateRelease_DescriptionIsNull_ThrowsArgumentNullException()
        {
            var sut = new TagRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.UpdateRelease(0, "tagName", null));
        }

        [Fact]
        public async Task UpdateRelease_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new TagRepository(_requestFactory);

            await sut.UpdateRelease(expected, "tagName", "description");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task UpdateRelease_ValidParameters_AddsTagNameUrlSegment()
        {
            const string expected = "tagName";
            var sut = new TagRepository(_requestFactory);

            await sut.UpdateRelease(0, expected, "description");

            _request.Received().AddUrlSegment("tagName", expected);
        }

        [Fact]
        public async Task UpdateRelease_ValidParameters_AddsDescriptionParameter()
        {
            const string expected = "description";
            var sut = new TagRepository(_requestFactory);

            await sut.UpdateRelease(0, "tagName", expected);

            _request.Received().AddParameter("description", expected);
        }

        [Fact]
        public async Task UpdateRelease_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new TagRepository(_requestFactory);

            await sut.UpdateRelease(0, "tagName", "description");

            _requestFactory.Received().Create("projects/{projectId}/repository/tags/{tagName}/release", Method.Put);
        }
    }
}
