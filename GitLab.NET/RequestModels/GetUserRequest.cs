using JetBrains.Annotations;
using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetUserRequest : IRequestModel
    {
        private const string ByIdResource = "users/{id}";
        private const string ByUsernameResource = "users";
        private const string CurrentUserResource = "user";

        private readonly uint? _id;
        private readonly string _username;

        public GetUserRequest() { }

        public GetUserRequest(uint id)
        {
            _id = id;
        }

        public GetUserRequest(string username)
        {
            _username = username;
        }

        public IRestRequest GetRequest()
        {
            var request = new RestRequest(Method.GET);

            if (_username != null)
            {
                request.Resource = ByUsernameResource;
                request.AddParameter("username", _username);
            }
            else if (_id != null)
            {
                request.Resource = ByIdResource;
                request.AddParameter("id", _id, ParameterType.UrlSegment);
            }
            else
            {
                request.Resource = CurrentUserResource;
            }

            return request;
        }
    }
}