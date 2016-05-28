using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class GetBuildTriggerRequestTests
    {
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
            var sut = new GetBuildTriggerRequest(expected, "token");

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_AddsTokenParameter()
        {
            const string expected = "token";
            var expectedParameter = new Parameter
            {
                Name = "token",
                Value = expected,
                Type = ParameterType.UrlSegment
            };
            var sut = new GetBuildTriggerRequest(0, expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new GetBuildTriggerRequest(0, "token");

            var result = sut.GetRequest();

            Assert.Equal(GetBuildTriggerRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToGet()
        {
            var sut = new GetBuildTriggerRequest(0, "token");

            var result = sut.GetRequest();

            Assert.Equal(Method.GET, result.Method);
        }
    }
}