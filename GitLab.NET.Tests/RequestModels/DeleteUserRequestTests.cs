using NSubstitute;
using System;
using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class DeleteUserRequestTests
    {
        [Fact]
        public void GetRequest_SetsMethodToDelete()
        {
            var sut = new DeleteUserRequest(0);

            var result = sut.GetRequest();

            Assert.Equal(Method.DELETE, result.Method);
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new DeleteUserRequest(0);

            var result = sut.GetRequest();

            Assert.Equal(DeleteUserRequest.Resource, result.Resource);
        }

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
            var sut = new DeleteUserRequest(expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }
    }
}
