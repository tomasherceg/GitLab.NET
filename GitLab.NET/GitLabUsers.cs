using GitLab.NET.RestModels;
using GitLab.NET.RequestModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitLab.NET
{
    public class GitLabUsers : GitLabBase
    {
        public GitLabUsers(string privateToken, Uri hostUri) : base(privateToken, hostUri) { }

        /// <summary>
        /// Gets a user by the user's id.
        /// </summary>
        /// <param name="id">The user's id.</param>
        /// <returns>The user if one was found, null if no user was found.</returns>
        public User Get(int id)
        {
            var request = new GetUser(id);

            var result = restExecutor.Execute<User>(request);

            return result.Data;
        }

        /// <summary>
        /// Gets a user by the user's id.
        /// </summary>
        /// <param name="id">The user's id.</param>
        /// <returns>The user if one was found, null if no user was found.</returns>
        public async Task<User> GetAsync(int id)
        {
            var request = new GetUser(id);

            var result = await restExecutor.ExecuteAsync<User>(request);

            return result.Data;
        }

        /// <summary>
        /// Gets a user by username.
        /// </summary>
        /// <param name="username">The user's username.</param>
        /// <returns>The user if one was found, null if no user was found.</returns>
        public User Get(string username)
        {
            var request = new GetUser(username);

            var result = restExecutor.Execute<User>(request);

            return result.Data;
        }

        /// <summary>
        /// Gets a user by username.
        /// </summary>
        /// <param name="username">The user's username.</param>
        /// <returns>The user if one was found, null if no user was found.</returns>
        public async Task<User> GetAsync(string username)
        {
            var request = new GetUser(username);

            var result = await restExecutor.ExecuteAsync<User>(request);

            return result.Data;
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <param name="resultsPerPage">The number of results to return per request.</param>
        /// <returns>A PaginatedResult containing a List of Users.</returns>
        public PaginatedResult<User> GetAll(int resultsPerPage = 20)
        {
            return GetAll(1, resultsPerPage);
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <param name="resultsPerPage">The number of results to return per request.</param>
        /// <returns>A PaginatedResult containing a List of Users.</returns>
        public async Task<PaginatedResult<User>> GetAllAsync(int resultsPerPage = 20)
        {
            return await GetAllAsync(1, resultsPerPage);
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <param name="page">The page number for a paginated request.</param>
        /// <param name="resultsPerPage">The number of results to return per request.</param>
        /// <returns>A PaginatedResult containing a List of Users.</returns>
        public PaginatedResult<User> GetAll(int page, int resultsPerPage = 20)
        {
            var request = new GetUsers(page, resultsPerPage);

            var result = restExecutor.Execute<List<User>>(request);

            return PaginatedResult<User>.Create(result);
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <param name="page">The page number for a paginated request.</param>
        /// <param name="resultsPerPage">The number of results to return per request.</param>
        /// <returns>A PaginatedResult containing a List of Users.</returns>
        public async Task<PaginatedResult<User>> GetAllAsync(int page, int resultsPerPage = 20)
        {
            var request = new GetUsers(page, resultsPerPage);

            var result = await restExecutor.ExecuteAsync<List<User>>(request);

            return PaginatedResult<User>.Create(result);
        }

        /// <summary>
        /// Searches for a user by email address or name.
        /// </summary>
        /// <param name="searchQuery">The user's name or email address.</param>
        /// <param name="resultsPerPage">The number of results to return per request.</param>
        /// <returns>A PaginatedResult containing a List of Users matching the provided name or email address.</returns>
        public PaginatedResult<User> Search(string searchQuery, int resultsPerPage = 20)
        {
            return Search(searchQuery, 1, resultsPerPage);
        }

        /// <summary>
        /// Searches for a user by email address or name.
        /// </summary>
        /// <param name="searchQuery">The user's name or email address.</param>
        /// <param name="resultsPerPage">The number of results to return per request.</param>
        /// <returns>A PaginatedResult containing a List of Users matching the provided name or email address.</returns>
        public async Task<PaginatedResult<User>> SearchAsync(string searchQuery, int resultsPerPage = 20)
        {
            return await SearchAsync(searchQuery, 1, resultsPerPage);
        }

        /// <summary>
        /// Searches for a user by email address or name.
        /// </summary>
        /// <param name="searchQuery">The user's name or email address.</param>
        /// <param name="page">The page number for a paginated request.</param>
        /// <param name="resultsPerPage">The number of results to return per request.</param>
        /// <returns>A PaginatedResult containing a List of Users matching the provided name or email address.</returns>
        public PaginatedResult<User> Search(string searchQuery, int page, int resultsPerPage = 20)
        {
            var request = new GetUsers(searchQuery, page, resultsPerPage);

            var result = restExecutor.Execute<List<User>>(request);

            return PaginatedResult<User>.Create(result);
        }

        /// <summary>
        /// Searches for a user by email address or name.
        /// </summary>
        /// <param name="searchQuery">The user's name or email address.</param>
        /// <param name="page">The page number for a paginated request.</param>
        /// <param name="resultsPerPage">The number of results to return per request.</param>
        /// <returns>A PaginatedResult containing a List of Users matching the provided name or email address.</returns>
        public async Task<PaginatedResult<User>> SearchAsync(string searchQuery, int page, int resultsPerPage = 20)
        {
            var request = new GetUsers(searchQuery, page, resultsPerPage);

            var result = await restExecutor.ExecuteAsync<List<User>>(request);

            return PaginatedResult<User>.Create(result);
        }
    }
}
