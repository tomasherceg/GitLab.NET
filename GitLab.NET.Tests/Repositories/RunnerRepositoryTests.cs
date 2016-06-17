using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NSubstitute;
using Xunit;

namespace GitLab.NET.Tests.Repositories
{
    public class RunnerRepositoryTests
    {
        public RunnerRepositoryTests()
        {
            _request = Substitute.For<IRequest>();
            _requestFactory = Substitute.For<IRequestFactory>();
            _requestFactory.Create(Arg.Any<string>(), Arg.Any<Method>(), Arg.Any<bool>()).Returns(_request);
            _sut = new RunnerRepository(_requestFactory);
        }

        private readonly IRequest _request;
        private readonly IRequestFactory _requestFactory;
        private readonly RunnerRepository _sut;

        [Fact]
        public async Task Delete_ValidParameters_AddsRunnerIdUrlSegment()
        {
            const uint expected = 0;

            await _sut.Delete(expected);

            _request.Received().AddUrlSegment("runnerId", expected);
        }

        [Fact]
        public async Task Delete_ValidParameters_SetsCorrectResourceAndMethod()
        {
            await _sut.Delete(0);

            _requestFactory.Received().Create("runners/{runnerId}", Method.Delete);
        }

        [Fact]
        public async Task DisableForProject_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;

            await _sut.DisableForProject(0, expected);

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task DisableForProject_ValidParameters_AddsRunnerIdUrlSegment()
        {
            const uint expected = 0;

            await _sut.DisableForProject(expected, 0);

            _request.Received().AddUrlSegment("runnerId", expected);
        }

        [Fact]
        public async Task DisableForProject_ValidParameters_SetsCorrectResourceAndMethod()
        {
            await _sut.DisableForProject(0, 0);

            _requestFactory.Received().Create("projects/{projectId}/runners/{runnerId}", Method.Delete);
        }

        [Fact]
        public async Task EnableForProject_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;

            await _sut.EnableForProject(0, expected);

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task EnableForProject_ValidParameters_AddsRunnerIdParameter()
        {
            const uint expected = 0;

            await _sut.EnableForProject(expected, 0);

            _request.Received().AddParameter("runnerId", expected);
        }

        [Fact]
        public async Task EnableForProject_ValidParameters_SetsCorrectResourceAndMethod()
        {
            await _sut.EnableForProject(0, 0);

            _requestFactory.Received().Create("projects/{projectId}/runners", Method.Post);
        }

        [Fact]
        public async Task Find_ValidParameters_AddsRunnerIdUrlSegment()
        {
            const uint expected = 0;

            await _sut.Find(expected);

            _request.Received().AddUrlSegment("runnerId", expected);
        }

        [Fact]
        public async Task Find_ValidParameters_SetsCorrectResourceAndMethod()
        {
            await _sut.Find(0);

            _requestFactory.Received().Create("runners/{runnerId}", Method.Get);
        }

        [Fact]
        public async Task GetAll_ScopeIsSet_AddsScopeParameter()
        {
            const string expected = "active";
            const RunnerScope scope = RunnerScope.Active;

            await _sut.GetAll(scope);

            _request.Received().AddParameterIfNotNull("scope", expected);
        }

        [Fact]
        public async Task GetAll_ValidParameters_SetsCorrectResourceAndMethod()
        {
            await _sut.GetAll();

            _requestFactory.Received().Create("runners/all", Method.Get);
        }

        [Fact]
        public async Task GetByProject_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;

            await _sut.GetByProject(expected);

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task GetByProject_ValidParameters_SetsCorrectResourceAndMethod()
        {
            await _sut.GetByProject(0);

            _requestFactory.Received().Create("projects/{projectId}/runners", Method.Get);
        }

        [Fact]
        public async Task GetOwned_ScopeIsSet_AddsScopeParameter()
        {
            const string expected = "active";
            const RunnerScope scope = RunnerScope.Active;

            await _sut.GetOwned(scope);

            _request.Received().AddParameterIfNotNull("scope", expected);
        }

        [Fact]
        public async Task GetOwned_ValidParameters_SetsCorrectResourceAndMethod()
        {
            await _sut.GetOwned();

            _requestFactory.Received().Create("runners", Method.Get);
        }

        [Fact]
        public async Task Update_ActiveIsSet_AddsActiveParameter()
        {
            const bool expected = true;

            await _sut.Update(0, active: expected);

            _request.Received().AddParameterIfNotNull("active", expected);
        }

        [Fact]
        public async Task Update_DescriptionIsSet_AddsDescriptionParameter()
        {
            const string expected = "description";

            await _sut.Update(0, expected);

            _request.Received().AddParameterIfNotNull("description", expected);
        }

        [Fact]
        public async Task Update_TagListIsSet_AddsTagListParameter()
        {
            var expected = new[]
            {
                "tag1",
                "tag2"
            };

            await _sut.Update(0, tagList: expected);

            _request.Received().AddParameterIfNotNull("tag_list", expected);
        }

        [Fact]
        public async Task Update_ValidParameters_AddsRunnerIdUrlSegment()
        {
            const uint expected = 0;

            await _sut.Update(expected);

            _request.Received().AddUrlSegment("runnerId", expected);
        }
    }
}