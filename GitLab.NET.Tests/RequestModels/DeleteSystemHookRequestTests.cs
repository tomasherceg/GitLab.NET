using NSubstitute;
using System;
using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class DeleteSystemHookRequestTests
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
            var sut = new DeleteSystemHookRequest(expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new DeleteSystemHookRequest(0);

            var result = sut.GetRequest();

            Assert.Equal(DeleteSystemHookRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToPost()
        {
            var sut = new DeleteSystemHookRequest(0);

            var result = sut.GetRequest();

            Assert.Equal(Method.DELETE, result.Method);
        }
    }
}
