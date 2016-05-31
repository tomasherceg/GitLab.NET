using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    /// <summary> Provides GitLab Build Variable access in a repository pattern. </summary>
    public class BuildVariableRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="BuildVariableRepository" /> instance. </summary>
        /// <param name="requestFactory"> An instance of <see cref="IRequestFactory" /> to use for this repository. </param>
        public BuildVariableRepository(IRequestFactory requestFactory) : base(requestFactory) { }

        /// <summary> Creates a new build variable. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="key"> The desired key for the new build variable. </param>
        /// <param name="value"> The desired value for the new build variable. </param>
        /// <returns> A <see cref="RequestResult{BuildVariable}" /> representing the results of the request. </returns>
        public async Task<RequestResult<BuildVariable>> Create(uint projectId, string key, string value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            var request = RequestFactory.Create("projects/{projectId}/variables", Method.Post);

            request.AddUrlSegment("projectId", projectId);
            request.AddParameter("key", key);
            request.AddParameter("value", value);

            return await request.ExecuteAsync<BuildVariable>();
        }

        /// <summary> Deletes a build variable by the specified key. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="key"> The key of the desired build variable. </param>
        /// <returns> A <see cref="RequestResult{BuildVariable}" /> representing the results of the request. </returns>
        public async Task<RequestResult<BuildVariable>> Delete(uint projectId, string key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var request = RequestFactory.Create("projects/{projectId}/variables/{key}", Method.Delete);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("key", key);

            return await request.ExecuteAsync<BuildVariable>();
        }

        /// <summary> Gets a build variable by the specified key. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="key"> The key of the desired build variable. </param>
        /// <returns> A <see cref="RequestResult{BuildVariable}" /> representing the results of the request. </returns>
        public async Task<RequestResult<BuildVariable>> Find(uint projectId, string key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var request = RequestFactory.Create("projects/{projectId}/variables/{key}", Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("key", key);

            return await request.ExecuteAsync<BuildVariable>();
        }

        /// <summary> Gets all build variables for the specified project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="page"> The page number for a paginated request. </param>
        /// <param name="resultsPerPage"> The number of results to return per request. </param>
        /// <returns> A <see cref="PaginatedResult{BuildVariable}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<BuildVariable>> GetAll(uint projectId, uint page = Config.DefaultPage, uint resultsPerPage = Config.DefaultResultsPerPage)
        {
            if (page < Config.DefaultPage)
                throw new ArgumentOutOfRangeException(nameof(page), page, "The parameter 'page' must be greater than " + Config.DefaultPage + ".");

            if (resultsPerPage < Config.MinResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage, "The parameter 'resultsPerPage' must be greater than " + Config.MinResultsPerPage + ".");

            if (resultsPerPage > Config.MaxResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage, "The parameter 'resultsPerPage' must be less than " + Config.MaxResultsPerPage + ".");

            var request = RequestFactory.Create("projects/{projectId}/variables", Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddParameter("page", page);
            request.AddParameter("per_page", resultsPerPage);

            return await request.ExecutePaginatedAsync<BuildVariable>();
        }

        /// <summary> Updates an existing build variable. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="key"> The key of the build variable. </param>
        /// <param name="value"> The desired value for the build variable. </param>
        /// <returns> A <see cref="RequestResult{BuildVariable}" /> representing the results of the request. </returns>
        public async Task<RequestResult<BuildVariable>> Update(uint projectId, string key, string value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            var request = RequestFactory.Create("projects/{projectId}/variables/{key}", Method.Put);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("key", key);
            request.AddParameter("value", value);

            return await request.ExecuteAsync<BuildVariable>();
        }
    }
}