using NSubstitute;
using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NUnit.Framework;

namespace GitLab.NET.Tests.Repositories
{
	public class MergeRequestRepositoryTests
	{
		public MergeRequestRepositoryTests()
		{
			_request = Substitute.For<IRequest>();
			_requestFactory = Substitute.For<IRequestFactory>();
			_requestFactory.Create(Arg.Any<string>(), Arg.Any<Method>(), Arg.Any<bool>()).Returns(_request);
			_sut = new MergeRequestRepository(_requestFactory);
		}

		private readonly IRequest _request;
		private readonly IRequestFactory _requestFactory;
		private readonly MergeRequestRepository _sut;

		[Test]
		public async Task Accept_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Accept(expected, 0);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Accept_ValidParameters_AddsMergeRequestIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Accept(0, expected);

			_request.Received().AddUrlSegment("mergeRequestId", expected);
		}

		[Test]
		public async Task Accept_CommitMessageIsSet_AddsMergeCommitMessageParameter()
		{
			const string expected = "commitMessage";

			await _sut.Accept(0, 0, commitMessage: expected);

			_request.Received().AddParameterIfNotNull("merge_commit_message", expected);
		}

		[Test]
		public async Task Accept_RemoveSourceBranchIsSet_AddsShouldRemoveSourceBranchParameter()
		{
			const bool expected = true;

			await _sut.Accept(0, 0, removeSourceBranch: expected);

			_request.Received().AddParameterIfNotNull("should_remove_source_branch", expected);
		}

		[Test]
		public async Task Accept_MergedWhenBuildSucceedsIsSet_AddsMergedWhenBuildSucceedsParameter()
		{
			const bool expected = true;

			await _sut.Accept(0, 0, mergedWhenBuildSucceeds: expected);

			_request.Received().AddParameterIfNotNull("merged_when_build_succeeds", expected);
		}

		[Test]
		public async Task Accept_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.Accept(0, 0);

			_requestFactory.Received().Create("projects/{projectId}/merge_requests/{mergeRequestId}/merge", Method.Put);
		}

		[Test]
		public async Task CancelMergeOnBuildSuccess_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.CancelMergeOnBuildSuccess(expected, 0);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task CancelMergeOnBuildSuccess_ValidParameters_AddsMergeRequestIdParameter()
		{
			const uint expected = 0;

			await _sut.CancelMergeOnBuildSuccess(0, expected);

			_request.Received().AddUrlSegment("mergeRequestId", expected);
		}

		[Test]
		public async Task CancelMergeOnBuildSuccess_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.CancelMergeOnBuildSuccess(0, 0);

			_requestFactory.Received().Create("projects/{projectId}/merge_requests/{mergeRequestId}/cancel_merge_when_build_succeeds", Method.Put);
		}

		[Test]
		public void Create_SourceBranchIsNull_ThrowsArgumentNullException()
		{
			Assert.ThrowsAsync<ArgumentNullException>(() => _sut.Create(0, null, "targetBranch", "title"));
		}

		[Test]
		public void Create_TargetBranchIsNull_ThrowsArgumentNullException()
		{
			Assert.ThrowsAsync<ArgumentNullException>(() => _sut.Create(0, "sourceBranch", null, "title"));
		}

		[Test]
		public void Create_TitleIsNull_ThrowsArgumentNullException()
		{
			Assert.ThrowsAsync<ArgumentNullException>(() => _sut.Create(0, "sourceBranch", "targetBranch", null));
		}

		[Test]
		public async Task Create_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Create(expected, "sourceBranch", "targetBranch", "title");

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Create_ValidParameters_AddsSourceBranchParameter()
		{
			const string expected = "sourceBranch";

			await _sut.Create(0, expected, "targetBranch", "title");

			_request.Received().AddParameter("source_branch", expected);
		}

		[Test]
		public async Task Create_ValidParameters_AddsTargetBranchParameter()
		{
			const string expected = "targetBranch";

			await _sut.Create(0, "sourceBranch", expected, "title");

			_request.Received().AddParameter("target_branch", expected);
		}

		[Test]
		public async Task Create_ValidParameters_AddsTitleParameter()
		{
			const string expected = "title";

			await _sut.Create(0, "sourceBranch", "targetBranch", expected);

			_request.Received().AddParameter("title", expected);
		}

		[Test]
		public async Task Create_AssigneeIdIsSet_AddsAssigneeIdParameter()
		{
			const uint expected = 0;

			await _sut.Create(0, "sourceBranch", "targetBranch", "title", assigneeId: expected);

			_request.Received().AddParameterIfNotNull("assignee_id", expected);
		}

		[Test]
		public async Task Create_DescriptionIsSet_AddsDescriptionParameter()
		{
			const string expected = "description";

			await _sut.Create(0, "sourceBranch", "targetBranch", "title", description: expected);

			_request.Received().AddParameterIfNotNull("description", expected);
		}

		[Test]
		public async Task Create_TargetProjectIdIsSet_AddsTargetProjectIdParameter()
		{
			const uint expected = 0;

			await _sut.Create(0, "sourceBranch", "targetBranch", "title", targetProjectId: expected);

			_request.Received().AddParameterIfNotNull("target_project_id", expected);
		}

		[Test]
		public async Task Create_LabelsIsSet_AddsLabelsParameter()
		{
			var labels = new[]
			{
				"label1",
				"label2"
			};
			const string expected = "label1,label2";

			await _sut.Create(0, "sourceBranch", "targetBranch", "title", labels: labels);

			_request.Received().AddParameterIfNotNull("labels", expected);
		}

		[Test]
		public async Task Create_MilestoneIdIsSet_AddsMilestoneIdParameter()
		{
			const uint expected = 0;

			await _sut.Create(0, "sourceBranch", "targetBranch", "title", milestoneId: expected);

			_request.Received().AddParameterIfNotNull("milestone_id", expected);
		}

		[Test]
		public async Task Create_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.Create(0, "sourceBranch", "targetBranch", "title");

			_requestFactory.Received().Create("projects/{projectId}/merge_requests", Method.Post);
		}

		[Test]
		public async Task Delete_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Delete(expected, 0);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Delete_ValidParameters_AddsMergeRequestIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Delete(0, expected);

			_request.Received().AddUrlSegment("mergeRequestId", expected);
		}

		[Test]
		public async Task Delete_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.Delete(0, 0);

			_requestFactory.Received().Create("projects/{projectId}/merge_requests/{mergeRequestId}", Method.Delete);
		}

		[Test]
		public async Task Find_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Find(expected, 0);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Find_ValidParameters_AddsMergeRequestIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Find(0, expected);

			_request.Received().AddUrlSegment("mergeRequestId", expected);
		}

		[Test]
		public async Task Find_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.Find(0, 0);

			_requestFactory.Received().Create("projects/{projectId}/merge_requests/{mergeRequestId}", Method.Get);
		}

		[Test]
		public void GetAll_PageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
		{
			Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => _sut.GetAll(0, page: uint.MinValue));
		}

		[Test]
		public void GetAll_ResultsPerPageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
		{
			Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => _sut.GetAll(0, resultsPerPage: uint.MinValue));
		}

		[Test]
		public void GetAll_ResultsPerPageIsGreaterThanMaximum_ThrowsArgumentOutOfRangeException()
		{
			Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => _sut.GetAll(0, resultsPerPage: uint.MaxValue));
		}

		[Test]
		public async Task GetAll_PageIsSet_AddsPageParameter()
		{
			const uint expected = 5;

			await _sut.GetAll(0, page: expected);

			_request.Received().AddParameter("page", expected);
		}

		[Test]
		public async Task GetAll_ResultsPerPageIsSet_AddsPerPageParameter()
		{
			const uint expected = 5;

			await _sut.GetAll(0, resultsPerPage: expected);

			_request.Received().AddParameter("per_page", expected);
		}

		[Test]
		public async Task GetAll_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.GetAll(expected);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task GetAll_StateIsSet_AddsStateParameter()
		{
			const MergeRequestState state = MergeRequestState.Merged;
			const string expected = "merged";

			await _sut.GetAll(0, state: state);

			_request.Received().AddParameterIfNotNull("state", expected);
		}

		[Test]
		public async Task GetAll_OrderByIsSet_AddsOrderByParameter()
		{
			const OrderBy orderBy = OrderBy.UpdatedAt;
			const string expected = "updated_at";

			await _sut.GetAll(0, orderBy: orderBy);

			_request.Received().AddParameterIfNotNull("order_by", expected);
		}

		[Test]
		public async Task GetAll_SortIsSet_AddsSortParameter()
		{
			const SortOrder sort = SortOrder.Asc;
			const string expected = "asc";

			await _sut.GetAll(0, sort: sort);

			_request.Received().AddParameterIfNotNull("sort", expected);
		}

		[Test]
		public async Task GetAll_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.GetAll(0);

			_requestFactory.Received().Create("projects/{projectId}/merge_requests", Method.Get);
		}

		[Test]
		public async Task GetChanges_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.GetChanges(expected, 0);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task GetChanges_ValidParameters_AddsMergeRequestIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.GetChanges(0, expected);

			_request.Received().AddUrlSegment("mergeRequestId", expected);
		}

		[Test]
		public async Task GetChanges_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.GetChanges(0, 0);

			_requestFactory.Received().Create("projects/{projectId}/merge_requests/{mergeRequestId}/changes", Method.Get);
		}

		[Test]
		public async Task GetCommits_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.GetCommits(expected, 0);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task GetCommits_ValidParameters_AddsMergeRequestIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.GetCommits(0, expected);

			_request.Received().AddUrlSegment("mergeRequestId", expected);
		}

		[Test]
		public async Task GetCommits_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.GetCommits(0, 0);

			_requestFactory.Received().Create("projects/{projectId}/merge_requests/{mergeRequestId}/commits", Method.Get);
		}

		[Test]
		public void GetIssuesClosedOnMerge_PageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
		{
			Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => _sut.GetIssuesClosedOnMerge(0, 0, page: uint.MinValue));
		}

		[Test]
		public void GetIssuesClosedOnMerge_ResultsPerPageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
		{
			Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => _sut.GetIssuesClosedOnMerge(0, 0, resultsPerPage: uint.MinValue));
		}

		[Test]
		public void GetIssuesClosedOnMerge_ResultsPerPageIsGreaterThanMaximum_ThrowsArgumentOutOfRangeException()
		{
			Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => _sut.GetIssuesClosedOnMerge(0, 0, resultsPerPage: uint.MaxValue));
		}

		[Test]
		public async Task GetIssuesClosedOnMerge_PageIsSet_AddsPageParameter()
		{
			const uint expected = 5;

			await _sut.GetIssuesClosedOnMerge(0, 0, page: expected);

			_request.Received().AddParameter("page", expected);
		}

		[Test]
		public async Task GetIssuesClosedOnMerge_ResultsPerPageIsSet_AddsPerPageParameter()
		{
			const uint expected = 5;

			await _sut.GetIssuesClosedOnMerge(0, 0, resultsPerPage: expected);

			_request.Received().AddParameter("per_page", expected);
		}

		[Test]
		public async Task GetIssuesClosedOnMerge_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.GetIssuesClosedOnMerge(expected, 0);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task GetIssuesClosedOnMerge_ValidParameters_AddsMergeRequestIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.GetIssuesClosedOnMerge(0, expected);

			_request.Received().AddUrlSegment("mergeRequestId", expected);
		}

		[Test]
		public async Task GetIssuesClosedOnMerge_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.GetIssuesClosedOnMerge(0, 0);

			_requestFactory.Received().Create("projects/{projectId}/merge_requests/{mergeRequestId}/closes_issues", Method.Get);
		}

		[Test]
		public async Task Subscribe_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Subscribe(expected, 0);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Subscribe_ValidParameters_AddsMergeRequestIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Subscribe(0, expected);

			_request.Received().AddUrlSegment("mergeRequestId", expected);
		}

		[Test]
		public async Task Subscribe_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.Subscribe(0, 0);

			_requestFactory.Received().Create("projects/{projectId}/merge_requests/{mergeRequestId}/subscription", Method.Post);
		}

		[Test]
		public async Task Unsubscribe_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Unsubscribe(expected, 0);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Unsubscribe_ValidParameters_AddsMergeRequestIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Unsubscribe(0, expected);

			_request.Received().AddUrlSegment("mergeRequestId", expected);
		}

		[Test]
		public async Task Unsubscribe_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.Unsubscribe(0, 0);

			_requestFactory.Received().Create("projects/{projectId}/merge_requests/{mergeRequestId}/subscription", Method.Delete);
		}

		[Test]
		public async Task Update_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Update(expected, 0);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Update_ValidParameters_AddsMergeRequestIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Update(0, expected);

			_request.Received().AddUrlSegment("mergeRequestId", expected);
		}

		[Test]
		public async Task Update_TargetBranchIsSet_AddsTargetBranchParameter()
		{
			const string expected = "targetBranch";

			await _sut.Update(0, 0, targetBranch: expected);

			_request.Received().AddParameterIfNotNull("target_branch", expected);
		}

		[Test]
		public async Task Update_AssigneeIdIsSet_AddsAssigneeIdParameter()
		{
			const uint expected = 0;

			await _sut.Update(0, 0, assigneeId: expected);

			_request.Received().AddParameterIfNotNull("assignee_id", expected);
		}

		[Test]
		public async Task Update_TitleIsSet_AddsTitleParameter()
		{
			const string expected = "title";

			await _sut.Update(0, 0, title: expected);

			_request.Received().AddParameterIfNotNull("title", expected);
		}

		[Test]
		public async Task Update_DescriptionIsSet_AddsDescriptionParameter()
		{
			const string expected = "description";

			await _sut.Update(0, 0, description: expected);

			_request.Received().AddParameterIfNotNull("description", expected);
		}

		[Test]
		public async Task Update_StateIsSet_AddsStateEventParameter()
		{
			const MergeRequestStateEvent state = MergeRequestStateEvent.Merge;
			const string expected = "merge";

			await _sut.Update(0, 0, state: state);

			_request.Received().AddParameterIfNotNull("state", expected);
		}

		[Test]
		public async Task Update_LabelsIsSet_AddsLabelsParameter()
		{
			var labels = new[]
			{
				"label1",
				"label2"
			};
			const string expected = "label1,label2";

			await _sut.Update(0, 0, labels: labels);

			_request.Received().AddParameterIfNotNull("labels", expected);
		}

		[Test]
		public async Task Update_MilestoneIdIsSet_AddsMilestoneIdParameter()
		{
			const uint expected = 0;

			await _sut.Update(0, 0, milestoneId: expected);

			_request.Received().AddParameterIfNotNull("milestone_id", expected);
		}

		[Test]
		public async Task Update_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.Update(0, 0);

			_requestFactory.Received().Create("projects/{projectId}/merge_requests/{mergeRequestId}", Method.Put);
		}
	}
}
