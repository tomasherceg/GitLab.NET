using RestSharp.Authenticators;

namespace GitLab.NET
{
    /// <summary> A GitLab private token authenticator. </summary>
    public interface IPrivateTokenAuthenticator : IAuthenticator
    {
        /// <summary> The user's private token. </summary>
        string PrivateToken { get; set; }
    }
}