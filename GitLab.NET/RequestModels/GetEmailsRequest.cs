using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetEmailsRequest : IRequestModel
    {
        public const string Resource = "user/emails/{id}";

        private readonly uint _id;

        public GetEmailsRequest(uint id)
        {
            _id = id;
        }

        public IRestRequest GetRequest()
        {
            var request = new RestRequest(Resource, Method.GET);
            request.AddParameter("id", _id, ParameterType.UrlSegment);
            return request;
        }
    }
}