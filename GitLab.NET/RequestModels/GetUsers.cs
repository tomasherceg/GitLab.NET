using GitLab.NET.RestSharpExtensions;
using RestSharp;
using System;

namespace GitLab.NET.RequestModels
{
    public class GetUsers : IRequestModel
    {
        public const string resource = "users";

        public string Search { get; private set; }
        public int Page { get; private set; }
        public int ResultsPerPage { get; private set; }

        public GetUsers(int page, int resultsPerPage)
        {
            Page = page;
            ResultsPerPage = resultsPerPage;
        }

        public GetUsers(string search, int page, int resultsPerPage)
        {
            if (search == null)
                throw new ArgumentNullException(nameof(search));

            if (string.IsNullOrWhiteSpace(search))
                throw new ArgumentException("The parameter must not be empty or white space.", nameof(search));

            Search = search;
            Page = page;
            ResultsPerPage = resultsPerPage;
        }

        public RestRequest GetRequest()
        {
            var request = new RestRequest(resource, Method.GET);

            request.AddParameterIfNotNull("search", Search);
            request.AddParameter("page", Page);
            request.AddParameter("per_page", ResultsPerPage);

            return request;
        }
    }
}
