using System;
using System.Net;
using System.Threading.Tasks;
using GitLab.NET.Exceptions;
using GitLab.NET.ResponseModels;
using JetBrains.Annotations;
using RestSharp;
using RestSharp.Authenticators;

namespace GitLab.NET
{
    public class RestExecutor : IRestExecutor
    {
        private readonly IAuthenticator _authenticator;
        [NotNull] private readonly Uri _baseUri;
        [NotNull] private readonly IRestClientFactory _restClientFactory;

        public RestExecutor(IRestClientFactory restClientFactory, Uri baseUri, IAuthenticator authenticator = null)
        {
            _baseUri = baseUri;
            _authenticator = authenticator;
            _restClientFactory = restClientFactory;
        }

        /// <summary>
        ///     Executes a request synchronously and returns its result.
        /// </summary>
        /// <typeparam name="T">The type to deserialize the response to.</typeparam>
        /// <param name="requestModel">The IRestRequest to execute.</param>
        /// <returns>An object of type T with the deserialized data.</returns>
        public IRestResponse<T> Execute<T>([NotNull] IRequestModel requestModel) where T : new()
        {
            var client = _restClientFactory.Create(_baseUri, _authenticator);

            var response = client.Execute<T>(requestModel.GetRequest());

            HandleException(response);
            HandleErrors(response);

            return response;
        }

        /// <summary>
        ///     Executes a request asynchronously and returns its result.
        /// </summary>
        /// <typeparam name="T">The type to deserialize the response to.</typeparam>
        /// <param name="requestModel">The IRestRequest to execute.</param>
        /// <returns>An object of type T with the deserialized data.</returns>
        public async Task<IRestResponse<T>> ExecuteAsync<T>([NotNull] IRequestModel requestModel) where T : new()
        {
            var client = _restClientFactory.Create(_baseUri, _authenticator);

            var response = await client.ExecuteTaskAsync<T>(requestModel.GetRequest());

            HandleException(response);
            HandleErrors(response);

            return response;
        }

        private static void HandleException(IRestResponse response)
        {
            if (response.ErrorException != null)
                throw new ApplicationException("Error retrieving response. Check inner exception for more information.", response.ErrorException);
        }

        private static void HandleErrors(IRestResponse response)
        {
            string message;
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                case HttpStatusCode.Created:
                case HttpStatusCode.NotModified:
                    return;
                case HttpStatusCode.BadRequest:
                    message = GetErrorMessage(response);
                    throw new BadRequestException(message);
                case HttpStatusCode.Unauthorized:
                    message = GetErrorMessage(response);
                    throw new UnauthorizedException(message);
                case HttpStatusCode.Forbidden:
                    message = GetErrorMessage(response);
                    throw new ForbiddenException(message);
                case HttpStatusCode.NotFound:
                    message = GetErrorMessage(response);
                    throw new NotFoundException(message);
                case HttpStatusCode.MethodNotAllowed:
                    message = GetErrorMessage(response);
                    throw new MethodNotAllowedException(message);
                case HttpStatusCode.Conflict:
                    message = GetErrorMessage(response);
                    throw new ConflictException(message);
                case HttpStatusCode.InternalServerError:
                    message = GetErrorMessage(response);
                    throw new ServerErrorException(message);
                case (HttpStatusCode)422:
                    message = GetErrorMessage(response);
                    throw new UnprocessableException(message);
            }
        }

        private static string GetErrorMessage(IRestResponse response)
        {
            return SimpleJson.DeserializeObject<Error>(response.Content).Message;
        }
    }
}