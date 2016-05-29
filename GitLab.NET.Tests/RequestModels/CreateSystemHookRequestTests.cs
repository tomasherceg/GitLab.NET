using NSubstitute;
using System;
using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class CreateSystemHookRequestTests
    {
        [Fact]
        public void GetRequest_AddsUrlParameter()
        {
            const string expected = "url";
            var expectedParameter = new Parameter
            {
                Name = "url",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateSystemHookRequest(expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new CreateSystemHookRequest("url");

            var result = sut.GetRequest();

            Assert.Equal(CreateSystemHookRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToPost()
        {
            var sut = new CreateSystemHookRequest("url");

            var result = sut.GetRequest();

            Assert.Equal(Method.POST, result.Method);
        }
    }
}
