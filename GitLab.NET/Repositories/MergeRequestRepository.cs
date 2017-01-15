using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Helpers;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    /// <summary> Provides GitLab Merge Request access in a repository pattern. </summary>
    public class MergeRequestRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="MergeRequestRepository" /> instance. </summary>
        /// <param name="requestFactory"> An instance of <see cref="IRequestFactory" /> to use for this repository. </param>
        public MergeRequestRepository(IRequestFactory requestFactory) : base(requestFactory)
        {
        }

        /// <summary> Accepts a merge request. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="mergeRequestId"> The ID of the merge request. </param>
        /// <param name="commitMessage"> The commit message to use for the merge. </param>
        /// <param name="removeSourceBranch"> Whether or not to remove the source branch on merge. </param>
        /// <param name="mergedWhenBuildSucceeds"> Whether or not to merge when the build succeeds. </param>
        /// <returns> A <see cref="RequestResult{MergeRequest}" /> representing the results of the request. </returns>
        public async Task<RequestResult<MergeRequest>> Accept(uint projectId, uint mergeRequestId,
            string commitMessage = null, bool? removeSourceBranch = null, bool? mergedWhenBuildSucceeds = null)
        {
            var request = RequestFactory.Create("projects/{projectId}/merge_requests/{mergeRequestId}/merge", Method.Put);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("mergeRequestId", mergeRequestId);
            request.AddParameterIfNotNull("merge_commit_message", commitMessage);
            request.AddParameterIfNotNull("should_remove_source_branch", removeSourceBranch);
            request.AddParameterIfNotNull("merged_when_build_succeeds", mergedWhenBuildSucceeds);

            return await request.Execute<MergeRequest>();
        }

        /// <summary> Cancels a merge request that is set to merge on build success. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="mergeRequestId"> The ID of the merge request. </param>
        /// <returns> A <see cref="RequestResult{MergeRequest}" /> representing the results of the request. </returns>
        public async Task<RequestResult<MergeRequest>> CancelMergeOnBuildSuccess(uint projectId, uint mergeRequestId)
        {
            var request =
                RequestFactory.Create(
                    "projects/{projectId}/merge_requests/{mergeRequestId}/cancel_merge_when_build_succeeds", Method.Put);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("mergeRequestId", mergeRequestId);

            return await request.Execute<MergeRequest>();
        }

        /// <summary> Creates a new merge request. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="sourceBranch"> The source branch for this merge request. </param>
        /// <param name="targetBranch"> The target branch for this merge request. </param>
        /// <param name="title"> The title for this merge request. </param>
        /// <param name="description"> The description for this merge request. </param>
        /// <param name="assigneeId"> The ID of the user to assign to this merge request. </param>
        /// <param name="targetProjectId"> The ID of the project to merge into. </param>
        /// <param name="labels"> The labels to assign to this merge request. </param>
        /// <param name="milestoneId"> The ID of the milestone to assign to this merge request. </param>
        /// <returns> A <see cref="RequestResult{MergeRequest}" /> representing the results of this request. </returns>
        public async Task<RequestResult<MergeRequest>> Create(uint projectId,
            string sourceBranch,
            string targetBranch,
            string title,
            string description = null,
            uint? assigneeId = null,
            uint? targetProjectId = null,
            string[] labels = null,
            uint? milestoneId = null)
        {
            if (sourceBranch == null)
                throw new ArgumentNullException(nameof(sourceBranch));

            if (targetBranch == null)
                throw new ArgumentNullException(nameof(targetBranch));

            if (title == null)
                throw new ArgumentNullException(nameof(title));

            var request = RequestFactory.Create("projects/{projectId}/merge_requests", Method.Post);

            request.AddUrlSegment("projectId", projectId);
            request.AddParameter("source_branch", sourceBranch);
            request.AddParameter("target_branch", targetBranch);
            request.AddParameter("title", title);
            request.AddParameterIfNotNull("description", description);
            request.AddParameterIfNotNull("assignee_id", assigneeId);
            request.AddParameterIfNotNull("target_project_id", targetProjectId);
            request.AddParameterIfNotNull("labels", labels.ToCommaSeparated());
            request.AddParameterIfNotNull("milestone_id", milestoneId);

            return await request.Execute<MergeRequest>();
        }

        /// <summary> Deletes a merge request. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="mergeRequestId"> The ID of the merge request. </param>
        /// <returns> A <see cref="RequestResult{MergeRequest}" /> representing the results of this request. </returns>
        public async Task<RequestResult<MergeRequest>> Delete(uint projectId, uint mergeRequestId)
        {
            var request = RequestFactory.Create("projects/{projectId}/merge_requests/{mergeRequestId}", Method.Delete);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("mergeRequestId", mergeRequestId);

            return await request.Execute<MergeRequest>();
        }

        /// <summary> Finds a merge request by its ID. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="mergeRequestId"> The ID of the merge request. </param>
        /// <returns> A <see cref="RequestResult{MergeRequest}" /> representing the results of this request. </returns>
        public async Task<RequestResult<MergeRequest>> Find(uint projectId, uint mergeRequestId)
        {
            var request = RequestFactory.Create("projects/{projectId}/merge_requests/{mergeRequestId}", Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("mergeRequestId", mergeRequestId);

            return await request.Execute<MergeRequest>();
        }

        /// <summary> Gets all merge requests associated with the specified project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="state"> The state to limit results to. </param>
        /// <param name="orderBy"> The field to order results by. </param>
        /// <param name="sort"> The sort order to use for sorting. </param>
        /// <param name="page"> The page number for a paginated request. </param>
        /// <param name="resultsPerPage"> The number of results to return per request. </param>
        /// <returns> A <see cref="PaginatedResult{MergeRequest}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<MergeRequest>> GetAll(uint projectId,
            MergeRequestState? state = null,
            OrderBy? orderBy = null,
            SortOrder? sort = null,
            uint? page = Config.DefaultPage,
            uint? resultsPerPage = Config.DefaultResultsPerPage)
        {
            if (page < Config.DefaultPage)
                throw new ArgumentOutOfRangeException(nameof(page), page,
                    "The parameter 'page' must be greater than " + Config.DefaultPage + ".");

            if (resultsPerPage < Config.MinResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage,
                    "The parameter 'resultsPerPage' must be greater than " + Config.MinResultsPerPage + ".");

            if (resultsPerPage > Config.MaxResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage,
                    "The parameter 'resultsPerPage' must be less than " + Config.MaxResultsPerPage + ".");

            var stateValue = state != null ? Enum.GetName(typeof(MergeRequestState), state)?.ToLower() : null;
            var orderByValue = orderBy?.GetDescription();
            var sortValue = sort != null ? Enum.GetName(typeof(SortOrder), sort)?.ToLower() : null;

            var request = RequestFactory.Create("projects/{projectId}/merge_requests", Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddParameterIfNotNull("state", stateValue);
            request.AddParameterIfNotNull("order_by", orderByValue);
            request.AddParameterIfNotNull("sort", sortValue);
            request.AddParameter("page", page);
            request.AddParameter("per_page", resultsPerPage);

            return await request.ExecutePaginated<MergeRequest>();
        }

        /// <summary> Gets all changes that will be applied by the merge request. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="mergeRequestId"> The ID of the merge request. </param>
        /// <returns> A <see cref="RequestResult{MergeRequest}" /> representing the results of this request. </returns>
        public async Task<RequestResult<MergeRequest>> GetChanges(uint projectId, uint mergeRequestId)
        {
            var request = RequestFactory.Create("projects/{projectId}/merge_requests/{mergeRequestId}/changes",
                Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("mergeRequestId", mergeRequestId);

            return await request.Execute<MergeRequest>();
        }

        /// <summary> Gets the commits for the specified merge request. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="mergeRequestId"> The ID of the merge request. </param>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{Commit}" /> representing the results of this
        ///     request.
        /// </returns>
        public async Task<RequestResult<List<Commit>>> GetCommits(uint projectId, uint mergeRequestId)
        {
            var request = RequestFactory.Create("projects/{projectId}/merge_requests/{mergeRequestId}/commits",
                Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("mergeRequestId", mergeRequestId);

            return await request.Execute<List<Commit>>();
        }

        /// <summary> Creates a new comment for merge request. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="mergeRequestId"> The ID of the merge request. </param>
        /// ///
        /// <param name="comment"> The comment content. </param>
        /// <returns> A <see cref="RequestResult{Comment}" /> representing the results of this request. </returns>
        public async Task<RequestResult<Comment>> CreateComment(uint projectId, uint mergeRequestId, string comment)
        {
            var request = RequestFactory.Create("projects/{projectId}/merge_requests/{mergeRequestId}/comments",
                Method.Post);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("mergeRequestId", mergeRequestId);
            request.AddParameter("note", comment);

            return await request.Execute<Comment>();
        }

        /// <summary> Gets all comments of the merge request. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="mergeRequestId"> The ID of the merge request. </param>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{Comment}" /> representing the results of this
        ///     request.
        /// </returns>
        public async Task<RequestResult<List<Comment>>> GetComments(uint projectId, uint mergeRequestId)
        {
            var request = RequestFactory.Create("projects/{projectId}/merge_requests/{mergeRequestId}/comments",
                Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("mergeRequestId", mergeRequestId);

            return await request.Execute<List<Comment>>();
        }

        /// <summary> Gets all issues that will be closed on accepting the merge request. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="mergeRequestId"> The ID of the merge request. </param>
        /// <param name="page"> The page number for a paginated request. </param>
        /// <param name="resultsPerPage"> The number of results to return per request. </param>
        /// <returns> A <see cref="PaginatedResult{Issue}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<Issue>> GetIssuesClosedOnMerge(uint projectId, uint mergeRequestId,
            uint page = Config.DefaultPage, uint resultsPerPage = Config.DefaultResultsPerPage)
        {
            if (page < Config.DefaultPage)
                throw new ArgumentOutOfRangeException(nameof(page), page,
                    "The parameter 'page' must be greater than " + Config.DefaultPage + ".");

            if (resultsPerPage < Config.MinResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage,
                    "The parameter 'resultsPerPage' must be greater than " + Config.MinResultsPerPage + ".");

            if (resultsPerPage > Config.MaxResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage,
                    "The parameter 'resultsPerPage' must be less than " + Config.MaxResultsPerPage + ".");

            var request = RequestFactory.Create("projects/{projectId}/merge_requests/{mergeRequestId}/closes_issues",
                Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("mergeRequestId", mergeRequestId);
            request.AddParameter("page", page);
            request.AddParameter("per_page", resultsPerPage);

            return await request.ExecutePaginated<Issue>();
        }

        /// <summary> Subscribes to a merge request. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="mergeRequestId"> The ID of the merge request. </param>
        /// <returns> </returns>
        public async Task<RequestResult<MergeRequest>> Subscribe(uint projectId, uint mergeRequestId)
        {
            var request = RequestFactory.Create("projects/{projectId}/merge_requests/{mergeRequestId}/subscription",
                Method.Post);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("mergeRequestId", mergeRequestId);

            return await request.Execute<MergeRequest>();
        }

        /// <summary> Unsubscribes from a merge request. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="mergeRequestId"> The ID of the merge request. </param>
        /// <returns> </returns>
        public async Task<RequestResult<MergeRequest>> Unsubscribe(uint projectId, uint mergeRequestId)
        {
            var request = RequestFactory.Create("projects/{projectId}/merge_requests/{mergeRequestId}/subscription",
                Method.Delete);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("mergeRequestId", mergeRequestId);

            return await request.Execute<MergeRequest>();
        }

        /// <summary> Updates a merge request. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="mergeRequestId"> The ID of the merge request. </param>
        /// <param name="targetBranch"> The target branch for this merge request. </param>
        /// <param name="title"> The title for this merge request. </param>
        /// <param name="description"> The description for this merge request. </param>
        /// <param name="assigneeId"> The ID of the user to assign to this merge request. </param>
        /// <param name="milestoneId"> The ID of the milestone to assign to this merge request. </param>
        /// <param name="labels"> The labels to assign to this merge request. </param>
        /// <param name="state"> The state event for this merge request. </param>
        /// <returns> A <see cref="RequestResult{MergeRequest}" /> representing the results of this request. </returns>
        public async Task<RequestResult<MergeRequest>> Update(uint projectId,
            uint mergeRequestId,
            string targetBranch = null,
            string title = null,
            string description = null,
            uint? assigneeId = null,
            uint? milestoneId = null,
            string[] labels = null,
            MergeRequestStateEvent? state = null)
        {
            var stateValue = state != null ? Enum.GetName(typeof(MergeRequestStateEvent), state)?.ToLower() : null;

            var request = RequestFactory.Create("projects/{projectId}/merge_requests/{mergeRequestId}", Method.Put);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("mergeRequestId", mergeRequestId);
            request.AddParameterIfNotNull("target_branch", targetBranch);
            request.AddParameterIfNotNull("title", title);
            request.AddParameterIfNotNull("description", description);
            request.AddParameterIfNotNull("assignee_id", assigneeId);
            request.AddParameterIfNotNull("milestone_id", milestoneId);
            request.AddParameterIfNotNull("labels", labels.ToCommaSeparated());
            request.AddParameterIfNotNull("state", stateValue);

            return await request.Execute<MergeRequest>();
        }
    }
}