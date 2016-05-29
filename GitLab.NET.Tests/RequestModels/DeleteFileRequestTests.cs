using GitLab.NET.RequestModels;
using GitLab.NET.Tests.TestHelpers;
using RestSharp;
using Xunit;

namespace GitLab.NET.Tests.RequestModels
{
    public class DeleteFileRequestTests
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
            var sut = new DeleteFileRequest(0, "filePath", expected, "commitMessage");

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
            var sut = new DeleteFileRequest(0, "filePath", "branchName", expected);

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
            var sut = new DeleteFileRequest(0, expected, "branchName", "commitMessage");

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
            var sut = new DeleteFileRequest(expected, "filePath", "branchName", "commitMessage");

            var result = sut.GetRequest();

            Assert.Contains(expectedParameter, result.Parameters, new ParameterEqualityComparer());
        }

        [Fact]
        public void GetRequest_SetsCorrectResource()
        {
            var sut = new DeleteFileRequest(0, "filePath", "branchName", "commitMessage");

            var result = sut.GetRequest();

            Assert.Equal(DeleteFileRequest.Resource, result.Resource);
        }

        [Fact]
        public void GetRequest_SetsMethodToGet()
        {
            var sut = new DeleteFileRequest(0, "filePath", "branchName", "commitMessage");

            var result = sut.GetRequest();

            Assert.Equal(Method.DELETE, result.Method);
        }
    }
}