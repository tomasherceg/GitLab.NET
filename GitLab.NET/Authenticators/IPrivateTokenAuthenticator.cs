using RestSharp.Authenticators;

namespace GitLab.NET.Authenticators
{
    internal interface IPrivateTokenAuthenticator : IAuthenticator
    {
        string PrivateToken { get; set; }
    }
}