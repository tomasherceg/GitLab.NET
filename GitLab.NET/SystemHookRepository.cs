// ReSharper disable UnusedMember.Global

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitLab.NET.RequestModels;
using GitLab.NET.ResponseModels;

namespace GitLab.NET
{
    /// <summary> Provides GitLab System Hook access in a repository pattern. </summary>
    public class SystemHookRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="SystemHookRepository" /> instance. </summary>
        /// <param name="restExecutor"> An instance of <see cref="IRequestExecutor" /> to use for this repository. </param>
        public SystemHookRepository(IRequestExecutor restExecutor) : base(restExecutor) { }

        /// <summary> Creates a new system hook. </summary>
        /// <param name="url"> The URL to use for the new system hook. </param>
        /// <returns> A <see cref="RequestResult{SystemHook}" /> representing the results of the request. </returns>
        public RequestResult<SystemHook> Create(string url)
        {
            if (url == null)
                throw new ArgumentNullException(nameof(url));

            var request = new CreateSystemHookRequest(url);

            var result = RequestExecutor.Execute<SystemHook>(request);

            return new RequestResult<SystemHook>(result);
        }

        /// <summary> Creates a new system hook. </summary>
        /// <param name="url"> The URL to use for the new system hook. </param>
        /// <returns> A <see cref="RequestResult{SystemHook}" /> representing the results of the request. </returns>
        public async Task<RequestResult<SystemHook>> CreateAsync(string url)
        {
            if (url == null)
                throw new ArgumentNullException(nameof(url));

            var request = new CreateSystemHookRequest(url);

            var result = await RequestExecutor.ExecuteAsync<SystemHook>(request);

            return new RequestResult<SystemHook>(result);
        }

        /// <summary> Deletes a system hook. </summary>
        /// <param name="hookId"> The ID of the system hook to delete. </param>
        /// <returns> A <see cref="RequestResult{SystemHook}" /> representing the results of the request. </returns>
        public RequestResult<SystemHook> Delete(uint hookId)
        {
            var request = new DeleteSystemHookRequest(hookId);

            var result = RequestExecutor.Execute<SystemHook>(request);

            return new RequestResult<SystemHook>(result);
        }

        /// <summary> Deletes a system hook. </summary>
        /// <param name="hookId"> The ID of the system hook to delete. </param>
        /// <returns> A <see cref="RequestResult{SystemHook}" /> representing the results of the request. </returns>
        public async Task<RequestResult<SystemHook>> DeleteAsync(uint hookId)
        {
            var request = new DeleteSystemHookRequest(hookId);

            var result = await RequestExecutor.ExecuteAsync<SystemHook>(request);

            return new RequestResult<SystemHook>(result);
        }

        /// <summary> Gets all system hooks. </summary>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{SystemHoook}" /> representing the results of
        ///     the request.
        /// </returns>
        public RequestResult<List<SystemHook>> GetAll()
        {
            var request = new GetSystemHooksRequest();

            var result = RequestExecutor.Execute<List<SystemHook>>(request);

            return new RequestResult<List<SystemHook>>(result);
        }

        /// <summary> Gets all system hooks. </summary>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{SystemHoook}" /> representing the results of
        ///     the request.
        /// </returns>
        public async Task<RequestResult<List<SystemHook>>> GetAllAsync()
        {
            var request = new GetSystemHooksRequest();

            var result = await RequestExecutor.ExecuteAsync<List<SystemHook>>(request);

            return new RequestResult<List<SystemHook>>(result);
        }

        /// <summary> Tests a system hook. </summary>
        /// <param name="hookId"> The ID of the system hook to test. </param>
        /// <returns> A <see cref="RequestResult{SystemHookEvent}" /> representing the results of the request. </returns>
        public RequestResult<SystemHookEvent> Test(uint hookId)
        {
            var request = new TestSystemHookRequest(hookId);

            var result = RequestExecutor.Execute<SystemHookEvent>(request);

            return new RequestResult<SystemHookEvent>(result);
        }

        /// <summary> Tests a system hook. </summary>
        /// <param name="hookId"> The ID of the system hook to test. </param>
        /// <returns> A <see cref="RequestResult{SystemHookEvent}" /> representing the results of the request. </returns>
        public async Task<RequestResult<SystemHookEvent>> TestAsync(uint hookId)
        {
            var request = new TestSystemHookRequest(hookId);

            var result = await RequestExecutor.ExecuteAsync<SystemHookEvent>(request);

            return new RequestResult<SystemHookEvent>(result);
        }
    }
}