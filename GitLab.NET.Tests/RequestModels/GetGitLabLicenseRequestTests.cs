using GitLab.NET.RequestModels;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class GetGitLabLicenseRequestTests
    {
        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new GetGitLabLicenseRequest();

            var result = sut.GetRequest();

            Assert.Equal(GetGitLabLicenseRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToGet()
        {
            var sut = new GetGitLabLicenseRequest();

            var result = sut.GetRequest();

            Assert.Equal(Method.GET, result.Method);
        }
    }
}