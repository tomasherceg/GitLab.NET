using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class GetUserRequestTests
    {
        [Fact]
        public void GetRequest_IdIsSet_AddsIdParameter()
        {
            uint expectedId = 5;
            var expectedParameter = new Parameter
            {
                Name = "id",
                Value = expectedId,
                Type = ParameterType.UrlSegment
            };
            var sut = new GetUserRequest(expectedId);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_IdIsSet_SetsCorrectResource()
        {
            var sut = new GetUserRequest(0);

            var result = sut.GetRequest();

            Assert.Equal(GetUserRequest.ByIdResource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToGet()
        {
            var sut = new GetUserRequest();

            var result = sut.GetRequest();

            Assert.Equal(Method.GET, result.Method);
        }

        [Fact]
        public void GetRequest_UsernameAndIdNotSet_SetsCorrectResource()
        {
            var sut = new GetUserRequest();

            var result = sut.GetRequest();

            Assert.Equal(GetUserRequest.CurrentUserResource, result.Resource);
        }

        [Fact]
        public void GetRequest_UsernameIsSet_AddsUsernameParameter()
        {
            const string expectedUsername = "username";
            var expectedParameter = new Parameter
            {
                Name = "username",
                Value = expectedUsername,
                Type = ParameterType.GetOrPost
            };
            var sut = new GetUserRequest(expectedUsername);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_UsernameIsSet_SetsCorrectResource()
        {
            var sut = new GetUserRequest("username");

            var result = sut.GetRequest();

            Assert.Equal(GetUserRequest.ByUsernameResource, result.Resource);
        }
    }
}