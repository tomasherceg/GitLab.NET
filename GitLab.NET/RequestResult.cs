// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

using System.Net;
using RestSharp;

namespace GitLab.NET
{
    /// <summary> Provides data from an API request. </summary>
    /// <typeparam name="T"> The type of the data for this result. </typeparam>
    public class RequestResult<T>
    {
        /// <summary> The <see cref="HttpStatusCode" /> returned by the server for this request. </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary> The results from the query. </summary>
        public T Results { get; }

        /// <summary> Creates a new <see cref="RequestResult{T}" /> instance. </summary>
        /// <param name="response"> The response to populate this instance with. </param>
        public RequestResult(IRestResponse<T> response)
        {
            StatusCode = response.StatusCode;
            Results = response.Data;
        }
    }

    /// <summary> Provides data from an API request. </summary>
    public class RequestResult
    {
        /// <summary> The <see cref="HttpStatusCode" /> returned by the server for this request. </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary> The results from the query. </summary>
        public string Results { get; }

        /// <summary> Creates a new <see cref="RequestResult{T}" /> instance. </summary>
        /// <param name="response"> The response to populate this instance with. </param>
        public RequestResult(IRestResponse response)
        {
            StatusCode = response.StatusCode;
            Results = response.Content;
        }
    }
}