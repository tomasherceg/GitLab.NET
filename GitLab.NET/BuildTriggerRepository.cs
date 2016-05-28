// ReSharper disable UnusedMember.Global

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitLab.NET.RequestModels;
using GitLab.NET.ResponseModels;

namespace GitLab.NET
{
    /// <summary> Provides GitLab Build Trigger access in a repository pattern. </summary>
    public class BuildTriggerRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="BuildTriggerRepository" /> instance. </summary>
        /// <param name="restExecutor"> An instance of <see cref="IRequestExecutor" /> to use for this repository. </param>
        public BuildTriggerRepository(IRequestExecutor restExecutor) : base(restExecutor) { }

        /// <summary> Creates a new build trigger associated with the specified project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <returns> A <see cref="RequestResult{BuildTrigger}" /> representing the results of the request. </returns>
        public RequestResult<BuildTrigger> Create(uint projectId)
        {
            var request = new CreateBuildTriggerRequest(projectId);

            var result = RequestExecutor.Execute<BuildTrigger>(request);

            return new RequestResult<BuildTrigger>(result);
        }

        /// <summary> Creates a new build trigger associated with the specified project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <returns> A <see cref="RequestResult{BuildTrigger}" /> representing the results of the request. </returns>
        public async Task<RequestResult<BuildTrigger>> CreateAsync(uint projectId)
        {
            var request = new CreateBuildTriggerRequest(projectId);

            var result = await RequestExecutor.ExecuteAsync<BuildTrigger>(request);

            return new RequestResult<BuildTrigger>(result);
        }

        /// <summary> Deletes the build trigger with the provided token. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="token"> The token of the build trigger. </param>
        /// <returns> A <see cref="RequestResult{BuildTrigger}" /> representing the results of the request. </returns>
        public RequestResult<BuildTrigger> Delete(uint projectId, string token)
        {
            if (token == null)
                throw new ArgumentNullException(nameof(token));

            var request = new DeleteBuildTriggerRequest(projectId, token);

            var result = RequestExecutor.Execute<BuildTrigger>(request);

            return new RequestResult<BuildTrigger>(result);
        }

        /// <summary> Deletes the build trigger with the provided token. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="token"> The token of the build trigger. </param>
        /// <returns> A <see cref="RequestResult{BuildTrigger}" /> representing the results of the request. </returns>
        public async Task<RequestResult<BuildTrigger>> DeleteAsync(uint projectId, string token)
        {
            if (token == null)
                throw new ArgumentNullException(nameof(token));

            var request = new DeleteBuildTriggerRequest(projectId, token);

            var result = await RequestExecutor.ExecuteAsync<BuildTrigger>(request);

            return new RequestResult<BuildTrigger>(result);
        }

        /// <summary> Gets all build triggers associated with the specified project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <returns> A <see cref="PaginatedResult{BuildTrigger}" /> representing the results of the request. </returns>
        public PaginatedResult<BuildTrigger> GetAll(uint projectId)
        {
            var request = new GetBuildTriggersRequest(projectId);

            var result = RequestExecutor.Execute<List<BuildTrigger>>(request);

            return new PaginatedResult<BuildTrigger>(result);
        }

        /// <summary> Gets all build triggers associated with the specified project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <returns> A <see cref="PaginatedResult{BuildTrigger}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<BuildTrigger>> GetAllAsync(uint projectId)
        {
            var request = new GetBuildTriggersRequest(projectId);

            var result = await RequestExecutor.ExecuteAsync<List<BuildTrigger>>(request);

            return new PaginatedResult<BuildTrigger>(result);
        }

        /// <summary> Gets a build trigger by its token. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="token"> The token of the desired build trigger. </param>
        /// <returns> A <see cref="RequestResult{BuildTrigger}" /> representing the results of the request. </returns>
        public RequestResult<BuildTrigger> GetById(uint projectId, string token)
        {
            if (token == null)
                throw new ArgumentNullException(nameof(token));

            var request = new GetBuildTriggerRequest(projectId, token);

            var result = RequestExecutor.Execute<BuildTrigger>(request);

            return new RequestResult<BuildTrigger>(result);
        }

        /// <summary> Gets a build trigger by its token. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="token"> The token of the desired build trigger. </param>
        /// <returns> A <see cref="RequestResult{BuildTrigger}" /> representing the results of the request. </returns>
        public async Task<RequestResult<BuildTrigger>> GetByIdAsync(uint projectId, string token)
        {
            if (token == null)
                throw new ArgumentNullException(nameof(token));

            var request = new GetBuildTriggerRequest(projectId, token);

            var result = await RequestExecutor.ExecuteAsync<BuildTrigger>(request);

            return new RequestResult<BuildTrigger>(result);
        }
    }
}