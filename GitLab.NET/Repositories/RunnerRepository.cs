using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    /// <summary> Provides GitLab Runner access in a repository pattern. </summary>
    public class RunnerRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="RunnerRepository" /> instance. </summary>
        /// <param name="requestFactory"> An instance of <see cref="IRequestFactory" /> to use for this repository. </param>
        public RunnerRepository(IRequestFactory requestFactory) : base(requestFactory) { }

        /// <summary> Deletes a runner. </summary>
        /// <param name="runnerId"> The runner's ID. </param>
        /// <returns> A <see cref="RequestResult{Runner}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Runner>> Delete(uint runnerId)
        {
            var request = RequestFactory.Create("runners/{runnerId}", Method.Delete);

            request.AddUrlSegment("runnerId", runnerId);

            return await request.ExecuteAsync<Runner>();
        }

        /// <summary> Disables a runner for the specified project. </summary>
        /// <param name="runnerId"> The runner's ID. </param>
        /// <param name="projectId"> The project's ID. </param>
        /// <returns> A <see cref="RequestResult{Runner}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Runner>> DisableForProject(uint runnerId, uint projectId)
        {
            var request = RequestFactory.Create("projects/{projectId}/runners/{runnerId}", Method.Delete);

            request.AddUrlSegment("runnerId", runnerId);
            request.AddUrlSegment("projectId", projectId);

            return await request.ExecuteAsync<Runner>();
        }

        /// <summary> Enables a runner for the specified project. </summary>
        /// <param name="runnerId"> The runner's ID. </param>
        /// <param name="projectId"> The project's ID. </param>
        /// <returns> A <see cref="RequestResult{Runner}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Runner>> EnableForProject(uint runnerId, uint projectId)
        {
            var request = RequestFactory.Create("projects/{projectId}/runners", Method.Post);

            request.AddUrlSegment("projectId", projectId);
            request.AddParameter("runnerId", runnerId);

            return await request.ExecuteAsync<Runner>();
        }

        /// <summary> Finds a runner by its ID. </summary>
        /// <param name="runnerId"> The runner's ID. </param>
        /// <returns> A <see cref="RequestResult{Runner}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Runner>> Find(uint runnerId)
        {
            var request = RequestFactory.Create("runners/{runnerId}", Method.Get);

            request.AddUrlSegment("runnerId", runnerId);

            return await request.ExecuteAsync<Runner>();
        }

        /// <summary> Gets all runners in the GitLab instance. </summary>
        /// <param name="scope"> The scope to limit the results to (active/paused/online/specific/shared) </param>
        /// <returns> A <see cref="PaginatedResult{Runner}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<Runner>> GetAll(string scope = null)
        {
            var request = RequestFactory.Create("runners/all", Method.Get);

            request.AddParameterIfNotNull("scope", scope);

            return await request.ExecutePaginatedAsync<Runner>();
        }

        /// <summary> Gets all runners assigned to the specified project. </summary>
        /// <param name="projectId"> The project's ID. </param>
        /// <returns> A <see cref="PaginatedResult{Runner}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<Runner>> GetByProject(uint projectId)
        {
            var request = RequestFactory.Create("projects/{projectId}/runners", Method.Get);

            request.AddUrlSegment("projectId", projectId);

            return await request.ExecutePaginatedAsync<Runner>();
        }

        /// <summary> Gets all runners owned by the currently authenticated user. </summary>
        /// <param name="scope"> The scope to limit the results to (active/paused/online) </param>
        /// <returns> A <see cref="PaginatedResult{Runner}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<Runner>> GetOwned(string scope = null)
        {
            var request = RequestFactory.Create("runners", Method.Get);

            request.AddParameterIfNotNull("scope", scope);

            return await request.ExecutePaginatedAsync<Runner>();
        }

        /// <summary> Updates a runner's details. </summary>
        /// <param name="runnerId"> The runner's ID. </param>
        /// <param name="description"> The new description for the runner. </param>
        /// <param name="active"> Whether or not the runner is active. </param>
        /// <param name="tagList"> The new tag list for the runner. </param>
        /// <returns> A <see cref="RequestResult{Runner}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Runner>> Update(uint runnerId, string description = null, bool? active = null, string[] tagList = null)
        {
            var request = RequestFactory.Create("runners/{runnerId}", Method.Put);

            request.AddUrlSegment("runnerId", runnerId);
            request.AddParameterIfNotNull("description", description);
            request.AddParameterIfNotNull("active", active);
            request.AddParameterIfNotNull("tag_list", tagList);

            return await request.ExecuteAsync<Runner>();
        }
    }
}