using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class CreateBuildVariableRequestTests
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
            var sut = new CreateBuildVariableRequest(0, expected, "value");

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
            var sut = new CreateBuildVariableRequest(expected, "key", "value");

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_AddsValueParameter()
        {
            const string expected = "value";
            var expectedParameter = new Parameter
            {
                Name = "value",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateBuildVariableRequest(0, "key", expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new CreateBuildVariableRequest(0, "key", "value");

            var result = sut.GetRequest();

            Assert.Equal(CreateBuildVariableRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToPost()
        {
            var sut = new CreateBuildVariableRequest(0, "key", "value");

            var result = sut.GetRequest();

            Assert.Equal(Method.POST, result.Method);
        }
    }
}