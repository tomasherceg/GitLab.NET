using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class DeleteEmailRequestTests
    {
        [Fact]
        public void GetRequest_SetsMethodToDelete()
        {
            var sut = new DeleteEmailRequest(0);

            var result = sut.GetRequest();

            Assert.Equal(Method.DELETE, result.Method);
        }

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
            var sut = new DeleteEmailRequest(expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_UserIdIsNotSet_SetsCorrectResource()
        {
            var sut = new DeleteEmailRequest(0);

            var result = sut.GetRequest();

            Assert.Equal(DeleteEmailRequest.ForCurrentUserResource, result.Resource);
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
            var sut = new DeleteEmailRequest(expected, 0);

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
            var sut = new DeleteEmailRequest(0, expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_UserIdIsSet_SetsCorrectResource()
        {
            var sut = new DeleteEmailRequest(0, 0);

            var result = sut.GetRequest();

            Assert.Equal(DeleteEmailRequest.ForSpecifiedUserResource, result.Resource);
        }
    }
}