using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    /// <summary> Provides GitLab Issue access in a repository pattern. </summary>
    public class IssueRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="IssueRepository" /> instance. </summary>
        /// <param name="requestFactory"> An instance of <see cref="IRequestFactory" /> to use for this repository. </param>
        public IssueRepository(IRequestFactory requestFactory) : base(requestFactory) { }

        /// <summary> Creates a new issue. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="title"> The title for the issue. </param>
        /// <param name="description"> The description for the issue. </param>
        /// <param name="assigneeId"> The ID of the user to assign this issue to. </param>
        /// <param name="milestoneId"> The ID of the milestone to assign this issue to. </param>
        /// <param name="labels"> The labels to assign to this issue. </param>
        /// <param name="createdAt"> The date and time this issue was created at. </param>
        /// <returns> A <see cref="RequestResult{Issue}" /> representing the results of this request. </returns>
        public async Task<RequestResult<Issue>> Create(uint projectId,
                                                       string title,
                                                       string description = null,
                                                       uint? assigneeId = null,
                                                       uint? milestoneId = null,
                                                       string[] labels = null,
                                                       DateTime? createdAt = null)
        {
            if (title == null)
                throw new ArgumentNullException(nameof(title));

            var request = RequestFactory.Create("projects/{projectId}/issues", Method.Post);

            request.AddUrlSegment("projectId", projectId);
            request.AddParameter("title", title);
            request.AddParameterIfNotNull("description", description);
            request.AddParameterIfNotNull("assignee_id", assigneeId);
            request.AddParameterIfNotNull("milestone_id", milestoneId);
            request.AddParameterIfNotNull("labels", ArrayToCommaSeparated(labels));
            request.AddParameterIfNotNull("created_at", createdAt);

            return await request.ExecuteAsync<Issue>();
        }

        /// <summary> Deletes an issue. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="issueId"> The ID of the issue. </param>
        /// <returns> A <see cref="RequestResult{Issue}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Issue>> Delete(uint projectId, uint issueId)
        {
            var request = RequestFactory.Create("projects/{projectId}/issues/{issueId}", Method.Delete);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("issueId", issueId);

            return await request.ExecuteAsync<Issue>();
        }

        /// <summary> Gets an issue by its ID. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="issueId"> The ID of the issue. </param>
        /// <returns> A <see cref="RequestResult{Issue}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Issue>> Find(uint projectId, uint issueId)
        {
            var request = RequestFactory.Create("projects/{projectId}/issues/{issueId}", Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("issueId", issueId);

            return await request.ExecuteAsync<Issue>();
        }

        /// <summary> Gets all issues for the specified project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="state"> Limit the results to the specified state. (opened/closed) </param>
        /// <param name="labels"> Limit the results to only issues with the specified labels. </param>
        /// <param name="milestone"> Limit the results to only issues for the specified milestone. </param>
        /// <param name="orderBy"> Order the results by created_at or updated_at. Default is created_at. </param>
        /// <param name="sort"> Sort results in ascending or descending order. (asc/desc) </param>
        /// <returns> A <see cref="PaginatedResult{Issue}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<Issue>> GetByProject(uint projectId, IssueState? state = null, string[] labels = null, string milestone = null, string orderBy = null, string sort = null)
        {
            var stateValue = state != null ? Enum.GetName(typeof(IssueState), state)?.ToLower() : null;

            var request = RequestFactory.Create("projects/{projectId}/issues", Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddParameterIfNotNull("state", stateValue);
            request.AddParameterIfNotNull("labels", ArrayToCommaSeparated(labels));
            request.AddParameterIfNotNull("milestone", milestone);
            request.AddParameterIfNotNull("order_by", orderBy);
            request.AddParameterIfNotNull("sort", sort);

            return await request.ExecutePaginatedAsync<Issue>();
        }

        /// <summary> Gets all issues created by the currently authenticated user. </summary>
        /// <param name="state"> Limit the results to the specified state. (opened/closed) </param>
        /// <param name="labels"> Limit the results to only issues with specified labels. </param>
        /// <param name="orderBy"> Order the results by created_at or updated_at. Default is created_at. </param>
        /// <param name="sort"> Sort results in ascending or descending order. (asc/desc) </param>
        /// <returns> A <see cref="PaginatedResult{Issue}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<Issue>> GetOwned(IssueState? state = null, string[] labels = null, IssueOrderBy? orderBy = null, SortOrder? sort = null)
        {
            var stateValue = state != null ? Enum.GetName(typeof(IssueState), state)?.ToLower() : null;
            var orderByValue = orderBy != null ? Enum.GetName(typeof(IssueOrderBy), orderBy)?.ToLower() : null;
            var sortValue = sort != null ? Enum.GetName(typeof(SortOrder), sort)?.ToLower() : null;

            var request = RequestFactory.Create("issues", Method.Get);

            request.AddParameterIfNotNull("state", stateValue);
            request.AddParameterIfNotNull("labels", ArrayToCommaSeparated(labels));
            request.AddParameterIfNotNull("order_by", orderByValue);
            request.AddParameterIfNotNull("sort", sortValue);

            return await request.ExecutePaginatedAsync<Issue>();
        }

        /// <summary> Moves an issue to a new project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="issueId"> The ID of the issue. </param>
        /// <param name="newProjectId"> The ID of the project to move the issue to. </param>
        /// <returns> A <see cref="RequestResult{Issue}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Issue>> Move(uint projectId, uint issueId, uint newProjectId)
        {
            var request = RequestFactory.Create("projects/{projectId}/issues/{issueId}/move", Method.Post);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("issueId", issueId);
            request.AddParameter("to_project_id", newProjectId);

            return await request.ExecuteAsync<Issue>();
        }

        /// <summary> Subscribes to an issue. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="issueId"> The ID of the issue. </param>
        /// <returns> A <see cref="RequestResult{Issue}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Issue>> Subscribe(uint projectId, uint issueId)
        {
            var request = RequestFactory.Create("projects/{projectId}/issues/{issueId}/subscription", Method.Post);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("issueId", issueId);

            return await request.ExecuteAsync<Issue>();
        }

        /// <summary> Unsubscribes from an issue. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="issueId"> The ID of the issue. </param>
        /// <returns> A <see cref="RequestResult{Issue}" /> representing the resultse of the request. </returns>
        public async Task<RequestResult<Issue>> Unsubscribe(uint projectId, uint issueId)
        {
            var request = RequestFactory.Create("projects/{projectId}/issues/{issueId}/subscription", Method.Delete);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("issueId", issueId);

            return await request.ExecuteAsync<Issue>();
        }

        /// <summary> updates an issue. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="issueId"> The ID of the issue. </param>
        /// <param name="title"> The new title for the issue. </param>
        /// <param name="description"> The new description for this issue. </param>
        /// <param name="assigneeId"> The ID of the user to assign this issue to. </param>
        /// <param name="milestoneId"> The ID of the milestone to assign this issue to. </param>
        /// <param name="labels"> The labels for this issue. </param>
        /// <param name="state"> The state event to update this issue with. (close/reopen) </param>
        /// <param name="updatedAt"> The date and time this issue was updated at. </param>
        /// <returns> A <see cref="RequestResult{Issue}" /> representing the results of this request. </returns>
        public async Task<RequestResult<Issue>> Update(uint projectId,
                                                       uint issueId,
                                                       string title = null,
                                                       string description = null,
                                                       uint? assigneeId = null,
                                                       uint? milestoneId = null,
                                                       string[] labels = null,
                                                       IssueStateEvent? state = null,
                                                       DateTime? updatedAt = null)
        {
            var stateValue = state != null ? Enum.GetName(typeof(IssueStateEvent), state)?.ToLower() : null;

            var request = RequestFactory.Create("projects/{projectId}/issues/{issueId}", Method.Put);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("issueId", issueId);
            request.AddParameterIfNotNull("title", title);
            request.AddParameterIfNotNull("description", description);
            request.AddParameterIfNotNull("assignee_id", assigneeId);
            request.AddParameterIfNotNull("milestone_id", milestoneId);
            request.AddParameterIfNotNull("labels", ArrayToCommaSeparated(labels));
            request.AddParameterIfNotNull("state_event", stateValue);
            request.AddParameterIfNotNull("updated_at", updatedAt);

            return await request.ExecuteAsync<Issue>();
        }

        private static string ArrayToCommaSeparated(string[] input)
        {
            if (input == null || input.Length <= 0)
                return null;

            var result = input[0];

            for (var i = 1; i < input.Length; i++)
                result += "," + input[i];

            return result;
        }
    }
}
