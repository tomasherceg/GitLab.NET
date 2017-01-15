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
        public NamespaceRepository(IRequestFactory requestFactory) : base(requestFactory)
        {
        }

        /// <summary> Gets all namespaces that the currently authenticated user is authorized to see. </summary>
        /// <param name="page"> The page number for a paginated request. </param>
        /// <param name="resultsPerPage"> The number of results to return per request. </param>
        /// <returns> A <see cref="PaginatedResult{Namespace}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<Namespace>> GetAll(uint page = Config.DefaultPage,
            uint resultsPerPage = Config.DefaultResultsPerPage)
        {
            if (page < Config.DefaultPage)
                throw new ArgumentOutOfRangeException(nameof(page), page,
                    "The parameter 'page' must be greater than " + Config.DefaultPage + ".");

            if (resultsPerPage < Config.MinResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage,
                    "The parameter 'resultsPerPage' must be greater than " + Config.MinResultsPerPage + ".");

            if (resultsPerPage > Config.MaxResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage,
                    "The parameter 'resultsPerPage' must be less than " + Config.MaxResultsPerPage + ".");

            var request = RequestFactory.Create("namespaces", Method.Get);

            request.AddParameter("page", page);
            request.AddParameter("per_page", resultsPerPage);

            return await request.ExecutePaginated<Namespace>();
        }

        /// <summary> Gets all namespaces matching the search query that the currently authenticated user is authorized to see. </summary>
        /// <param name="search"> The search term. </param>
        /// <param name="page"> The page number for a paginated request. </param>
        /// <param name="resultsPerPage"> The number of results to return per request. </param>
        /// <returns> A <see cref="PaginatedResult{Namespace}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<Namespace>> Search(string search, uint page = Config.DefaultPage,
            uint resultsPerPage = Config.DefaultResultsPerPage)
        {
            if (search == null)
                throw new ArgumentNullException(nameof(search));

            if (page < Config.DefaultPage)
                throw new ArgumentOutOfRangeException(nameof(page), page,
                    "The parameter 'page' must be greater than " + Config.DefaultPage + ".");

            if (resultsPerPage < Config.MinResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage,
                    "The parameter 'resultsPerPage' must be greater than " + Config.MinResultsPerPage + ".");

            if (resultsPerPage > Config.MaxResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage,
                    "The parameter 'resultsPerPage' must be less than " + Config.MaxResultsPerPage + ".");

            var request = RequestFactory.Create("namespaces", Method.Get);

            request.AddParameter("search", search);
            request.AddParameter("page", page);
            request.AddParameter("per_page", resultsPerPage);

            return await request.ExecutePaginated<Namespace>();
        }
    }
}