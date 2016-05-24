using GitLab.NET.RestSharpExtensions;
using RestSharp;
using System;

namespace GitLab.NET.RequestModels
{
    public class GetUsers : IRequestModel
    {
        private const string Resource = "users";

        private readonly string _search;
        private readonly int _page;
        private readonly int _resultsPerPage;

        public GetUsers(int page, int resultsPerPage)
        {
            _page = page;
            _resultsPerPage = resultsPerPage;
        }

        public GetUsers(string search, int page, int resultsPerPage)
        {
            if (search == null)
                throw new ArgumentNullException(nameof(search));

            if (string.IsNullOrWhiteSpace(search))
                throw new ArgumentException("The parameter must not be empty or white space.", nameof(search));

            _search = search;
            _page = page;
            _resultsPerPage = resultsPerPage;
        }

        public RestRequest GetRequest()
        {
            var request = new RestRequest(Resource, Method.GET);

            request.AddParameterIfNotNull("search", _search);
            request.AddParameter("page", _page);
            request.AddParameter("per_page", _resultsPerPage);

            return request;
        }
    }
}
