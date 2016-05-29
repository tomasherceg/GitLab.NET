using GitLab.NET.RequestModels;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class GetSystemHooksRequestTests
    {
        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new GetSystemHooksRequest();

            var result = sut.GetRequest();

            Assert.Equal(GetSystemHooksRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToGet()
        {
            var sut = new GetSystemHooksRequest();

            var result = sut.GetRequest();

            Assert.Equal(Method.GET, result.Method);
        }
    }
}