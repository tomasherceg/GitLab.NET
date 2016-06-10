using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NSubstitute;
using NUnit.Framework;

namespace GitLab.NET.Tests.Repositories
{
	public class CommitRepositoryTests
	{
		public CommitRepositoryTests()
		{
			_request = Substitute.For<IRequest>();
			_requestFactory = Substitute.For<IRequestFactory>();
			_requestFactory.Create(Arg.Any<string>(), Arg.Any<Method>(), Arg.Any<bool>()).Returns(_request);
		}

		private readonly IRequest _request;
		private readonly IRequestFactory _requestFactory;

		[Test]
		public void CreateComment_CommitShaIsNull_ThrowsArgumentNullException()
		{
			var sut = new CommitRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateComment(0, null, "note"));
		}

		[Test]
		public async Task CreateComment_LineIsSet_AddsLineParameter()
		{
			const uint expected = 0;
			var sut = new CommitRepository(_requestFactory);

			await sut.CreateComment(0, "commitSha", "note", line: expected);

			_request.Received().AddParameterIfNotNull("line", expected);
		}

		[Test]
		public async Task CreateComment_LineTypeIsSet_AddsLineTypeParameter()
		{
			const string expected = "new";
			const LineType lineType = LineType.New;
			var sut = new CommitRepository(_requestFactory);

			await sut.CreateComment(0, "commitSha", "note", lineType: lineType);

			_request.Received().AddParameterIfNotNull("line_type", expected);
		}

		[Test]
		public void CreateComment_NoteIsNull_ThrowsArgumentNullException()
		{
			var sut = new CommitRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateComment(0, "commitSha", null));
		}

		[Test]
		public async Task CreateComment_PathIsSet_AddsPathParameter()
		{
			const string expected = "path";
			var sut = new CommitRepository(_requestFactory);

			await sut.CreateComment(0, "commitSha", "note", expected);

			_request.Received().AddParameterIfNotNull("path", expected);
		}

		[Test]
		public async Task CreateComment_ValidParameters_AddsCommitShaUrlSegment()
		{
			const string expected = "commitSha";
			var sut = new CommitRepository(_requestFactory);

			await sut.CreateComment(0, expected, "note");

			_request.Received().AddUrlSegment("commitSha", expected);
		}

		[Test]
		public async Task CreateComment_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new CommitRepository(_requestFactory);

			await sut.CreateComment(expected, "commitSha", "note");

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task CreateComment_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new CommitRepository(_requestFactory);

			await sut.CreateComment(0, "commitSha", "note");

			_requestFactory.Received().Create("projects/{projectId}/repository/commits/{commitSha}/comments", Method.Post);
		}

		[Test]
		public async Task CreateCommit_ValidParameters_AddsNoteParameter()
		{
			const string expected = "note";
			var sut = new CommitRepository(_requestFactory);

			await sut.CreateComment(0, "commitSha", expected);

			_request.Received().AddParameter("note", expected);
		}

		[Test]
		public void CreateStatus_CommitShaIsNull_ThrowsArgumentNullException()
		{
			var sut = new CommitRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateStatus(0, null, BuildStatus.Pending));
		}

		[Test]
		public async Task CreateStatus_DescriptionIsSet_AddsDescriptionParameter()
		{
			const string expected = "description";
			var sut = new CommitRepository(_requestFactory);

			await sut.CreateStatus(0, "commitSha", BuildStatus.Pending, description: expected);

			_request.Received().AddParameterIfNotNull("description", expected);
		}

		[Test]
		public async Task CreateStatus_NameIsSet_AddsNameParameter()
		{
			const string expected = "name";
			var sut = new CommitRepository(_requestFactory);

			await sut.CreateStatus(0, "commitSha", BuildStatus.Pending, name: expected);

			_request.Received().AddParameterIfNotNull("name", expected);
		}

		[Test]
		public async Task CreateStatus_RefNameIsSet_AddsRefNameParameter()
		{
			const string expected = "refName";
			var sut = new CommitRepository(_requestFactory);

			await sut.CreateStatus(0, "commitSha", BuildStatus.Pending, expected);

			_request.Received().AddParameterIfNotNull("ref", expected);
		}

		[Test]
		public async Task CreateStatus_TargetUrlIsSet_AddsTargetUrlParameter()
		{
			const string expected = "targetUrl";
			var sut = new CommitRepository(_requestFactory);

			await sut.CreateStatus(0, "commitSha", BuildStatus.Pending, targetUrl: expected);

			_request.Received().AddParameterIfNotNull("target_url", expected);
		}

		[Test]
		public async Task CreateStatus_ValidParameters_AddsCommitShaUrlSegment()
		{
			const string expected = "commitSha";
			var sut = new CommitRepository(_requestFactory);

			await sut.CreateStatus(0, expected, BuildStatus.Pending);

			_request.Received().AddUrlSegment("commitSha", expected);
		}

		[Test]
		public async Task CreateStatus_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new CommitRepository(_requestFactory);

			await sut.CreateStatus(expected, "commitSha", BuildStatus.Pending);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task CreateStatus_ValidParameters_AddsStateParameter()
		{
			const string expected = "pending";
			const BuildStatus state = BuildStatus.Pending;
			var sut = new CommitRepository(_requestFactory);

			await sut.CreateStatus(0, "commitSha", state);

			_request.Received().AddParameter("state", expected);
		}

		[Test]
		public async Task CreateStatus_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new CommitRepository(_requestFactory);

			await sut.CreateStatus(0, "commitSha", BuildStatus.Pending);

			_requestFactory.Received().Create("projects/{projectId}/statuses/{commitSha}", Method.Post);
		}

		[Test]
		public void Find_CommitShaIsNull_ThrowsArgumentNullException()
		{
			var sut = new CommitRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.Find(0, null));
		}

		[Test]
		public async Task Find_ValidParameters_AddsCommitShaUrlSegment()
		{
			const string expected = "commitSha";
			var sut = new CommitRepository(_requestFactory);

			await sut.Find(0, expected);

			_request.Received().AddUrlSegment("commitSha", expected);
		}

		[Test]
		public async Task Find_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new CommitRepository(_requestFactory);

			await sut.Find(expected, "commitSha");

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Find_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new CommitRepository(_requestFactory);

			await sut.Find(0, "commitSha");

			_requestFactory.Received().Create("projects/{projectId}/repository/commits/{commitSha}", Method.Get);
		}

		[Test]
		public async Task GetAll_RefNameIsSet_AddsRefNameParameter()
		{
			const string expected = "refName";
			var sut = new CommitRepository(_requestFactory);

			await sut.GetAll(0, expected);

			_request.Received().AddParameterIfNotNull("ref_name", expected);
		}

		[Test]
		public async Task GetAll_SinceIsSet_AddsSinceParameter()
		{
			var expected = DateTime.MinValue;
			var sut = new CommitRepository(_requestFactory);

			await sut.GetAll(0, since: expected);

			_request.Received().AddParameterIfNotNull("since", expected);
		}

		[Test]
		public async Task GetAll_UntilIsSet_AddsUntilParameter()
		{
			var expected = DateTime.MaxValue;
			var sut = new CommitRepository(_requestFactory);

			await sut.GetAll(0, until: expected);

			_request.Received().AddParameterIfNotNull("until", expected);
		}

		[Test]
		public async Task GetAll_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new CommitRepository(_requestFactory);

			await sut.GetAll(expected);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task GetAll_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new CommitRepository(_requestFactory);

			await sut.GetAll(0);

			_requestFactory.Received().Create("projects/{projectId}/repository/commits", Method.Get);
		}

		[Test]
		public void GetComments_CommitShaIsNull_ThrowsArgumentNullException()
		{
			var sut = new CommitRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.GetComments(0, null));
		}

		[Test]
		public void GetComments_PageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
		{
			var sut = new CommitRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.GetComments(0, "commitSha", uint.MinValue));
		}

		[Test]
		public async Task GetComments_PageIsSet_AddsPageParameter()
		{
			const uint expected = 5;
			var sut = new CommitRepository(_requestFactory);

			await sut.GetComments(0, "commitSha", expected);

			_request.Received().AddParameter("page", expected);
		}

		[Test]
		public void GetComments_ResultsPerPageIsGreaterThanMaximum_ThrowsArgumentOutOfRangeException()
		{
			var sut = new CommitRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.GetComments(0, "commitSha", resultsPerPage: uint.MaxValue));
		}

		[Test]
		public void GetComments_ResultsPerPageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
		{
			var sut = new CommitRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.GetComments(0, "commitSha", resultsPerPage: uint.MinValue));
		}

		[Test]
		public async Task GetComments_ResultsPerPageIsSet_AddsPerPageParameter()
		{
			const uint expected = 5;
			var sut = new CommitRepository(_requestFactory);

			await sut.GetComments(0, "commitSha", resultsPerPage: expected);

			_request.Received().AddParameter("per_page", expected);
		}

		[Test]
		public async Task GetComments_ValidParameters_AddsCommitShaUrlSegment()
		{
			const string expected = "commitSha";
			var sut = new CommitRepository(_requestFactory);

			await sut.GetComments(0, expected);

			_request.Received().AddUrlSegment("commitSha", expected);
		}

		[Test]
		public async Task GetComments_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new CommitRepository(_requestFactory);

			await sut.GetComments(expected, "commitSha");

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task GetComments_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new CommitRepository(_requestFactory);

			await sut.GetComments(0, "commitSha");

			_requestFactory.Received().Create("projects/{projectId}/repository/commits/{commitSha}/comments", Method.Get);
		}

		[Test]
		public void GetDiff_CommitShaIsNull_ThrowsArgumentNullException()
		{
			var sut = new CommitRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.GetDiff(0, null));
		}

		[Test]
		public async Task GetDiff_ValidParameters_AddsCommitShaUrlSegment()
		{
			const string expected = "commitSha";
			var sut = new CommitRepository(_requestFactory);

			await sut.GetDiff(0, expected);

			_request.Received().AddUrlSegment("commitSha", expected);
		}

		[Test]
		public async Task GetDiff_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new CommitRepository(_requestFactory);

			await sut.GetDiff(expected, "commitSha");

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task GetDiff_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new CommitRepository(_requestFactory);

			await sut.GetDiff(0, "commitSha");

			_requestFactory.Received().Create("projects/{projectId}/repository/commits/{commitSha}/diff", Method.Get);
		}

		[Test]
		public async Task GetStatus_AllIsSet_AddsAllParameter()
		{
			const bool expected = true;
			var sut = new CommitRepository(_requestFactory);

			await sut.GetStatus(0, "commitSha", all: expected);

			_request.Received().AddParameterIfNotNull("all", expected);
		}

		[Test]
		public void GetStatus_CommitShaIsNull_ThrowsArgumentNullException()
		{
			var sut = new CommitRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.GetStatus(0, null));
		}

		[Test]
		public async Task GetStatus_NameIsSet_AddsNameParameter()
		{
			const string expected = "name";
			var sut = new CommitRepository(_requestFactory);

			await sut.GetStatus(0, "commitSha", name: expected);

			_request.Received().AddParameterIfNotNull("name", expected);
		}

		[Test]
		public void GetStatus_PageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
		{
			var sut = new CommitRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.GetStatus(0, "commitSha", page: uint.MinValue));
		}

		[Test]
		public async Task GetStatus_PageIsSet_AddsPageParameter()
		{
			const uint expected = 5;
			var sut = new CommitRepository(_requestFactory);

			await sut.GetStatus(0, "commitSha", page: expected);

			_request.Received().AddParameter("page", expected);
		}

		[Test]
		public async Task GetStatus_RefNameIsSet_AddsRefNameParameter()
		{
			const string expected = "refName";
			var sut = new CommitRepository(_requestFactory);

			await sut.GetStatus(0, "commitSha", expected);

			_request.Received().AddParameterIfNotNull("ref_name", expected);
		}

		[Test]
		public void GetStatus_ResultsPerPageIsGreaterThanMaximum_ThrowsArgumentOutOfRangeException()
		{
			var sut = new CommitRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.GetStatus(0, "commitSha", resultsPerPage: uint.MaxValue));
		}

		[Test]
		public void GetStatus_ResultsPerPageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
		{
			var sut = new CommitRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => sut.GetStatus(0, "commitSha", resultsPerPage: uint.MinValue));
		}

		[Test]
		public async Task GetStatus_ResultsPerPageIsSet_AddsPerPageParameter()
		{
			const uint expected = 5;
			var sut = new CommitRepository(_requestFactory);

			await sut.GetStatus(0, "commitSha", resultsPerPage: expected);

			_request.Received().AddParameter("per_page", expected);
		}

		[Test]
		public async Task GetStatus_StageIsSet_AddsStageParameter()
		{
			const string expected = "stage";
			var sut = new CommitRepository(_requestFactory);

			await sut.GetStatus(0, "commitSha", stage: expected);

			_request.Received().AddParameterIfNotNull("stage", expected);
		}

		[Test]
		public async Task GetStatus_ValidParameters_AddsCommitShaUrlSegment()
		{
			const string expected = "commitSha";
			var sut = new CommitRepository(_requestFactory);

			await sut.GetStatus(0, expected);

			_request.Received().AddUrlSegment("commitSha", expected);
		}

		[Test]
		public async Task GetStatus_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new CommitRepository(_requestFactory);

			await sut.GetStatus(expected, "commitSha");

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task GetStatus_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new CommitRepository(_requestFactory);

			await sut.GetStatus(0, "commitSha");

			_requestFactory.Received().Create("projects/{projectId}/repository/commits/{commitSha}/statuses", Method.Get);
		}

		[Test]
		public void UpdateStatus_CommitShaIsNull_ThrowsArgumentNullException()
		{
			var sut = new CommitRepository(_requestFactory);

			Assert.ThrowsAsync<ArgumentNullException>(() => sut.UpdateStatus(0, null, BuildStatus.Pending));
		}

		[Test]
		public async Task UpdateStatus_DescriptionIsSet_AddsDescriptionParameter()
		{
			const string expected = "description";
			var sut = new CommitRepository(_requestFactory);

			await sut.UpdateStatus(0, "commitSha", BuildStatus.Pending, description: expected);

			_request.Received().AddParameterIfNotNull("description", expected);
		}

		[Test]
		public async Task UpdateStatus_NameIsSet_AddsNameParameter()
		{
			const string expected = "name";
			var sut = new CommitRepository(_requestFactory);

			await sut.UpdateStatus(0, "commitSha", BuildStatus.Pending, name: expected);

			_request.Received().AddParameterIfNotNull("name", expected);
		}

		[Test]
		public async Task UpdateStatus_RefNameIsSet_AddsRefNameParameter()
		{
			const string expected = "refName";
			var sut = new CommitRepository(_requestFactory);

			await sut.UpdateStatus(0, "commitSha", BuildStatus.Pending, expected);

			_request.Received().AddParameterIfNotNull("ref", expected);
		}

		[Test]
		public async Task UpdateStatus_TargetUrlIsSet_AddsTargetUrlParameter()
		{
			const string expected = "targetUrl";
			var sut = new CommitRepository(_requestFactory);

			await sut.UpdateStatus(0, "commitSha", BuildStatus.Pending, targetUrl: expected);

			_request.Received().AddParameterIfNotNull("target_url", expected);
		}

		[Test]
		public async Task UpdateStatus_ValidParameters_AddsCommitShaUrlSegment()
		{
			const string expected = "commitSha";
			var sut = new CommitRepository(_requestFactory);

			await sut.UpdateStatus(0, expected, BuildStatus.Pending);

			_request.Received().AddUrlSegment("commitSha", expected);
		}

		[Test]
		public async Task UpdateStatus_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;
			var sut = new CommitRepository(_requestFactory);

			await sut.UpdateStatus(expected, "commitSha", BuildStatus.Pending);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task UpdateStatus_ValidParameters_AddsStateParameter()
		{
			const string expected = "pending";
			const BuildStatus state = BuildStatus.Pending;
			var sut = new CommitRepository(_requestFactory);

			await sut.UpdateStatus(0, "commitSha", state);

			_request.Received().AddParameter("state", expected);
		}

		[Test]
		public async Task UpdateStatus_ValidParameters_SetsCorrectResourceAndMethod()
		{
			var sut = new CommitRepository(_requestFactory);

			await sut.UpdateStatus(0, "commitSha", BuildStatus.Pending);

			_requestFactory.Received().Create("projects/{projectId}/statuses/{commitSha}", Method.Post);
		}
	}
}