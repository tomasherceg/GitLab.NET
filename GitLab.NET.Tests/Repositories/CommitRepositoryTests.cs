using NSubstitute;
using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using Xunit;

namespace GitLab.NET.Tests.Repositories
{
    public class CommitRepositoryTests
    {
        private readonly IRequest _request;
        private readonly IRequestFactory _requestFactory;

        public CommitRepositoryTests()
        {
            _request = Substitute.For<IRequest>();
            _requestFactory = Substitute.For<IRequestFactory>();
            _requestFactory.Create(Arg.Any<string>(), Arg.Any<Method>(), Arg.Any<bool>()).Returns(_request);
        }

        #region CreateComment
        [Fact]
        public void CreateComment_CommitShaIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(_requestFactory);

            Assert.Throws<ArgumentNullException>(() => sut.CreateComment(0, null, "note"));
        }

        [Fact]
        public void CreateComment_NoteIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(_requestFactory);

            Assert.Throws<ArgumentNullException>(() => sut.CreateComment(0, "commitSha", null));
        }

        [Fact]
        public void CreateComment_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new CommitRepository(_requestFactory);

            sut.CreateComment(expected, "commitSha", "note");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public void CreateComment_ValidParameters_AddsCommitShaUrlSegment()
        {
            const string expected = "commitSha";
            var sut = new CommitRepository(_requestFactory);

            sut.CreateComment(0, expected, "note");

            _request.Received().AddUrlSegment("commitSha", expected);
        }

        [Fact]
        public void CreateCommit_ValidParameters_AddsNoteParameter()
        {
            const string expected = "note";
            var sut = new CommitRepository(_requestFactory);

            sut.CreateComment(0, "commitSha", expected);

            _request.Received().AddParameter("note", expected);
        }

        [Fact]
        public void CreateComment_PathIsSet_AddsPathParameter()
        {
            const string expected = "path";
            var sut = new CommitRepository(_requestFactory);

            sut.CreateComment(0, "commitSha", "note", path: expected);

            _request.Received().AddParameterIfNotNull("path", expected);
        }

        [Fact]
        public void CreateComment_LineIsSet_AddsLineParameter()
        {
            const uint expected = 0;
            var sut = new CommitRepository(_requestFactory);

            sut.CreateComment(0, "commitSha", "note", line: expected);

            _request.Received().AddParameterIfNotNull("line", expected);
        }

        [Fact]
        public void CreateComment_LineTypeIsSet_AddsLineTypeParameter()
        {
            const string expected = "lineType";
            var sut = new CommitRepository(_requestFactory);

            sut.CreateComment(0, "commitSha", "note", lineType: expected);

            _request.Received().AddParameterIfNotNull("line_type", expected);
        }

        [Fact]
        public void CreateComment_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new CommitRepository(_requestFactory);

            sut.CreateComment(0, "commitSha", "note");

            _requestFactory.Received().Create("projects/{projectId}/repository/commits/{commitSha}/comments", Method.Post);
        }

        [Fact]
        public async Task CreateCommentAsync_CommitShaIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateCommentAsync(0, null, "note"));
        }

        [Fact]
        public async Task CreateCommentAsync_NoteIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateCommentAsync(0, "commitSha", null));
        }

        [Fact]
        public async Task CreateCommentAsync_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new CommitRepository(_requestFactory);

            await sut.CreateCommentAsync(expected, "commitSha", "note");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task CreateCommentAsync_ValidParameters_AddsCommitShaUrlSegment()
        {
            const string expected = "commitSha";
            var sut = new CommitRepository(_requestFactory);

            await sut.CreateCommentAsync(0, expected, "note");

            _request.Received().AddUrlSegment("commitSha", expected);
        }

        [Fact]
        public async Task CreateCommitAsync_ValidParameters_AddsNoteParameter()
        {
            const string expected = "note";
            var sut = new CommitRepository(_requestFactory);

            await sut.CreateCommentAsync(0, "commitSha", expected);

            _request.Received().AddParameter("note", expected);
        }

        [Fact]
        public async Task CreateCommentAsync_PathIsSet_AddsPathParameter()
        {
            const string expected = "path";
            var sut = new CommitRepository(_requestFactory);

            await sut.CreateCommentAsync(0, "commitSha", "note", path: expected);

            _request.Received().AddParameterIfNotNull("path", expected);
        }

        [Fact]
        public async Task CreateCommentAsync_LineIsSet_AddsLineParameter()
        {
            const uint expected = 0;
            var sut = new CommitRepository(_requestFactory);

            await sut.CreateCommentAsync(0, "commitSha", "note", line: expected);

            _request.Received().AddParameterIfNotNull("line", expected);
        }

        [Fact]
        public async Task CreateCommentAsync_LineTypeIsSet_AddsLineTypeParameter()
        {
            const string expected = "lineType";
            var sut = new CommitRepository(_requestFactory);

            await sut.CreateCommentAsync(0, "commitSha", "note", lineType: expected);

            _request.Received().AddParameterIfNotNull("line_type", expected);
        }

        [Fact]
        public async Task CreateCommentAsync_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new CommitRepository(_requestFactory);

            await sut.CreateCommentAsync(0, "commitSha", "note");

            _requestFactory.Received().Create("projects/{projectId}/repository/commits/{commitSha}/comments", Method.Post);
        }
        #endregion

        #region CreateStatus
        [Fact]
        public void CreateStatus_CommitShaIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(_requestFactory);

            Assert.Throws<ArgumentNullException>(() => sut.CreateStatus(0, null, "state"));
        }

        [Fact]
        public void CreateStatus_StateIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(_requestFactory);

            Assert.Throws<ArgumentNullException>(() => sut.CreateStatus(0, "commitSha", null));
        }

        [Fact]
        public void CreateStatus_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new CommitRepository(_requestFactory);

            sut.CreateStatus(expected, "commitSha", "state");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public void CreateStatus_ValidParameters_AddsCommitShaUrlSegment()
        {
            const string expected = "commitSha";
            var sut = new CommitRepository(_requestFactory);

            sut.CreateStatus(0, expected, "state");

            _request.Received().AddUrlSegment("commitSha", expected);
        }

        [Fact]
        public void CreateStatus_ValidParameters_AddsStateParameter()
        {
            const string expected = "state";
            var sut = new CommitRepository(_requestFactory);

            sut.CreateStatus(0, "commitSha", expected);

            _request.Received().AddParameter("state", expected);
        }
        
        [Fact]
        public void CreateStatus_RefNameIsSet_AddsRefNameParameter()
        {
            const string expected = "refName";
            var sut = new CommitRepository(_requestFactory);

            sut.CreateStatus(0, "commitSha", "state", refName: expected);

            _request.Received().AddParameterIfNotNull("ref", expected);
        }

        [Fact]
        public void CreateStatus_NameIsSet_AddsNameParameter()
        {
            const string expected = "name";
            var sut = new CommitRepository(_requestFactory);

            sut.CreateStatus(0, "commitSha", "state", name: expected);

            _request.Received().AddParameterIfNotNull("name", expected);
        }

        [Fact]
        public void CreateStatus_TargetUrlIsSet_AddsTargetUrlParameter()
        {
            const string expected = "targetUrl";
            var sut = new CommitRepository(_requestFactory);

            sut.CreateStatus(0, "commitSha", "state", targetUrl: expected);

            _request.Received().AddParameterIfNotNull("target_url", expected);
        }

        [Fact]
        public void CreateStatus_DescriptionIsSet_AddsDescriptionParameter()
        {
            const string expected = "description";
            var sut = new CommitRepository(_requestFactory);

            sut.CreateStatus(0, "commitSha", "state", description: expected);

            _request.Received().AddParameterIfNotNull("description", expected);
        }

        [Fact]
        public void CreateStatus_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new CommitRepository(_requestFactory);

            sut.CreateStatus(0, "commitSha", "state");

            _requestFactory.Received().Create("projects/{projectId}/statuses/{commitSha}", Method.Post);
        }

        [Fact]
        public async Task CreateStatusAsync_CommitShaIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateStatusAsync(0, null, "state"));
        }

        [Fact]
        public async Task CreateStatusAsync_StateIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateStatusAsync(0, "commitSha", null));
        }

        [Fact]
        public async Task CreateStatusAsync_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new CommitRepository(_requestFactory);

            await sut.CreateStatusAsync(expected, "commitSha", "state");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task CreateStatusAsync_ValidParameters_AddsCommitShaUrlSegment()
        {
            const string expected = "commitSha";
            var sut = new CommitRepository(_requestFactory);

            await sut.CreateStatusAsync(0, expected, "state");

            _request.Received().AddUrlSegment("commitSha", expected);
        }

        [Fact]
        public async Task CreateStatusAsync_ValidParameters_AddsStateParameter()
        {
            const string expected = "state";
            var sut = new CommitRepository(_requestFactory);

            await sut.CreateStatusAsync(0, "commitSha", expected);

            _request.Received().AddParameter("state", expected);
        }

        [Fact]
        public async Task CreateStatusAsync_RefNameIsSet_AddsRefNameParameter()
        {
            const string expected = "refName";
            var sut = new CommitRepository(_requestFactory);

            await sut.CreateStatusAsync(0, "commitSha", "state", refName: expected);

            _request.Received().AddParameterIfNotNull("ref", expected);
        }

        [Fact]
        public async Task CreateStatusAsync_NameIsSet_AddsNameParameter()
        {
            const string expected = "name";
            var sut = new CommitRepository(_requestFactory);

            await sut.CreateStatusAsync(0, "commitSha", "state", name: expected);

            _request.Received().AddParameterIfNotNull("name", expected);
        }

        [Fact]
        public async Task CreateStatusAsync_TargetUrlIsSet_AddsTargetUrlParameter()
        {
            const string expected = "targetUrl";
            var sut = new CommitRepository(_requestFactory);

            await sut.CreateStatusAsync(0, "commitSha", "state", targetUrl: expected);

            _request.Received().AddParameterIfNotNull("target_url", expected);
        }

        [Fact]
        public async Task CreateStatusAsync_DescriptionIsSet_AddsDescriptionParameter()
        {
            const string expected = "description";
            var sut = new CommitRepository(_requestFactory);

            await sut.CreateStatusAsync(0, "commitSha", "state", description: expected);

            _request.Received().AddParameterIfNotNull("description", expected);
        }

        [Fact]
        public async Task CreateStatusAsync_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new CommitRepository(_requestFactory);

            await sut.CreateStatusAsync(0, "commitSha", "state");

            _requestFactory.Received().Create("projects/{projectId}/statuses/{commitSha}", Method.Post);
        }
        #endregion

        #region Find
        [Fact]
        public void Find_CommitShaIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(_requestFactory);

            Assert.Throws<ArgumentNullException>(() => sut.Find(0, null));
        }

        [Fact]
        public void Find_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new CommitRepository(_requestFactory);

            sut.Find(expected, "commitSha");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public void Find_ValidParameters_AddsCommitShaUrlSegment()
        {
            const string expected = "commitSha";
            var sut = new CommitRepository(_requestFactory);

            sut.Find(0, expected);

            _request.Received().AddUrlSegment("commitSha", expected);
        }

        [Fact]
        public void Find_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new CommitRepository(_requestFactory);

            sut.Find(0, "commitSha");

            _requestFactory.Received().Create("projects/{projectId}/repository/commits/{commitSha}", Method.Get);
        }

        [Fact]
        public async Task FindAsync_CommitShaIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.FindAsync(0, null));
        }

        [Fact]
        public async Task FindAsync_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new CommitRepository(_requestFactory);

            await sut.FindAsync(expected, "commitSha");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task FindAsync_ValidParameters_AddsCommitShaUrlSegment()
        {
            const string expected = "commitSha";
            var sut = new CommitRepository(_requestFactory);

            await sut.FindAsync(0, expected);

            _request.Received().AddUrlSegment("commitSha", expected);
        }

        [Fact]
        public async Task FindAsync_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new CommitRepository(_requestFactory);

            await sut.FindAsync(0, "commitSha");

            _requestFactory.Received().Create("projects/{projectId}/repository/commits/{commitSha}", Method.Get);
        }
        #endregion

        #region GetAll
        [Fact]
        public void GetAll_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new CommitRepository(_requestFactory);

            sut.GetAll(expected);

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public void GetAll_RefNameIsSet_AddsRefNameParameter()
        {
            const string expected = "refName";
            var sut = new CommitRepository(_requestFactory);

            sut.GetAll(0, refName: expected);

            _request.Received().AddParameterIfNotNull("ref_name", expected);
        }

        [Fact]
        public void GetAll_SinceIsSet_AddsSinceParameter()
        {
            var expected = DateTime.MinValue;
            var sut = new CommitRepository(_requestFactory);

            sut.GetAll(0, since: expected);

            _request.Received().AddParameterIfNotNull("since", expected);
        }

        [Fact]
        public void GetAll_UntilIsSet_AddsUntilParameter()
        {
            var expected = DateTime.MaxValue;
            var sut = new CommitRepository(_requestFactory);

            sut.GetAll(0, until: expected);

            _request.Received().AddParameterIfNotNull("until", expected);
        }

        [Fact]
        public void GetAll_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new CommitRepository(_requestFactory);

            sut.GetAll(0);

            _requestFactory.Received().Create("projects/{projectId}/repository/commits", Method.Get);
        }

        [Fact]
        public async Task GetAllAsync_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new CommitRepository(_requestFactory);

            await sut.GetAllAsync(expected);

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task GetAllAsync_RefNameIsSet_AddsRefNameParameter()
        {
            const string expected = "refName";
            var sut = new CommitRepository(_requestFactory);

            await sut.GetAllAsync(0, refName: expected);

            _request.Received().AddParameterIfNotNull("ref_name", expected);
        }

        [Fact]
        public async Task GetAllAsync_SinceIsSet_AddsSinceParameter()
        {
            var expected = DateTime.MinValue;
            var sut = new CommitRepository(_requestFactory);

            await sut.GetAllAsync(0, since: expected);

            _request.Received().AddParameterIfNotNull("since", expected);
        }

        [Fact]
        public async Task GetAllAsync_UntilIsSet_AddsUntilParameter()
        {
            var expected = DateTime.MaxValue;
            var sut = new CommitRepository(_requestFactory);

            await sut.GetAllAsync(0, until: expected);

            _request.Received().AddParameterIfNotNull("until", expected);
        }

        [Fact]
        public async Task GetAllAsync_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new CommitRepository(_requestFactory);

            await sut.GetAllAsync(0);

            _requestFactory.Received().Create("projects/{projectId}/repository/commits", Method.Get);
        }
        #endregion

        #region GetComments
        [Fact]
        public void GetComments_CommitShaIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(_requestFactory);

            Assert.Throws<ArgumentNullException>(() => sut.GetComments(0, null));
        }

        [Fact]
        public void GetComments_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new CommitRepository(_requestFactory);

            sut.GetComments(expected, "commitSha");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public void GetComments_ValidParameters_AddsCommitShaUrlSegment()
        {
            const string expected = "commitSha";
            var sut = new CommitRepository(_requestFactory);

            sut.GetComments(0, expected);

            _request.Received().AddUrlSegment("commitSha", expected);
        }

        [Fact]
        public void GetComments_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new CommitRepository(_requestFactory);

            sut.GetComments(0, "commitSha");

            _requestFactory.Received().Create("projects/{projectId}/repository/commits/{commitSha}/comments", Method.Get);
        }

        [Fact]
        public async Task GetCommentsAsync_CommitShaIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.GetCommentsAsync(0, null));
        }

        [Fact]
        public async Task GetCommentsAsync_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new CommitRepository(_requestFactory);

            await sut.GetCommentsAsync(expected, "commitSha");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task GetCommentsAsync_ValidParameters_AddsCommitShaUrlSegment()
        {
            const string expected = "commitSha";
            var sut = new CommitRepository(_requestFactory);

            await sut.GetCommentsAsync(0, expected);

            _request.Received().AddUrlSegment("commitSha", expected);
        }

        [Fact]
        public async Task GetCommentsAsync_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new CommitRepository(_requestFactory);

            await sut.GetCommentsAsync(0, "commitSha");

            _requestFactory.Received().Create("projects/{projectId}/repository/commits/{commitSha}/comments", Method.Get);
        }
        #endregion

        #region GetDiff
        [Fact]
        public void GetDiff_CommitShaIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(_requestFactory);

            Assert.Throws<ArgumentNullException>(() => sut.GetDiff(0, null));
        }

        [Fact]
        public void GetDiff_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new CommitRepository(_requestFactory);

            sut.GetDiff(expected, "commitSha");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public void GetDiff_ValidParameters_AddsCommitShaUrlSegment()
        {
            const string expected = "commitSha";
            var sut = new CommitRepository(_requestFactory);

            sut.GetDiff(0, expected);

            _request.Received().AddUrlSegment("commitSha", expected);
        }

        [Fact]
        public void GetDiff_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new CommitRepository(_requestFactory);

            sut.GetDiff(0, "commitSha");

            _requestFactory.Received().Create("projects/{projectId}/repository/commits/{commitSha}/diff", Method.Get);
        }

        [Fact]
        public async Task GetDiffAsync_CommitShaIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.GetDiffAsync(0, null));
        }

        [Fact]
        public async Task GetDiffAsync_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new CommitRepository(_requestFactory);

            await sut.GetDiffAsync(expected, "commitSha");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task GetDiffAsync_ValidParameters_AddsCommitShaUrlSegment()
        {
            const string expected = "commitSha";
            var sut = new CommitRepository(_requestFactory);

            await sut.GetDiffAsync(0, expected);

            _request.Received().AddUrlSegment("commitSha", expected);
        }

        [Fact]
        public async Task GetDiffAsync_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new CommitRepository(_requestFactory);

            await sut.GetDiffAsync(0, "commitSha");

            _requestFactory.Received().Create("projects/{projectId}/repository/commits/{commitSha}/diff", Method.Get);
        }
        #endregion

        #region GetStatus
        [Fact]
        public void GetStatus_CommitShaIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(_requestFactory);

            Assert.Throws<ArgumentNullException>(() => sut.GetStatus(0, null));
        }

        [Fact]
        public void GetStatus_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new CommitRepository(_requestFactory);

            sut.GetStatus(expected, "commitSha");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public void GetStatus_ValidParameters_AddsCommitShaUrlSegment()
        {
            const string expected = "commitSha";
            var sut = new CommitRepository(_requestFactory);

            sut.GetStatus(0, expected);

            _request.Received().AddUrlSegment("commitSha", expected);
        }

        [Fact]
        public void GetStatus_RefNameIsSet_AddsRefNameParameter()
        {
            const string expected = "refName";
            var sut = new CommitRepository(_requestFactory);

            sut.GetStatus(0, "commitSha", refName: expected);

            _request.Received().AddParameterIfNotNull("ref_name", expected);
        }

        [Fact]
        public void GetStatus_StageIsSet_AddsStageParameter()
        {
            const string expected = "stage";
            var sut = new CommitRepository(_requestFactory);

            sut.GetStatus(0, "commitSha", stage: expected);

            _request.Received().AddParameterIfNotNull("stage", expected);
        }

        [Fact]
        public void GetStatus_NameIsSet_AddsNameParameter()
        {
            const string expected = "name";
            var sut = new CommitRepository(_requestFactory);

            sut.GetStatus(0, "commitSha", name: expected);

            _request.Received().AddParameterIfNotNull("name", expected);
        }

        [Fact]
        public void GetStatus_AllIsSet_AddsAllParameter()
        {
            const bool expected = true;
            var sut = new CommitRepository(_requestFactory);

            sut.GetStatus(0, "commitSha", all: expected);

            _request.Received().AddParameterIfNotNull("all", expected);
        }

        [Fact]
        public void GetStatus_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new CommitRepository(_requestFactory);

            sut.GetStatus(0, "commitSha");

            _requestFactory.Received().Create("projects/{projectId}/repository/commits/{commitSha}/statuses", Method.Get);
        }
        
        [Fact]
        public async Task GetStatusAsync_CommitShaIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.GetStatusAsync(0, null));
        }

        [Fact]
        public async Task GetStatusAsync_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new CommitRepository(_requestFactory);

            await sut.GetStatusAsync(expected, "commitSha");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task GetStatusAsync_ValidParameters_AddsCommitShaUrlSegment()
        {
            const string expected = "commitSha";
            var sut = new CommitRepository(_requestFactory);

            await sut.GetStatusAsync(0, expected);

            _request.Received().AddUrlSegment("commitSha", expected);
        }

        [Fact]
        public async Task GetStatusAsync_RefNameIsSet_AddsRefNameParameter()
        {
            const string expected = "refName";
            var sut = new CommitRepository(_requestFactory);

            await sut.GetStatusAsync(0, "commitSha", refName: expected);

            _request.Received().AddParameterIfNotNull("ref_name", expected);
        }

        [Fact]
        public async Task GetStatusAsync_StageIsSet_AddsStageParameter()
        {
            const string expected = "stage";
            var sut = new CommitRepository(_requestFactory);

            await sut.GetStatusAsync(0, "commitSha", stage: expected);

            _request.Received().AddParameterIfNotNull("stage", expected);
        }

        [Fact]
        public async Task GetStatusAsync_NameIsSet_AddsNameParameter()
        {
            const string expected = "name";
            var sut = new CommitRepository(_requestFactory);

            await sut.GetStatusAsync(0, "commitSha", name: expected);

            _request.Received().AddParameterIfNotNull("name", expected);
        }

        [Fact]
        public async Task GetStatusAsync_AllIsSet_AddsAllParameter()
        {
            const bool expected = true;
            var sut = new CommitRepository(_requestFactory);

            await sut.GetStatusAsync(0, "commitSha", all: expected);

            _request.Received().AddParameterIfNotNull("all", expected);
        }

        [Fact]
        public async Task GetStatusAsync_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new CommitRepository(_requestFactory);

            await sut.GetStatusAsync(0, "commitSha");

            _requestFactory.Received().Create("projects/{projectId}/repository/commits/{commitSha}/statuses", Method.Get);
        }
        #endregion

        #region UpdateStatus
        [Fact]
        public void UpdateStatus_CommitShaIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(_requestFactory);

            Assert.Throws<ArgumentNullException>(() => sut.UpdateStatus(0, null, "state"));
        }

        [Fact]
        public void UpdateStatus_StateIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(_requestFactory);

            Assert.Throws<ArgumentNullException>(() => sut.UpdateStatus(0, "commitSha", null));
        }

        [Fact]
        public void UpdateStatus_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new CommitRepository(_requestFactory);

            sut.UpdateStatus(expected, "commitSha", "state");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public void UpdateStatus_ValidParameters_AddsCommitShaUrlSegment()
        {
            const string expected = "commitSha";
            var sut = new CommitRepository(_requestFactory);

            sut.UpdateStatus(0, expected, "state");

            _request.Received().AddUrlSegment("commitSha", expected);
        }

        [Fact]
        public void UpdateStatus_ValidParameters_AddsStateParameter()
        {
            const string expected = "state";
            var sut = new CommitRepository(_requestFactory);

            sut.UpdateStatus(0, "commitSha", expected);

            _request.Received().AddParameter("state", expected);
        }

        [Fact]
        public void UpdateStatus_RefNameIsSet_AddsRefNameParameter()
        {
            const string expected = "refName";
            var sut = new CommitRepository(_requestFactory);

            sut.UpdateStatus(0, "commitSha", "state", refName: expected);

            _request.Received().AddParameterIfNotNull("ref", expected);
        }

        [Fact]
        public void UpdateStatus_NameIsSet_AddsNameParameter()
        {
            const string expected = "name";
            var sut = new CommitRepository(_requestFactory);

            sut.UpdateStatus(0, "commitSha", "state", name: expected);

            _request.Received().AddParameterIfNotNull("name", expected);
        }

        [Fact]
        public void UpdateStatus_TargetUrlIsSet_AddsTargetUrlParameter()
        {
            const string expected = "targetUrl";
            var sut = new CommitRepository(_requestFactory);

            sut.UpdateStatus(0, "commitSha", "state", targetUrl: expected);

            _request.Received().AddParameterIfNotNull("target_url", expected);
        }

        [Fact]
        public void UpdateStatus_DescriptionIsSet_AddsDescriptionParameter()
        {
            const string expected = "description";
            var sut = new CommitRepository(_requestFactory);

            sut.UpdateStatus(0, "commitSha", "state", description: expected);

            _request.Received().AddParameterIfNotNull("description", expected);
        }

        [Fact]
        public void UpdateStatus_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new CommitRepository(_requestFactory);

            sut.UpdateStatus(0, "commitSha", "state");

            _requestFactory.Received().Create("projects/{projectId}/statuses/{commitSha}", Method.Post);
        }

        [Fact]
        public async Task UpdateStatusAsync_CommitShaIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.UpdateStatusAsync(0, null, "state"));
        }

        [Fact]
        public async Task UpdateStatusAsync_StateIsNull_ThrowsArgumentNullException()
        {
            var sut = new CommitRepository(_requestFactory);

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.UpdateStatusAsync(0, "commitSha", null));
        }

        [Fact]
        public async Task UpdateStatusAsync_ValidParameters_AddsProjectIdUrlSegment()
        {
            const uint expected = 0;
            var sut = new CommitRepository(_requestFactory);

            await sut.UpdateStatusAsync(expected, "commitSha", "state");

            _request.Received().AddUrlSegment("projectId", expected);
        }

        [Fact]
        public async Task UpdateStatusAsync_ValidParameters_AddsCommitShaUrlSegment()
        {
            const string expected = "commitSha";
            var sut = new CommitRepository(_requestFactory);

            await sut.UpdateStatusAsync(0, expected, "state");

            _request.Received().AddUrlSegment("commitSha", expected);
        }

        [Fact]
        public async Task UpdateStatusAsync_ValidParameters_AddsStateParameter()
        {
            const string expected = "state";
            var sut = new CommitRepository(_requestFactory);

            await sut.UpdateStatusAsync(0, "commitSha", expected);

            _request.Received().AddParameter("state", expected);
        }

        [Fact]
        public async Task UpdateStatusAsync_RefNameIsSet_AddsRefNameParameter()
        {
            const string expected = "refName";
            var sut = new CommitRepository(_requestFactory);

            await sut.UpdateStatusAsync(0, "commitSha", "state", refName: expected);

            _request.Received().AddParameterIfNotNull("ref", expected);
        }

        [Fact]
        public async Task UpdateStatusAsync_NameIsSet_AddsNameParameter()
        {
            const string expected = "name";
            var sut = new CommitRepository(_requestFactory);

            await sut.UpdateStatusAsync(0, "commitSha", "state", name: expected);

            _request.Received().AddParameterIfNotNull("name", expected);
        }

        [Fact]
        public async Task UpdateStatusAsync_TargetUrlIsSet_AddsTargetUrlParameter()
        {
            const string expected = "targetUrl";
            var sut = new CommitRepository(_requestFactory);

            await sut.UpdateStatusAsync(0, "commitSha", "state", targetUrl: expected);

            _request.Received().AddParameterIfNotNull("target_url", expected);
        }

        [Fact]
        public async Task UpdateStatusAsync_DescriptionIsSet_AddsDescriptionParameter()
        {
            const string expected = "description";
            var sut = new CommitRepository(_requestFactory);

            await sut.UpdateStatusAsync(0, "commitSha", "state", description: expected);

            _request.Received().AddParameterIfNotNull("description", expected);
        }

        [Fact]
        public async Task UpdateStatusAsync_ValidParameters_SetsCorrectResourceAndMethod()
        {
            var sut = new CommitRepository(_requestFactory);

            await sut.UpdateStatusAsync(0, "commitSha", "state");

            _requestFactory.Received().Create("projects/{projectId}/statuses/{commitSha}", Method.Post);
        }
        #endregion
    }
}
