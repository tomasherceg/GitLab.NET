using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetNamespacesRequest : IRequestModel
    {
        public const string Resource = "namespaces";

        private readonly string _search;

        public GetNamespacesRequest(string search = null)
        {
            _search = search;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.GET);
            result.AddParameterIfNotNull("search", _search);
            return result;
        }
    }
}