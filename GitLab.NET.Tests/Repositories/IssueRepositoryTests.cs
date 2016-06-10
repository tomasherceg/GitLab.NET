using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NSubstitute;
using NUnit.Framework;

namespace GitLab.NET.Tests.Repositories
{
	public class IssueRepositoryTests
	{
		public IssueRepositoryTests()
		{
			_request = Substitute.For<IRequest>();
			_requestFactory = Substitute.For<IRequestFactory>();
			_requestFactory.Create(Arg.Any<string>(), Arg.Any<Method>(), Arg.Any<bool>()).Returns(_request);
			_sut = new IssueRepository(_requestFactory);
		}

		private readonly IRequest _request;
		private readonly IRequestFactory _requestFactory;
		private readonly IssueRepository _sut;

		[Test]
		public async Task Create_AssigneeIdIsSet_AddsAssigneeIdParameter()
		{
			const uint expected = 0;

			await _sut.Create(0, "title", assigneeId: expected);

			_request.Received().AddParameterIfNotNull("assignee_id", expected);
		}

		[Test]
		public async Task Create_CreatedAtIsSet_AddsCreatedAtParameter()
		{
			var expected = DateTime.Now;

			await _sut.Create(0, "title", createdAt: expected);

			_request.Received().AddParameterIfNotNull("created_at", expected);
		}

		[Test]
		public async Task Create_DescriptionIsSet_AddsDescriptionParameter()
		{
			const string expected = "description";

			await _sut.Create(0, "title", expected);

			_request.Received().AddParameterIfNotNull("description", expected);
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

			await _sut.Create(0, "title", labels: labels);

			_request.Received().AddParameterIfNotNull("labels", expected);
		}

		[Test]
		public async Task Create_MilestoneIdIsSet_AddsMilestoneIdParameter()
		{
			const uint expected = 0;

			await _sut.Create(0, "title", milestoneId: expected);

			_request.Received().AddParameterIfNotNull("milestone_id", expected);
		}

		[Test]
		public void Create_TitleIsNull_ThrowsArgumentNullException()
		{
			Assert.ThrowsAsync<ArgumentNullException>(() => _sut.Create(0, null));
		}

		[Test]
		public async Task Create_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Create(expected, "title");

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Create_ValidParameters_AddsTitleParameter()
		{
			const string expected = "title";

			await _sut.Create(0, expected);

			_request.Received().AddParameter("title", expected);
		}

		[Test]
		public async Task Create_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.Create(0, "title");

			_requestFactory.Received().Create("projects/{projectId}/issues", Method.Post);
		}

		[Test]
		public async Task Delete_ValidParameters_AddsIssueIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Delete(0, expected);

			_request.Received().AddUrlSegment("issueId", expected);
		}

		[Test]
		public async Task Delete_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Delete(expected, 0);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Delete_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.Delete(0, 0);

			_requestFactory.Received().Create("projects/{projectId}/issues/{issueId}", Method.Delete);
		}

		[Test]
		public async Task Find_ValidParameters_AddsIssueIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Find(0, expected);

			_request.Received().AddUrlSegment("issueId", expected);
		}

		[Test]
		public async Task Find_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Find(expected, 0);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Find_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.Find(0, 0);

			_requestFactory.Received().Create("projects/{projectId}/issues/{issueId}", Method.Get);
		}

		[Test]
		public async Task GetByProject_LabelsIsSet_AddsLabelsParameter()
		{
			var labels = new[]
			{
				"label1",
				"label2"
			};
			const string expected = "label1,label2";

			await _sut.GetByProject(0, labels: labels);

			_request.Received().AddParameterIfNotNull("labels", expected);
		}

		[Test]
		public async Task GetByProject_MilestoneIsSet_AddsMilestoneParameter()
		{
			const string expected = "milestone";

			await _sut.GetByProject(0, milestone: expected);

			_request.Received().AddParameterIfNotNull("milestone", expected);
		}

		[Test]
		public async Task GetByProject_OrderByIsSet_AddsOrderByParameter()
		{
			const OrderBy orderBy = OrderBy.UpdatedAt;
			const string expected = "updated_at";

			await _sut.GetByProject(0, orderBy: orderBy);

			_request.Received().AddParameterIfNotNull("order_by", expected);
		}

		[Test]
		public async Task GetByProject_SortIsSet_AddsSortParameter()
		{
			const SortOrder sort = SortOrder.Asc;
			const string expected = "asc";

			await _sut.GetByProject(0, sort: sort);

			_request.Received().AddParameterIfNotNull("sort", expected);
		}

		[Test]
		public async Task GetByProject_StateIsSet_AddsStateParameter()
		{
			const string expected = "closed";
			const IssueState state = IssueState.Closed;

			await _sut.GetByProject(0, state);

			_request.Received().AddParameterIfNotNull("state", expected);
		}

		[Test]
		public async Task GetByProject_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.GetByProject(expected);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task GetByProject_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.GetByProject(0);

			_requestFactory.Received().Create("projects/{projectId}/issues", Method.Get);
		}

		[Test]
		public async Task GetOwned_LabelsIsSet_AddsLabelsParameter()
		{
			var labels = new[]
			{
				"label1",
				"label2"
			};
			const string expected = "label1,label2";

			await _sut.GetOwned(labels: labels);

			_request.Received().AddParameterIfNotNull("labels", expected);
		}

		[Test]
		public async Task GetOwned_OrderByIsSet_AddsOrderByParameter()
		{
			const string expected = "updated_at";
			const OrderBy orderBy = OrderBy.UpdatedAt;

			await _sut.GetOwned(orderBy: orderBy);

			_request.Received().AddParameterIfNotNull("order_by", expected);
		}

		[Test]
		public async Task GetOwned_SortIsSet_AddsSortParameter()
		{
			const string expected = "asc";
			const SortOrder sort = SortOrder.Asc;

			await _sut.GetOwned(sort: sort);

			_request.Received().AddParameterIfNotNull("sort", expected);
		}

		[Test]
		public async Task GetOwned_StateIsSet_AddsStateParameter()
		{
			const string expected = "opened";
			const IssueState state = IssueState.Opened;

			await _sut.GetOwned(state);

			_request.Received().AddParameterIfNotNull("state", expected);
		}

		[Test]
		public async Task GetOwned_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.GetOwned();

			_requestFactory.Received().Create("issues", Method.Get);
		}

		[Test]
		public async Task Move_ValidParameters_AddsIssueIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Move(0, expected, 0);

			_request.Received().AddUrlSegment("issueId", expected);
		}

		[Test]
		public async Task Move_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Move(expected, 0, 0);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Move_ValidParameters_AddsToProjectIdParameter()
		{
			const uint expected = 0;

			await _sut.Move(0, 0, expected);

			_request.Received().AddParameter("to_project_id", expected);
		}

		[Test]
		public async Task Move_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.Move(0, 0, 0);

			_requestFactory.Received().Create("projects/{projectId}/issues/{issueId}/move", Method.Post);
		}

		[Test]
		public async Task Subscribe_ValidParameters_AddsIssueIdParameter()
		{
			const uint expected = 0;

			await _sut.Subscribe(0, expected);

			_request.Received().AddUrlSegment("issueId", expected);
		}

		[Test]
		public async Task Subscribe_ValidParameters_AddsProjectIdParameter()
		{
			const uint expected = 0;

			await _sut.Subscribe(expected, 0);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Subscribe_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.Subscribe(0, 0);

			_requestFactory.Received().Create("projects/{projectId}/issues/{issueId}/subscription", Method.Post);
		}

		[Test]
		public async Task Unsubscribe_ValidParameters_AddsIssueIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Unsubscribe(0, expected);

			_request.Received().AddUrlSegment("issueId", expected);
		}

		[Test]
		public async Task Unsubscribe_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Unsubscribe(expected, 0);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Unsubscribe_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.Unsubscribe(0, 0);

			_requestFactory.Received().Create("projects/{projectId}/issues/{issueId}/subscription", Method.Delete);
		}

		[Test]
		public async Task Update_AssigneeIdIsSet_AddsAssigneeIdParameter()
		{
			const uint expected = 0;

			await _sut.Update(0, 0, assigneeId: expected);

			_request.Received().AddParameterIfNotNull("assignee_id", expected);
		}

		[Test]
		public async Task Update_DescriptionIsSet_AddsDescriptionParameter()
		{
			const string expected = "description";

			await _sut.Update(0, 0, description: expected);

			_request.Received().AddParameterIfNotNull("description", expected);
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
		public async Task Update_StateIsSet_AddsStateEventParameter()
		{
			const string expected = "close";
			const IssueStateEvent state = IssueStateEvent.Close;

			await _sut.Update(0, 0, state: state);

			_request.Received().AddParameterIfNotNull("state_event", expected);
		}

		[Test]
		public async Task Update_TitleIsSet_AddsTitleParameter()
		{
			const string expected = "title";

			await _sut.Update(0, 0, expected);

			_request.Received().AddParameterIfNotNull("title", expected);
		}

		[Test]
		public async Task Update_UpdatedAtIsSet_AddsUpdatedAtParameter()
		{
			var expected = DateTime.Now;

			await _sut.Update(0, 0, updatedAt: expected);

			_request.Received().AddParameterIfNotNull("updated_at", expected);
		}

		[Test]
		public async Task Update_ValidParameters_AddsIssueIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Update(0, expected);

			_request.Received().AddUrlSegment("issueId", expected);
		}

		[Test]
		public async Task Update_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Update(expected, 0);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Update_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.Update(0, 0);

			_requestFactory.Received().Create("projects/{projectId}/issues/{issueId}", Method.Put);
		}
	}
}
