using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetLicensesRequest : IRequestModel
    {
        public const string Resource = "licenses";

        private readonly bool? _popular;

        public GetLicensesRequest(bool? popular = null)
        {
            _popular = popular;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.GET);
            result.AddParameterIfNotNull("popular", _popular, ParameterType.GetOrPost);
            return result;
        }
    }
}