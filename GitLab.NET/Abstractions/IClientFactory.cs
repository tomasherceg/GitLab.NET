using RestSharp;

namespace GitLab.NET.Abstractions
{
    internal interface IClientFactory
    {
        IRestClient Create(bool authenticate = true);
    }
}