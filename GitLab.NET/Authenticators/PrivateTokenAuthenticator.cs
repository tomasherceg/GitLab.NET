using RestSharp;

namespace GitLab.NET.Authenticators
{
    /// <summary> A GitLab private token authenticator. </summary>
    internal class PrivateTokenAuthenticator : IPrivateTokenAuthenticator
    {
        public PrivateTokenAuthenticator(string privateToken)
        {
            PrivateToken = privateToken;
        }

        /// <summary> The user's private token. </summary>
        public string PrivateToken { get; set; }

        /// <summary> Adds the provided private token to the request as a header. </summary>
        /// <param name="client"> The <see cref="IRestClient" />. </param>
        /// <param name="request"> The <see cref="IRestRequest" /> to add the header to. </param>
        public void Authenticate(IRestClient client, IRestRequest request)
        {
            request.AddParameter("PRIVATE-TOKEN", PrivateToken, ParameterType.HttpHeader);
        }
    }
}