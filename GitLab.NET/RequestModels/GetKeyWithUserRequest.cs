using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetKeyWithUserRequest : IRequestModel
    {
        public const string Resource = "keys/{id}";

        private readonly uint _id;

        public GetKeyWithUserRequest(uint id)
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