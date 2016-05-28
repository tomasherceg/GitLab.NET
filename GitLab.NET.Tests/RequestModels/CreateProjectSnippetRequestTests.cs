using GitLab.NET.RequestModels;
using GitLab.NET.ResponseModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class CreateProjectSnippetRequestTests
    {
        [Fact]
        public void GetRequest_AddsCodeParameter()
        {
            const string expected = "code";
            var expectedParameter = new Parameter
            {
                Name = "code",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateProjectSnippetRequest(0, "title", "fileName", expected, VisibilityLevel.Public);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_AddsFileNameParameter()
        {
            const string expected = "fileName";
            var expectedParameter = new Parameter
            {
                Name = "file_name",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateProjectSnippetRequest(0, "title", expected, "code", VisibilityLevel.Public);

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
            var sut = new CreateProjectSnippetRequest(expected, "title", "fileName", "code", VisibilityLevel.Public);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_AddsTitleParameter()
        {
            const string expected = "title";
            var expectedParameter = new Parameter
            {
                Name = "title",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateProjectSnippetRequest(0, expected, "fileName", "code", VisibilityLevel.Public);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_AddsVisibilityLevelParameter()
        {
            const VisibilityLevel expected = VisibilityLevel.Public;
            var expectedParameter = new Parameter
            {
                Name = "visibility_level",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateProjectSnippetRequest(0, "title", "fileName", "code", expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new CreateProjectSnippetRequest(0, "title", "fileName", "code", VisibilityLevel.Public);

            var result = sut.GetRequest();

            Assert.Equal(CreateProjectSnippetRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToPost()
        {
            var sut = new CreateProjectSnippetRequest(0, "title", "fileName", "code", VisibilityLevel.Public);

            var result = sut.GetRequest();

            Assert.Equal(Method.POST, result.Method);
        }
    }
}