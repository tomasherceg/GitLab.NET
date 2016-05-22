using GitLabAPI.NET.Factories;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Threading.Tasks;

namespace GitLabAPI.NET
{
    public class RequestExecutor
    {
        private Uri baseUri;
        private IAuthenticator authenticator;
        private IRestClientFactory restClientFactory = new RestClientFactory();

        public RequestExecutor(Uri baseUri, IAuthenticator authenticator = null)
        {
            if (baseUri == null)
                throw new ArgumentNullException(nameof(baseUri));

            this.baseUri = baseUri;
            this.authenticator = authenticator;
        }

        public RequestExecutor(IRestClientFactory restClientFactory, Uri baseUri, IAuthenticator authenticator = null) : this(baseUri, authenticator)
        {
            this.restClientFactory = restClientFactory;
        }

        /// <summary>
        /// Executes a request synchronously and returns its result.
        /// </summary>
        /// <typeparam name="T">The type to deserialize the response to.</typeparam>
        /// <param name="request">The IRestRequest to execute.</param>
        /// <returns>An object of type T with the deserialized data.</returns>
        public T Execute<T>(RestRequest request) where T : new()
        {
            var client = restClientFactory.Create(baseUri, authenticator);

            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                throw new ApplicationException(message, response.ErrorException);
            }

            return response.Data;
        }

        /// <summary>
        /// Executes a request asynchronously and returns its result.
        /// </summary>
        /// <typeparam name="T">The type to deserialize the response to.</typeparam>
        /// <param name="request">The IRestRequest to execute.</param>
        /// <returns>An object of type T with the deserialized data.</returns>
        public async Task<T> ExecuteAsync<T>(RestRequest request) where T : new()
        {
            var client = restClientFactory.Create(baseUri, authenticator);

            var response = await client.ExecuteTaskAsync<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                throw new ApplicationException(message, response.ErrorException);
            }

            return response.Data;
        }
    }
}
