using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class GetRepositoryTreeRequestTests
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
            var sut = new GetRepositoryTreeRequest(expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_PathIsSet_AddsPathParameter()
        {
            const string expected = "path";
            var expectedParameter = new Parameter
            {
                Name = "path",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new GetRepositoryTreeRequest(0, expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_RefNameIsSet_AddsRefNameParameter()
        {
            const string expected = "ref_name";
            var expectedParameter = new Parameter
            {
                Name = "ref_name",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new GetRepositoryTreeRequest(0, refName: expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new GetRepositoryTreeRequest(0);

            var result = sut.GetRequest();

            Assert.Equal(GetRepositoryTreeRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToGet()
        {
            var sut = new GetRepositoryTreeRequest(0);

            var result = sut.GetRequest();

            Assert.Equal(Method.GET, result.Method);
        }
    }
}