using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetUsersRequest : IRequestModel
    {
        private const string Resource = "users";
        private readonly int _page;
        private readonly int _resultsPerPage;

        private readonly string _search;

        public GetUsersRequest(int page, int resultsPerPage)
        {
            _page = page;
            _resultsPerPage = resultsPerPage;
        }

        public GetUsersRequest(string search, int page, int resultsPerPage)
        {
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