﻿using System;
using System.Threading.Tasks;
using GitLab.NET.Authenticators;
using GitLab.NET.RequestModels;
using RestSharp;

namespace GitLab.NET.Abstractions
{
    /// <summary> Executes RESTful requests and returns the results. </summary>
    public class RequestExecutor : IRequestExecutor
    {
        private readonly IPrivateTokenAuthenticator _authenticator;
        private readonly Uri _baseUri;
        private readonly IRestClientFactory _restClientFactory;

        /// <summary> Creates a new RequestExecutor instance. </summary>
        /// <param name="restClientFactory"> The IRestClientFactory to use for this instance. </param>
        /// <param name="baseUri"> The URI to send all requests to. </param>
        /// <param name="authenticator"> The IAuthenticator to use for this instance. </param>
        public RequestExecutor(IRestClientFactory restClientFactory, Uri baseUri, IPrivateTokenAuthenticator authenticator)
        {
            if (restClientFactory == null)
                throw new ArgumentNullException(nameof(restClientFactory));

            if (baseUri == null)
                throw new ArgumentNullException(nameof(baseUri));

            if (authenticator == null)
                throw new ArgumentNullException(nameof(authenticator));

            _baseUri = baseUri;
            _authenticator = authenticator;
            _restClientFactory = restClientFactory;
        }

        /// <summary> Executes a request synchronously and returns its result. </summary>
        /// <typeparam name="T"> The type to deserialize the response to. </typeparam>
        /// <param name="request"> The request model to execute. </param>
        /// <param name="authenticate"> Whether or not to use the provided authenticator for this request. </param>
        /// <returns> An <see cref="IRestResponse{T}" /> instance containing the results of the request. </returns>
        public IRestResponse<T> Execute<T>(IRequestModel request, bool authenticate = true) where T : new()
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var client = authenticate ? _restClientFactory.Create(_baseUri, _authenticator) : _restClientFactory.Create(_baseUri);

            var response = client.Execute<T>(request.GetRequest());

            HandleException(response);

            return response;
        }

        /// <summary> Executes a request asynchronously and returns its result. </summary>
        /// <typeparam name="T"> The type to deserialize the response to. </typeparam>
        /// <param name="request"> The request model to execute. </param>
        /// <param name="authenticate"> Whether or not to use the provided authenticator for this request. </param>
        /// <returns> An <see cref="IRestResponse{T}" /> instance containing the results of the request. </returns>
        public async Task<IRestResponse<T>> ExecuteAsync<T>(IRequestModel request, bool authenticate = true) where T : new()
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var client = authenticate ? _restClientFactory.Create(_baseUri, _authenticator) : _restClientFactory.Create(_baseUri);

            var response = await client.ExecuteTaskAsync<T>(request.GetRequest());

            HandleException(response);

            return response;
        }

        /// <summary> Executes a request synchronously and returns its result. </summary>
        /// <param name="request"> The request model to execute. </param>
        /// <param name="authenticate"> Whether or not to use the provided authenticator for this request. </param>
        /// <returns> An <see cref="IRestResponse" /> instance containing the results of the request. </returns>
        public IRestResponse Execute(IRequestModel request, bool authenticate = true)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var client = authenticate ? _restClientFactory.Create(_baseUri, _authenticator) : _restClientFactory.Create(_baseUri);

            var response = client.Execute(request.GetRequest());

            HandleException(response);

            return response;
        }

        /// <summary> Executes a request asynchronously and returns its result. </summary>
        /// <param name="request"> The request model to execute. </param>
        /// <param name="authenticate"> Whether or not to use the provided authenticator for this request. </param>
        /// <returns> An <see cref="IRestResponse" /> instance containing the results of the request. </returns>
        public async Task<IRestResponse> ExecuteAsync(IRequestModel request, bool authenticate = true)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var client = authenticate ? _restClientFactory.Create(_baseUri, _authenticator) : _restClientFactory.Create(_baseUri);

            var response = await client.ExecuteTaskAsync(request.GetRequest());

            HandleException(response);

            return response;
        }

        private static void HandleException(IRestResponse response)
        {
            if (response.ErrorException != null)
                throw response.ErrorException;
        }
    }
}