using System.Collections.Generic;
using System.Net;
using System.Web.Script.Serialization;
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

        //public Dictionary<string, string> Errors { get; }

        /// <summary>
        /// Creates a new <see cref="RequestResult{T}" /> instance.
        /// </summary>
        /// <param name="response">The response to populate this instance with.</param>
        public RequestResult(IRestResponse<T> response)
        {
            StatusCode = response.StatusCode;
            Results = response.Data;

            // Fuck this shit because it's retarded to try and process. Do it later.
            //if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Created && response.StatusCode != HttpStatusCode.NotModified)
            //    Errors = PopulateErrors(response.Content);
        }

        private Dictionary<string, string> PopulateErrors(string jsonResponse)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<Dictionary<string, string>>(jsonResponse);
        }
    }
}