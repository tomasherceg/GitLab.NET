using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    /// <summary> Provides GitLab Commit access in a repository pattern. </summary>
    public class CommitRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="CommitRepository" /> instance. </summary>
        /// <param name="requestFactory"> An instance of <see cref="IRequestFactory" /> to use for this repository. </param>
        public CommitRepository(IRequestFactory requestFactory) : base(requestFactory)
        {
        }

        /// <summary> Creates a new commit comment. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="commitSha"> The commit sha or branch or tag name. </param>
        /// <param name="note"> The text for the comment. </param>
        /// <param name="path"> The file path to associate this comment with. </param>
        /// <param name="line"> The line to associate this comment with. </param>
        /// <param name="lineType"> The line type for this comment. </param>
        /// <returns> A <see cref="RequestResult{CommitComment}" /> representing the results of the request. </returns>
        public async Task<RequestResult<CommitComment>> CreateComment(uint projectId, string commitSha, string note,
            string path = null, uint? line = null, LineType? lineType = null)
        {
            if (commitSha == null)
                throw new ArgumentNullException(nameof(commitSha));

            if (note == null)
                throw new ArgumentNullException(nameof(note));

            var request = RequestFactory.Create("projects/{projectId}/repository/commits/{commitSha}/comments",
                Method.Post);

            var lineTypeValue = lineType != null ? Enum.GetName(typeof(LineType), lineType)?.ToLower() : null;

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("commitSha", commitSha);
            request.AddParameter("note", note);
            request.AddParameterIfNotNull("path", path);
            request.AddParameterIfNotNull("line", line);
            request.AddParameterIfNotNull("line_type", lineTypeValue);

            return await request.Execute<CommitComment>();
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
        public async Task<RequestResult<CommitStatus>> CreateStatus(uint projectId,
            string commitSha,
            BuildStatus state,
            string refName = null,
            string name = null,
            string targetUrl = null,
            string description = null)
        {
            if (commitSha == null)
                throw new ArgumentNullException(nameof(commitSha));

            var request = RequestFactory.Create("projects/{projectId}/statuses/{commitSha}", Method.Post);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("commitSha", commitSha);
            request.AddParameter("state", Enum.GetName(typeof(BuildStatus), state)?.ToLower());
            request.AddParameterIfNotNull("ref", refName);
            request.AddParameterIfNotNull("name", name);
            request.AddParameterIfNotNull("target_url", targetUrl);
            request.AddParameterIfNotNull("description", description);

            return await request.Execute<CommitStatus>();
        }

        /// <summary> Gets a commit by its SHA. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="commitSha"> The SHA of the desired commit. </param>
        /// <returns> A <see cref="RequestResult{Commit}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Commit>> Find(uint projectId, string commitSha)
        {
            if (commitSha == null)
                throw new ArgumentNullException(nameof(commitSha));

            var request = RequestFactory.Create("projects/{projectId}/repository/commits/{commitSha}", Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("commitSha", commitSha);

            return await request.Execute<Commit>();
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
        public async Task<RequestResult<List<Commit>>> GetAll(uint projectId, string refName = null,
            DateTime? since = null, DateTime? until = null)
        {
            var request = RequestFactory.Create("projects/{projectId}/repository/commits", Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddParameterIfNotNull("ref_name", refName);
            request.AddParameterIfNotNull("since", since);
            request.AddParameterIfNotNull("until", until);

            return await request.Execute<List<Commit>>();
        }

        /// <summary> Gets the comments for a commit. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="commitSha"> The commit sha or branch or tag name. </param>
        /// <param name="page"> The page number for a paginated request. </param>
        /// <param name="resultsPerPage"> The number of results to return per request. </param>
        /// <returns> A <see cref="PaginatedResult{CommitComment}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<CommitComment>> GetComments(uint projectId, string commitSha,
            uint page = Config.DefaultPage, uint resultsPerPage = Config.DefaultResultsPerPage)
        {
            if (commitSha == null)
                throw new ArgumentNullException(nameof(commitSha));

            if (page < Config.DefaultPage)
                throw new ArgumentOutOfRangeException(nameof(page), page,
                    "The parameter 'page' must be greater than " + Config.DefaultPage + ".");

            if (resultsPerPage < Config.MinResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage,
                    "The parameter 'resultsPerPage' must be greater than " + Config.MinResultsPerPage + ".");

            if (resultsPerPage > Config.MaxResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage,
                    "The parameter 'resultsPerPage' must be less than " + Config.MaxResultsPerPage + ".");

            var request = RequestFactory.Create("projects/{projectId}/repository/commits/{commitSha}/comments",
                Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("commitSha", commitSha);
            request.AddParameter("page", page);
            request.AddParameter("per_page", resultsPerPage);

            return await request.ExecutePaginated<CommitComment>();
        }

        /// <summary> Gets a commit diff. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="commitSha"> The SHA of the commit to get the diff for. </param>
        /// <returns> A <see cref="RequestResult{CommitDiff}" /> representing the results of the request. </returns>
        public async Task<RequestResult<CommitDiff>> GetDiff(uint projectId, string commitSha)
        {
            if (commitSha == null)
                throw new ArgumentNullException(nameof(commitSha));

            var request = RequestFactory.Create("projects/{projectId}/repository/commits/{commitSha}/diff", Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("commitSha", commitSha);

            return await request.Execute<CommitDiff>();
        }

        /// <summary> Gets the status for a commit. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="commitSha"> The commit sha. </param>
        /// <param name="refName"> The branch or tag name. </param>
        /// <param name="stage"> </param>
        /// <param name="name"> </param>
        /// <param name="all"> </param>
        /// <param name="page"> The page number for a paginated request. </param>
        /// <param name="resultsPerPage"> The number of results to return per request. </param>
        /// <returns> </returns>
        public async Task<PaginatedResult<CommitStatus>> GetStatus(uint projectId,
            string commitSha,
            string refName = null,
            string stage = null,
            string name = null,
            bool? all = null,
            uint page = Config.DefaultPage,
            uint resultsPerPage = Config.DefaultResultsPerPage)
        {
            if (commitSha == null)
                throw new ArgumentNullException(nameof(commitSha));

            if (page < Config.DefaultPage)
                throw new ArgumentOutOfRangeException(nameof(page), page,
                    "The parameter 'page' must be greater than " + Config.DefaultPage + ".");

            if (resultsPerPage < Config.MinResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage,
                    "The parameter 'resultsPerPage' must be greater than " + Config.MinResultsPerPage + ".");

            if (resultsPerPage > Config.MaxResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage,
                    "The parameter 'resultsPerPage' must be less than " + Config.MaxResultsPerPage + ".");

            var request = RequestFactory.Create("projects/{projectId}/repository/commits/{commitSha}/statuses",
                Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("commitSha", commitSha);
            request.AddParameter("page", page);
            request.AddParameter("per_page", resultsPerPage);
            request.AddParameterIfNotNull("ref_name", refName);
            request.AddParameterIfNotNull("stage", stage);
            request.AddParameterIfNotNull("name", name);
            request.AddParameterIfNotNull("all", all);

            return await request.ExecutePaginated<CommitStatus>();
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
        public async Task<RequestResult<CommitStatus>> UpdateStatus(uint projectId,
            string commitSha,
            BuildStatus state,
            string refName = null,
            string name = null,
            string targetUrl = null,
            string description = null)
        {
            if (commitSha == null)
                throw new ArgumentNullException(nameof(commitSha));

            return await CreateStatus(projectId, commitSha, state, refName, name, targetUrl, description);
        }
    }
}