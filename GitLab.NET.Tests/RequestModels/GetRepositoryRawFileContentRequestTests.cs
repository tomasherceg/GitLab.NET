using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class GetRepositoryRawFileContentRequestTests
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
            var sut = new GetRepositoryRawFileContentRequest(expected, "sha", "filePath");

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
            var sut = new GetRepositoryRawFileContentRequest(0, expected, "filePath");

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_AddsFilePathParameter()
        {
            const string expected = "filepath";
            var expectedParameter = new Parameter
            {
                Name = "filepath",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new GetRepositoryRawFileContentRequest(0, "sha", expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new GetRepositoryRawFileContentRequest(0, "sha", "filePath");

            var result = sut.GetRequest();

            Assert.Equal(GetRepositoryRawFileContentRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToGet()
        {
            var sut = new GetRepositoryRawFileContentRequest(0, "sha", "filePath");

            var result = sut.GetRequest();

            Assert.Equal(Method.GET, result.Method);
        }
    }
}