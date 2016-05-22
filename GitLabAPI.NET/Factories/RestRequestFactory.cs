using RestSharp;
using System;

namespace GitLabAPI.NET.Factories
{
    public class RestRequestFactory : IRestRequestFactory
    {
        public IRestRequest Create(Method method = Method.GET)
        {
            return new RestRequest(method);
        }
    }
}
