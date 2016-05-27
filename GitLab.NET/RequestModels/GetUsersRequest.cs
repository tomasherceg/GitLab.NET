using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetUsersRequest : IRequestModel
    {
        public const string Resource = "users";

        private readonly uint _page;
        private readonly uint _resultsPerPage;
        private readonly string _search;

        public GetUsersRequest(uint page, uint resultsPerPage)
        {
            _page = page;
            _resultsPerPage = resultsPerPage;
        }

        public GetUsersRequest(string search, uint page, uint resultsPerPage)
        {
            _search = search;
            _page = page;
            _resultsPerPage = resultsPerPage;
        }

        public IRestRequest GetRequest()
        {
            var request = new RestRequest(Resource, Method.GET);

            request.AddParameterIfNotNull("search", _search);
            request.AddParameter("page", _page);
            request.AddParameter("per_page", _resultsPerPage);

            return request;
        }
    }
}