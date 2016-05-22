using RestSharp;
using System;

namespace GitLabAPI.Factories
{
    public interface IRestClientFactory
    {
        IRestClient Create();
    }
}
