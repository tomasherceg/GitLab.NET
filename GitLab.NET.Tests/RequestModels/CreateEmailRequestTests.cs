using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class CreateEmailRequestTests
    {
        [Fact]
        public void GetRequest_AddsEmailParameter()
        {
            const string expected = "email";
            var expectedParameter = new Parameter
            {
                Name = "email",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateEmailRequest(expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsMethodToPost()
        {
            var sut = new CreateEmailRequest("email");

            var result = sut.GetRequest();

            Assert.Equal(Method.POST, result.Method);
        }

        [Fact]
        public void GetRequest_UserIdIsNotSet_SetsCorrectResource()
        {
            var sut = new CreateEmailRequest("email");

            var result = sut.GetRequest();

            Assert.Equal(CreateEmailRequest.ForCurrentUserResource, result.Resource);
        }

        [Fact]
        public void GetRequest_UserIdIsSet_AddsIdParameter()
        {
            const uint expected = 5;
            var expectedParameter = new Parameter
            {
                Name = "id",
                Value = expected,
                Type = ParameterType.UrlSegment
            };
            var sut = new CreateEmailRequest(expected, "email");

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_UserIdIsSet_SetsCorrectResource()
        {
            var sut = new CreateEmailRequest(0, "email");

            var result = sut.GetRequest();

            Assert.Equal(CreateEmailRequest.ForSpecifiedUserResource, result.Resource);
        }
    }
}