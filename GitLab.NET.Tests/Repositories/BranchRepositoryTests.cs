using NSubstitute;
using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using Xunit;

namespace GitLab.NET.Tests.Repositories
{
	public class BranchRepositoryTests
	{
		public BranchRepositoryTests()
		{
			_request = Substitute.For<IRequest>();
			_requestFactory = Substitute.For<IRequestFactory>();
			_requestFactory.Create(Arg.Any<string>(), Arg.Any<Method>(), Arg.Any<bool>()).Returns(_request);
			_sut = new BranchRepository(_requestFactory);
		}

		private readonly IRequest _request;
		private readonly IRequestFactory _requestFactory;
		private readonly BranchRepository _sut;

		[Fact]
		public async Task Create_BranchNameIsNull_ThrowsArgumentNullException()
		{
			await Assert.ThrowsAsync<ArgumentNullException>(() => _sut.Create(0, null, "refName"));
		}

		[Fact]
		public async Task Create_RefNameIsNull_ThrowsArgumentNullException()
		{
			await Assert.ThrowsAsync<ArgumentNullException>(() => _sut.Create(0, "branchName", null));
		}

		[Fact]
		public async Task Create_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Create(expected, "branchName", "refName");

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Fact]
		public async Task Create_ValidParameters_AddsBranchNameParameter()
		{
			const string expected = "branchName";

			await _sut.Create(0, expected, "refName");

			_request.Received().AddParameter("branch_name", expected);
		}

		[Fact]
		public async Task Create_ValidParameters_AddsRefParameter()
		{
			const string expected = "refName";

			await _sut.Create(0, "branchName", expected);

			_request.Received().AddParameter("ref", expected);
		}

		[Fact]
		public async Task Create_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.Create(0, "branchName", "refName");

			_requestFactory.Received().Create("projects/{projectId}/repository/branches", Method.Post);
		}

		[Fact]
		public async Task Delete_BranchNameIsNull_ThrowsArgumentNullException()
		{
			await Assert.ThrowsAsync<ArgumentNullException>(() => _sut.Delete(0, null));
		}

		[Fact]
		public async Task Delete_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Delete(expected, "branchName");

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Fact]
		public async Task Delete_ValidParameters_AddsBranchNameUrlSegment()
		{
			const string expected = "branchName";

			await _sut.Delete(0, expected);

			_request.Received().AddUrlSegment("branchName", expected);
		}

		[Fact]
		public async Task Delete_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.Delete(0, "branchName");

			_requestFactory.Received().Create("projects/{projectId}/repository/branches/{branchName}", Method.Delete);
		}

		[Fact]
		public async Task Find_BranchNameIsNull_ThrowsArgumentNullException()
		{
			await Assert.ThrowsAsync<ArgumentNullException>(() => _sut.Find(0, null));
		}

		[Fact]
		public async Task Find_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Find(expected, "branchName");

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Fact]
		public async Task Find_ValidParameters_AddsBranchNameUrlSegment()
		{
			const string expected = "branchName";

			await _sut.Find(0, expected);

			_request.Received().AddUrlSegment("branchName", expected);
		}

		[Fact]
		public async Task Find_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.Find(0, "branchName");

			_requestFactory.Received().Create("projects/{projectId}/repository/branches/{branchName}", Method.Get);
		}

		[Fact]
		public async Task GetAll_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.GetAll(expected);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Fact]
		public async Task GetAll_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.GetAll(0);

			_requestFactory.Received().Create("projects/{projectId}/repository/branches", Method.Get);
		}

		[Fact]
		public async Task Protect_BranchNameIsNull_ThrowsArgumentNullException()
		{
			await Assert.ThrowsAsync<ArgumentNullException>(() => _sut.Protect(0, null));
		}

		[Fact]
		public async Task Protect_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Protect(expected, "branchName");

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Fact]
		public async Task Protect_ValidParameters_AddsBranchNameUrlSegment()
		{
			const string expected = "branchName";

			await _sut.Protect(0, expected);

			_request.Received().AddUrlSegment("branchName", expected);
		}

		[Fact]
		public async Task Protect_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.Protect(0, "branchName");

			_requestFactory.Received().Create("projects/{projectId}/repository/branches/{branchName}/protect", Method.Put);
		}

		[Fact]
		public async Task Unprotect_BranchNameIsNull_ThrowsArgumentNullException()
		{
			await Assert.ThrowsAsync<ArgumentNullException>(() => _sut.Unprotect(0, null));
		}

		[Fact]
		public async Task Unprotect_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Unprotect(expected, "branchName");

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Fact]
		public async Task Unprotect_ValidParameters_AddsBranchNameUrlSegment()
		{
			const string expected = "branchName";

			await _sut.Unprotect(0, expected);

			_request.Received().AddUrlSegment("branchName", expected);
		}

		[Fact]
		public async Task Unprotect_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.Unprotect(0, "branchName");

			_requestFactory.Received().Create("projects/{projectId}/repository/branches/{branchName}/unprotect", Method.Put);
		}
	}
}
