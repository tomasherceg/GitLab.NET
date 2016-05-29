using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class CreateReleaseRequestTests
    {
        [Fact]
        public void GetRequest_AddsDescriptionParameter()
        {
            const string expected = "description";
            var expectedParameter = new Parameter
            {
                Name = "description",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateReleaseRequest(0, "tagName", expected);

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
            var sut = new CreateReleaseRequest(expected, "tagName", "description");

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_AddsTagNameParameter()
        {
            const string expected = "tagName";
            var expectedParameter = new Parameter
            {
                Name = "tagName",
                Value = expected,
                Type = ParameterType.UrlSegment
            };
            var sut = new CreateReleaseRequest(0, expected, "description");

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new CreateReleaseRequest(0, "tagName", "description");

            var result = sut.GetRequest();

            Assert.Equal(CreateReleaseRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToGet()
        {
            var sut = new CreateReleaseRequest(0, "tagName", "description");

            var result = sut.GetRequest();

            Assert.Equal(Method.POST, result.Method);
        }
    }
}