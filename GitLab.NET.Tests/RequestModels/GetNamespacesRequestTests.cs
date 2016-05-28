using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class GetNamespacesRequestTests
    {
        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new GetNamespacesRequest();

            var result = sut.GetRequest();

            Assert.Equal(GetNamespacesRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToGet()
        {
            var sut = new GetNamespacesRequest();

            var result = sut.GetRequest();

            Assert.Equal(Method.GET, result.Method);
        }

        [Fact]
        public void GetRequest_SearchIsSet_AddsSearchParameter()
        {
            const string expected = "search";
            var expectedParameter = new Parameter
            {
                Name = "search",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new GetNamespacesRequest(expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }
    }
}