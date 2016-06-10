using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NSubstitute;
using NUnit.Framework;

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

		[Test]
		public void Create_CodeIsNull_ThrowsArgumentNullException()
		{
			var sut = new ProjectSnippetRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.Create(0, "title", "fileName", null, VisibilityLevel.Public));
		}

		[Test]
		public void Create_FileNameIsNull_ThrowsArgumentNullException()
		{
			var sut = new ProjectSnippetRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.Create(0, "title", null, "code", VisibilityLevel.Public));
		}

		[Test]
		public void Create_TitleIsNull_ThrowArgumentNullException()
		{
			var sut = new ProjectSnippetRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.Create(0, null, "fileName", "code", VisibilityLevel.Public));
		}

		[Test]
		public async Task Create_ValidParameters_AddsCodeParameter()
		{
			const string expected = "code";
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Create(0, "title", "fileName", expected, VisibilityLevel.Public);

			_request.Received().AddParameter("code", expected);
		}

		[Test]
		public async Task Create_ValidParameters_AddsFileNameParameter()
		{
			const string expected = "fileName";
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Create(0, "title", expected, "code", VisibilityLevel.Public);

			_request.Received().AddParameter("file_name", expected);
		}

		[Test]
		public async Task Create_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Create(expected, "title", "fileName", "code", VisibilityLevel.Public);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Create_ValidParameters_AddsTitleParameter()
		{
			const string expected = "title";
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Create(0, expected, "fileName", "code", VisibilityLevel.Public);

			_request.Received().AddParameter("title", expected);
		}

		[Test]
		public async Task Create_ValidParameters_AddsVisibilityLevelParameter()
		{
			const VisibilityLevel expected = VisibilityLevel.Public;
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Create(0, "title", "fileName", "code", expected);

			_request.Received().AddParameter("visibility_level", expected);
		}

		[Test]
		public async Task Create_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Create(0, "title", "fileName", "code", VisibilityLevel.Public);

			_requestFactory.Received().Create("projects/{projectId}/snippets", Method.Post);
		}

		[Test]
		public async Task Delete_ValidParameters_AddsIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Delete(expected, 0);

			_request.Received().AddUrlSegment("id", expected);
		}

		[Test]
		public async Task Delete_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Delete(0, expected);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Delete_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Delete(0, 0);

			_requestFactory.Received().Create("projects/{projectId}/snippets/{id}", Method.Delete);
		}

		[Test]
		public async Task Find_ValidParameters_AddsIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Find(expected, 0);

			_request.Received().AddUrlSegment("id", expected);
		}

		[Test]
		public async Task Find_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Find(0, expected);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Find_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Find(0, 0);

			_requestFactory.Received().Create("projects/{projectId}/snippets/{id}", Method.Get);
		}

		[Test]
		public void GetAll_PageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
		{
			var sut = new ProjectSnippetRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.GetAll(0, uint.MinValue));
		}

		[Test]
		public async Task GetAll_PageIsSet_AddsPageParameter()
		{
			const uint expected = 5;
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.GetAll(0, expected);

			_request.Received().AddParameter("page", expected);
		}

		[Test]
		public void GetAll_ResultsPerPageIsGreaterThanMaximum_ThrowsArgumentOutOfRangeException()
		{
			var sut = new ProjectSnippetRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.GetAll(0, resultsPerPage: uint.MaxValue));
		}

		[Test]
		public void GetAll_ResultsPerPageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
		{
			var sut = new ProjectSnippetRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.GetAll(0, resultsPerPage: uint.MinValue));
		}

		[Test]
		public async Task GetAll_ResultsPerPageIsSet_AddsPerPageParameter()
		{
			const uint expected = 5;
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.GetAll(0, resultsPerPage: expected);

			_request.Received().AddParameter("per_page", expected);
		}

		[Test]
		public async Task GetAll_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.GetAll(expected);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task GetAll_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.GetAll(0);

			_requestFactory.Received().Create("projects/{projectId}/snippets", Method.Get);
		}

		[Test]
		public async Task GetContent_ValidParameters_AddsIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.GetContent(expected, 0);

			_request.Received().AddUrlSegment("id", expected);
		}

		[Test]
		public async Task GetContent_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.GetContent(0, expected);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task GetContent_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.GetContent(0, 0);

			_requestFactory.Received().Create("projects/{projectId}/snippets/{id}/raw", Method.Get);
		}

		[Test]
		public async Task Update_CodeIsSet_AddsCodeParameter()
		{
			const string expected = "code";
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Update(0, 0, code: expected);

			_request.Received().AddParameterIfNotNull("code", expected);
		}

		[Test]
		public async Task Update_FileNameIsSet_AddsFileNameParameter()
		{
			const string expected = "fileName";
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Update(0, 0, fileName: expected);

			_request.Received().AddParameterIfNotNull("file_name", expected);
		}

		[Test]
		public async Task Update_TitleIsSet_AddsTitleParameter()
		{
			const string expected = "title";
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Update(0, 0, expected);

			_request.Received().AddParameterIfNotNull("title", expected);
		}

		[Test]
		public async Task Update_ValidParameters_AddsIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Update(expected, 0);

			_request.Received().AddUrlSegment("id", expected);
		}

		[Test]
		public async Task Update_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Update(0, expected);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Update_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Update(0, 0);

			_requestFactory.Received().Create("projects/{projectId}/snippets/{id}", Method.Put);
		}

		[Test]
		public async Task Update_VisibilityLevelIsSet_AddsVisibilityLevelParameter()
		{
			const VisibilityLevel expected = VisibilityLevel.Public;
			var sut = new ProjectSnippetRepository(_requestFactory);

			await sut.Update(0, 0, visibilityLevel: expected);

			_request.Received().AddParameterIfNotNull("visibility_level", expected);
		}
	}
}