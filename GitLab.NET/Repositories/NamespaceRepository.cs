using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.RequestModels;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    /// <summary> Provides GitLab Namespace access in a repository pattern. </summary>
    public class NamespaceRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="NamespaceRepository" /> instance. </summary>
        /// <param name="requestFactory"> An instance of <see cref="IRequestFactory" /> to use for this repository. </param>
        public NamespaceRepository(IRequestFactory requestFactory) : base(requestFactory) { }

        /// <summary> Gets all namespaces that the currently authenticated user is authorized to see. </summary>
        /// <returns> A <see cref="PaginatedResult{Namespace}" /> representing the results of the request. </returns>
        public PaginatedResult<Namespace> GetAll()
        {
            var request = new GetNamespacesRequest();

            var result = RequestExecutor.Execute<List<Namespace>>(request);

            return new PaginatedResult<Namespace>(result);
        }

        /// <summary> Gets all namespaces that the currently authenticated user is authorized to see. </summary>
        /// <returns> A <see cref="PaginatedResult{Namespace}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<Namespace>> GetAllAsync()
        {
            var request = new GetNamespacesRequest();

            var result = await RequestExecutor.ExecuteAsync<List<Namespace>>(request);

            return new PaginatedResult<Namespace>(result);
        }

        /// <summary> Gets all namespaces matching the search query that the currently authenticated user is authorized to see. </summary>
        /// <param name="search"> The search term. </param>
        /// <returns> A <see cref="PaginatedResult{Namespace}" /> representing the results of the request. </returns>
        public PaginatedResult<Namespace> Search(string search)
        {
            if (search == null)
                throw new ArgumentNullException(nameof(search));

            var request = new GetNamespacesRequest(search);

            var result = RequestExecutor.Execute<List<Namespace>>(request);

            return new PaginatedResult<Namespace>(result);
        }

        /// <summary> Gets all namespaces matching the search query that the currently authenticated user is authorized to see. </summary>
        /// <param name="search"> The search term. </param>
        /// <returns> A <see cref="PaginatedResult{Namespace}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<Namespace>> SearchAsync(string search)
        {
            if (search == null)
                throw new ArgumentNullException(nameof(search));

            var request = new GetNamespacesRequest(search);

            var result = await RequestExecutor.ExecuteAsync<List<Namespace>>(request);

            return new PaginatedResult<Namespace>(result);
        }
    }
}