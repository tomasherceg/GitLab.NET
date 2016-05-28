using NSubstitute;
using System;
using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class GetLicensesRequestTests
    {
        [Fact]
        public void GetRequest_SetsMethodToGet()
        {
            var sut = new GetLicensesRequest();

            var result = sut.GetRequest();

            Assert.Equal(Method.GET, result.Method);
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new GetLicensesRequest();

            var result = sut.GetRequest();

            Assert.Equal(GetLicensesRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_PopularIsSet_AddsPopularParameter()
        {
            const bool expected = true;
            var expectedParameter = new Parameter
            {
                Name = "popular",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new GetLicensesRequest(expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }
    }
}
