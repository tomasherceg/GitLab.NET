using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class DeleteUserRequest : IRequestModel
    {
        public const string Resource = "users/{id}";

        private readonly uint _id;

        public DeleteUserRequest(uint id)
        {
            _id = id;
        }

        public IRestRequest GetRequest()
        {
            var request = new RestRequest(Resource, Method.DELETE);

            request.AddParameter("id", _id, ParameterType.UrlSegment);

            return request;
        }
    }
}