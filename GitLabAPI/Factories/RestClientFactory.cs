using RestSharp;
using System;

namespace GitLabAPI.Factories
{
    public class RestClientFactory : IRestClientFactory
    {
        public IRestClient Create()
        {
            return new RestClient();
        }
    }
}
