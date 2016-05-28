using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class GetBlobRawContentRequestTests
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
            var sut = new GetRepositoryRawBlobContentRequest(expected, "sha");

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_AddsShaParameter()
        {
            const string expected = "sha";
            var expectedParameter = new Parameter
            {
                Name = "sha",
                Value = expected,
                Type = ParameterType.UrlSegment
            };
            var sut = new GetRepositoryRawBlobContentRequest(0, expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new GetRepositoryRawBlobContentRequest(0, "sha");

            var result = sut.GetRequest();

            Assert.Equal(GetRepositoryRawBlobContentRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToGet()
        {
            var sut = new GetRepositoryRawBlobContentRequest(0, "sha");

            var result = sut.GetRequest();

            Assert.Equal(Method.GET, result.Method);
        }
    }
}