using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    /// <summary> Provides GitLab Key access in a repository pattern. </summary>
    public class KeyRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="KeyRepository" /> instance. </summary>
        /// <param name="requestFactory"> An instance of <see cref="IRequestFactory" /> to use for this repository. </param>
        public KeyRepository(IRequestFactory requestFactory) : base(requestFactory) { }

        /// <summary> Creates a new SSH key under the currently authenticated user's account or the specified user's account. </summary>
        /// <param name="title"> The title for the new SSH key. </param>
        /// <param name="key"> The key for the new SSH key. </param>
        /// <param name="userId"> The user's ID. </param>
        /// <returns> A <see cref="RequestResult{SshKey}" /> representing the results of the request. </returns>
        public async Task<RequestResult<SshKey>> Create(string title, string key, uint? userId = null)
        {
            if (title == null)
                throw new ArgumentNullException(nameof(title));

            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var resource = userId != null ? "users/{userId}/keys" : "user/keys";
            var request = RequestFactory.Create(resource, Method.Post);

            request.AddUrlSegmentIfNotNull("userId", userId);
            request.AddParameter("title", title);
            request.AddParameter("key", key);

            return await request.Execute<SshKey>();
        }

        /// <summary> Delete's an SSH key from the currently authenticated user's account or the specified user's account. </summary>
        /// <param name="id"> The ID of the key to delete. </param>
        /// <param name="userId"> The ID of the user. </param>
        /// <returns> A <see cref="RequestResult{SshKey}" /> representing the results of the request. </returns>
        public async Task<RequestResult<SshKey>> Delete(uint id, uint? userId = null)
        {
            var resource = userId != null ? "users/{userId}/keys/{id}" : "user/keys/{id}";
            var request = RequestFactory.Create(resource, Method.Delete);

            request.AddUrlSegmentIfNotNull("userId", userId);
            request.AddUrlSegment("id", id);

            return await request.Execute<SshKey>();
        }

        /// <summary> Finds an SSH key by ID. </summary>
        /// <param name="id"> The ID of the SSH key. </param>
        /// <returns> A <see cref="RequestResult{SshKey}" /> representing the results of the request. </returns>
        public async Task<RequestResult<SshKey>> Find(uint id)
        {
            var request = RequestFactory.Create("user/keys/{id}", Method.Get);

            request.AddUrlSegment("id", id);

            return await request.Execute<SshKey>();
        }

        /// <summary> Finds an SSH key and user information by ID. </summary>
        /// <param name="id"> The ID of the SSH key. </param>
        /// <returns> A <see cref="RequestResult{SshKey}" /> representing the results of the request. </returns>
        public async Task<RequestResult<SshKey>> FindWithUser(uint id)
        {
            var request = RequestFactory.Create("keys/{id}", Method.Get);

            request.AddUrlSegment("id", id);

            return await request.Execute<SshKey>();
        }

        /// <summary> Gets all SSH keys for the current user or the specified user. </summary>
        /// <param name="userId"> The ID of the user. </param>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{SshKey}" /> representing the results of the
        ///     request.
        /// </returns>
        public async Task<RequestResult<List<SshKey>>> GetAll(uint? userId = null)
        {
            var resource = userId != null ? "users/{userId}/keys" : "user/keys";
            var request = RequestFactory.Create(resource, Method.Get);

            request.AddUrlSegmentIfNotNull("userId", userId);

            return await request.Execute<List<SshKey>>();
        }
    }
}