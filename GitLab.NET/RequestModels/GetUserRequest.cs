using JetBrains.Annotations;
using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetUserRequest : IRequestModel
    {
        public const string ByIdResource = "users/{id}";
        public const string ByUsernameResource = "users";

        private readonly int? _id;
        private readonly string _username;

        public GetUserRequest(int id)
        {
            _id = id;
        }

        public GetUserRequest([NotNull] string username)
        {
            _username = username;
        }

        public RestRequest GetRequest()
        {
            if (_username != null)
            {
                var request = new RestRequest(ByUsernameResource, Method.GET);
                request.AddParameter("username", _username);
                return request;
            }
            else
            {
                var request = new RestRequest(ByIdResource, Method.GET);
                request.AddParameter("id", _id, ParameterType.UrlSegment);
                return request;
            }
        }
    }
}