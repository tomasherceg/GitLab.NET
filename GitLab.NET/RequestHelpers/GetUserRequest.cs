using RestSharp;

namespace GitLab.NET.RequestHelpers
{
    public class GetUserRequest : IRequestHelper
    {
        public const string resource = "/account/{UserId}";

        public int? Id { get; set; }

        public GetUserRequest() { }

        public GetUserRequest(int id)
        {
            Id = id;
        }

        public RestRequest GetRequest()
        {
            var request = new RestRequest(Method.GET);

            request.AddParameter("UserId", Id, ParameterType.UrlSegment);

            return request;
        }
    }
}
