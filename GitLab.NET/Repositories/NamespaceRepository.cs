using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
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
            var request = RequestFactory.Create("namespaces", Method.Get);

            return request.ExecutePaginated<Namespace>();
        }

        /// <summary> Gets all namespaces that the currently authenticated user is authorized to see. </summary>
        /// <returns> A <see cref="PaginatedResult{Namespace}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<Namespace>> GetAllAsync()
        {
            var request = RequestFactory.Create("namespaces", Method.Get);

            return await request.ExecutePaginatedAsync<Namespace>();
        }

        /// <summary> Gets all namespaces matching the search query that the currently authenticated user is authorized to see. </summary>
        /// <param name="search"> The search term. </param>
        /// <returns> A <see cref="PaginatedResult{Namespace}" /> representing the results of the request. </returns>
        public PaginatedResult<Namespace> Search(string search)
        {
            if (search == null)
                throw new ArgumentNullException(nameof(search));

            var request = RequestFactory.Create("namespaces", Method.Get);

            request.AddParameter("search", search);

            return request.ExecutePaginated<Namespace>();
        }

        /// <summary> Gets all namespaces matching the search query that the currently authenticated user is authorized to see. </summary>
        /// <param name="search"> The search term. </param>
        /// <returns> A <see cref="PaginatedResult{Namespace}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<Namespace>> SearchAsync(string search)
        {
            if (search == null)
                throw new ArgumentNullException(nameof(search));

            var request = RequestFactory.Create("namespaces", Method.Get);

            request.AddParameter("search", search);

            return await request.ExecutePaginatedAsync<Namespace>();
        }
    }
}