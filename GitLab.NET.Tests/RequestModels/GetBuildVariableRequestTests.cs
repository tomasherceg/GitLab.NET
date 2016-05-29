﻿using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class GetBuildVariableRequestTests
    {
        [Fact]
        public void GetRequest_AddsKeyParameter()
        {
            const string expected = "key";
            var expectedParameter = new Parameter
            {
                Name = "key",
                Value = expected,
                Type = ParameterType.UrlSegment
            };
            var sut = new GetBuildVariableRequest(0, expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

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
            var sut = new GetBuildVariableRequest(expected, "key");

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new GetBuildVariableRequest(0, "key");

            var result = sut.GetRequest();

            Assert.Equal(GetBuildVariableRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToGet()
        {
            var sut = new GetBuildVariableRequest(0, "key");

            var result = sut.GetRequest();

            Assert.Equal(Method.GET, result.Method);
        }
    }
}