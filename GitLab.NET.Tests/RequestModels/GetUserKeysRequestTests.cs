using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class GetUserKeysRequestTests
    {
        [Fact]
        public void GetRequest_UserIdIsNotSet_SetsCorrectResource()
        {
            var sut = new GetUserKeysRequest();

            var result = sut.GetRequest();

            Assert.Equal(GetUserKeysRequest.ForCurrentUserRequest, result.Resource);
        }

        [Fact]
        public void GetRequest_UserIdIsNotSet_SetsMethodToGet()
        {
            var sut = new GetUserKeysRequest();

            var result = sut.GetRequest();

            Assert.Equal(Method.GET, result.Method);
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
            var sut = new GetUserKeysRequest(expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_UserIdIsSet_SetsCorrectResource()
        {
            var sut = new GetUserKeysRequest(0);

            var result = sut.GetRequest();

            Assert.Equal(GetUserKeysRequest.ForSpecifiedUserRequest, result.Resource);
        }

        [Fact]
        public void GetRequest_UserIdIsSet_SetsMethodToGet()
        {
            var sut = new GetUserKeysRequest(0);

            var result = sut.GetRequest();

            Assert.Equal(Method.GET, result.Method);
        }
    }
}