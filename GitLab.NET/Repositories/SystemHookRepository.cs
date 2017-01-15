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
        public SystemHookRepository(IRequestFactory requestFactory) : base(requestFactory)
        {
        }

        /// <summary> Creates a new system hook. </summary>
        /// <param name="url"> The URL to use for the new system hook. </param>
        /// <param name="mergeRequestsEvents"> Track merge requests events by new system hook. </param>
        /// <param name="pushEvents"> Track push events by new system hook. </param>
        /// <param name="buildEvents"> Track build events by new system hook. </param>
        /// <param name="enableSSLVerification"> Enable SSL verification for new system hook. </param>
        /// <returns> A <see cref="RequestResult{SystemHook}" /> representing the results of the request. </returns>
        public async Task<RequestResult<SystemHook>> Create(string url, bool? mergeRequestsEvents = null,
            bool? pushEvents = null, bool? buildEvents = null, bool? enableSSLVerification = null)
        {
            if (url == null)
                throw new ArgumentNullException(nameof(url));

            var request = RequestFactory.Create("hooks", Method.Post);

            request.AddParameter("url", url);
            request.AddParameterIfNotNull("merge_requests_events", mergeRequestsEvents);
            request.AddParameterIfNotNull("push_events", pushEvents);
            request.AddParameterIfNotNull("build_events", buildEvents);
            request.AddParameterIfNotNull("enable_ssl_verification", enableSSLVerification);

            return await request.Execute<SystemHook>();
        }

        /// <summary> Updates an existing system hook. </summary>
        /// <param name="hookId"> The ID of the system hook to update. </param>
        /// <param name="url"> The URL of the system hook to update. </param>
        /// <param name="mergeRequestsEvents"> Update trackicng merge requests events. </param>
        /// <param name="pushEvents"> Update trackicng push events. </param>
        /// <param name="buildEvents"> Update trackicng build events. </param>
        /// <param name="enableSSLVerification"> Update SSL verification. </param>
        /// <returns> A <see cref="RequestResult{SystemHook}" /> representing the results of the request. </returns>
        public async Task<RequestResult<SystemHook>> Update(uint hookId, string url, bool mergeRequestsEvents,
            bool pushEvents, bool buildEvents, bool enableSSLVerification)
        {
            var request = RequestFactory.Create("hooks/{hookId}", Method.Put);

            request.AddUrlSegment("hookId", hookId);

            request.AddParameter("url", url);

            request.AddParameter("merge_requests_events", mergeRequestsEvents);
            request.AddParameter("push_events", pushEvents);
            request.AddParameter("build_events", buildEvents);
            request.AddParameter("enable_ssl_verification", enableSSLVerification);

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
        public async Task<RequestResult<List<SystemHook>>> GetAll(uint? projectId = null)
        {
            var request = RequestFactory.Create("hooks", Method.Get);

            request.AddParameterIfNotNull("project_id", projectId);

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