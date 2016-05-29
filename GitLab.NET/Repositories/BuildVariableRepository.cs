// ReSharper disable UnusedMember.Global

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.RequestModels;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    /// <summary> Provides GitLab Build Variable access in a repository pattern. </summary>
    public class BuildVariableRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="BuildVariableRepository" /> instance. </summary>
        /// <param name="restExecutor"> An instance of <see cref="IRequestExecutor" /> to use for this repository. </param>
        public BuildVariableRepository(IRequestExecutor restExecutor) : base(restExecutor) { }

        /// <summary> Creates a new build variable. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="key"> The desired key for the new build variable. </param>
        /// <param name="value"> The desired value for the new build variable. </param>
        /// <returns> A <see cref="RequestResult{BuildVariable}" /> representing the results of the request. </returns>
        public RequestResult<BuildVariable> Create(uint projectId, string key, string value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            var request = new CreateBuildVariableRequest(projectId, key, value);

            var result = RequestExecutor.Execute<BuildVariable>(request);

            return new RequestResult<BuildVariable>(result);
        }

        /// <summary> Creates a new build variable. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="key"> The desired key for the new build variable. </param>
        /// <param name="value"> The desired value for the new build variable. </param>
        /// <returns> A <see cref="RequestResult{BuildVariable}" /> representing the results of the request. </returns>
        public async Task<RequestResult<BuildVariable>> CreateAsync(uint projectId, string key, string value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            var request = new CreateBuildVariableRequest(projectId, key, value);

            var result = await RequestExecutor.ExecuteAsync<BuildVariable>(request);

            return new RequestResult<BuildVariable>(result);
        }

        /// <summary> Deletes a build variable by the specified key. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="key"> The key of the desired build variable. </param>
        /// <returns> A <see cref="RequestResult{BuildVariable}" /> representing the results of the request. </returns>
        public RequestResult<BuildVariable> Delete(uint projectId, string key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var request = new DeleteBuildVariableRequest(projectId, key);

            var result = RequestExecutor.Execute<BuildVariable>(request);

            return new RequestResult<BuildVariable>(result);
        }

        /// <summary> Deletes a build variable by the specified key. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="key"> The key of the desired build variable. </param>
        /// <returns> A <see cref="RequestResult{BuildVariable}" /> representing the results of the request. </returns>
        public async Task<RequestResult<BuildVariable>> DeleteAsync(uint projectId, string key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var request = new DeleteBuildVariableRequest(projectId, key);

            var result = await RequestExecutor.ExecuteAsync<BuildVariable>(request);

            return new RequestResult<BuildVariable>(result);
        }

        /// <summary> Gets all build variables for the specified project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <returns> A <see cref="PaginatedResult{BuildVariable}" /> representing the results of the request. </returns>
        public PaginatedResult<BuildVariable> GetAll(uint projectId)
        {
            var request = new GetBuildVariablesRequest(projectId);

            var result = RequestExecutor.Execute<List<BuildVariable>>(request);

            return new PaginatedResult<BuildVariable>(result);
        }

        /// <summary> Gets all build variables for the specified project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <returns> A <see cref="PaginatedResult{BuildVariable}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<BuildVariable>> GetAllAsync(uint projectId)
        {
            var request = new GetBuildVariablesRequest(projectId);

            var result = await RequestExecutor.ExecuteAsync<List<BuildVariable>>(request);

            return new PaginatedResult<BuildVariable>(result);
        }

        /// <summary> Gets a build variable by the specified key. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="key"> The key of the desired build variable. </param>
        /// <returns> A <see cref="RequestResult{BuildVariable}" /> representing the results of the request. </returns>
        public RequestResult<BuildVariable> GetByKey(uint projectId, string key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var request = new GetBuildVariableRequest(projectId, key);

            var result = RequestExecutor.Execute<BuildVariable>(request);

            return new RequestResult<BuildVariable>(result);
        }

        /// <summary> Gets a build variable by the specified key. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="key"> The key of the desired build variable. </param>
        /// <returns> A <see cref="RequestResult{BuildVariable}" /> representing the results of the request. </returns>
        public async Task<RequestResult<BuildVariable>> GetByKeyAsync(uint projectId, string key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var request = new GetBuildVariableRequest(projectId, key);

            var result = await RequestExecutor.ExecuteAsync<BuildVariable>(request);

            return new RequestResult<BuildVariable>(result);
        }

        /// <summary> Updates an existing build variable. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="key"> The key of the build variable. </param>
        /// <param name="value"> The desired value for the build variable. </param>
        /// <returns> A <see cref="RequestResult{BuildVariable}" /> representing the results of the request. </returns>
        public RequestResult<BuildVariable> Update(uint projectId, string key, string value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            var request = new UpdateBuildVariableRequest(projectId, key, value);

            var result = RequestExecutor.Execute<BuildVariable>(request);

            return new RequestResult<BuildVariable>(result);
        }

        /// <summary> Updates an existing build variable. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="key"> The key of the build variable. </param>
        /// <param name="value"> The desired value for the build variable. </param>
        /// <returns> A <see cref="RequestResult{BuildVariable}" /> representing the results of the request. </returns>
        public async Task<RequestResult<BuildVariable>> UpdateAsync(uint projectId, string key, string value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            var request = new UpdateBuildVariableRequest(projectId, key, value);

            var result = await RequestExecutor.ExecuteAsync<BuildVariable>(request);

            return new RequestResult<BuildVariable>(result);
        }
    }
}