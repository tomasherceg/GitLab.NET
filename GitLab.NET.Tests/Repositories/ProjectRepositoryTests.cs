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
        public async Task GetAllProjects() {
            var client = new GitLabClient(new Uri(TestServerConfig.GitLabPrivateTestProjectFullPath), TestServerConfig.GitLabPrivateToken);
            var projects = await client.Projects.GetAll();
            Assert.Equal(2, projects.Data.Count);
        }

        [Fact]
        public async Task GetAccessibleProjects() {
            var client = new GitLabClient(new Uri(TestServerConfig.GitLabPrivateTestProjectFullPath), TestServerConfig.GitLabPrivateToken);
            var projects = await client.Projects.Accessible();
            Assert.Equal(2, projects.Data.Count);
        }

        [Fact]
        public async Task GetNonGroupedProject() {
            var client = new GitLabClient(new Uri(TestServerConfig.GitLabPrivateTestProjectInGroupFullPath), TestServerConfig.GitLabPrivateToken);
            var project = await client.Projects.Find(TestServerConfig.GitLabPrivateTestProjectId);
            Assert.Equal(TestServerConfig.GitLabPrivateTestProjectName, project.Data.Name);
            Assert.Equal(TestServerConfig.GitLabPrivateTestProjectDescription, project.Data.Description);
        }

        [Fact]
        public async Task GetGroupedProject() {
            var client = new GitLabClient(new Uri(TestServerConfig.GitLabPrivateTestProjectFullPath), TestServerConfig.GitLabPrivateToken);
            var project = await client.Projects.Find(TestServerConfig.GitLabPrivateTestProjectInGroupId);
            Assert.Equal(TestServerConfig.GitLabPrivateTestProjectInGroupName, project.Data.Name);
            Assert.Equal(TestServerConfig.GitLabPrivateTestProjectDescription, project.Data.Description);
            Assert.Equal(TestServerConfig.GitLabPrivateTestProjectGroupName, project.Data.Namespace.Path);
        }
    }

    public static class TestServerConfig {
        public static readonly string GitLabName, GitLabUserName, EMailFirstName, EMailLastName = "GitLabNetTest";
        public static readonly string GitLabPrivateToken = "SySK9dNRsbtSvKZbazkA";
        public static readonly string GitLabPassword, EMailPassword = "GitLabNetTestPassword123";
        public static readonly string EMail = "GitLabNetTest@gmail.com";
        public static readonly DateTime EMailBirthDay = new DateTime(1987, 2, 15);
        public static readonly string EMailGender = "Male";
        public static readonly string EMailCountry = "USA";

        public static readonly string GitLabServerPath = @"https://gitlab.com/";
        public static readonly string GitLabPrivateTestProjectFullPath = GitLabServerPath + @"GitLabNetTest/GitLabNetPrivateTestProject1.git";

        public static readonly string GitLabPrivateTestProjectName = "GitLabNetPrivateTestProject1";
        public static readonly string GitLabPrivateTestProjectDescription = "Not for use. Only for testing GitLab.NET.";
        public static readonly string GitLabPrivateTestProjectGroupDescription = "This group not for use. Only for testing GitLab.NET.";
        public static readonly uint GitLabPrivateTestProjectId = 1483816;

        public static readonly string GitLabPrivateTestProjectGroupName = "GitLabNetPrivateTestGroup1";
        public static readonly string GitLabPrivateTestProjectInGroupName = "GitLabNetPrivateTestProjectInGroup1";
        public static readonly string GitLabPrivateTestProjectInGroupFullPath = GitLabServerPath + @"GitLabNetPrivateTestGroup1/GitLabNetPrivateTestProjectInGroup1.git";
        public static readonly uint GitLabPrivateTestProjectInGroupId = 1483868;
    }
}
