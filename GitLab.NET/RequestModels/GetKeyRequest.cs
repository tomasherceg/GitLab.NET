using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetKeyRequest : IRequestModel
    {
        public const string Resource = "user/keys/{id}";

        private readonly uint _id;

        public GetKeyRequest(uint id)
        {
            _id = id;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.GET);
            result.AddParameter("id", _id, ParameterType.UrlSegment);
            return result;
        }
    }
}