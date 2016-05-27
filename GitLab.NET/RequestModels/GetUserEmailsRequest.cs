using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetUserEmailsRequest : IRequestModel
    {
        public const string CurrentUserResource = "user/emails";
        public const string SpecifiedUserResource = "users/{id}/emails";

        private readonly uint? _id;

        public GetUserEmailsRequest() { }

        public GetUserEmailsRequest(uint id)
        {
            _id = id;
        }

        public IRestRequest GetRequest()
        {
            if (_id != null)
            {
                var request = new RestRequest(SpecifiedUserResource, Method.GET);
                request.AddParameter("id", _id, ParameterType.UrlSegment);
                return request;
            }
            else
            {
                var request = new RestRequest(CurrentUserResource, Method.GET);
                return request;
            }
        }
    }
}