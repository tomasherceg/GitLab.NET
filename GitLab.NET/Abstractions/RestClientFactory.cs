using System;
using RestSharp;
using RestSharp.Authenticators;

namespace GitLab.NET.Abstractions
{
    /// <summary> A factory for creating <see cref="IRestClient" /> instances. </summary>
    internal class RestClientFactory : IRestClientFactory
    {
        /// <summary> Creates an <see cref="IRestClient" /> instance. </summary>
        /// <param name="baseUri"> The Uri to pass to the <see cref="IRestClient" />. </param>
        /// <param name="authenticator"> The <see cref="IAuthenticator" /> to use for the <see cref="IRestClient" /> </param>
        /// <returns> An <see cref="IRestClient" /> instance. </returns>
        public IRestClient Create(Uri baseUri, IAuthenticator authenticator = null)
        {
            var result = new RestClient(baseUri)
            {
                Authenticator = authenticator
            };

            return result;
        }
    }
}