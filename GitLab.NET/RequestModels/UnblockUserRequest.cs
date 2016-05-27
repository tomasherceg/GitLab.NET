using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class UnblockUserRequest : IRequestModel
    {
        public const string Resource = "users/{id}/block";

        private readonly uint _id;

        public UnblockUserRequest(uint id)
        {
            _id = id;
        }

        public IRestRequest GetRequest()
        {
            var request = new RestRequest(Resource, Method.PUT);
            request.AddParameter("id", _id, ParameterType.UrlSegment);

            return request;
        }
    }
}