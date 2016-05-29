using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class GetCommitRequestTests
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
            var sut = new GetCommitRequest(0, expected);

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
            var sut = new GetCommitRequest(expected, "commitSha");

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new GetCommitRequest(0, "commitSha");

            var result = sut.GetRequest();

            Assert.Equal(GetCommitRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToGet()
        {
            var sut = new GetCommitRequest(0, "commitSha");

            var result = sut.GetRequest();

            Assert.Equal(Method.GET, result.Method);
        }
    }
}