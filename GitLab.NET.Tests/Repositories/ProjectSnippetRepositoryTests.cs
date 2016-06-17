using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NSubstitute;
using Xunit;

namespace GitLab.NET.Tests.Repositories
{
	public class ProjectSnippetRepositoryTests
	{
		public ProjectSnippetRepositoryTests()
		{
			_request = Substitute.For<IRequest>();
			_requestFactory = Substitute.For<IRequestFactory>();
			_requestFactory.Create(Arg.Any<string>(), Arg.Any<Method>(), Arg.Any<bool>()).Returns(_request);
		}

		private readonly IRequest _request;
		private readonly IRequestFactory _requestFactory;

		[Fact]
		public async Task Create_CodeIsNull_ThrowsArgumentNullException()
		{
			var sut = new ProjectSnippetRepository(_requestFactory);

			await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Create(0, "title", "fileName", null, VisibilityLevel.Public));
		}

		[Fact]
		public async Task Create_FileNameIsNull_ThrowsArgumentNullException()
		{
			var sut = new ProjectSnippetRepository(_requestFactory);

			await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Create(0, "title", null, "code", VisibilityLevel.Public));
		}

		[Fact]
		public async Task Create_TitleIsNull_ThrowArgumentNullException()
		{
			var sut = new ProjectSnippetRepository(_requestFactory);

			await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Create(0, null, "fileName", "code", VisibilityLevel.Public));
		}

		[Fact]
		public async Task Create_ValidParameters_AddsCodeParameter()
		{
			const string expected = "code";
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Create(0, "title", "fileName", expected, VisibilityLevel.Public);

			_request.Received().AddParameter("code", expected);
		}

		[Fact]
		public async Task Create_ValidParameters_AddsFileNameParameter()
		{
			const string expected = "fileName";
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Create(0, "title", expected, "code", VisibilityLevel.Public);

			_request.Received().AddParameter("file_name", expected);
		}

		[Fact]
		public async Task Create_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Create(expected, "title", "fileName", "code", VisibilityLevel.Public);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Fact]
		public async Task Create_ValidParameters_AddsTitleParameter()
		{
			const string expected = "title";
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Create(0, expected, "fileName", "code", VisibilityLevel.Public);

			_request.Received().AddParameter("title", expected);
		}

		[Fact]
		public async Task Create_ValidParameters_AddsVisibilityLevelParameter()
		{
			const VisibilityLevel expected = VisibilityLevel.Public;
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Create(0, "title", "fileName", "code", expected);

			_request.Received().AddParameter("visibility_level", expected);
		}

		[Fact]
		public async Task Create_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Create(0, "title", "fileName", "code", VisibilityLevel.Public);

			_requestFactory.Received().Create("projects/{projectId}/snippets", Method.Post);
		}

		[Fact]
		public async Task Delete_ValidParameters_AddsIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Delete(expected, 0);

			_request.Received().AddUrlSegment("id", expected);
		}

		[Fact]
		public async Task Delete_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Delete(0, expected);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Fact]
		public async Task Delete_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Delete(0, 0);

			_requestFactory.Received().Create("projects/{projectId}/snippets/{id}", Method.Delete);
		}

		[Fact]
		public async Task Find_ValidParameters_AddsIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Find(expected, 0);

			_request.Received().AddUrlSegment("id", expected);
		}

		[Fact]
		public async Task Find_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Find(0, expected);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Fact]
		public async Task Find_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Find(0, 0);

			_requestFactory.Received().Create("projects/{projectId}/snippets/{id}", Method.Get);
		}

		[Fact]
		public async Task GetAll_PageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
		{
			var sut = new ProjectSnippetRepository(_requestFactory);

			await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.GetAll(0, uint.MinValue));
		}

		[Fact]
		public async Task GetAll_PageIsSet_AddsPageParameter()
		{
			const uint expected = 5;
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.GetAll(0, expected);

			_request.Received().AddParameter("page", expected);
		}

		[Fact]
		public async Task GetAll_ResultsPerPageIsGreaterThanMaximum_ThrowsArgumentOutOfRangeException()
		{
			var sut = new ProjectSnippetRepository(_requestFactory);

			await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.GetAll(0, resultsPerPage: uint.MaxValue));
		}

		[Fact]
		public async Task GetAll_ResultsPerPageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
		{
			var sut = new ProjectSnippetRepository(_requestFactory);

			await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.GetAll(0, resultsPerPage: uint.MinValue));
		}

		[Fact]
		public async Task GetAll_ResultsPerPageIsSet_AddsPerPageParameter()
		{
			const uint expected = 5;
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.GetAll(0, resultsPerPage: expected);

			_request.Received().AddParameter("per_page", expected);
		}

		[Fact]
		public async Task GetAll_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.GetAll(expected);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Fact]
		public async Task GetAll_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.GetAll(0);

			_requestFactory.Received().Create("projects/{projectId}/snippets", Method.Get);
		}

		[Fact]
		public async Task GetContent_ValidParameters_AddsIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.GetContent(expected, 0);

			_request.Received().AddUrlSegment("id", expected);
		}

		[Fact]
		public async Task GetContent_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.GetContent(0, expected);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Fact]
		public async Task GetContent_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.GetContent(0, 0);

			_requestFactory.Received().Create("projects/{projectId}/snippets/{id}/raw", Method.Get);
		}

		[Fact]
		public async Task Update_CodeIsSet_AddsCodeParameter()
		{
			const string expected = "code";
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Update(0, 0, code: expected);

			_request.Received().AddParameterIfNotNull("code", expected);
		}

		[Fact]
		public async Task Update_FileNameIsSet_AddsFileNameParameter()
		{
			const string expected = "fileName";
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Update(0, 0, fileName: expected);

			_request.Received().AddParameterIfNotNull("file_name", expected);
		}

		[Fact]
		public async Task Update_TitleIsSet_AddsTitleParameter()
		{
			const string expected = "title";
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Update(0, 0, expected);

			_request.Received().AddParameterIfNotNull("title", expected);
		}

		[Fact]
		public async Task Update_ValidParameters_AddsIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Update(expected, 0);

			_request.Received().AddUrlSegment("id", expected);
		}

		[Fact]
		public async Task Update_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Update(0, expected);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Fact]
		public async Task Update_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Update(0, 0);

			_requestFactory.Received().Create("projects/{projectId}/snippets/{id}", Method.Put);
		}

		[Fact]
		public async Task Update_VisibilityLevelIsSet_AddsVisibilityLevelParameter()
		{
			const VisibilityLevel expected = VisibilityLevel.Public;
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Update(0, 0, visibilityLevel: expected);

			_request.Received().AddParameterIfNotNull("visibility_level", expected);
		}
	}
}