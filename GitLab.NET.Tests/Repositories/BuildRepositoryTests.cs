using NSubstitute;
using System;
using System.Linq;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NUnit.Framework;

namespace GitLab.NET.Tests.Repositories
{
	public class BuildRepositoryTests
	{
		public BuildRepositoryTests()
		{
			_request = Substitute.For<IRequest>();
			_requestFactory = Substitute.For<IRequestFactory>();
			_requestFactory.Create(Arg.Any<string>(), Arg.Any<Method>(), Arg.Any<bool>()).Returns(_request);
			_sut = new BuildRepository(_requestFactory);
		}

		private readonly IRequest _request;
		private readonly IRequestFactory _requestFactory;
		private readonly BuildRepository _sut;

		[Test]
		public async Task Cancel_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Cancel(expected, 0);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Cancel_ValidParameters_AddsBuildIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Cancel(0, expected);

			_request.Received().AddUrlSegment("buildId", expected);
		}

		[Test]
		public async Task Cancel_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.Cancel(0, 0);

			_requestFactory.Received().Create("projects/{projectId}/builds/{buildId}/cancel", Method.Post);
		}

		[Test]
		public async Task Erase_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Erase(expected, 0);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Erase_ValidParameters_AddsBuildIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Erase(0, expected);

			_request.Received().AddUrlSegment("buildId", expected);
		}

		[Test]
		public async Task Erase_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.Erase(0, 0);

			_requestFactory.Received().Create("projects/{projectId}/builds/{buildId}/erase", Method.Post);
		}

		[Test]
		public async Task Find_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Find(expected, 0);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Find_ValidParameters_AddsBuildIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Find(0, expected);

			_request.Received().AddUrlSegment("buildId", expected);
		}

		[Test]
		public async Task Find_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.Find(0, 0);

			_requestFactory.Received().Create("projects/{projectId}/builds/{buildId}", Method.Get);
		}

		[Test]
		public async Task GetArtifacts_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.GetArtifacts(expected, 0);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task GetArtifacts_ValidParameters_AddsBuildIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.GetArtifacts(0, expected);

			_request.Received().AddUrlSegment("buildId", expected);
		}

		[Test]
		public async Task GetArtifacts_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.GetArtifacts(0, 0);

			_requestFactory.Received().Create("projects/{projectId}/builds/{buildId}/artifacts", Method.Get);
		}

		[Test]
		public void GetByCommit_CommitShaIsNull_ThrowsArgumentNullException()
		{
			Assert.ThrowsAsync<ArgumentNullException>(() => _sut.GetByCommit(0, null));
		}

		[Test]
		public async Task GetByCommit_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.GetByCommit(expected, "commitSha");

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task GetByCommit_ValidParameters_AddsCommitShaUrlSegment()
		{
			const string expected = "commitSha";

			await _sut.GetByCommit(0, expected);

			_request.Received().AddUrlSegment("commitSha", expected);
		}

		[Test]
		public async Task GetByCommit_ScopesIsSet_AddsScopeParameter()
		{
			var scopes = new[]
			{
				BuildStatus.Pending,
				BuildStatus.Success
			};
			var expected = new[]
			{
				"pending",
				"success"
			};

			await _sut.GetByCommit(0, "commitSha", scopes);

			_request.Received().AddParameterIfNotNull("scope", Arg.Is<string[]>(actual => expected.SequenceEqual(actual)));
		}

		[Test]
		public async Task GetByCommit_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.GetByCommit(0, "commitSha");

			_requestFactory.Received().Create("projects/{projectId}/repository/commits/{commitSha}/builds", Method.Get);
		}

		[Test]
		public async Task GetByProject_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.GetByProject(expected);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task GetByProject_ScopesIsSet_AddsScopeParameter()
		{
			var scopes = new[]
			{
				BuildStatus.Pending,
				BuildStatus.Success
			};
			var expected = new[]
			{
				"pending",
				"success"
			};

			await _sut.GetByProject(0, scopes);

			_request.Received().AddParameterIfNotNull("scope", Arg.Is<string[]>(actual => expected.SequenceEqual(actual)));
		}

		[Test]
		public async Task GetByProject_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.GetByProject(0);

			_requestFactory.Received().Create("projects/{projectId}/builds", Method.Get);
		}

		[Test]
		public async Task Retry_ValidParameters_AddsProjectIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Retry(expected, 0);

			_request.Received().AddUrlSegment("projectId", expected);
		}

		[Test]
		public async Task Retry_ValidParameters_AddsBuildIdUrlSegment()
		{
			const uint expected = 0;

			await _sut.Retry(0, expected);

			_request.Received().AddUrlSegment("buildId", expected);
		}

		[Test]
		public async Task Retry_ValidParameters_SetsCorrectResourceAndMethod()
		{
			await _sut.Retry(0, 0);

			_requestFactory.Received().Create("projects/{projectId}/builds/{buildId}/retry", Method.Post);
		}
	}
}
