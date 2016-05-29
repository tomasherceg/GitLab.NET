using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class CreateCommitStatusRequestTests
    {
        [Fact]
        public void GetRequest_AddsCommitShaParameter()
        {
            const string expected = "commitSha";
            var expectedParameter = new Parameter
            {
                Name = "commitSha",
                Value = expected,
                Type = ParameterType.UrlSegment
            };
            var sut = new CreateCommitStatusRequest(0, expected, "state");

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_AddsProjectIdParameter()
        {
            const uint expected = 5;
            var expectedParameter = new Parameter
            {
                Name = "projectId",
                Value = expected,
                Type = ParameterType.UrlSegment
            };
            var sut = new CreateCommitStatusRequest(expected, "commitSha", "state");

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_AddsStateParameter()
        {
            const string expected = "state";
            var expectedParameter = new Parameter
            {
                Name = "state",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateCommitStatusRequest(0, "commitSha", expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_DescriptionIsSet_AddsDescriptionParameter()
        {
            const string expected = "description";
            var expectedParameter = new Parameter
            {
                Name = "description",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateCommitStatusRequest(0, "commitSha", "state", description: expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_NameIsSet_AddsNameParameter()
        {
            const string expected = "name";
            var expectedParameter = new Parameter
            {
                Name = "name",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateCommitStatusRequest(0, "commitSha", "state", name: expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_RefNameIsSet_AddsRefNameParameter()
        {
            const string expected = "refName";
            var expectedParameter = new Parameter
            {
                Name = "ref",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateCommitStatusRequest(0, "commitSha", "state", expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new CreateCommitStatusRequest(0, "commitSha", "state");

            var result = sut.GetRequest();

            Assert.Equal(CreateCommitStatusRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToGet()
        {
            var sut = new CreateCommitStatusRequest(0, "commitSha", "state");

            var result = sut.GetRequest();

            Assert.Equal(Method.POST, result.Method);
        }

        [Fact]
        public void GetRequest_TargetUrlIsSet_AddsTargetUrlParameter()
        {
            const string expected = "targetUrl";
            var expectedParameter = new Parameter
            {
                Name = "target_url",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateCommitStatusRequest(0, "commitSha", "state", targetUrl: expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }
    }
}