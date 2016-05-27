using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class DeleteEmailRequest : IRequestModel
    {
        public const string ForCurrentUserResource = "user/emails/{id}";
        public const string ForSpecifiedUserResource = "users/{userId}/emails/{id}";

        private readonly uint _id;
        private readonly uint? _userId;

        public DeleteEmailRequest(uint id, uint? userId = null)
        {
            _id = id;
            _userId = userId;
        }

        public IRestRequest GetRequest()
        {
            if (_userId != null)
            {
                var request = new RestRequest(ForSpecifiedUserResource, Method.DELETE);
                request.AddParameter("userId", _userId, ParameterType.UrlSegment);
                request.AddParameter("id", _id, ParameterType.UrlSegment);
                return request;
            }
            else
            {
                var request = new RestRequest(ForCurrentUserResource, Method.DELETE);
                request.AddParameter("id", _id, ParameterType.UrlSegment);
                return request;
            }
        }
    }
}