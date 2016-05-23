﻿using GitLabAPI.NET.Factories;
using GitLabAPI.NET.Helpers;
using GitLabAPI.NET.Models;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace GitLabAPI.NET
{
    /// <summary>
    /// Retrieves a private token for a given username/password combination.
    /// </summary>
    public class UserAuthenticator
    {
        public IRestClientFactory RestClientFactory { get; set; } = new RestClientFactory();
        
        private const string apiPath = "/api/v3";

        private RestExecutor restExecutor;

        /// <summary>
        /// Creates a new instance of UserAuthenticator.
        /// </summary>
        /// <param name="hostUri">The url for the GitLab server without /api/v3.</param>
        public UserAuthenticator(Uri hostUri)
        {
            var baseUri = new Uri(hostUri, apiPath);

            restExecutor = new RestExecutor(baseUri);
        }

        /// <summary>
        /// Synchronously retrieves a private token for a user.
        /// </summary>
        /// <param name="user">The username or email address for the user.</param>
        /// <param name="password">The user's password.</param>
        /// <returns>The user's private token. Null if the username/password was incorrect.</returns>
        public string GetPrivateToken(string user, string password)
        {
            var request = createSessionRequest(user, password);

            var response = restExecutor.Execute<User>(request);

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.Created:
                    return response.Data.PrivateToken;
                case System.Net.HttpStatusCode.Unauthorized:
                    return null;
                default:
                    throw new NotSupportedException("An unhandled status code was encountered: '" + response.StatusCode.ToString() + "'.");
            }
        }

        /// <summary>
        /// Asynchronously retrieves a private token for a user.
        /// </summary>
        /// <param name="user">The username or email address for the user.</param>
        /// <param name="password">The user's password.</param>
        /// <returns>The user's private token. Null if the username/password was incorrect.</returns>
        public async Task<string> GetPrivateTokenAsync(string user, string password)
        {
            var request = createSessionRequest(user, password);

            var response = await restExecutor.ExecuteAsync<User>(request);

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.Created:
                    return response.Data.PrivateToken;
                case System.Net.HttpStatusCode.Unauthorized:
                    return null;
                default:
                    throw new NotSupportedException("An unhandled status code was encountered: '" + response.StatusCode.ToString() + "'.");
            }
        }

        private RestRequest createSessionRequest(string user, string password)
        {
            var request = new RestRequest(Method.POST);
            request.AddParameter("login", user);
            request.AddParameter("password", password);

            return request;
        }
    }
}
