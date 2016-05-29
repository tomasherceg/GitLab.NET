using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class GetCommitStatusRequestTests
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
            var sut = new GetCommitStatusRequest(0, expected);

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
            var sut = new GetCommitStatusRequest(expected, "commitSha");

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_AllIsSet_AddsAllParameter()
        {
            const bool expected = true;
            var expectedParameter = new Parameter
            {
                Name = "all",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new GetCommitStatusRequest(0, "commitSha", all: expected);

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
            var sut = new GetCommitStatusRequest(0, "commitSha", name: expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_RefNameIsSet_AddsRefNameParameter()
        {
            const string expected = "refName";
            var expectedParameter = new Parameter
            {
                Name = "ref_name",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new GetCommitStatusRequest(0, "commitSha", expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new GetCommitStatusRequest(0, "commitSha");

            var result = sut.GetRequest();

            Assert.Equal(GetCommitStatusRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToGet()
        {
            var sut = new GetCommitStatusRequest(0, "commitSha");

            var result = sut.GetRequest();

            Assert.Equal(Method.GET, result.Method);
        }

        [Fact]
        public void GetRequest_StageIsSet_AddsStageParameter()
        {
            const string expected = "stage";
            var expectedParameter = new Parameter
            {
                Name = "stage",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new GetCommitStatusRequest(0, "commitSha", stage: expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }
    }
}