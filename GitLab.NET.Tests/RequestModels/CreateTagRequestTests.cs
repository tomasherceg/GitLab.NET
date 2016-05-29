using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class CreateTagRequestTests
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
            var sut = new CreateTagRequest(expected, "tagName", "refName");

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
            var sut = new CreateTagRequest(0, "tagName", expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_AddsTagNameParameter()
        {
            const string expected = "tagName";
            var expectedParameter = new Parameter
            {
                Name = "tag_name",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateTagRequest(0, expected, "refName");

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_MessageIsSet_AddsMessageParameter()
        {
            const string expected = "message";
            var expectedParameter = new Parameter
            {
                Name = "message",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateTagRequest(0, "tagName", "refName", expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_ReleaseDescriptionIsSet_AddsReleaseDescriptionParameter()
        {
            const string expected = "releaseDescription";
            var expectedParameter = new Parameter
            {
                Name = "release_description",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateTagRequest(0, "tagName", "refName", releaseDescription: expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new CreateTagRequest(0, "tagName", "refName");

            var result = sut.GetRequest();

            Assert.Equal(CreateTagRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToGet()
        {
            var sut = new CreateTagRequest(0, "tagName", "refName");

            var result = sut.GetRequest();

            Assert.Equal(Method.POST, result.Method);
        }
    }
}