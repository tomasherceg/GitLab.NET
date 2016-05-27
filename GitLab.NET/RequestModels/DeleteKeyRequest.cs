using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class DeleteKeyRequest : IRequestModel
    {
        public const string ForCurrentUserResource = "user/keys/{id}";
        public const string ForSpecifiedUserResource = "user/{userId}/keys/{id}";

        private readonly uint _id;
        private readonly uint? _userId;

        public DeleteKeyRequest(uint id, uint? userId = null)
        {
            _id = id;
            _userId = userId;
        }

        public IRestRequest GetRequest()
        {
            if (_userId != null)
            {
                var result = new RestRequest(ForSpecifiedUserResource, Method.DELETE);
                result.AddParameter("id", _id, ParameterType.UrlSegment);
                result.AddParameter("userId", _userId, ParameterType.UrlSegment);
                return result;
            }
            else
            {
                var result = new RestRequest(ForCurrentUserResource, Method.DELETE);
                result.AddParameter("id", _id, ParameterType.UrlSegment);
                return result;
            }
        }
    }
}