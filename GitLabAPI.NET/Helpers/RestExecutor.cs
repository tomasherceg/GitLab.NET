using GitLabAPI.NET.Factories;
using GitLabAPI.NET.RequestHelpers;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Threading.Tasks;

namespace GitLabAPI.NET.Helpers
{
    public class RestExecutor
    {
        private Uri baseUri;
        private IAuthenticator authenticator;
        private IRestClientFactory restClientFactory;

        public RestExecutor(IRestClientFactory restClientFactory, Uri baseUri, IAuthenticator authenticator = null)
        {
            if (baseUri == null)
                throw new ArgumentNullException(nameof(baseUri));

            if (restClientFactory == null)
                throw new ArgumentNullException(nameof(restClientFactory));

            this.baseUri = baseUri;
            this.authenticator = authenticator;
            this.restClientFactory = restClientFactory;
        }

        /// <summary>
        /// Executes a request synchronously and returns its result.
        /// </summary>
        /// <typeparam name="T">The type to deserialize the response to.</typeparam>
        /// <param name="request">The IRestRequest to execute.</param>
        /// <returns>An object of type T with the deserialized data.</returns>
        public IRestResponse<T> Execute<T>(IRequestHelper request) where T : new()
        {
            var client = restClientFactory.Create(baseUri, authenticator);

            var response = client.Execute<T>(request.GetRequest());

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                throw new ApplicationException(message, response.ErrorException);
            }

            return response;
        }

        /// <summary>
        /// Executes a request asynchronously and returns its result.
        /// </summary>
        /// <typeparam name="T">The type to deserialize the response to.</typeparam>
        /// <param name="request">The IRestRequest to execute.</param>
        /// <returns>An object of type T with the deserialized data.</returns>
        public async Task<IRestResponse<T>> ExecuteAsync<T>(IRequestHelper request) where T : new()
        {
            var client = restClientFactory.Create(baseUri, authenticator);

            var response = await client.ExecuteTaskAsync<T>(request.GetRequest());

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                throw new ApplicationException(message, response.ErrorException);
            }

            return response;
        }
    }
}
