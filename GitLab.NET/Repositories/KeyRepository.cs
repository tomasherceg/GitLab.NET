// ReSharper disable UnusedMember.Global

using System.Collections.Generic;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.RequestModels;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    /// <summary> Provides GitLab Key access in a repository pattern. </summary>
    public class KeyRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="KeyRepository" /> instance. </summary>
        /// <param name="restExecutor"> An instance of <see cref="IRequestExecutor" /> to use for this repository. </param>
        public KeyRepository(IRequestExecutor restExecutor) : base(restExecutor) { }

        /// <summary> Creates a new SSH key under the currently authenticated user's account. </summary>
        /// <param name="title"> The title for the new SSH key. </param>
        /// <param name="key"> The key for the new SSH key. </param>
        /// <returns> A <see cref="RequestResult{SshKey}" /> representing the results of the request. </returns>
        public RequestResult<SshKey> Create(string title, string key)
        {
            var request = new CreateKeyRequest(title, key);

            var result = RequestExecutor.Execute<SshKey>(request);

            return new RequestResult<SshKey>(result);
        }

        /// <summary> Creates a new SSH key under the currently authenticated user's account. </summary>
        /// <param name="title"> The title for the new SSH key. </param>
        /// <param name="key"> The key for the new SSH key. </param>
        /// <returns> A <see cref="RequestResult{SshKey}" /> representing the results of the request. </returns>
        public async Task<RequestResult<SshKey>> CreateAsync(string title, string key)
        {
            var request = new CreateKeyRequest(title, key);

            var result = await RequestExecutor.ExecuteAsync<SshKey>(request);

            return new RequestResult<SshKey>(result);
        }

        /// <summary> Creates a new SSH key under the specified user's account. </summary>
        /// <param name="title"> The title for the new SSH key. </param>
        /// <param name="key"> The key for the new SSH key. </param>
        /// <param name="userId"> The user's ID. </param>
        /// <returns> A <see cref="RequestResult{SshKey}" /> representing the results of the request. </returns>
        public RequestResult<SshKey> Create(string title, string key, uint userId)
        {
            var request = new CreateKeyRequest(title, key, userId);

            var result = RequestExecutor.Execute<SshKey>(request);

            return new RequestResult<SshKey>(result);
        }

        /// <summary> Creates a new SSH key under the specified user's account. </summary>
        /// <param name="title"> The title for the new SSH key. </param>
        /// <param name="key"> The key for the new SSH key. </param>
        /// <param name="userId"> The user's ID. </param>
        /// <returns> A <see cref="RequestResult{SshKey}" /> representing the results of the request. </returns>
        public async Task<RequestResult<SshKey>> CreateAsync(string title, string key, uint userId)
        {
            var request = new CreateKeyRequest(title, key, userId);

            var result = await RequestExecutor.ExecuteAsync<SshKey>(request);

            return new RequestResult<SshKey>(result);
        }

        /// <summary> Delete's an SSH key from the currently authenticated user's account. </summary>
        /// <param name="id"> The ID of the key to delete. </param>
        /// <returns> A <see cref="RequestResult{SshKey}" /> representing the results of the request. </returns>
        public RequestResult<SshKey> Delete(uint id)
        {
            var request = new DeleteKeyRequest(id);

            var result = RequestExecutor.Execute<SshKey>(request);

            return new RequestResult<SshKey>(result);
        }

        /// <summary> Delete's an SSH key from the currently authenticated user's account. </summary>
        /// <param name="id"> The ID of the key to delete. </param>
        /// <returns> A <see cref="RequestResult{SshKey}" /> representing the results of the request. </returns>
        public async Task<RequestResult<SshKey>> DeleteAsync(uint id)
        {
            var request = new DeleteKeyRequest(id);

            var result = await RequestExecutor.ExecuteAsync<SshKey>(request);

            return new RequestResult<SshKey>(result);
        }

        /// <summary> Delete's an SSH key from the specified user's account. </summary>
        /// <param name="id"> The ID of the key to delete. </param>
        /// <param name="userId"> The ID of the user. </param>
        /// <returns> A <see cref="RequestResult{SshKey}" /> representing the results of the request. </returns>
        public RequestResult<SshKey> Delete(uint id, uint userId)
        {
            var request = new DeleteKeyRequest(id, userId);

            var result = RequestExecutor.Execute<SshKey>(request);

            return new RequestResult<SshKey>(result);
        }

        /// <summary> Delete's an SSH key from the specified user's account. </summary>
        /// <param name="id"> The ID of the key to delete. </param>
        /// <param name="userId"> The ID of the user. </param>
        /// <returns> A <see cref="RequestResult{SshKey}" /> representing the results of the request. </returns>
        public async Task<RequestResult<SshKey>> DeleteAsync(uint id, uint userId)
        {
            var request = new DeleteKeyRequest(id, userId);

            var result = await RequestExecutor.ExecuteAsync<SshKey>(request);

            return new RequestResult<SshKey>(result);
        }

        /// <summary> Gets an SSH key by ID. </summary>
        /// <param name="id"> The ID of the SSH key. </param>
        /// <returns> A <see cref="RequestResult{SshKey}" /> representing the results of the request. </returns>
        public RequestResult<SshKey> GetById(uint id)
        {
            var request = new GetKeyRequest(id);

            var result = RequestExecutor.Execute<SshKey>(request);

            return new RequestResult<SshKey>(result);
        }

        /// <summary> Gets an SSH key by ID. </summary>
        /// <param name="id"> The ID of the SSH key. </param>
        /// <returns> A <see cref="RequestResult{SshKey}" /> representing the results of the request. </returns>
        public async Task<RequestResult<SshKey>> GetByIdAsync(uint id)
        {
            var request = new GetKeyRequest(id);

            var result = await RequestExecutor.ExecuteAsync<SshKey>(request);

            return new RequestResult<SshKey>(result);
        }

        /// <summary> Gets an SSH key and user information by ID. </summary>
        /// <param name="id"> The ID of the SSH key. </param>
        /// <returns> A <see cref="RequestResult{SshKey}" /> representing the results of the request. </returns>
        public RequestResult<SshKey> GetByIdWithUser(uint id)
        {
            var request = new GetKeyWithUserRequest(id);

            var result = RequestExecutor.Execute<SshKey>(request);

            return new RequestResult<SshKey>(result);
        }

        /// <summary> Gets an SSH key and user information by ID. </summary>
        /// <param name="id"> The ID of the SSH key. </param>
        /// <returns> A <see cref="RequestResult{SshKey}" /> representing the results of the request. </returns>
        public async Task<RequestResult<SshKey>> GetByIdWithUserAsync(uint id)
        {
            var request = new GetKeyWithUserRequest(id);

            var result = await RequestExecutor.ExecuteAsync<SshKey>(request);

            return new RequestResult<SshKey>(result);
        }

        /// <summary> Gets the currently authenticated user's SSH keys. </summary>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{SshKey}" /> representing the results of the
        ///     request.
        /// </returns>
        public RequestResult<List<SshKey>> GetForUser()
        {
            var request = new GetUserKeysRequest();

            var result = RequestExecutor.Execute<List<SshKey>>(request);

            return new RequestResult<List<SshKey>>(result);
        }

        /// <summary> Gets the currently authenticated user's SSH keys. </summary>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{SshKey}" /> representing the results of the
        ///     request.
        /// </returns>
        public async Task<RequestResult<List<SshKey>>> GetForUserAsync()
        {
            var request = new GetUserKeysRequest();

            var result = await RequestExecutor.ExecuteAsync<List<SshKey>>(request);

            return new RequestResult<List<SshKey>>(result);
        }

        /// <summary> Gets the specified user's SSH keys. </summary>
        /// <param name="userId"> The user's ID. </param>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{SshKey}" /> representing the results of the
        ///     request.
        /// </returns>
        public RequestResult<List<SshKey>> GetForUser(uint userId)
        {
            var request = new GetUserKeysRequest(userId);

            var result = RequestExecutor.Execute<List<SshKey>>(request);

            return new RequestResult<List<SshKey>>(result);
        }

        /// <summary> Gets the specified user's SSH keys. </summary>
        /// <param name="userId"> The user's ID. </param>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{SshKey}" /> representing the results of the
        ///     request.
        /// </returns>
        public async Task<RequestResult<List<SshKey>>> GetForUserAsync(uint userId)
        {
            var request = new GetUserKeysRequest(userId);

            var result = await RequestExecutor.ExecuteAsync<List<SshKey>>(request);

            return new RequestResult<List<SshKey>>(result);
        }
    }
}