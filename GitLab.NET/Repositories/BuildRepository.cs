using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    /// <summary> Provides GitLab Build access in a repository pattern. </summary>
    public class BuildRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="BuildRepository" /> instance. </summary>
        /// <param name="requestFactory"> An instance of <see cref="IRequestFactory" /> to use for this repository. </param>
        public BuildRepository(IRequestFactory requestFactory) : base(requestFactory) { }

        /// <summary> Cancels a build. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="buildId"> The ID of the build. </param>
        /// <returns> A <see cref="RequestResult{Build}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Build>> Cancel(uint projectId, uint buildId)
        {
            var request = RequestFactory.Create("projects/{projectId}/builds/{buildId}/cancel", Method.Post);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("buildId", buildId);

            return await request.ExecuteAsync<Build>();
        }

        /// <summary> Erases the build trace and artifacts of a build. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="buildId"> The ID of the build. </param>
        /// <returns> A <see cref="RequestResult{Build}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Build>> Erase(uint projectId, uint buildId)
        {
            var request = RequestFactory.Create("projects/{projectId}/builds/{buildId}/erase", Method.Post);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("buildId", buildId);

            return await request.ExecuteAsync<Build>();
        }

        /// <summary> Gets a build by its ID. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="buildId"> The ID of the build. </param>
        /// <returns> A <see cref="RequestResult{Build}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Build>> Find(uint projectId, uint buildId)
        {
            var request = RequestFactory.Create("projects/{projectId}/builds/{buildId}", Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("buildId", buildId);

            return await request.ExecuteAsync<Build>();
        }

        /// <summary> Gets the artifacts from a build by its ID. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="buildId"> The ID of the build. </param>
        /// <returns> A <see cref="RequestResult{T}" /> containing a byte array representing the results of the request. </returns>
        public async Task<RequestResult<byte[]>> GetArtifacts(uint projectId, uint buildId)
        {
            var request = RequestFactory.Create("projects/{projectId}/builds/{buildId}/artifacts", Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("buildId", buildId);

            return await request.ExecuteBytesAsync();
        }

        /// <summary> Gets all builds for the specified commit. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="commitSha"> The commit SHA. </param>
        /// <param name="scopes"> The scopes to limit the results to. </param>
        /// <returns> A <see cref="PaginatedResult{Build}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<Build>> GetByCommit(uint projectId, string commitSha, BuildStatus[] scopes = null)
        {
            if (commitSha == null)
                throw new ArgumentNullException(nameof(commitSha));

            var request = RequestFactory.Create("projects/{projectId}/repository/commits/{commitSha}/builds", Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("commitSha", commitSha);
            request.AddParameterIfNotNull("scope", GetScopes(scopes));

            return await request.ExecutePaginatedAsync<Build>();
        }

        /// <summary> Gets all builds for the specified project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="scopes"> The scopes to limit the results to. (pending/running/failed/success/canceled) </param>
        /// <returns> A <see cref="PaginatedResult{Build}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<Build>> GetByProject(uint projectId, BuildStatus[] scopes = null)
        {
            var request = RequestFactory.Create("projects/{projectId}/builds", Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddParameterIfNotNull("scope", GetScopes(scopes));

            return await request.ExecutePaginatedAsync<Build>();
        }

        /// <summary> Retries a build. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="buildId"> The ID of the build. </param>
        /// <returns> A <see cref="RequestResult{Build}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Build>> Retry(uint projectId, uint buildId)
        {
            var request = RequestFactory.Create("projects/{projectId}/builds/{buildId}/retry", Method.Post);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("buildId", buildId);

            return await request.ExecuteAsync<Build>();
        }

        private static string[] GetScopes(BuildStatus[] input)
        {
            if (input == null)
                return null;

            string[] results = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                results[i] = Enum.GetName(typeof(BuildStatus), input[i])?.ToLower();

                if (results[i] == null)
                    throw new NullReferenceException("Unable to process element " + i + " from scopes parameter.");
            }

            return results;
        }
    }
}