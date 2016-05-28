using GitLab.NET.RequestModels;
using GitLab.NET.ResponseModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class UpdateProjectSnippetRequestTests
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
            var sut = new UpdateProjectSnippetRequest(0, expected);

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
            var sut = new UpdateProjectSnippetRequest(expected, 0);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_CodeIsSet_AddsCodeParameter()
        {
            const string expected = "code";
            var expectedParameter = new Parameter
            {
                Name = "code",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new UpdateProjectSnippetRequest(0, 0, code: expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_FileNameIsSet_AddsFileNameParameter()
        {
            const string expected = "fileName";
            var expectedParameter = new Parameter
            {
                Name = "file_name",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new UpdateProjectSnippetRequest(0, 0, fileName: expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new UpdateProjectSnippetRequest(0, 0);

            var result = sut.GetRequest();

            Assert.Equal(UpdateProjectSnippetRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToPost()
        {
            var sut = new UpdateProjectSnippetRequest(0, 0);

            var result = sut.GetRequest();

            Assert.Equal(Method.PUT, result.Method);
        }

        [Fact]
        public void GetRequest_TitleIsSet_AddsTitleParameter()
        {
            const string expected = "title";
            var expectedParameter = new Parameter
            {
                Name = "title",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new UpdateProjectSnippetRequest(0, 0, expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_VisibilityLevelIsSet_AddsVisibilityLevelParameter()
        {
            const VisibilityLevel expected = VisibilityLevel.Public;
            var expectedParameter = new Parameter
            {
                Name = "visibility_level",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new UpdateProjectSnippetRequest(0, 0, visibilityLevel: expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }
    }
}