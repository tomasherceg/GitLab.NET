using System;
using RestSharp;

namespace GitLab.NET.Authenticators
{
    /// <summary> A GitLab private token authenticator. </summary>
    internal class PrivateTokenAuthenticator : IPrivateTokenAuthenticator
    {
        /// <summary> The user's private token. </summary>
        public string PrivateToken { get; set; }

        /// <summary> Adds the provided private token to the request as a header. </summary>
        /// <param name="client"> The <see cref="IRestClient" />. </param>
        /// <param name="request"> The <see cref="IRestRequest" /> to add the header to. </param>
        public void Authenticate(IRestClient client, IRestRequest request)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (PrivateToken == null)
                throw new NullReferenceException("PrivateToken is null.");

            request.AddParameter("PRIVATE-TOKEN", PrivateToken, ParameterType.HttpHeader);
        }
    }
}