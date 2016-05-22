using RestSharp;
using System;

namespace GitLabAPI.NET.Factories
{
    public class RestRequestFactory : IRestRequestFactory
    {
        public IRestRequest Create()
        {
            return new RestRequest();
        }
    }
}
