using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.RequestModels;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    /// <summary> Provides GitLab Commit access in a repository pattern. </summary>
    public class CommitRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="CommitRepository" /> instance. </summary>
        /// <param name="requestFactory"> An instance of <see cref="IRequestFactory" /> to use for this repository. </param>
        public CommitRepository(IRequestFactory requestFactory) : base(requestFactory) { }

        /// <summary> Creates a new commit comment. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="commitSha"> The commit sha or branch or tag name. </param>
        /// <param name="note"> The text for the comment. </param>
        /// <param name="path"> The file path to associate this comment with. </param>
        /// <param name="line"> The line to associate this comment with. </param>
        /// <param name="lineType"> The line type for this comment. </param>
        /// <returns> A <see cref="RequestResult{CommitComment}" /> representing the results of the request. </returns>
        public RequestResult<CommitComment> CreateComment(uint projectId, string commitSha, string note, string path = null, uint? line = null, string lineType = null)
        {
            if (commitSha == null)
                throw new ArgumentNullException(nameof(commitSha));

            if (note == null)
                throw new ArgumentNullException(nameof(note));

            var request = new CreateCommitCommentRequest(projectId, commitSha, note, path, line, lineType);

            var result = RequestExecutor.Execute<CommitComment>(request);

            return new RequestResult<CommitComment>(result);
        }

        /// <summary> Creates a new commit comment. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="commitSha"> The commit sha or branch or tag name. </param>
        /// <param name="note"> The text for the comment. </param>
        /// <param name="path"> The file path to associate this comment with. </param>
        /// <param name="line"> The line to associate this comment with. </param>
        /// <param name="lineType"> The line type for this comment. </param>
        /// <returns> A <see cref="RequestResult{CommitComment}" /> representing the results of the request. </returns>
        public async Task<RequestResult<CommitComment>> CreateCommentAsync(uint projectId, string commitSha, string note, string path = null, uint? line = null, string lineType = null)
        {
            if (commitSha == null)
                throw new ArgumentNullException(nameof(commitSha));

            if (note == null)
                throw new ArgumentNullException(nameof(note));

            var request = new CreateCommitCommentRequest(projectId, commitSha, note, path, line, lineType);

            var result = await RequestExecutor.ExecuteAsync<CommitComment>(request);

            return new RequestResult<CommitComment>(result);
        }

        /// <summary> Creates a status for a commit. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="commitSha"> The commit SHA. </param>
        /// <param name="state"> The state for the new status. </param>
        /// <param name="refName"> The branch or tag name to associate this status with. </param>
        /// <param name="name"> The name of the build. </param>
        /// <param name="targetUrl"> The target URL for the build. </param>
        /// <param name="description"> The description for the build status. </param>
        /// <returns> A <see cref="RequestResult{CommitStatus}" /> representing the results of the request. </returns>
        public RequestResult<CommitStatus> CreateStatus(uint projectId, string commitSha, string state, string refName = null, string name = null, string targetUrl = null, string description = null)
        {
            if (commitSha == null)
                throw new ArgumentNullException(nameof(commitSha));

            if (state == null)
                throw new ArgumentNullException(nameof(state));

            var request = new CreateCommitStatusRequest(projectId, commitSha, state, refName, name, targetUrl, description);

            var result = RequestExecutor.Execute<CommitStatus>(request);

            return new RequestResult<CommitStatus>(result);
        }

        /// <summary> Creates a status for a commit. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="commitSha"> The commit SHA. </param>
        /// <param name="state"> The state for the new status. </param>
        /// <param name="refName"> The branch or tag name to associate this status with. </param>
        /// <param name="name"> The name of the build. </param>
        /// <param name="targetUrl"> The target URL for the build. </param>
        /// <param name="description"> The description for the build status. </param>
        /// <returns> A <see cref="RequestResult{CommitStatus}" /> representing the results of the request. </returns>
        public async Task<RequestResult<CommitStatus>> CreateStatusAsync(uint projectId,
                                                                         string commitSha,
                                                                         string state,
                                                                         string refName = null,
                                                                         string name = null,
                                                                         string targetUrl = null,
                                                                         string description = null)
        {
            if (commitSha == null)
                throw new ArgumentNullException(nameof(commitSha));

            if (state == null)
                throw new ArgumentNullException(nameof(state));

            var request = new CreateCommitStatusRequest(projectId, commitSha, state, refName, name, targetUrl, description);

            var result = await RequestExecutor.ExecuteAsync<CommitStatus>(request);

            return new RequestResult<CommitStatus>(result);
        }

        /// <summary> Gets all commits for the specified project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="refName"> The branch or tag name to limit the results to. </param>
        /// <param name="since"> The maximum date and time to return results from. </param>
        /// <param name="until"> The maximum date and time to return results to. </param>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{Commit}" /> representing the results of the
        ///     request.
        /// </returns>
        public RequestResult<List<Commit>> GetAll(uint projectId, string refName = null, DateTime? since = null, DateTime? until = null)
        {
            var request = new GetCommitsRequest(projectId, refName, since, until);

            var result = RequestExecutor.Execute<List<Commit>>(request);

            return new RequestResult<List<Commit>>(result);
        }

        /// <summary> Gets all commits for the specified project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="refName"> The branch or tag name to limit the results to. </param>
        /// <param name="since"> The maximum date and time to return results from. </param>
        /// <param name="until"> The maximum date and time to return results to. </param>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{Commit}" /> representing the results of the
        ///     request.
        /// </returns>
        public async Task<RequestResult<List<Commit>>> GetAllAsync(uint projectId, string refName = null, DateTime? since = null, DateTime? until = null)
        {
            var request = new GetCommitsRequest(projectId, refName, since, until);

            var result = await RequestExecutor.ExecuteAsync<List<Commit>>(request);

            return new RequestResult<List<Commit>>(result);
        }

        /// <summary> Gets a commit by its SHA. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="commitSha"> The SHA of the desired commit. </param>
        /// <returns> A <see cref="RequestResult{Commit}" /> representing the results of the request. </returns>
        public RequestResult<Commit> GetBySha(uint projectId, string commitSha)
        {
            if (commitSha == null)
                throw new ArgumentNullException(nameof(commitSha));

            var request = new GetCommitRequest(projectId, commitSha);

            var result = RequestExecutor.Execute<Commit>(request);

            return new RequestResult<Commit>(result);
        }

        /// <summary> Gets a commit by its SHA. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="commitSha"> The SHA of the desired commit. </param>
        /// <returns> A <see cref="RequestResult{Commit}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Commit>> GetByShaAsync(uint projectId, string commitSha)
        {
            if (commitSha == null)
                throw new ArgumentNullException(nameof(commitSha));

            var request = new GetCommitRequest(projectId, commitSha);

            var result = await RequestExecutor.ExecuteAsync<Commit>(request);

            return new RequestResult<Commit>(result);
        }

        /// <summary> Gets the comments for a commit. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="commitSha"> The commit sha or branch or tag name. </param>
        /// <returns> A <see cref="PaginatedResult{CommitComment}" /> representing the results of the request. </returns>
        public PaginatedResult<CommitComment> GetComments(uint projectId, string commitSha)
        {
            if (commitSha == null)
                throw new ArgumentNullException(nameof(commitSha));

            var request = new GetCommitCommentsRequest(projectId, commitSha);

            var result = RequestExecutor.Execute<List<CommitComment>>(request);

            return new PaginatedResult<CommitComment>(result);
        }

        /// <summary> Gets the comments for a commit. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="commitSha"> The commit sha or branch or tag name. </param>
        /// <returns> A <see cref="PaginatedResult{CommitComment}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<CommitComment>> GetCommentsAsync(uint projectId, string commitSha)
        {
            if (commitSha == null)
                throw new ArgumentNullException(nameof(commitSha));

            var request = new GetCommitCommentsRequest(projectId, commitSha);

            var result = await RequestExecutor.ExecuteAsync<List<CommitComment>>(request);

            return new PaginatedResult<CommitComment>(result);
        }

        /// <summary> Gets a commit diff. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="commitSha"> The SHA of the commit to get the diff for. </param>
        /// <returns> A <see cref="RequestResult{CommitDiff}" /> representing the results of the request. </returns>
        public RequestResult<CommitDiff> GetDiff(uint projectId, string commitSha)
        {
            if (commitSha == null)
                throw new ArgumentNullException(nameof(commitSha));

            var request = new GetCommitDiffRequest(projectId, commitSha);

            var result = RequestExecutor.Execute<CommitDiff>(request);

            return new RequestResult<CommitDiff>(result);
        }

        /// <summary> Gets a commit diff. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="commitSha"> The SHA of the commit to get the diff for. </param>
        /// <returns> A <see cref="RequestResult{CommitDiff}" /> representing the results of the request. </returns>
        public async Task<RequestResult<CommitDiff>> GetDiffAsync(uint projectId, string commitSha)
        {
            if (commitSha == null)
                throw new ArgumentNullException(nameof(commitSha));

            var request = new GetCommitDiffRequest(projectId, commitSha);

            var result = await RequestExecutor.ExecuteAsync<CommitDiff>(request);

            return new RequestResult<CommitDiff>(result);
        }

        /// <summary> Gets the status for a commit. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="commitSha"> The commit sha. </param>
        /// <param name="refName"> The branch or tag name. </param>
        /// <param name="stage"> </param>
        /// <param name="name"> </param>
        /// <param name="all"> </param>
        /// <returns> </returns>
        public PaginatedResult<CommitStatus> GetStatus(uint projectId, string commitSha, string refName = null, string stage = null, string name = null, bool? all = null)
        {
            if (commitSha == null)
                throw new ArgumentNullException(nameof(commitSha));

            var request = new GetCommitStatusRequest(projectId, commitSha, refName, stage, name, all);

            var result = RequestExecutor.Execute<List<CommitStatus>>(request);

            return new PaginatedResult<CommitStatus>(result);
        }

        /// <summary> Gets the status for a commit. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="commitSha"> The commit sha. </param>
        /// <param name="refName"> The branch or tag name. </param>
        /// <param name="stage"> </param>
        /// <param name="name"> </param>
        /// <param name="all"> </param>
        /// <returns> </returns>
        public async Task<PaginatedResult<CommitStatus>> GetStatusAsync(uint projectId, string commitSha, string refName = null, string stage = null, string name = null, bool? all = null)
        {
            if (commitSha == null)
                throw new ArgumentNullException(nameof(commitSha));

            var request = new GetCommitStatusRequest(projectId, commitSha, refName, stage, name, all);

            var result = await RequestExecutor.ExecuteAsync<List<CommitStatus>>(request);

            return new PaginatedResult<CommitStatus>(result);
        }

        /// <summary> Updates the status for a commit. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="commitSha"> The commit SHA. </param>
        /// <param name="state"> The state for the new status. </param>
        /// <param name="refName"> The branch or tag name to associate this status with. </param>
        /// <param name="name"> The name of the build. </param>
        /// <param name="targetUrl"> The target URL for the build. </param>
        /// <param name="description"> The description for the build status. </param>
        /// <returns> A <see cref="RequestResult{CommitStatus}" /> representing the results of the request. </returns>
        public RequestResult<CommitStatus> UpdateStatus(uint projectId, string commitSha, string state, string refName = null, string name = null, string targetUrl = null, string description = null)
        {
            if (commitSha == null)
                throw new ArgumentNullException(nameof(commitSha));

            if (state == null)
                throw new ArgumentNullException(nameof(state));

            return CreateStatus(projectId, commitSha, state, refName, name, targetUrl, description);
        }

        /// <summary> Updates the status for a commit. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="commitSha"> The commit SHA. </param>
        /// <param name="state"> The state for the new status. </param>
        /// <param name="refName"> The branch or tag name to associate this status with. </param>
        /// <param name="name"> The name of the build. </param>
        /// <param name="targetUrl"> The target URL for the build. </param>
        /// <param name="description"> The description for the build status. </param>
        /// <returns> A <see cref="RequestResult{CommitStatus}" /> representing the results of the request. </returns>
        public async Task<RequestResult<CommitStatus>> UpdateStatusAsync(uint projectId,
                                                                         string commitSha,
                                                                         string state,
                                                                         string refName = null,
                                                                         string name = null,
                                                                         string targetUrl = null,
                                                                         string description = null)
        {
            if (commitSha == null)
                throw new ArgumentNullException(nameof(commitSha));

            if (state == null)
                throw new ArgumentNullException(nameof(state));

            return await CreateStatusAsync(projectId, commitSha, state, refName, name, targetUrl, description);
        }
    }
}