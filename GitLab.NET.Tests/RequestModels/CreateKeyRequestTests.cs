using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class CreateKeyRequestTests
    {
        [Fact]
        public void GetRequest_UserIdIsNotSet_AddsKeyParameter()
        {
            const string expected = "key";
            var expectedParameter = new Parameter
            {
                Name = "key",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateKeyRequest("title", expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_UserIdIsNotSet_AddsTitleParameter()
        {
            const string expected = "title";
            var expectedParameter = new Parameter
            {
                Name = "title",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateKeyRequest(expected, "key");

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_UserIdIsNotSet_SetsCorrectResource()
        {
            var sut = new CreateKeyRequest("title", "key");

            var result = sut.GetRequest();

            Assert.Equal(CreateKeyRequest.ForCurrentUserResource, result.Resource);
        }

        [Fact]
        public void GetRequest_UserIdIsNotSet_SetsMethodToPost()
        {
            var sut = new CreateKeyRequest("title", "key");

            var result = sut.GetRequest();

            Assert.Equal(Method.POST, result.Method);
        }

        [Fact]
        public void GetRequest_UserIdIsSet_AddsKeyParameter()
        {
            const string expected = "key";
            var expectedParameter = new Parameter
            {
                Name = "key",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateKeyRequest("title", expected, 0);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_UserIdIsSet_AddsTitleParameter()
        {
            const string expected = "title";
            var expectedParameter = new Parameter
            {
                Name = "title",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateKeyRequest(expected, "key", 0);

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
            var sut = new CreateKeyRequest("title", "key", expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_UserIdIsSet_SetsCorrectResource()
        {
            var sut = new CreateKeyRequest("title", "key", 0);

            var result = sut.GetRequest();

            Assert.Equal(CreateKeyRequest.ForSpecifiedUserResource, result.Resource);
        }

        [Fact]
        public void GetRequest_UserIdIsSet_SetsMethodToPost()
        {
            var sut = new CreateKeyRequest("title", "key", 0);

            var result = sut.GetRequest();

            Assert.Equal(Method.POST, result.Method);
        }
    }
}