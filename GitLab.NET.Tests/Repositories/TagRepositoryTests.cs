using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NSubstitute;
using NUnit.Framework;

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

		[Test]
		public async Task Create_MessageIsSet_AddsMessageParameter()
		{
			const string expected = "message";
			var sut = new TagRepository(_requestFactory);

			await sut.Create(0, "tagName", "refName", expected);

			_request.Received().AddParameterIfNotNull("message", expected);
		}

		[Test]
		public void Create_RefNameIsNull_ThrowsArgumentNullException()
		{
			var sut = new TagRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.Create(0, "tagName", null));
		}

		[Test]
		public async Task Create_ReleaseDescriptionIsSet_AddsReleaseDescriptionParameter()
		{
			const string expected = "releaseDescription";
			var sut = new TagRepository(_requestFactory);

			await sut.Create(0, "tagName", "refName", releaseDescription: expected);

			_request.Received().AddParameterIfNotNull("release_description", expected);
		}

		[Test]
		public void Create_TagNameIsNull_ThrowsArgumentNullException()
		{
			var sut = new TagRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.Create(0, null, "refName"));
		}

		[Test]
		public async Task Create_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new TagRepository(_requestFactory);

			await sut.Create(expected, "tagName", "refName");

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Create_ValidParameters_AddsRefParameter()
		{
			const string expected = "refName";
			var sut = new TagRepository(_requestFactory);

			await sut.Create(0, "tagName", expected);

			_request.Received().AddParameter("ref", expected);
		}

		[Test]
		public async Task Create_ValidParameters_AddsTagNameParameter()
		{
			const string expected = "tagName";
			var sut = new TagRepository(_requestFactory);

			await sut.Create(0, expected, "refName");

			_request.Received().AddParameter("tag_name", expected);
		}

		[Test]
		public async Task Create_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new TagRepository(_requestFactory);

			await sut.Create(0, "tagName", "refName");

			_requestFactory.Received().Create("projects/{projectId}/repository/tags", Method.Post);
		}

		[Test]
		public void CreateRelease_DescriptionIsNull_ThrowsArgumentNullException()
		{
			var sut = new TagRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateRelease(0, "tagName", null));
		}

		[Test]
		public void CreateRelease_TagNameIsNull_ThrowsArgumentNullException()
		{
			var sut = new TagRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateRelease(0, null, "description"));
		}

		[Test]
		public async Task CreateRelease_ValidParameters_AddsDescriptionParameter()
		{
			const string expected = "description";
			var sut = new TagRepository(_requestFactory);

			await sut.CreateRelease(0, "tagName", expected);

			_request.Received().AddParameter("description", expected);
		}

		[Test]
		public async Task CreateRelease_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new TagRepository(_requestFactory);

			await sut.CreateRelease(expected, "tagName", "description");

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task CreateRelease_ValidParameters_AddsTagNameUrlSegment()
		{
			const string expected = "tagName";
			var sut = new TagRepository(_requestFactory);

			await sut.CreateRelease(0, expected, "description");

			_request.Received().AddUrlSegment("tagName", expected);
		}

		[Test]
		public async Task CreateRelease_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new TagRepository(_requestFactory);

			await sut.CreateRelease(0, "tagName", "description");

			_requestFactory.Received().Create("projects/{projectId}/repository/tags/{tagName}/release", Method.Post);
		}

		[Test]
		public void Delete_TagNameIsNull_ThrowsArgumentNullException()
		{
			var sut = new TagRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.Delete(0, null));
		}

		[Test]
		public async Task Delete_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new TagRepository(_requestFactory);

			await sut.Delete(expected, "tagName");

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Delete_ValidParameters_AddsTagNameUrlSegment()
		{
			const string expected = "tagName";
			var sut = new TagRepository(_requestFactory);

			await sut.Delete(0, expected);

			_request.Received().AddUrlSegment("tagName", expected);
		}

		[Test]
		public async Task Delete_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new TagRepository(_requestFactory);

			await sut.Delete(0, "tagName");

			_requestFactory.Received().Create("projects/{projectId}/repository/tags/{tagName}", Method.Delete);
		}

		[Test]
		public void Find_TagNameIsNull_ThrowsArgumentNullException()
		{
			var sut = new TagRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.Find(0, null));
		}

		[Test]
		public async Task Find_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new TagRepository(_requestFactory);

			await sut.Find(expected, "tagName");

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Find_ValidParameters_AddsTagNameUrlSegment()
		{
			const string expected = "tagName";
			var sut = new TagRepository(_requestFactory);

			await sut.Find(0, expected);

			_request.Received().AddUrlSegment("tagName", expected);
		}

		[Test]
		public async Task Find_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new TagRepository(_requestFactory);

			await sut.Find(0, "tagName");

			_requestFactory.Received().Create("projects/{projectId}/repository/tags/{tagName}", Method.Get);
		}

		[Test]
		public async Task GetAll_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new TagRepository(_requestFactory);

			await sut.GetAll(expected);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task GetAll_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new TagRepository(_requestFactory);

			await sut.GetAll(0);

			_requestFactory.Received().Create("projects/{projectId}/repository/tags", Method.Get);
		}

		[Test]
		public void UpdateRelease_DescriptionIsNull_ThrowsArgumentNullException()
		{
			var sut = new TagRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.UpdateRelease(0, "tagName", null));
		}

		[Test]
		public void UpdateRelease_TagNameIsNull_ThrowsArgumentNullException()
		{
			var sut = new TagRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.UpdateRelease(0, null, "description"));
		}

		[Test]
		public async Task UpdateRelease_ValidParameters_AddsDescriptionParameter()
		{
			const string expected = "description";
			var sut = new TagRepository(_requestFactory);

			await sut.UpdateRelease(0, "tagName", expected);

			_request.Received().AddParameter("description", expected);
		}

		[Test]
		public async Task UpdateRelease_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new TagRepository(_requestFactory);

			await sut.UpdateRelease(expected, "tagName", "description");

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task UpdateRelease_ValidParameters_AddsTagNameUrlSegment()
		{
			const string expected = "tagName";
			var sut = new TagRepository(_requestFactory);

			await sut.UpdateRelease(0, expected, "description");

			_request.Received().AddUrlSegment("tagName", expected);
		}

		[Test]
		public async Task UpdateRelease_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new TagRepository(_requestFactory);

			await sut.UpdateRelease(0, "tagName", "description");

			_requestFactory.Received().Create("projects/{projectId}/repository/tags/{tagName}/release", Method.Put);
		}
	}
}