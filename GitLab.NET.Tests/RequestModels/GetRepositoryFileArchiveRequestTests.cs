using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class GetRepositoryFileArchiveRequestTests
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
            var sut = new GetRepositoryFileArchiveRequest(expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new GetRepositoryFileArchiveRequest(0);

            var result = sut.GetRequest();

            Assert.Equal(GetRepositoryFileArchiveRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToGet()
        {
            var sut = new GetRepositoryFileArchiveRequest(0);

            var result = sut.GetRequest();

            Assert.Equal(Method.GET, result.Method);
        }

        [Fact]
        public void GetRequest_ShaIsSet_AddsShaParameter()
        {
            const string expected = "sha";
            var expectedParameter = new Parameter
            {
                Name = "sha",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new GetRepositoryFileArchiveRequest(0, expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }
    }
}