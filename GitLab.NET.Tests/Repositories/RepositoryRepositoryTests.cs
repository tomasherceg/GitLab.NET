using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NSubstitute;
using Xunit;

namespace GitLab.NET.Tests.Repositories
{
	public class RepositoryRepositoryTests
	{
		public RepositoryRepositoryTests()
		{
			_request = Substitute.For<IRequest>();
			_requestFactory = Substitute.For<IRequestFactory>();
			_requestFactory.Create(Arg.Any<string>(), Arg.Any<Method>(), Arg.Any<bool>()).Returns(_request);
		}

		private readonly IRequest _request;
		private readonly IRequestFactory _requestFactory;

		[Fact]
		public async Task Compare_FromIsNull_ThrowsArgumentNullException()
		{
			var sut = new RepositoryRepository(_requestFactory);

			await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Compare(0, null, "to"));
		}

		[Fact]
		public async Task Compare_ToIsNull_ThrowsArgumentNullException()
		{
			var sut = new RepositoryRepository(_requestFactory);

			await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Compare(0, "from", null));
		}

		[Fact]
		public async Task Compare_ValidParameters_AddsFromParameter()
		{
			const string expected = "from";
			var sut = new RepositoryRepository(_requestFactory);

			await sut.Compare(0, expected, "to");

			_request.Received().AddParameter("from", expected);
		}

		[Fact]
		public async Task Compare_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new RepositoryRepository(_requestFactory);

			await sut.Compare(expected, "from", "to");

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Fact]
		public async Task Compare_ValidParameters_AddsToParameter()
		{
			const string expected = "to";
			var sut = new RepositoryRepository(_requestFactory);

			await sut.Compare(0, "from", expected);

			_request.Received().AddParameter("to", expected);
		}

		[Fact]
		public async Task Compare_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new RepositoryRepository(_requestFactory);

			await sut.Compare(0, "from", "to");

			_requestFactory.Received().Create("projects/{projectId}/repository/compare", Method.Get);
		}

		[Fact]
		public async Task GetArchive_ShaIsSet_AddsShaParameter()
		{
			const string expected = "sha";
			var sut = new RepositoryRepository(_requestFactory);

			await sut.GetArchive(0, expected);

			_request.Received().AddParameterIfNotNull("sha", expected);
		}

		[Fact]
		public async Task GetArchive_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new RepositoryRepository(_requestFactory);

			await sut.GetArchive(expected);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Fact]
		public async Task GetArchive_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new RepositoryRepository(_requestFactory);

			await sut.GetArchive(0);

			_requestFactory.Received().Create("projects/{projectId}/repository/archive", Method.Get);
		}

		[Fact]
		public async Task GetBlobContent_ShaIsNull_ThrowsArgumentNullException()
		{
			var sut = new RepositoryRepository(_requestFactory);

			await Assert.ThrowsAsync<ArgumentNullException>(() => sut.GetBlobContent(0, null));
		}

		[Fact]
		public async Task GetBlobContent_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new RepositoryRepository(_requestFactory);

			await sut.GetBlobContent(expected, "sha");

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Fact]
		public async Task GetBlobContent_ValidParameters_AddsShaUrlSegment()
		{
			const string expected = "sha";
			var sut = new RepositoryRepository(_requestFactory);

			await sut.GetBlobContent(0, expected);

			_request.Received().AddUrlSegment("sha", expected);
		}

		[Fact]
		public async Task GetBlobContent_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new RepositoryRepository(_requestFactory);

			await sut.GetBlobContent(0, "sha");

			_requestFactory.Received().Create("projects/{projectId}/repository/raw_blobs/{sha}", Method.Get);
		}

		[Fact]
		public async Task GetContributors_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new RepositoryRepository(_requestFactory);

			await sut.GetContributors(expected);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Fact]
		public async Task GetContributors_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new RepositoryRepository(_requestFactory);

			await sut.GetContributors(0);

			_requestFactory.Received().Create("projects/{projectId}/repository/contributors", Method.Get);
		}

		[Fact]
		public async Task GetFileContent_FilePathIsNull_ThrowsArgumentNullException()
		{
			var sut = new RepositoryRepository(_requestFactory);

			await Assert.ThrowsAsync<ArgumentNullException>(() => sut.GetFileContent(0, "sha", null));
		}

		[Fact]
		public async Task GetFileContent_ShaIsNull_ThrowsArgumentNullException()
		{
			var sut = new RepositoryRepository(_requestFactory);

			await Assert.ThrowsAsync<ArgumentNullException>(() => sut.GetFileContent(0, null, "filePath"));
		}

		[Fact]
		public async Task GetFileContent_ValidParameters_AddsFilePathParameter()
		{
			const string expected = "filePath";
			var sut = new RepositoryRepository(_requestFactory);

			await sut.GetFileContent(0, "sha", expected);

			_request.Received().AddParameter("filepath", expected);
		}

		[Fact]
		public async Task GetFileContent_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new RepositoryRepository(_requestFactory);

			await sut.GetFileContent(expected, "sha", "filePath");

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Fact]
		public async Task GetFileContent_ValidParameters_AddsShaUrlSegment()
		{
			const string expected = "sha";
			var sut = new RepositoryRepository(_requestFactory);

			await sut.GetFileContent(0, expected, "filePath");

			_request.Received().AddUrlSegment("sha", expected);
		}

		[Fact]
		public async Task GetFileContent_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new RepositoryRepository(_requestFactory);

			await sut.GetFileContent(0, "sha", "filePath");

			_requestFactory.Received().Create("projects/{projectId}/repository/blobs/{sha}", Method.Get);
		}

		[Fact]
		public async Task GetTree_PathIsSet_AddsPathParameter()
		{
			const string expected = "path";
			var sut = new RepositoryRepository(_requestFactory);

			await sut.GetTree(0, expected);

			_request.Received().AddParameterIfNotNull("path", expected);
		}

		[Fact]
		public async Task GetTree_RefNameIsSet_AddsRefNameParameter()
		{
			const string expected = "refName";
			var sut = new RepositoryRepository(_requestFactory);

			await sut.GetTree(0, refName: expected);

			_request.Received().AddParameterIfNotNull("ref_name", expected);
		}

		[Fact]
		public async Task GetTree_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new RepositoryRepository(_requestFactory);

			await sut.GetTree(expected);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Fact]
		public async Task GetTree_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new RepositoryRepository(_requestFactory);

			await sut.GetTree(0);

			_requestFactory.Received().Create("projects/{projectId}/repository/tree", Method.Get);
		}
	}
}