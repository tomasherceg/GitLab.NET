using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class UnblockUserRequestTests
    {
        [Fact]
        public void GetRequest_AddsIdParameter()
        {
            const uint expected = 5;
            var expectedParameter = new Parameter
            {
                Name = "id",
                Value = expected,
                Type = ParameterType.UrlSegment
            };
            var sut = new UnblockUserRequest(expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new UnblockUserRequest(0);

            var result = sut.GetRequest();

            Assert.Equal(UnblockUserRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToPut()
        {
            var sut = new UnblockUserRequest(0);

            var result = sut.GetRequest();

            Assert.Equal(Method.PUT, result.Method);
        }
    }
}