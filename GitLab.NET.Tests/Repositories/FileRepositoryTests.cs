using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NSubstitute;
using Xunit;

namespace GitLab.NET.Tests.Repositories
{
    public class FileRepositoryTests
    {
        public FileRepositoryTests()
        {
            _request = Substitute.For<IRequest>();
            _requestFactory = Substitute.For<IRequestFactory>();
            _requestFactory.Create(Arg.Any<string>(), Arg.Any<Method>(), Arg.Any<bool>()).Returns(_request);
        }

        private readonly IRequest _request;
        private readonly IRequestFactory _requestFactory;

        [Fact]
        public async Task Create_BranchNameIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(
                () => sut.Create(0, "filePath", null, "content", "commitMessage"));
        }

        [Fact]
        public async Task Create_CommitMessageIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(
                () => sut.Create(0, "filePath", "branchName", "content", null));
        }

        [Fact]
        public async Task Create_ContentIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(
                () => sut.Create(0, "filePath", "branchName", null, "commitMessage"));
        }

        [Fact]
        public async Task Create_EncodingIsSet_AddsEncodingParameter()
        {
            const string expected = "encoding";
            var sut = new FileRepository(_requestFactory);

            await sut.Create(0, "filePath", "branchName", "content", "commitMessage", expected);

            _request.Received().AddParameterIfNotNull("encoding", expected);
        }

        [Fact]
        public async Task Create_FilePathIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(
                () => sut.Create(0, null, "branchName", "content", "commitMessage"));
        }

        [Fact]
        public async Task Create_ValidParameters_AddsBranchNameParameter()
        {
            const string expected = "branchName";
            var sut = new FileRepository(_requestFactory);

            await sut.Create(0, "filePath", expected, "content", "commitMessage");

            _request.Received().AddParameter("branch_name", expected);
        }

        [Fact]
        public async Task Create_ValidParameters_AddsCommitMessageParameter()
        {
            const string expected = "commitMessage";
            var sut = new FileRepository(_requestFactory);

            await sut.Create(0, "filePath", "branchName", "content", expected);

            _request.Received().AddParameter("commit_message", expected);
        }

        [Fact]
        public async Task Create_ValidParameters_AddsContentParameter()
        {
            const string expected = "content";
            var sut = new FileRepository(_requestFactory);

            await sut.Create(0, "filePath", "branchName", expected, "commitMessage");

            _request.Received().AddParameter("content", expected);
        }

        [Fact]
        public async Task Create_ValidParameters_AddsFilePathParameter()
        {
            const string expected = "filePath";
            var sut = new FileRepository(_requestFactory);

            await sut.Create(0, expected, "branchName", "content", "commitMessage");

            _request.Received().AddParameter("file_path", expected);
        }

        [Fact]
        public async Task Create_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new FileRepository(_requestFactory);

            await sut.Create(expected, "filePath", "branchName", "content", "commitMessage");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task Create_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new FileRepository(_requestFactory);

            await sut.Create(0, "filePath", "branchName", "content", "commitMessage");

            _requestFactory.Received().Create("projects/{projectId}/repository/files", Method.Post);
        }

        [Fact]
        public async Task Delete_BranchNameIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Delete(0, "filePath", null, "commitMessage"));
        }

        [Fact]
        public async Task Delete_CommitMessageIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Delete(0, "filePath", "branchName", null));
        }

        [Fact]
        public async Task Delete_FilePathIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Delete(0, null, "branchName", "commitMessage"));
        }

        [Fact]
        public async Task Delete_ValidParameters_AddsBranchNameParameter()
        {
            const string expected = "branchName";
            var sut = new FileRepository(_requestFactory);

            await sut.Delete(0, "filePath", expected, "commitMessage");

            _request.Received().AddParameter("branch_name", expected);
        }

        [Fact]
        public async Task Delete_ValidParameters_AddsCommitMessageParameter()
        {
            const string expected = "commitMessage";
            var sut = new FileRepository(_requestFactory);

            await sut.Delete(0, "filePath", "branchName", expected);

            _request.Received().AddParameter("commit_message", expected);
        }

        [Fact]
        public async Task Delete_ValidParameters_AddsFilePathParameter()
        {
            const string expected = "filePath";
            var sut = new FileRepository(_requestFactory);

            await sut.Delete(0, expected, "branchName", "commitMessage");

            _request.Received().AddParameter("file_path", expected);
        }

        [Fact]
        public async Task Delete_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new FileRepository(_requestFactory);

            await sut.Delete(expected, "filePath", "branchName", "commitMessage");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task Delete_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new FileRepository(_requestFactory);

            await sut.Delete(0, "filePath", "branchName", "commitMessage");

            _requestFactory.Received().Create("projects/{projectId}/repository/files", Method.Delete);
        }

        [Fact]
        public async Task Find_FilePathIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Find(0, null, "refName"));
        }

        [Fact]
        public async Task Find_RefNameIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.Find(0, "filePath", null));
        }

        [Fact]
        public async Task Find_ValidParameters_AddsFilePathParameter()
        {
            const string expected = "filePath";
            var sut = new FileRepository(_requestFactory);

            await sut.Find(0, expected, "refName");

            _request.Received().AddParameter("file_path", expected);
        }

        [Fact]
        public async Task Find_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new FileRepository(_requestFactory);

            await sut.Find(expected, "filePath", "refName");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task Find_ValidParameters_AddsRefParameter()
        {
            const string expected = "refName";
            var sut = new FileRepository(_requestFactory);

            await sut.Find(0, "filePath", expected);

            _request.Received().AddParameter("ref", expected);
        }

        [Fact]
        public async Task Find_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new FileRepository(_requestFactory);

            await sut.Find(0, "filePath", "refName");

            _requestFactory.Received().Create("projects/{projectId}/repository/files", Method.Get);
        }

        [Fact]
        public async Task Update_BranchNameIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(
                () => sut.Update(0, "filePath", null, "content", "commitMessage"));
        }

        [Fact]
        public async Task Update_CommitMessageIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(
                () => sut.Update(0, "filePath", "branchName", "content", null));
        }

        [Fact]
        public async Task Update_ContentIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(
                () => sut.Update(0, "filePath", "branchName", null, "commitMessage"));
        }

        [Fact]
        public async Task Update_EncodingIsSet_AddsEncodingParameter()
        {
            const string expected = "encoding";
            var sut = new FileRepository(_requestFactory);

            await sut.Update(0, "filePath", "branchName", "content", "commitMessage", expected);

            _request.Received().AddParameterIfNotNull("encoding", expected);
        }

        [Fact]
        public async Task Update_FilePathIsNull_ThrowsArgumentNullException()
        {
            var sut = new FileRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(
                () => sut.Update(0, null, "branchName", "content", "commitMessage"));
        }

        [Fact]
        public async Task Update_ValidParameters_AddsBranchNameParameter()
        {
            const string expected = "branchName";
            var sut = new FileRepository(_requestFactory);

            await sut.Update(0, "filePath", expected, "content", "commitMessage");

            _request.Received().AddParameter("branch_name", expected);
        }

        [Fact]
        public async Task Update_ValidParameters_AddsCommitMessageParameter()
        {
            const string expected = "commitMessage";
            var sut = new FileRepository(_requestFactory);

            await sut.Update(0, "filePath", "branchName", "content", expected);

            _request.Received().AddParameter("commit_message", expected);
        }

        [Fact]
        public async Task Update_ValidParameters_AddsContentParameter()
        {
            const string expected = "content";
            var sut = new FileRepository(_requestFactory);

            await sut.Update(0, "filePath", "branchName", expected, "commitMessage");

            _request.Received().AddParameter("content", expected);
        }

        [Fact]
        public async Task Update_ValidParameters_AddsFilePathParameter()
        {
            const string expected = "filePath";
            var sut = new FileRepository(_requestFactory);

            await sut.Update(0, expected, "branchName", "content", "commitMessage");

            _request.Received().AddParameter("file_path", expected);
        }

        [Fact]
        public async Task Update_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new FileRepository(_requestFactory);

            await sut.Update(expected, "filePath", "branchName", "content", "commitMessage");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task Update_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new FileRepository(_requestFactory);

            await sut.Update(0, "filePath", "branchName", "content", "commitMessage");

            _requestFactory.Received().Create("projects/{projectId}/repository/files", Method.Put);
        }
    }
}