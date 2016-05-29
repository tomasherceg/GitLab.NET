using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class GetTagRequestTests
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
            var sut = new GetTagRequest(expected, "tagName");

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
            var sut = new GetTagRequest(0, expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new GetTagRequest(0, "tagName");

            var result = sut.GetRequest();

            Assert.Equal(GetTagRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToGet()
        {
            var sut = new GetTagRequest(0, "tagName");

            var result = sut.GetRequest();

            Assert.Equal(Method.GET, result.Method);
        }
    }
}