using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetUserKeysRequest : IRequestModel
    {
        public const string ForCurrentUserRequest = "user/keys";
        public const string ForSpecifiedUserRequest = "users/{id}/keys";

        private readonly uint? _userId;

        public GetUserKeysRequest() { }

        public GetUserKeysRequest(uint userId)
        {
            _userId = userId;
        }

        public IRestRequest GetRequest()
        {
            if (_userId != null)
            {
                var request = new RestRequest(ForSpecifiedUserRequest, Method.GET);
                request.AddParameter("id", _userId, ParameterType.UrlSegment);
                return request;
            }
            else
            {
                var request = new RestRequest(ForCurrentUserRequest, Method.GET);
                return request;
            }
        }
    }
}