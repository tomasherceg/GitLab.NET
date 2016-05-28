using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class CreateDeployKeyRequestTests
    {
        [Fact]
        public void GetRequest_AddsKeyParameter()
        {
            const string expected = "key";
            var expectedParameter = new Parameter
            {
                Name = "key",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateDeployKeyRequest(0, "title", expected);

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
            var sut = new CreateDeployKeyRequest(expected, "title", "key");

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_AddsTitleParameter()
        {
            const string expected = "title";
            var expectedParameter = new Parameter
            {
                Name = "title",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateDeployKeyRequest(0, expected, "key");

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new CreateDeployKeyRequest(0, "title", "key");

            var result = sut.GetRequest();

            Assert.Equal(CreateDeployKeyRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToPost()
        {
            var sut = new CreateDeployKeyRequest(0, "title", "key");

            var result = sut.GetRequest();

            Assert.Equal(Method.POST, result.Method);
        }
    }
}