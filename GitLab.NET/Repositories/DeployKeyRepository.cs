// ReSharper disable UnusedMember.Global

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.RequestModels;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    /// <summary> Provides GitLab Deploy Key access in a repository pattern. </summary>
    public class DeployKeyRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="DeployKeyRepository" /> instance. </summary>
        /// <param name="requestFactory"> An instance of <see cref="IRequestFactory" /> to use for this repository. </param>
        public DeployKeyRepository(IRequestFactory requestFactory) : base(requestFactory) { }

        /// <summary> Creates a new deploy key. </summary>
        /// <param name="projectId"> The ID of the project to associate this key with. </param>
        /// <param name="title"> The title of the key. </param>
        /// <param name="key"> The key. </param>
        /// <returns> A <see cref="RequestResult{DeployKey}" /> containing the results of this request. </returns>
        public RequestResult<DeployKey> Create(uint projectId, string title, string key)
        {
            if (title == null)
                throw new ArgumentNullException(nameof(title));

            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var request = new CreateDeployKeyRequest(projectId, title, key);

            var result = RequestExecutor.Execute<DeployKey>(request);

            return new RequestResult<DeployKey>(result);
        }

        /// <summary> Creates a new deploy key. </summary>
        /// <param name="projectId"> The ID of the project to associate this key with. </param>
        /// <param name="title"> The title of the key. </param>
        /// <param name="key"> The key. </param>
        /// <returns> A <see cref="RequestResult{DeployKey}" /> containing the results of this request. </returns>
        public async Task<RequestResult<DeployKey>> CreateAsync(uint projectId, string title, string key)
        {
            if (title == null)
                throw new ArgumentNullException(nameof(title));

            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var request = new CreateDeployKeyRequest(projectId, title, key);

            var result = await RequestExecutor.ExecuteAsync<DeployKey>(request);

            return new RequestResult<DeployKey>(result);
        }

        /// <summary> Deletes a deploy key. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="keyId"> The ID of the key to delete. </param>
        /// <returns> A <see cref="RequestResult{DeployKey}" /> containing the results of this request. </returns>
        public RequestResult<DeployKey> Delete(uint projectId, uint keyId)
        {
            var request = new DeleteDeployKeyRequest(projectId, keyId);

            var result = RequestExecutor.Execute<DeployKey>(request);

            return new RequestResult<DeployKey>(result);
        }

        /// <summary> Deletes a deploy key. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="keyId"> The ID of the key to delete. </param>
        /// <returns> A <see cref="RequestResult{DeployKey}" /> containing the results of this request. </returns>
        public async Task<RequestResult<DeployKey>> DeleteAsync(uint projectId, uint keyId)
        {
            var request = new DeleteDeployKeyRequest(projectId, keyId);

            var result = await RequestExecutor.ExecuteAsync<DeployKey>(request);

            return new RequestResult<DeployKey>(result);
        }

        /// <summary> Gets all deploy keys associated with the specified project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{DeployKey}" /> representing the results of the
        ///     request.
        /// </returns>
        public RequestResult<List<DeployKey>> GetAll(uint projectId)
        {
            var request = new GetDeployKeysRequest(projectId);

            var result = RequestExecutor.Execute<List<DeployKey>>(request);

            return new RequestResult<List<DeployKey>>(result);
        }

        /// <summary> Gets all deploy keys associated with the specified project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{DeployKey}" /> representing the results of the
        ///     request.
        /// </returns>
        public async Task<RequestResult<List<DeployKey>>> GetAllAsync(uint projectId)
        {
            var request = new GetDeployKeysRequest(projectId);

            var result = await RequestExecutor.ExecuteAsync<List<DeployKey>>(request);

            return new RequestResult<List<DeployKey>>(result);
        }

        /// <summary> Gets a deploy key. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="keyId"> The ID of the desired key. </param>
        /// <returns> A <see cref="RequestResult{DeployKey}" /> containing the results of this request. </returns>
        public RequestResult<DeployKey> GetById(uint projectId, uint keyId)
        {
            var request = new GetDeployKeyRequest(projectId, keyId);

            var result = RequestExecutor.Execute<DeployKey>(request);

            return new RequestResult<DeployKey>(result);
        }

        /// <summary> Gets a deploy key. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="keyId"> The ID of the desired key. </param>
        /// <returns> A <see cref="RequestResult{DeployKey}" /> containing the results of this request. </returns>
        public async Task<RequestResult<DeployKey>> GetByIdAsync(uint projectId, uint keyId)
        {
            var request = new GetDeployKeyRequest(projectId, keyId);

            var result = await RequestExecutor.ExecuteAsync<DeployKey>(request);

            return new RequestResult<DeployKey>(result);
        }
    }
}