using NSubstitute;
using System;
using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class BlockUserRequestTests
    {
        [Fact]
        public void GetRequest_SetsMethodToPut()
        {
            var sut = new BlockUserRequest(0);

            var result = sut.GetRequest();

            Assert.Equal(Method.PUT, result.Method);
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new BlockUserRequest(0);

            var result = sut.GetRequest();

            Assert.Equal(BlockUserRequest.Resource, result.Resource);
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
            var sut = new BlockUserRequest(expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }
    }
}
