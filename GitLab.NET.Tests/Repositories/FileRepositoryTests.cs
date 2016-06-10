using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NSubstitute;
using NUnit.Framework;

namespace GitLab.NET.Tests.Repositories
{
	public class FileRepositoryTests
	{
		public FileRepositoryTests()
		{
			_request = Substitute.For<IRequest>();
			_requestFactory = Substitute.For<IRequestFactory>();
			_requestFactory.Create(Arg.Any<string>(), Arg.Any<Method>(), Arg.Any<bool>()).Returns(_request);
		}

		private readonly IRequest _request;
		private readonly IRequestFactory _requestFactory;

		[Test]
		public void Create_BranchNameIsNull_ThrowsArgumentNullException()
		{
			var sut = new FileRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.Create(0, "filePath", null, "content", "commitMessage"));
		}

		[Test]
		public void Create_CommitMessageIsNull_ThrowsArgumentNullException()
		{
			var sut = new FileRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.Create(0, "filePath", "branchName", "content", null));
		}

		[Test]
		public void Create_ContentIsNull_ThrowsArgumentNullException()
		{
			var sut = new FileRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.Create(0, "filePath", "branchName", null, "commitMessage"));
		}

		[Test]
		public async Task Create_EncodingIsSet_AddsEncodingParameter()
		{
			const string expected = "encoding";
			var sut = new FileRepository(_requestFactory);

			await sut.Create(0, "filePath", "branchName", "content", "commitMessage", expected);

			_request.Received().AddParameterIfNotNull("encoding", expected);
		}

		[Test]
		public void Create_FilePathIsNull_ThrowsArgumentNullException()
		{
			var sut = new FileRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.Create(0, null, "branchName", "content", "commitMessage"));
		}

		[Test]
		public async Task Create_ValidParameters_AddsBranchNameParameter()
		{
			const string expected = "branchName";
			var sut = new FileRepository(_requestFactory);

			await sut.Create(0, "filePath", expected, "content", "commitMessage");

			_request.Received().AddParameter("branch_name", expected);
		}

		[Test]
		public async Task Create_ValidParameters_AddsCommitMessageParameter()
		{
			const string expected = "commitMessage";
			var sut = new FileRepository(_requestFactory);

			await sut.Create(0, "filePath", "branchName", "content", expected);

			_request.Received().AddParameter("commit_message", expected);
		}

		[Test]
		public async Task Create_ValidParameters_AddsContentParameter()
		{
			const string expected = "content";
			var sut = new FileRepository(_requestFactory);

			await sut.Create(0, "filePath", "branchName", expected, "commitMessage");

			_request.Received().AddParameter("content", expected);
		}

		[Test]
		public async Task Create_ValidParameters_AddsFilePathParameter()
		{
			const string expected = "filePath";
			var sut = new FileRepository(_requestFactory);

			await sut.Create(0, expected, "branchName", "content", "commitMessage");

			_request.Received().AddParameter("file_path", expected);
		}

		[Test]
		public async Task Create_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new FileRepository(_requestFactory);

			await sut.Create(expected, "filePath", "branchName", "content", "commitMessage");

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Create_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new FileRepository(_requestFactory);

			await sut.Create(0, "filePath", "branchName", "content", "commitMessage");

			_requestFactory.Received().Create("projects/{projectId}/repository/files", Method.Post);
		}

		[Test]
		public void Delete_BranchNameIsNull_ThrowsArgumentNullException()
		{
			var sut = new FileRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.Delete(0, "filePath", null, "commitMessage"));
		}

		[Test]
		public void Delete_CommitMessageIsNull_ThrowsArgumentNullException()
		{
			var sut = new FileRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.Delete(0, "filePath", "branchName", null));
		}

		[Test]
		public void Delete_FilePathIsNull_ThrowsArgumentNullException()
		{
			var sut = new FileRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.Delete(0, null, "branchName", "commitMessage"));
		}

		[Test]
		public async Task Delete_ValidParameters_AddsBranchNameParameter()
		{
			const string expected = "branchName";
			var sut = new FileRepository(_requestFactory);

			await sut.Delete(0, "filePath", expected, "commitMessage");

			_request.Received().AddParameter("branch_name", expected);
		}

		[Test]
		public async Task Delete_ValidParameters_AddsCommitMessageParameter()
		{
			const string expected = "commitMessage";
			var sut = new FileRepository(_requestFactory);

			await sut.Delete(0, "filePath", "branchName", expected);

			_request.Received().AddParameter("commit_message", expected);
		}

		[Test]
		public async Task Delete_ValidParameters_AddsFilePathParameter()
		{
			const string expected = "filePath";
			var sut = new FileRepository(_requestFactory);

			await sut.Delete(0, expected, "branchName", "commitMessage");

			_request.Received().AddParameter("file_path", expected);
		}

		[Test]
		public async Task Delete_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new FileRepository(_requestFactory);

			await sut.Delete(expected, "filePath", "branchName", "commitMessage");

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Delete_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new FileRepository(_requestFactory);

			await sut.Delete(0, "filePath", "branchName", "commitMessage");

			_requestFactory.Received().Create("projects/{projectId}/repository/files", Method.Delete);
		}

		[Test]
		public void Find_FilePathIsNull_ThrowsArgumentNullException()
		{
			var sut = new FileRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.Find(0, null, "refName"));
		}

		[Test]
		public void Find_RefNameIsNull_ThrowsArgumentNullException()
		{
			var sut = new FileRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.Find(0, "filePath", null));
		}

		[Test]
		public async Task Find_ValidParameters_AddsFilePathParameter()
		{
			const string expected = "filePath";
			var sut = new FileRepository(_requestFactory);

			await sut.Find(0, expected, "refName");

			_request.Received().AddParameter("file_path", expected);
		}

		[Test]
		public async Task Find_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new FileRepository(_requestFactory);

			await sut.Find(expected, "filePath", "refName");

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Find_ValidParameters_AddsRefParameter()
		{
			const string expected = "refName";
			var sut = new FileRepository(_requestFactory);

			await sut.Find(0, "filePath", expected);

			_request.Received().AddParameter("ref", expected);
		}

		[Test]
		public async Task Find_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new FileRepository(_requestFactory);

			await sut.Find(0, "filePath", "refName");

			_requestFactory.Received().Create("projects/{projectId}/repository/files", Method.Get);
		}

		[Test]
		public void Update_BranchNameIsNull_ThrowsArgumentNullException()
		{
			var sut = new FileRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.Update(0, "filePath", null, "content", "commitMessage"));
		}

		[Test]
		public void Update_CommitMessageIsNull_ThrowsArgumentNullException()
		{
			var sut = new FileRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.Update(0, "filePath", "branchName", "content", null));
		}

		[Test]
		public void Update_ContentIsNull_ThrowsArgumentNullException()
		{
			var sut = new FileRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.Update(0, "filePath", "branchName", null, "commitMessage"));
		}

		[Test]
		public async Task Update_EncodingIsSet_AddsEncodingParameter()
		{
			const string expected = "encoding";
			var sut = new FileRepository(_requestFactory);

			await sut.Update(0, "filePath", "branchName", "content", "commitMessage", expected);

			_request.Received().AddParameterIfNotNull("encoding", expected);
		}

		[Test]
		public void Update_FilePathIsNull_ThrowsArgumentNullException()
		{
			var sut = new FileRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.Update(0, null, "branchName", "content", "commitMessage"));
		}

		[Test]
		public async Task Update_ValidParameters_AddsBranchNameParameter()
		{
			const string expected = "branchName";
			var sut = new FileRepository(_requestFactory);

			await sut.Update(0, "filePath", expected, "content", "commitMessage");

			_request.Received().AddParameter("branch_name", expected);
		}

		[Test]
		public async Task Update_ValidParameters_AddsCommitMessageParameter()
		{
			const string expected = "commitMessage";
			var sut = new FileRepository(_requestFactory);

			await sut.Update(0, "filePath", "branchName", "content", expected);

			_request.Received().AddParameter("commit_message", expected);
		}

		[Test]
		public async Task Update_ValidParameters_AddsContentParameter()
		{
			const string expected = "content";
			var sut = new FileRepository(_requestFactory);

			await sut.Update(0, "filePath", "branchName", expected, "commitMessage");

			_request.Received().AddParameter("content", expected);
		}

		[Test]
		public async Task Update_ValidParameters_AddsFilePathParameter()
		{
			const string expected = "filePath";
			var sut = new FileRepository(_requestFactory);

			await sut.Update(0, expected, "branchName", "content", "commitMessage");

			_request.Received().AddParameter("file_path", expected);
		}

		[Test]
		public async Task Update_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new FileRepository(_requestFactory);

			await sut.Update(expected, "filePath", "branchName", "content", "commitMessage");

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Update_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new FileRepository(_requestFactory);

			await sut.Update(0, "filePath", "branchName", "content", "commitMessage");

			_requestFactory.Received().Create("projects/{projectId}/repository/files", Method.Put);
		}
	}
}