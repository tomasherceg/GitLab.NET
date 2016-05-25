using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using GitLab.NET.RequestModels;
using GitLab.NET.ResponseModels;

namespace GitLab.NET
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class UserRepository : RepositoryBase
    {
        public UserRepository(IRestExecutor restExecutor) : base(restExecutor) { }

        /// <summary>
        ///     Finds a user by the user's id.
        /// </summary>
        /// <param name="id">The user's id.</param>
        /// <returns>The user if one was found, null if no user was found.</returns>
        public User FindById(int id)
        {
            var request = new GetUserRequest(id);

            var result = RestExecutor.Execute<User>(request);

            return result.Data;
        }

        /// <summary>
        ///     Finds a user by the user's id.
        /// </summary>
        /// <param name="id">The user's id.</param>
        /// <returns>The user if one was found, null if no user was found.</returns>
        public async Task<User> FindByIdAsync(int id)
        {
            var request = new GetUserRequest(id);

            var result = await RestExecutor.ExecuteAsync<User>(request);

            return result.Data;
        }

        /// <summary>
        ///     Finds a user by username.
        /// </summary>
        /// <param name="username">The user's username.</param>
        /// <returns>The user if one was found, null if no user was found.</returns>
        public User FindByUsername(string username)
        {
            var request = new GetUserRequest(username);

            var result = RestExecutor.Execute<User>(request);

            return result.Data;
        }

        /// <summary>
        ///     Finds a user by username.
        /// </summary>
        /// <param name="username">The user's username.</param>
        /// <returns>The user if one was found, null if no user was found.</returns>
        public async Task<User> FindByUsernameAsync(string username)
        {
            var request = new GetUserRequest(username);

            var result = await RestExecutor.ExecuteAsync<User>(request);

            return result.Data;
        }

        /// <summary>
        ///     Gets all users.
        /// </summary>
        /// <param name="page">The page number for a paginated request.</param>
        /// <param name="resultsPerPage">The number of results to return per request.</param>
        /// <returns>A PaginatedResult containing a List of Users.</returns>
        public PaginatedResult<User> GetAll(int page = DefaultPage, int resultsPerPage = DefaultResultsPerPage)
        {
            var request = new GetUsersRequest(page, resultsPerPage);

            var result = RestExecutor.Execute<List<User>>(request);

            return PaginatedResult<User>.Create(result);
        }

        /// <summary>
        ///     Gets all users.
        /// </summary>
        /// <param name="page">The page number for a paginated request.</param>
        /// <param name="resultsPerPage">The number of results to return per request.</param>
        /// <returns>A PaginatedResult containing a List of Users.</returns>
        public async Task<PaginatedResult<User>> GetAllAsync(int page = DefaultPage, int resultsPerPage = DefaultResultsPerPage)
        {
            var request = new GetUsersRequest(page, resultsPerPage);

            var result = await RestExecutor.ExecuteAsync<List<User>>(request);

            return PaginatedResult<User>.Create(result);
        }

        /// <summary>
        ///     Searches for a user by email address or name.
        /// </summary>
        /// <param name="searchQuery">The user's name or email address.</param>
        /// <param name="page">The page number for a paginated request.</param>
        /// <param name="resultsPerPage">The number of results to return per request.</param>
        /// <returns>A PaginatedResult containing a List of Users matching the provided name or email address.</returns>
        public PaginatedResult<User> Search(string searchQuery, int page = DefaultPage, int resultsPerPage = DefaultResultsPerPage)
        {
            var request = new GetUsersRequest(searchQuery, page, resultsPerPage);

            var result = RestExecutor.Execute<List<User>>(request);

            return PaginatedResult<User>.Create(result);
        }

        /// <summary>
        ///     Searches for a user by email address or name.
        /// </summary>
        /// <param name="searchQuery">The user's name or email address.</param>
        /// <param name="page">The page number for a paginated request.</param>
        /// <param name="resultsPerPage">The number of results to return per request.</param>
        /// <returns>A PaginatedResult containing a List of Users matching the provided name or email address.</returns>
        public async Task<PaginatedResult<User>> SearchAsync(string searchQuery, int page = DefaultPage, int resultsPerPage = DefaultResultsPerPage)
        {
            var request = new GetUsersRequest(searchQuery, page, resultsPerPage);

            var result = await RestExecutor.ExecuteAsync<List<User>>(request);

            return PaginatedResult<User>.Create(result);
        }
    }
}