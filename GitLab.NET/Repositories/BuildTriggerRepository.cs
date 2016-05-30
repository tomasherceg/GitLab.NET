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
        public RequestResult<BuildTrigger> Create(uint projectId)
        {
            var request = RequestFactory.Create("projects/{projectId}/triggers", Method.Post);

            request.AddUrlSegment("projectId", projectId);

            return request.Execute<BuildTrigger>();
        }

        /// <summary> Creates a new build trigger associated with the specified project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <returns> A <see cref="RequestResult{BuildTrigger}" /> representing the results of the request. </returns>
        public async Task<RequestResult<BuildTrigger>> CreateAsync(uint projectId)
        {
            var request = RequestFactory.Create("projects/{projectId}/triggers", Method.Post);

            request.AddUrlSegment("projectId", projectId);

            return await request.ExecuteAsync<BuildTrigger>();
        }

        /// <summary> Deletes the build trigger with the provided token. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="token"> The token of the build trigger. </param>
        /// <returns> A <see cref="RequestResult{BuildTrigger}" /> representing the results of the request. </returns>
        public RequestResult<BuildTrigger> Delete(uint projectId, string token)
        {
            if (token == null)
                throw new ArgumentNullException(nameof(token));

            var request = RequestFactory.Create("projects/{projectId}/triggers/{token}", Method.Delete);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("token", token);

            return request.Execute<BuildTrigger>();
        }

        /// <summary> Deletes the build trigger with the provided token. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="token"> The token of the build trigger. </param>
        /// <returns> A <see cref="RequestResult{BuildTrigger}" /> representing the results of the request. </returns>
        public async Task<RequestResult<BuildTrigger>> DeleteAsync(uint projectId, string token)
        {
            if (token == null)
                throw new ArgumentNullException(nameof(token));

            var request = RequestFactory.Create("projects/{projectId}/triggers/{token}", Method.Delete);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("token", token);

            return await request.ExecuteAsync<BuildTrigger>();
        }

        /// <summary> Gets a build trigger by its token. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="token"> The token of the desired build trigger. </param>
        /// <returns> A <see cref="RequestResult{BuildTrigger}" /> representing the results of the request. </returns>
        public RequestResult<BuildTrigger> Find(uint projectId, string token)
        {
            if (token == null)
                throw new ArgumentNullException(nameof(token));

            var request = RequestFactory.Create("projects/{projectId}/triggers/{token}", Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("token", token);

            return request.Execute<BuildTrigger>();
        }

        /// <summary> Gets a build trigger by its token. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="token"> The token of the desired build trigger. </param>
        /// <returns> A <see cref="RequestResult{BuildTrigger}" /> representing the results of the request. </returns>
        public async Task<RequestResult<BuildTrigger>> FindAsync(uint projectId, string token)
        {
            if (token == null)
                throw new ArgumentNullException(nameof(token));

            var request = RequestFactory.Create("projects/{projectId}/triggers/{token}", Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("token", token);

            return await request.ExecuteAsync<BuildTrigger>();
        }

        /// <summary> Gets all build triggers associated with the specified project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <returns> A <see cref="PaginatedResult{BuildTrigger}" /> representing the results of the request. </returns>
        public PaginatedResult<BuildTrigger> GetAll(uint projectId)
        {
            var request = RequestFactory.Create("projects/{projectId}/triggers", Method.Get);

            request.AddUrlSegment("projectId", projectId);

            return request.ExecutePaginated<BuildTrigger>();
        }

        /// <summary> Gets all build triggers associated with the specified project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <returns> A <see cref="PaginatedResult{BuildTrigger}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<BuildTrigger>> GetAllAsync(uint projectId)
        {
            var request = RequestFactory.Create("projects/{projectId}/triggers", Method.Get);

            request.AddUrlSegment("projectId", projectId);

            return await request.ExecutePaginatedAsync<BuildTrigger>();
        }
    }
}