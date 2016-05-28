using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class DeleteKeyRequestTests
    {
        [Fact]
        public void GetRequest_UserIdIsNotSet_AddsIdParameter()
        {
            const uint expected = 5;
            var expectedParameter = new Parameter
            {
                Name = "id",
                Value = expected,
                Type = ParameterType.UrlSegment
            };
            var sut = new DeleteKeyRequest(expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_UserIdIsNotSet_SetsCorrectResource()
        {
            var sut = new DeleteKeyRequest(0);

            var result = sut.GetRequest();

            Assert.Equal(DeleteKeyRequest.ForCurrentUserResource, result.Resource);
        }

        [Fact]
        public void GetRequest_UserIdIsNotSet_SetsMethodToDelete()
        {
            var sut = new DeleteKeyRequest(0);

            var result = sut.GetRequest();

            Assert.Equal(Method.DELETE, result.Method);
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
            var sut = new DeleteKeyRequest(expected, 0);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_UserIdIsSet_AddsUserIdParameter()
        {
            const uint expected = 5;
            var expectedParameter = new Parameter
            {
                Name = "userId",
                Value = expected,
                Type = ParameterType.UrlSegment
            };
            var sut = new DeleteKeyRequest(0, expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_UserIdIsSet_SetsCorrectResource()
        {
            var sut = new DeleteKeyRequest(0, 0);

            var result = sut.GetRequest();

            Assert.Equal(DeleteKeyRequest.ForSpecifiedUserResource, result.Resource);
        }

        [Fact]
        public void GetRequest_UserIdIsSet_SetsMethodToDelete()
        {
            var sut = new DeleteKeyRequest(0, 0);

            var result = sut.GetRequest();

            Assert.Equal(Method.DELETE, result.Method);
        }
    }
}