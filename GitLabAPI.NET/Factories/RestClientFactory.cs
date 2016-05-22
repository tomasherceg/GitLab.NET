using RestSharp;
using System;

namespace GitLabAPI.NET.Factories
{
    public class RestClientFactory : IRestClientFactory
    {
        public IRestClient Create()
        {
            return new RestClient();
        }
    }
}
