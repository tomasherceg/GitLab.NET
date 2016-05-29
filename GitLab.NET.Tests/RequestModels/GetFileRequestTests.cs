using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class GetFileRequestTests
    {
        [Fact]
        public void GetRequest_AddsFilePathParameter()
        {
            const string expected = "filePath";
            var expectedParameter = new Parameter
            {
                Name = "file_path",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new GetFileRequest(0, expected, "refName");

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
            var sut = new GetFileRequest(expected, "filePath", "refName");

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_AddsRefNameParameter()
        {
            const string expected = "refName";
            var expectedParameter = new Parameter
            {
                Name = "ref",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new GetFileRequest(0, "filePath", expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new GetFileRequest(0, "filePath", "refName");

            var result = sut.GetRequest();

            Assert.Equal(GetFileRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToGet()
        {
            var sut = new GetFileRequest(0, "filePath", "refName");

            var result = sut.GetRequest();

            Assert.Equal(Method.GET, result.Method);
        }
    }
}