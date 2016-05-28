using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class DeleteDeployKeyRequestTests
    {
        [Fact]
        public void GetRequest_AddsKeyIdParameter()
        {
            const uint expected = 5;
            var expectedParameter = new Parameter
            {
                Name = "keyId",
                Value = expected,
                Type = ParameterType.UrlSegment
            };
            var sut = new DeleteDeployKeyRequest(0, expected);

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
            var sut = new DeleteDeployKeyRequest(expected, 0);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new DeleteDeployKeyRequest(0, 0);

            var result = sut.GetRequest();

            Assert.Equal(DeleteDeployKeyRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToDelete()
        {
            var sut = new DeleteDeployKeyRequest(0, 0);

            var result = sut.GetRequest();

            Assert.Equal(Method.DELETE, result.Method);
        }
    }
}