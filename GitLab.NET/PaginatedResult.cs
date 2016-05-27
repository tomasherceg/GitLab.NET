using System.Collections.Generic;
using System.Linq;
using System.Net;
using RestSharp;

namespace GitLab.NET
{
    /// <summary> Stores results from a paginated query as well as pagination information. </summary>
    /// <typeparam name="T"> The type of result stored. </typeparam>
    public class PaginatedResult<T> : RequestResult<List<T>>
    {
        /// <summary> The current page. </summary>
        public uint? CurrentPage { get; }

        /// <summary> The number of the previous page. </summary>
        public uint? PreviousPage { get; }

        /// <summary> The number of the next page. </summary>
        public uint? NextPage { get; }

        /// <summary> The number of results returned per page. </summary>
        public uint? ResultsPerPage { get; }

        /// <summary> The total number of pages for this result. </summary>
        public uint? TotalPages { get; }

        /// <summary> The total number of results available. </summary>
        public uint? TotalResults { get; }

        /// <summary>
        /// Creates a new <see cref="PaginatedResult{T}" /> instance.
        /// </summary>
        /// <param name="response">The response to populate this instance with.</param>
        public PaginatedResult(IRestResponse<List<T>> response) : base(response)
        {
            CurrentPage = response.Headers.GetAsUInt("X-Page");
            PreviousPage = response.Headers.GetAsUInt("X-Prev-Page");
            NextPage = response.Headers.GetAsUInt("X-Next-Page");
            ResultsPerPage = response.Headers.GetAsUInt("X-Per-Page");
            TotalPages = response.Headers.GetAsUInt("X-Total-Pages");
            TotalResults = response.Headers.GetAsUInt("X-Total");
        }
    }
}