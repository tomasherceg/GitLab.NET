using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class GetProjectSnippetRequestTests
    {
        [Fact]
        public void GetRequest_AddsIdParameter()
        {
            const uint expected = 5;
            var expectedParameter = new Parameter
            {
                Name = "id",
                Value = expected,
                Type = ParameterType.UrlSegment
            };
            var sut = new GetProjectSnippetRequest(expected, 0);

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
            var sut = new GetProjectSnippetRequest(0, expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new GetProjectSnippetRequest(0, 0);

            var result = sut.GetRequest();

            Assert.Equal(GetProjectSnippetRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToGet()
        {
            var sut = new GetProjectSnippetRequest(0, 0);

            var result = sut.GetRequest();

            Assert.Equal(Method.GET, result.Method);
        }
    }
}