using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    /// <summary> Provides GitLab Build Trigger access in a repository pattern. </summary>
    public class BuildTriggerRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="BuildTriggerRepository" /> instance. </summary>
        /// <param name="requestFactory"> An instance of <see cref="IRequestFactory" /> to use for this repository. </param>
        public BuildTriggerRepository(IRequestFactory requestFactory) : base(requestFactory) { }

        /// <summary> Creates a new build trigger associated with the specified project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <returns> A <see cref="RequestResult{BuildTrigger}" /> representing the results of the request. </returns>
        public async Task<RequestResult<BuildTrigger>> Create(uint projectId)
        {
            var request = RequestFactory.Create("projects/{projectId}/triggers", Method.Post);

            request.AddUrlSegment("projectId", projectId);

            return await request.Execute<BuildTrigger>();
        }

        /// <summary> Deletes the build trigger with the provided token. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="token"> The token of the build trigger. </param>
        /// <returns> A <see cref="RequestResult{BuildTrigger}" /> representing the results of the request. </returns>
        public async Task<RequestResult<BuildTrigger>> Delete(uint projectId, string token)
        {
            if (token == null)
                throw new ArgumentNullException(nameof(token));

            var request = RequestFactory.Create("projects/{projectId}/triggers/{token}", Method.Delete);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("token", token);

            return await request.Execute<BuildTrigger>();
        }

        /// <summary> Gets a build trigger by its token. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="token"> The token of the desired build trigger. </param>
        /// <returns> A <see cref="RequestResult{BuildTrigger}" /> representing the results of the request. </returns>
        public async Task<RequestResult<BuildTrigger>> Find(uint projectId, string token)
        {
            if (token == null)
                throw new ArgumentNullException(nameof(token));

            var request = RequestFactory.Create("projects/{projectId}/triggers/{token}", Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("token", token);

            return await request.Execute<BuildTrigger>();
        }

        /// <summary> Gets all build triggers associated with the specified project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="page"> The page number for a paginated request. </param>
        /// <param name="resultsPerPage"> The number of results to return per request. </param>
        /// <returns> A <see cref="PaginatedResult{BuildTrigger}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<BuildTrigger>> GetAll(uint projectId, uint page = Config.DefaultPage, uint resultsPerPage = Config.DefaultResultsPerPage)
        {
            if (page < Config.DefaultPage)
                throw new ArgumentOutOfRangeException(nameof(page), page, "The parameter 'page' must be greater than " + Config.DefaultPage + ".");

            if (resultsPerPage < Config.MinResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage, "The parameter 'resultsPerPage' must be greater than " + Config.MinResultsPerPage + ".");

            if (resultsPerPage > Config.MaxResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage, "The parameter 'resultsPerPage' must be less than " + Config.MaxResultsPerPage + ".");

            var request = RequestFactory.Create("projects/{projectId}/triggers", Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddParameter("page", page);
            request.AddParameter("per_page", resultsPerPage);

            return await request.ExecutePaginated<BuildTrigger>();
        }
    }
}