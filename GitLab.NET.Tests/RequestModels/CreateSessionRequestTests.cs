using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class CreateSessionRequestTests
    {
        [Fact]
        public void GetRequest_AddsLoginParameter()
        {
            const string expectedLogin = "username";
            var expectedParameter = new Parameter
            {
                Name = "login",
                Value = expectedLogin,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateSessionRequest(expectedLogin, "password");

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_AddsPasswordParameter()
        {
            const string expectedPassword = "password";
            var expectedParameter = new Parameter
            {
                Name = "password",
                Value = expectedPassword,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateSessionRequest("username", expectedPassword);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new CreateSessionRequest("username", "password");

            var result = sut.GetRequest();

            Assert.Equal(CreateSessionRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToPost()
        {
            var sut = new CreateSessionRequest("username", "password");

            var result = sut.GetRequest();

            Assert.Equal(Method.POST, result.Method);
        }
    }
}