using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NSubstitute;
using Xunit;

namespace GitLab.NET.Tests.Repositories
{
	public class MilestoneRepositoryTests
	{
		public MilestoneRepositoryTests()
		{
			_request = Substitute.For<IRequest>();
			_requestFactory = Substitute.For<IRequestFactory>();
			_requestFactory.Create(Arg.Any<string>(), Arg.Any<Method>(), Arg.Any<bool>()).Returns(_request);
			_sut = new MilestoneRepository(_requestFactory);
		}

		private readonly IRequest _request;
		private readonly IRequestFactory _requestFactory;
		private readonly MilestoneRepository _sut;

		[Fact]
		public async Task Create_DescriptionIsSet_AddsDescriptionParameter()
		{
			const string expected = "description";

			await _sut.Create(0, "title", expected);

			_request.Received().AddParameterIfNotNull("description", expected);
		}

		[Fact]
		public async Task Create_DueDateIsSet_AddsDueDateParameter()
		{
			var expected = DateTime.MaxValue;

			await _sut.Create(0, "title", dueDate: expected);

			_request.Received().AddParameterIfNotNull("due_date", expected);
		}

		[Fact]
		public async Task Create_TitleIsNull_ThrowsArgumentNullException()
		{
			await Assert.ThrowsAsync<ArgumentNullException>(() => _sut.Create(0, null));
		}

		[Fact]
		public async Task Create_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Create(expected, "title");

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Fact]
		public async Task Create_ValidParameters_AddsTitleParameter()
		{
			const string expected = "title";

			await _sut.Create(0, expected);

			_request.Received().AddParameter("title", expected);
		}

		[Fact]
		public async Task Create_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.Create(0, "title");

			_requestFactory.Received().Create("projects/{projectId}/milestones", Method.Post);
		}

		[Fact]
		public async Task Find_ValidParameters_AddsMilestoneIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Find(0, expected);

			_request.Received().AddUrlSegment("milestoneId", expected);
		}

		[Fact]
		public async Task Find_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Find(expected, 0);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Fact]
		public async Task Find_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.Find(0, 0);

			_requestFactory.Received().Create("projects/{projectId}/milestones/{milestoneId}", Method.Get);
		}

		[Fact]
		public async Task GetAll_PageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
		{
			await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => _sut.GetAll(0, page: uint.MinValue));
		}

		[Fact]
		public async Task GetAll_PageIsSet_AddsPageParameter()
		{
			const uint expected = 5;

			await _sut.GetAll(0, page: expected);

			_request.Received().AddParameter("page", expected);
		}

		[Fact]
		public async Task GetAll_ResultsPerPageIsGreaterThanMaximum_ThrowsArgumentOutOfRangeException()
		{
			await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => _sut.GetAll(0, resultsPerPage: uint.MaxValue));
		}

		[Fact]
		public async Task GetAll_ResultsPerPageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
		{
			await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => _sut.GetAll(0, resultsPerPage: uint.MinValue));
		}

		[Fact]
		public async Task GetAll_ResultsPerPageIsSet_AddsPerPageParameter()
		{
			const uint expected = 5;

			await _sut.GetAll(0, resultsPerPage: expected);

			_request.Received().AddParameter("per_page", expected);
		}

		[Fact]
		public async Task GetAll_StateIsSet_AddsStateParameter()
		{
			const string expected = "active";
			const MilestoneState state = MilestoneState.Active;

			await _sut.GetAll(0, state);

			_request.Received().AddParameterIfNotNull("state", expected);
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

			_requestFactory.Received().Create("projects/{projectId}/milestones", Method.Get);
		}

		[Fact]
		public async Task GetIssues_PageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
		{
			await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => _sut.GetIssues(0, 0, uint.MinValue));
		}

		[Fact]
		public async Task GetIssues_PageIsSet_AddsPageParameter()
		{
			const uint expected = 5;

			await _sut.GetIssues(0, 0, expected);

			_request.Received().AddParameter("page", expected);
		}

		[Fact]
		public async Task GetIssues_ResultsPerPageIsGreaterThanMaximum_ThrowsArgumentOutOfRangeException()
		{
			await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => _sut.GetIssues(0, 0, resultsPerPage: uint.MaxValue));
		}

		[Fact]
		public async Task GetIssues_ResultsPerPageIsLessThanMinimum_ThrowsArgumentOutOfRangeException()
		{
			await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => _sut.GetIssues(0, 0, resultsPerPage: uint.MinValue));
		}

		[Fact]
		public async Task GetIssues_ResultsPerPageIsSet_AddsPerPageParameter()
		{
			const uint expected = 5;

			await _sut.GetIssues(0, 0, resultsPerPage: expected);

			_request.Received().AddParameter("per_page", expected);
		}

		[Fact]
		public async Task GetIssues_ValidParameters_AddsMilestoneIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.GetIssues(0, expected);

			_request.Received().AddUrlSegment("milestoneId", expected);
		}

		[Fact]
		public async Task GetIssues_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.GetIssues(expected, 0);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Fact]
		public async Task Update_DescriptionIsSet_AddsDescriptionParameter()
		{
			const string expected = "description";

			await _sut.Update(0, 0, description: expected);

			_request.Received().AddParameterIfNotNull("description", expected);
		}

		[Fact]
		public async Task Update_DueDateIsSet_AddsDueDateParameter()
		{
			var expected = DateTime.MaxValue;

			await _sut.Update(0, 0, dueDate: expected);

			_request.Received().AddParameterIfNotNull("due_date", expected);
		}

		[Fact]
		public async Task Update_StateIsSet_AddsStateEventParameter()
		{
			const string expected = "activate";
			const MilestoneStateEvent state = MilestoneStateEvent.Activate;

			await _sut.Update(0, 0, state: state);

			_request.Received().AddParameterIfNotNull("state_event", expected);
		}

		[Fact]
		public async Task Update_TitleIsSet_AddsTitleParameter()
		{
			const string expected = "title";

			await _sut.Update(0, 0, expected);

			_request.Received().AddParameterIfNotNull("title", expected);
		}

		[Fact]
		public async Task Update_ValidParameters_AddsMilestoneIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Update(0, expected);

			_request.Received().AddUrlSegment("milestoneId", expected);
		}

		[Fact]
		public async Task Update_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Update(expected, 0);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Fact]
		public async Task Update_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.Update(0, 0);

			_requestFactory.Received().Create("projects/{projectId}/milestones/{milestoneId}", Method.Put);
		}
	}
}