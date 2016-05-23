using RestSharp;
using RestSharp.Authenticators;
using System;

namespace GitLabAPI.NET.Factories
{
    public interface IRestClientFactory
    {
        IRestClient Create(Uri baseUri, IAuthenticator authenticator = null);
    }
}
