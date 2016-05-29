using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class UpdateFileRequestTests
    {
        [Fact]
        public void GetRequest_AddsBranchNameParameter()
        {
            const string expected = "branchName";
            var expectedParameter = new Parameter
            {
                Name = "branch_name",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new UpdateFileRequest(0, "filePath", expected, "content", "commitMessage");

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_AddsCommitMessageParameter()
        {
            const string expected = "commitMessage";
            var expectedParameter = new Parameter
            {
                Name = "commit_message",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new UpdateFileRequest(0, "filePath", "branchName", "content", expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_AddsContentParameter()
        {
            const string expected = "content";
            var expectedParameter = new Parameter
            {
                Name = "content",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new UpdateFileRequest(0, "filePath", "branchName", expected, "commitMessage");

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_AddsFilePathParameter()
        {
            const string expected = "filePath";
            var expectedParameter = new Parameter
            {
                Name = "file_path",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new UpdateFileRequest(0, expected, "branchName", "content", "commitMessage");

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
            var sut = new UpdateFileRequest(expected, "filePath", "branchName", "content", "commitMessage");

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_EncodingIsSet_AddsEncodingParameter()
        {
            const string expected = "encoding";
            var expectedParameter = new Parameter
            {
                Name = "encoding",
                Value = expected,
                Type = ParameterType.GetOrPost
            };
            var sut = new UpdateFileRequest(0, "filePath", "branchName", "content", "commitMessage", expected);

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new UpdateFileRequest(0, "filePath", "branchName", "content", "commitMessage");

            var result = sut.GetRequest();

            Assert.Equal(UpdateFileRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToGet()
        {
            var sut = new UpdateFileRequest(0, "filePath", "branchName", "content", "commitMessage");

            var result = sut.GetRequest();

            Assert.Equal(Method.PUT, result.Method);
        }
    }
}