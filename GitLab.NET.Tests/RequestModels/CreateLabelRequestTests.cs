using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class CreateLabelRequestTests
    {
        [Fact]
        public void GetRequest_AddsColorParameter()
        {
            const string expected = "color";
            var expectedParameter = new Parameter
            {
                Name = "color",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateLabelRequest(0, "name", expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_AddsNameParameter()
        {
            const string expected = "name";
            var expectedParameter = new Parameter
            {
                Name = "name",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateLabelRequest(0, expected, "color");

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
            var sut = new CreateLabelRequest(expected, "name", "color");

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_DescriptionIsSet_AddsDescriptionParameter()
        {
            const string expected = "description";
            var expectedParameter = new Parameter
            {
                Name = "description",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateLabelRequest(0, "name", "color", expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new CreateLabelRequest(0, "name", "color");

            var result = sut.GetRequest();

            Assert.Equal(CreateLabelRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToGet()
        {
            var sut = new CreateLabelRequest(0, "name", "color");

            var result = sut.GetRequest();

            Assert.Equal(Method.POST, result.Method);
        }
    }
}