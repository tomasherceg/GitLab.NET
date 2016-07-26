using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NSubstitute;
using Xunit;
using System.Linq;

namespace GitLab.NET.Tests.Repositories {
    public class ProjectRepositoryTests {

        public ProjectRepositoryTests() {
            _request = Substitute.For<IRequest>();
            _requestFactory = Substitute.For<IRequestFactory>();
            _requestFactory.Create(Arg.Any<string>(), Arg.Any<Method>(), Arg.Any<bool>()).Returns(_request);
        }

        private readonly IRequest _request;
        private readonly IRequestFactory _requestFactory;

        [Fact]
        public async Task Find_IdOverload_ValidParameters_AddsIdUrlSegment() {
            const uint expected = 0;
            var sut = new ProjectRepository(_requestFactory);

            await sut.Find(expected);

            _request.Received().AddUrlSegment("id", expected);
        }

        [Fact]
        public async Task GetProject() {
            GitLabClient client = new GitLabClient(new Uri(TestCredentials.GitServer), TestCredentials.GitLabToken);
            var data = (await client.Projects.GetAll()).Data;
            foreach(var el in data) {
                System.Diagnostics.Debug.WriteLine(el.Name);
            }
            data = (await client.Projects.Accessible()).Data;
            foreach(var el in data) {
                System.Diagnostics.Debug.WriteLine(el.Name);
            }
            var res = (await client.Projects.GetAll()).Data.FirstOrDefault(x => string.Compare(x.HttpUrlToRepo, TestCredentials.GitServer + "/tester/testxpfall", StringComparison.InvariantCultureIgnoreCase) == 0);

            //GitLabWrapper wrapper = new GitLabWrapper(TestCredentials.GitServer, TestCredentials.GitLabToken);
            //var project = wrapper.FindProject("tester/testxpfall");
            //Assert.IsNotNull(project);
        }
    }

    public static class TestCredentials {
        public const string GitLabToken = "X6XV2G_ycz_U4pi4m93K";
        public const string GitServer = "http://litvinov-lnx";
        public const string VcsServer = @"net.tcp://vcsservice.devexpress.devx:9091/DXVCSService";
    }


}
