using System;
using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class GetCommitsRequestTests
    {
        [Fact]
        public void GetRequest_AddsProjectIdParameter()
        {
            const uint expected = 5;
            var expectedParameter = new Parameter
            {
                Name = "projectId",
                Value = expected,
                Type = ParameterType.UrlSegment
            };
            var sut = new GetCommitsRequest(expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_RefNameIsSet_AddsRefNameParameter()
        {
            const string expected = "refName";
            var expectedParameter = new Parameter
            {
                Name = "ref_name",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new GetCommitsRequest(0, refName: expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SinceIsSet_AddsSinceParameter()
        {
            var expected = DateTime.MinValue;
            var expectedParameter = new Parameter
            {
                Name = "since",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new GetCommitsRequest(0, since: expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_UntilIsSet_AddsUntilParameter()
        {
            var expected = DateTime.MaxValue;
            var expectedParameter = new Parameter
            {
                Name = "until",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new GetCommitsRequest(0, until: expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new GetCommitsRequest(0);

            var result = sut.GetRequest();

            Assert.Equal(GetCommitsRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToGet()
        {
            var sut = new GetCommitsRequest(0);

            var result = sut.GetRequest();

            Assert.Equal(Method.GET, result.Method);
        }
    }
}