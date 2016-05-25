using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using RestSharp;

namespace GitLab.NET
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class PaginatedResult<T>
    {
        public int? CurrentPage { get; private set; }
        public int? PreviousPage { get; private set; }
        public int? NextPage { get; private set; }
        public int? ResultsPerPage { get; private set; }
        public int? TotalPages { get; private set; }
        public int? TotalResults { get; private set; }

        public List<T> Results { get; set; }

        private PaginatedResult(IRestResponse<List<T>> response)
        {
            CurrentPage = response.Headers.GetAsInt("X-Page");
            PreviousPage = response.Headers.GetAsInt("X-Prev-Page");
            NextPage = response.Headers.GetAsInt("X-Next-Page");
            ResultsPerPage = response.Headers.GetAsInt("X-Per-Page");
            TotalPages = response.Headers.GetAsInt("X-Total-Pages");
            TotalResults = response.Headers.GetAsInt("X-Total");

            Results = response.Data;
        }

        public static PaginatedResult<T> Create(IRestResponse<List<T>> response)
        {
            return new PaginatedResult<T>(response);
        }
    }

    internal static class HeaderHelper
    {
        public static int? GetAsInt(this IEnumerable<Parameter> headers, string name)
        {
            var header = headers.FirstOrDefault(h => h.Name == name)?.Value as string;

            if (header == null)
                return null;

            int result;

            var didParse = int.TryParse(header, out result);

            if (didParse)
                return result;

            return null;
        }
    }
}