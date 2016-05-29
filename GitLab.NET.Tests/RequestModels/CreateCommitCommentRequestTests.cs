using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class CreateCommitCommentRequestTests
    {
        [Fact]
        public void GetRequest_AddsCommitShaParameter()
        {
            const string expected = "commitSha";
            var expectedParameter = new Parameter
            {
                Name = "commitSha",
                Value = expected,
                Type = ParameterType.UrlSegment
            };
            var sut = new CreateCommitCommentRequest(0, expected, "note");

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_AddsNoteParameter()
        {
            const string expected = "note";
            var expectedParameter = new Parameter
            {
                Name = "note",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateCommitCommentRequest(0, "commitSha", expected);

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
            var sut = new CreateCommitCommentRequest(expected, "commitSha", "note");

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_LineIsSet_AddsLineParameter()
        {
            const uint expected = 5;
            var expectedParameter = new Parameter
            {
                Name = "line",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateCommitCommentRequest(0, "commitSha", "note", line: expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_LineTypeIsSet_AddsLineTypeParameter()
        {
            const string expected = "lineType";
            var expectedParameter = new Parameter
            {
                Name = "line_type",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateCommitCommentRequest(0, "commitSha", "note", lineType: expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_PathIsSet_AddsPathParameter()
        {
            const string expected = "path";
            var expectedParameter = new Parameter
            {
                Name = "path",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new CreateCommitCommentRequest(0, "commitSha", "note", expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new CreateCommitCommentRequest(0, "commitSha", "note");

            var result = sut.GetRequest();

            Assert.Equal(CreateCommitCommentRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToGet()
        {
            var sut = new CreateCommitCommentRequest(0, "commitSha", "note");

            var result = sut.GetRequest();

            Assert.Equal(Method.POST, result.Method);
        }
    }
}