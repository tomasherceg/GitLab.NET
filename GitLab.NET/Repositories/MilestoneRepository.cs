using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    /// <summary> Provides GitLab Milestone access in a repository pattern. </summary>
    public class MilestoneRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="MilestoneRepository" /> instance. </summary>
        /// <param name="requestFactory"> An instance of <see cref="IRequestFactory" /> to use for this repository. </param>
        public MilestoneRepository(IRequestFactory requestFactory) : base(requestFactory) { }

        /// <summary> Creates a milestone. </summary>
        /// <param name="projectId"> The ID of the project to attach the milestone to. </param>
        /// <param name="title"> The title for the milestone. </param>
        /// <param name="description"> The description for the milestone. </param>
        /// <param name="dueDate"> The due date for the milestone. </param>
        /// <returns> A <see cref="RequestResult{Milestone}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Milestone>> Create(uint projectId, string title, string description = null, DateTime? dueDate = null)
        {
            if (title == null)
                throw new ArgumentNullException(nameof(title));

            var request = RequestFactory.Create("projects/{projectId}/milestones", Method.Post);

            request.AddUrlSegment("projectId", projectId);
            request.AddParameter("title", title);
            request.AddParameterIfNotNull("description", description);
            request.AddParameterIfNotNull("due_date", dueDate);

            return await request.ExecuteAsync<Milestone>();
        }

        /// <summary> Finds a milestone by its ID. </summary>
        /// <param name="projectId"> The ID of the project the milestone is attached to. </param>
        /// <param name="milestoneId"> The ID of the milestone. </param>
        /// <returns> A <see cref="RequestResult{Milestone}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Milestone>> Find(uint projectId, uint milestoneId)
        {
            var request = RequestFactory.Create("projects/{projectId}/milestones/{milestoneId}", Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("milestoneId", milestoneId);

            return await request.ExecuteAsync<Milestone>();
        }

        /// <summary> Gets all milestones attached to the specified project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="state"> The state to limit results to (active/closed) </param>
        /// <param name="page"> The page number for a paginated request. </param>
        /// <param name="resultsPerPage"> The number of results to return per request. </param>
        /// <returns> A <see cref="PaginatedResult{Milestone}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<Milestone>> GetAll(uint projectId, string state = null, uint page = Config.DefaultPage, uint resultsPerPage = Config.DefaultResultsPerPage)
        {
            if (page < Config.DefaultPage)
                throw new ArgumentOutOfRangeException(nameof(page), page, "The parameter 'page' must be greater than " + Config.DefaultPage + ".");

            if (resultsPerPage < Config.MinResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage, "The parameter 'resultsPerPage' must be greater than " + Config.MinResultsPerPage + ".");

            if (resultsPerPage > Config.MaxResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage, "The parameter 'resultsPerPage' must be less than " + Config.MaxResultsPerPage + ".");

            var request = RequestFactory.Create("projects/{projectId}/milestones", Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddParameterIfNotNull("state", state);
            request.AddParameter("page", page);
            request.AddParameter("per_page", resultsPerPage);

            return await request.ExecutePaginatedAsync<Milestone>();
        }

        /// <summary> Gets all issues attached to the specified milestone. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="milestoneId"> The ID of the milestone. </param>
        /// <param name="page"> The page number for a paginated request. </param>
        /// <param name="resultsPerPage"> The number of results to return per request. </param>
        /// <returns> A <see cref="PaginatedResult{Issue}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<Issue>> GetIssues(uint projectId, uint milestoneId, uint page = Config.DefaultPage, uint resultsPerPage = Config.DefaultResultsPerPage)
        {
            if (page < Config.DefaultPage)
                throw new ArgumentOutOfRangeException(nameof(page), page, "The parameter 'page' must be greater than " + Config.DefaultPage + ".");

            if (resultsPerPage < Config.MinResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage, "The parameter 'resultsPerPage' must be greater than " + Config.MinResultsPerPage + ".");

            if (resultsPerPage > Config.MaxResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage, "The parameter 'resultsPerPage' must be less than " + Config.MaxResultsPerPage + ".");

            var request = RequestFactory.Create("projects/{projectId}/milestones/{milestoneId}/issues", Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("milestoneId", milestoneId);
            request.AddParameter("page", page);
            request.AddParameter("per_page", resultsPerPage);

            return await request.ExecutePaginatedAsync<Issue>();
        }

        /// <summary> Updates a milestone. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="milestoneId"> The ID of the milestone. </param>
        /// <param name="title"> The new title for the milestone. </param>
        /// <param name="description"> The new description for the milestone. </param>
        /// <param name="dueDate"> The new due date for the milestone. </param>
        /// <param name="state"> The new state for the milestone (close/activate). </param>
        /// <returns> A <see cref="RequestResult{Milestone}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Milestone>> Update(uint projectId, uint milestoneId, string title = null, string description = null, DateTime? dueDate = null, string state = null)
        {
            var request = RequestFactory.Create("projects/{projectId}/milestones/{milestoneId}", Method.Put);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("milestoneId", milestoneId);
            request.AddParameterIfNotNull("title", title);
            request.AddParameterIfNotNull("description", description);
            request.AddParameterIfNotNull("due_date", dueDate);
            request.AddParameterIfNotNull("state_event", state);

            return await request.ExecuteAsync<Milestone>();
        }
    }
}