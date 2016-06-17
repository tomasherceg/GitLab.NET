using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    /// <summary> Provides GitLab System Hook access in a repository pattern. </summary>
    public class SystemHookRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="SystemHookRepository" /> instance. </summary>
        /// <param name="requestFactory"> An instance of <see cref="IRequestFactory" /> to use for this repository. </param>
        public SystemHookRepository(IRequestFactory requestFactory) : base(requestFactory) { }

        /// <summary> Creates a new system hook. </summary>
        /// <param name="url"> The URL to use for the new system hook. </param>
        /// <returns> A <see cref="RequestResult{SystemHook}" /> representing the results of the request. </returns>
        public async Task<RequestResult<SystemHook>> Create(string url)
        {
            if (url == null)
                throw new ArgumentNullException(nameof(url));

            var request = RequestFactory.Create("hooks", Method.Post);

            request.AddParameter("url", url);

            return await request.Execute<SystemHook>();
        }

        /// <summary> Deletes a system hook. </summary>
        /// <param name="hookId"> The ID of the system hook to delete. </param>
        /// <returns> A <see cref="RequestResult{SystemHook}" /> representing the results of the request. </returns>
        public async Task<RequestResult<SystemHook>> Delete(uint hookId)
        {
            var request = RequestFactory.Create("hooks/{hookId}", Method.Delete);

            request.AddUrlSegment("hookId", hookId);

            return await request.Execute<SystemHook>();
        }

        /// <summary> Gets all system hooks. </summary>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{SystemHoook}" /> representing the results of
        ///     the request.
        /// </returns>
        public async Task<RequestResult<List<SystemHook>>> GetAll()
        {
            var request = RequestFactory.Create("hooks", Method.Get);

            return await request.Execute<List<SystemHook>>();
        }

        /// <summary> Tests a system hook. </summary>
        /// <param name="hookId"> The ID of the system hook to test. </param>
        /// <returns> A <see cref="RequestResult{SystemHookEvent}" /> representing the results of the request. </returns>
        public async Task<RequestResult<SystemHookEvent>> Test(uint hookId)
        {
            var request = RequestFactory.Create("hooks/{hookId}", Method.Get);

            request.AddUrlSegment("hookId", hookId);

            return await request.Execute<SystemHookEvent>();
        }
    }
}