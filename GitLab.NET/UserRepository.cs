using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitLab.NET.RequestModels;
using GitLab.NET.ResponseModels;

namespace GitLab.NET
{
    /// <summary> Provides GitLab User access in a repository pattern. </summary>
    public class UserRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="UserRepository" /> instance. </summary>
        /// <param name="restExecutor"> An instance of <see cref="IRequestExecutor" /> to use for this repository. </param>
        public UserRepository(IRequestExecutor restExecutor) : base(restExecutor) { }

        /// <summary> Finds a user by id. </summary>
        /// <param name="id"> The user's id. </param>
        /// <returns> A <see cref="RequestResult{T}" /> representing the results of the request. </returns>
        public RequestResult<User> FindById(uint id)
        {
            var request = new GetUserRequest(id);

            var result = RequestExecutor.Execute<User>(request);

            return new RequestResult<User>(result);
        }

        /// <summary> Finds a user by id. </summary>
        /// <param name="id"> The user's id. </param>
        /// <returns> A <see cref="RequestResult{T}" /> representing the results of the request. </returns>
        public async Task<RequestResult<User>> FindByIdAsync(uint id)
        {
            var request = new GetUserRequest(id);

            var result = await RequestExecutor.ExecuteAsync<User>(request);

            return new RequestResult<User>(result);
        }

        /// <summary> Finds a user by username. </summary>
        /// <param name="username"> The user's username. </param>
        /// <returns> A <see cref="RequestResult{T}" /> representing the results of the request. </returns>
        public RequestResult<User> FindByUsername(string username)
        {
            if (username == null)
                throw new ArgumentNullException(nameof(username));

            var request = new GetUserRequest(username);

            var result = RequestExecutor.Execute<User>(request);

            return new RequestResult<User>(result);
        }

        /// <summary> Finds a user by username. </summary>
        /// <param name="username"> The user's username. </param>
        /// <returns> A <see cref="RequestResult{T}" /> representing the results of the request. </returns>
        public async Task<RequestResult<User>> FindByUsernameAsync(string username)
        {
            if (username == null)
                throw new ArgumentNullException(nameof(username));

            var request = new GetUserRequest(username);

            var result = await RequestExecutor.ExecuteAsync<User>(request);

            return new RequestResult<User>(result);
        }

        /// <summary> Gets all users. </summary>
        /// <param name="page"> The page number for a paginated request. </param>
        /// <param name="resultsPerPage"> The number of results to return per request. </param>
        /// <returns> A <see cref="PaginatedResult{T}" /> representing the results of the request. </returns>
        public PaginatedResult<User> GetAll(uint page = Config.DefaultPage, uint resultsPerPage = Config.DefaultResultsPerPage)
        {
            if (page < Config.DefaultPage)
                throw new ArgumentOutOfRangeException(nameof(page));

            if (resultsPerPage < Config.MinResultsPerPage || resultsPerPage > Config.MaxResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage));

            var request = new GetUsersRequest(page, resultsPerPage);

            var result = RequestExecutor.Execute<List<User>>(request);

            return new PaginatedResult<User>(result);
        }

        /// <summary> Gets all users. </summary>
        /// <param name="page"> The page number for a paginated request. </param>
        /// <param name="resultsPerPage"> The number of results to return per request. </param>
        /// <returns> A <see cref="PaginatedResult{T}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<User>> GetAllAsync(uint page = Config.DefaultPage, uint resultsPerPage = Config.DefaultResultsPerPage)
        {
            if (page < Config.DefaultPage)
                throw new ArgumentOutOfRangeException(nameof(page));

            if (resultsPerPage < Config.MinResultsPerPage || resultsPerPage > Config.MaxResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage));

            var request = new GetUsersRequest(page, resultsPerPage);

            var result = await RequestExecutor.ExecuteAsync<List<User>>(request);

            return new PaginatedResult<User>(result);
        }

        /// <summary> Searches for a user by email address or name. </summary>
        /// <param name="searchQuery"> The user's name or email address. </param>
        /// <param name="page"> The page number for a paginated request. </param>
        /// <param name="resultsPerPage"> The number of results to return per request. </param>
        /// <returns> A <see cref="PaginatedResult{T}" /> representing the results of the request. </returns>
        public PaginatedResult<User> Search(string searchQuery, uint page = Config.DefaultPage, uint resultsPerPage = Config.DefaultResultsPerPage)
        {
            if (searchQuery == null)
                throw new ArgumentNullException(nameof(searchQuery));

            if (page < Config.DefaultPage)
                throw new ArgumentOutOfRangeException(nameof(page));

            if (resultsPerPage < Config.MinResultsPerPage || resultsPerPage > Config.MaxResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage));

            var request = new GetUsersRequest(searchQuery, page, resultsPerPage);

            var result = RequestExecutor.Execute<List<User>>(request);

            return new PaginatedResult<User>(result);
        }

        /// <summary> Searches for a user by email address or name. </summary>
        /// <param name="searchQuery"> The user's name or email address. </param>
        /// <param name="page"> The page number for a paginated request. </param>
        /// <param name="resultsPerPage"> The number of results to return per request. </param>
        /// <returns> A <see cref="PaginatedResult{T}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<User>> SearchAsync(string searchQuery, uint page = Config.DefaultPage, uint resultsPerPage = Config.DefaultResultsPerPage)
        {
            if (searchQuery == null)
                throw new ArgumentNullException(nameof(searchQuery));

            if (page < Config.DefaultPage)
                throw new ArgumentOutOfRangeException(nameof(page));

            if (resultsPerPage < Config.MinResultsPerPage || resultsPerPage > Config.MaxResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage));

            var request = new GetUsersRequest(searchQuery, page, resultsPerPage);

            var result = await RequestExecutor.ExecuteAsync<List<User>>(request);

            return new PaginatedResult<User>(result);
        }
    }
}