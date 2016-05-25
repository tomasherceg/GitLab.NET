using System;
using RestSharp;
using RestSharp.Authenticators;

namespace GitLab.NET
{
    public interface IRestClientFactory
    {
        IRestClient Create(Uri baseUri, IAuthenticator authenticator = null);
    }
}