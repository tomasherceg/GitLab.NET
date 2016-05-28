using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class GetUserEmailsRequestTests
    {
        [Fact]
        public void GetRequest_IdIsNotSet_SetsCorrectResource()
        {
            var sut = new GetUserEmailsRequest();

            var result = sut.GetRequest();

            Assert.Equal(GetUserEmailsRequest.CurrentUserResource, result.Resource);
        }

        [Fact]
        public void GetRequest_IdIsNotSet_SetsMethodToGet()
        {
            var sut = new GetUserEmailsRequest();

            var result = sut.GetRequest();

            Assert.Equal(Method.GET, result.Method);
        }

        [Fact]
        public void GetRequest_IdIsSet_AddsIdParameter()
        {
            const uint expected = 5;
            var expectedParameter = new Parameter
            {
                Name = "id",
                Value = expected,
                Type = ParameterType.UrlSegment
            };
            var sut = new GetUserEmailsRequest(expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_IdIsSet_SetsCorrectResource()
        {
            var sut = new GetUserEmailsRequest(0);

            var result = sut.GetRequest();

            Assert.Equal(GetUserEmailsRequest.SpecifiedUserResource, result.Resource);
        }

        [Fact]
        public void GetRequest_IdIsSet_SetsMethodToGet()
        {
            var sut = new GetUserEmailsRequest(0);

            var result = sut.GetRequest();

            Assert.Equal(Method.GET, result.Method);
        }
    }
}