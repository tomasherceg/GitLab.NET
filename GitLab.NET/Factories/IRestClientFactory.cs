using RestSharp;
using RestSharp.Authenticators;
using System;

namespace GitLab.NET.Factories
{
    public interface IRestClientFactory
    {
        IRestClient Create(Uri baseUri, IAuthenticator authenticator = null);
    }
}
