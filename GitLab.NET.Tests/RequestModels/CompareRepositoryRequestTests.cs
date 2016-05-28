using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class CompareRepositoryRequestTests
    {
        [Fact]
        public void GetRequest_AddsFromParameter()
        {
            const string expected = "from";
            var expectedParameter = new Parameter
            {
                Name = "from",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CompareRepositoryRequest(0, expected, "to");

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
            var sut = new CompareRepositoryRequest(expected, "from", "to");

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_AddsToParameter()
        {
            const string expected = "to";
            var expectedParameter = new Parameter
            {
                Name = "to",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CompareRepositoryRequest(0, "from", expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new CompareRepositoryRequest(0, "from", "to");

            var result = sut.GetRequest();

            Assert.Equal(CompareRepositoryRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToGet()
        {
            var sut = new CompareRepositoryRequest(0, "from", "to");

            var result = sut.GetRequest();

            Assert.Equal(Method.GET, result.Method);
        }
    }
}