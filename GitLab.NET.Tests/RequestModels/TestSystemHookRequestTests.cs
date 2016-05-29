using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class TestSystemHookRequestTests
    {
        [Fact]
        public void GetRequest_AddsHookIdParameter()
        {
            const uint expected = 5;
            var expectedParameter = new Parameter
            {
                Name = "hookId",
                Value = expected,
                Type = ParameterType.UrlSegment
            };
            var sut = new TestSystemHookRequest(expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new TestSystemHookRequest(0);

            var result = sut.GetRequest();

            Assert.Equal(TestSystemHookRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToPost()
        {
            var sut = new TestSystemHookRequest(0);

            var result = sut.GetRequest();

            Assert.Equal(Method.GET, result.Method);
        }
    }
}