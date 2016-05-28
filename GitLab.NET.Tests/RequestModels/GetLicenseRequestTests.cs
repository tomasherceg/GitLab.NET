using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class GetLicenseRequestTests
    {
        [Fact]
        public void GetRequest_AddsKeyParameter()
        {
            const string expected = "key";
            var expectedParameter = new Parameter
            {
                Name = "key",
                Value = expected,
                Type = ParameterType.UrlSegment
            };
            var sut = new GetLicenseRequest(expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_FullNameIsSet_AddsFullNameParameter()
        {
            const string expected = "fullname";
            var expectedParameter = new Parameter
            {
                Name = "fullname",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new GetLicenseRequest("key", fullName: expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_ProjectIsSet_AddsProjectParameter()
        {
            const string expected = "project";
            var expectedParameter = new Parameter
            {
                Name = "project",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new GetLicenseRequest("key", expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new GetLicenseRequest("key");

            var result = sut.GetRequest();

            Assert.Equal(GetLicenseRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToGet()
        {
            var sut = new GetLicenseRequest("key");

            var result = sut.GetRequest();

            Assert.Equal(Method.GET, result.Method);
        }
    }
}