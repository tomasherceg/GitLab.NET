using GitLabAPI.NET.Exceptions;
using GitLabAPI.NET.Factories;
using GitLabAPI.NET.Models;
using GitLabAPI.NET.RequestHelpers;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Net;
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

            handleException(response);
            handleErrors(response);

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

            handleException(response);
            handleErrors(response);

            return response;
        }

        private void handleException<T>(IRestResponse<T> response)
        {
            if (response.ErrorException != null)
                throw new ApplicationException("Error retrieving response. Check inner exception for more information.", response.ErrorException);
        }
        
        private void handleErrors<T>(IRestResponse<T> response)
        {
            string message;
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                case HttpStatusCode.Created:
                case HttpStatusCode.NotModified:
                    return;
                case HttpStatusCode.BadRequest:
                    message = getErrorMessage(response);
                    throw new BadRequestException(message);
                case HttpStatusCode.Unauthorized:
                    message = getErrorMessage(response);
                    throw new UnauthorizedException(message);
                case HttpStatusCode.Forbidden:
                    message = getErrorMessage(response);
                    throw new ForbiddenException(message);
                case HttpStatusCode.NotFound:
                    message = getErrorMessage(response);
                    throw new NotFoundException(message);
                case HttpStatusCode.MethodNotAllowed:
                    message = getErrorMessage(response);
                    throw new MethodNotAllowedException(message);
                case HttpStatusCode.Conflict:
                    message = getErrorMessage(response);
                    throw new ConflictException(message);
                case HttpStatusCode.InternalServerError:
                    message = getErrorMessage(response);
                    throw new ServerErrorException(message);
                case (HttpStatusCode)422:
                    message = getErrorMessage(response);
                    throw new UnprocessableException(message);
            }
        }

        private string getErrorMessage<T>(IRestResponse<T> response)
        {
            return SimpleJson.DeserializeObject<Error>(response.Content).Message;
        }
    }
}
