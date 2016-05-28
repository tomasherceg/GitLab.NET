using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class DeleteBuildVariableRequestTests
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
            var sut = new DeleteBuildVariableRequest(0, expected);

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
            var sut = new DeleteBuildVariableRequest(expected, "key");

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new DeleteBuildVariableRequest(0, "key");

            var result = sut.GetRequest();

            Assert.Equal(DeleteBuildVariableRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToDelete()
        {
            var sut = new DeleteBuildVariableRequest(0, "key");

            var result = sut.GetRequest();

            Assert.Equal(Method.DELETE, result.Method);
        }
    }
}