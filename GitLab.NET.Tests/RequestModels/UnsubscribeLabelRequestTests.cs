using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class UnsubscribeLabelRequestTests
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
            var sut = new UnsubscribeLabelRequest(expected, "name");

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_LabelNameIsSet_AddsLabelNameParameter()
        {
            const string expected = "labelName";
            var expectedParameter = new Parameter
            {
                Name = "labelId",
                Value = expected,
                Type = ParameterType.UrlSegment
            };
            var sut = new UnsubscribeLabelRequest(0, expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new UnsubscribeLabelRequest(0, "name");

            var result = sut.GetRequest();

            Assert.Equal(UnsubscribeLabelRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToGet()
        {
            var sut = new UnsubscribeLabelRequest(0, "name");

            var result = sut.GetRequest();

            Assert.Equal(Method.DELETE, result.Method);
        }
    }
}