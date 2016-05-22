using RestSharp;
using System;

namespace GitLabAPI.Factories
{
    public class RestRequestFactory : IRestRequestFactory
    {
        public IRestRequest Create()
        {
            return new RestRequest();
        }
    }
}
