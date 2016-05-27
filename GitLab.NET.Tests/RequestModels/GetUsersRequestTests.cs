using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class GetUsersRequestTests
    {
        [Fact]
        public void GetRequest_AddsPageParameter()
        {
            uint expectedPage = 2;
            var expectedParameter = new Parameter
            {
                Name = "page",
                Value = expectedPage,
                Type = ParameterType.GetOrPost
            };
            var sut = new GetUsersRequest(expectedPage, 20);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_AddsResultsPerPageParameter()
        {
            uint expectedResultsPerPage = 50;
            var expectedParameter = new Parameter
            {
                Name = "per_page",
                Value = expectedResultsPerPage,
                Type = ParameterType.GetOrPost
            };
            var sut = new GetUsersRequest(1, expectedResultsPerPage);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SearchIsSet_AddsSearchParameter()
        {
            var expectedSearch = "search";
            var expectedParameter = new Parameter
            {
                Name = "search",
                Value = expectedSearch,
                Type = ParameterType.GetOrPost
            };
            var sut = new GetUsersRequest(expectedSearch, 1, 20);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new GetUsersRequest(1, 20);

            var result = sut.GetRequest();

            Assert.Equal(GetUsersRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToGet()
        {
            var sut = new GetUsersRequest(1, 20);

            var result = sut.GetRequest();

            Assert.Equal(Method.GET, result.Method);
        }
    }
}