// ReSharper disable UnusedMember.Global
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

        /// <summary> Blocks a user. </summary>
        /// <param name="id"> The user's ID. </param>
        /// <returns> A <see cref="RequestResult{User}" /> representing the results of the request. </returns>
        public RequestResult<User> Block(uint id)
        {
            var request = new BlockUserRequest(id);

            var result = RequestExecutor.Execute<User>(request);

            return new RequestResult<User>(result);
        }

        /// <summary> Blocks a user. </summary>
        /// <param name="id"> The user's ID. </param>
        /// <returns> A <see cref="RequestResult{User}" /> representing the results of the request. </returns>
        public async Task<RequestResult<User>> BlockAsync(uint id)
        {
            var request = new BlockUserRequest(id);

            var result = await RequestExecutor.ExecuteAsync<User>(request);

            return new RequestResult<User>(result);
        }

        /// <summary> Creates a new user. </summary>
        /// <param name="email"> The user's email address. </param>
        /// <param name="password"> The user's password. </param>
        /// <param name="username"> The user's username. </param>
        /// <param name="name"> The user's full name. </param>
        /// <param name="skype"> The user's Skype profile. </param>
        /// <param name="linkedIn"> The user's LinkedIn profile. </param>
        /// <param name="twitter"> The user's Twitter profile. </param>
        /// <param name="websiteUrl"> The user's website URL. </param>
        /// <param name="projectsLimit"> The maximum projects the user is allowed to create. </param>
        /// <param name="externUid"> The UID for the external authentication provider. </param>
        /// <param name="provider"> The external provider. </param>
        /// <param name="bio"> The user's bio. </param>
        /// <param name="location"> The user's location. </param>
        /// <param name="admin"> Whether or not the user should receive administrator privileges. </param>
        /// <param name="canCreateGroup"> Whether or not the user can create groups. </param>
        /// <param name="confirm"> Whether or not the user needs to confirm their account. </param>
        /// <param name="external"> Whether or not the user's account should be flagged as external. </param>
        /// <returns> A <see cref="RequestResult{User}" /> representing the results of the request. </returns>
        public RequestResult<User> Create(string email,
                                          string password,
                                          string username,
                                          string name,
                                          string skype = null,
                                          string linkedIn = null,
                                          string twitter = null,
                                          string websiteUrl = null,
                                          uint? projectsLimit = null,
                                          string externUid = null,
                                          string provider = null,
                                          string bio = null,
                                          string location = null,
                                          bool? admin = null,
                                          bool? canCreateGroup = null,
                                          bool? confirm = null,
                                          bool? external = null)
        {
            if (email == null)
                throw new ArgumentNullException(nameof(email));

            if (password == null)
                throw new ArgumentNullException(nameof(password));

            if (username == null)
                throw new ArgumentNullException(nameof(username));

            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var request = new CreateUserRequest(email, password, username, name, skype, linkedIn, twitter, websiteUrl, projectsLimit, externUid, provider, bio, location, admin, canCreateGroup, confirm,
                                                external);

            var result = RequestExecutor.Execute<User>(request);

            return new RequestResult<User>(result);
        }

        /// <summary> Creates a new user. </summary>
        /// <param name="email"> The user's email address. </param>
        /// <param name="password"> The user's password. </param>
        /// <param name="username"> The user's username. </param>
        /// <param name="name"> The user's full name. </param>
        /// <param name="skype"> The user's Skype profile. </param>
        /// <param name="linkedIn"> The user's LinkedIn profile. </param>
        /// <param name="twitter"> The user's Twitter profile. </param>
        /// <param name="websiteUrl"> The user's website URL. </param>
        /// <param name="projectsLimit"> The maximum projects the user is allowed to create. </param>
        /// <param name="externUid"> The UID for the external authentication provider. </param>
        /// <param name="provider"> The external provider. </param>
        /// <param name="bio"> The user's bio. </param>
        /// <param name="location"> The user's location. </param>
        /// <param name="admin"> Whether or not the user should receive administrator privileges. </param>
        /// <param name="canCreateGroup"> Whether or not the user can create groups. </param>
        /// <param name="confirm"> Whether or not the user needs to confirm their account. </param>
        /// <param name="external"> Whether or not the user's account should be flagged as external. </param>
        /// <returns> A <see cref="RequestResult{User}" /> representing the results of the request. </returns>
        public async Task<RequestResult<User>> CreateAsync(string email,
                                                           string password,
                                                           string username,
                                                           string name,
                                                           string skype = null,
                                                           string linkedIn = null,
                                                           string twitter = null,
                                                           string websiteUrl = null,
                                                           uint? projectsLimit = null,
                                                           string externUid = null,
                                                           string provider = null,
                                                           string bio = null,
                                                           string location = null,
                                                           bool? admin = null,
                                                           bool? canCreateGroup = null,
                                                           bool? confirm = null,
                                                           bool? external = null)
        {
            if (email == null)
                throw new ArgumentNullException(nameof(email));

            if (password == null)
                throw new ArgumentNullException(nameof(password));

            if (username == null)
                throw new ArgumentNullException(nameof(username));

            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var request = new CreateUserRequest(email, password, username, name, skype, linkedIn, twitter, websiteUrl, projectsLimit, externUid, provider, bio, location, admin, canCreateGroup, confirm,
                                                external);

            var result = await RequestExecutor.ExecuteAsync<User>(request);

            return new RequestResult<User>(result);
        }

        /// <summary> Gets all users. </summary>
        /// <param name="page"> The page number for a paginated request. </param>
        /// <param name="resultsPerPage"> The number of results to return per request. </param>
        /// <returns> A <see cref="PaginatedResult{User}" /> representing the results of the request. </returns>
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
        /// <returns> A <see cref="PaginatedResult{User}" /> representing the results of the request. </returns>
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

        /// <summary> Gets a user by id. </summary>
        /// <param name="id"> The user's id. </param>
        /// <returns> A <see cref="RequestResult{User}" /> representing the results of the request. </returns>
        public RequestResult<User> GetById(uint id)
        {
            var request = new GetUserRequest(id);

            var result = RequestExecutor.Execute<User>(request);

            return new RequestResult<User>(result);
        }

        /// <summary> Gets a user by id. </summary>
        /// <param name="id"> The user's id. </param>
        /// <returns> A <see cref="RequestResult{User}" /> representing the results of the request. </returns>
        public async Task<RequestResult<User>> GetByIdAsync(uint id)
        {
            var request = new GetUserRequest(id);

            var result = await RequestExecutor.ExecuteAsync<User>(request);

            return new RequestResult<User>(result);
        }

        /// <summary> Gets a user by username. </summary>
        /// <param name="username"> The user's username. </param>
        /// <returns> A <see cref="RequestResult{User}" /> representing the results of the request. </returns>
        public RequestResult<User> GetByUsername(string username)
        {
            if (username == null)
                throw new ArgumentNullException(nameof(username));

            var request = new GetUserRequest(username);

            var result = RequestExecutor.Execute<User>(request);

            return new RequestResult<User>(result);
        }

        /// <summary> Gets a user by username. </summary>
        /// <param name="username"> The user's username. </param>
        /// <returns> A <see cref="RequestResult{User}" /> representing the results of the request. </returns>
        public async Task<RequestResult<User>> GetByUsernameAsync(string username)
        {
            if (username == null)
                throw new ArgumentNullException(nameof(username));

            var request = new GetUserRequest(username);

            var result = await RequestExecutor.ExecuteAsync<User>(request);

            return new RequestResult<User>(result);
        }

        /// <summary> Gets the currently authenticated user. </summary>
        /// <returns> A <see cref="RequestResult{User}" /> representing the results of the request. </returns>
        public RequestResult<User> GetCurrent()
        {
            var request = new GetUserRequest();

            var result = RequestExecutor.Execute<User>(request);

            return new RequestResult<User>(result);
        }

        /// <summary> Gets the currently authenticated user. </summary>
        /// <returns> A <see cref="RequestResult{User}" /> representing the results of the request. </returns>
        public async Task<RequestResult<User>> GetCurrentAsync()
        {
            var request = new GetUserRequest();

            var result = await RequestExecutor.ExecuteAsync<User>(request);

            return new RequestResult<User>(result);
        }

        /// <summary> Searches for a user by email address or name. </summary>
        /// <param name="searchQuery"> The user's name or email address. </param>
        /// <param name="page"> The page number for a paginated request. </param>
        /// <param name="resultsPerPage"> The number of results to return per request. </param>
        /// <returns> A <see cref="PaginatedResult{User}" /> representing the results of the request. </returns>
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
        /// <returns> A <see cref="PaginatedResult{User}" /> representing the results of the request. </returns>
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

        /// <summary> Unblocks a user. </summary>
        /// <param name="id"> The user's ID. </param>
        /// <returns> A <see cref="RequestResult{User}" /> representing the results of the request. </returns>
        public RequestResult<User> Unblock(uint id)
        {
            var request = new UnblockUserRequest(id);

            var result = RequestExecutor.Execute<User>(request);

            return new RequestResult<User>(result);
        }

        /// <summary> Unblocks a user. </summary>
        /// <param name="id"> The user's ID. </param>
        /// <returns> A <see cref="RequestResult{User}" /> representing the results of the request. </returns>
        public async Task<RequestResult<User>> UnblockAsync(uint id)
        {
            var request = new UnblockUserRequest(id);

            var result = await RequestExecutor.ExecuteAsync<User>(request);

            return new RequestResult<User>(result);
        }

        /// <summary> Updates information for a user. </summary>
        /// <param name="id"> The user's ID. </param>
        /// <param name="email"> The user's email address. </param>
        /// <param name="password"> The user's password. </param>
        /// <param name="username"> The user's username. </param>
        /// <param name="name"> The user's full name. </param>
        /// <param name="skype"> The user's Skype profile. </param>
        /// <param name="linkedIn"> The user's LinkedIn profile. </param>
        /// <param name="twitter"> The user's Twitter profile. </param>
        /// <param name="websiteUrl"> The user's website URL. </param>
        /// <param name="projectsLimit"> The maximum projects the user is allowed to create. </param>
        /// <param name="externUid"> The UID for the external authentication provider. </param>
        /// <param name="provider"> The external provider. </param>
        /// <param name="bio"> The user's bio. </param>
        /// <param name="location"> The user's location. </param>
        /// <param name="admin"> Whether or not the user should receive administrator privileges. </param>
        /// <param name="canCreateGroup"> Whether or not the user can create groups. </param>
        /// <param name="external"> Whether or not the user's account should be flagged as external. </param>
        /// <returns> A <see cref="RequestResult{User}" /> representing the results of the request. </returns>
        public RequestResult<User> Update(uint id,
                                          string email = null,
                                          string password = null,
                                          string username = null,
                                          string name = null,
                                          string skype = null,
                                          string linkedIn = null,
                                          string twitter = null,
                                          string websiteUrl = null,
                                          uint? projectsLimit = null,
                                          string externUid = null,
                                          string provider = null,
                                          string bio = null,
                                          string location = null,
                                          bool? admin = null,
                                          bool? canCreateGroup = null,
                                          bool? external = null)
        {
            var request = new UpdateUserRequest(id, email, password, username, name, skype, linkedIn, twitter, websiteUrl, projectsLimit, externUid, provider, bio, location, admin, canCreateGroup,
                                                external);

            var result = RequestExecutor.Execute<User>(request);

            return new RequestResult<User>(result);
        }

        /// <summary> Updates information for a user. </summary>
        /// <param name="id"> The user's ID. </param>
        /// <param name="email"> The user's email address. </param>
        /// <param name="password"> The user's password. </param>
        /// <param name="username"> The user's username. </param>
        /// <param name="name"> The user's full name. </param>
        /// <param name="skype"> The user's Skype profile. </param>
        /// <param name="linkedIn"> The user's LinkedIn profile. </param>
        /// <param name="twitter"> The user's Twitter profile. </param>
        /// <param name="websiteUrl"> The user's website URL. </param>
        /// <param name="projectsLimit"> The maximum projects the user is allowed to create. </param>
        /// <param name="externUid"> The UID for the external authentication provider. </param>
        /// <param name="provider"> The external provider. </param>
        /// <param name="bio"> The user's bio. </param>
        /// <param name="location"> The user's location. </param>
        /// <param name="admin"> Whether or not the user should receive administrator privileges. </param>
        /// <param name="canCreateGroup"> Whether or not the user can create groups. </param>
        /// <param name="external"> Whether or not the user's account should be flagged as external. </param>
        /// <returns> A <see cref="RequestResult{User}" /> representing the results of the request. </returns>
        public async Task<RequestResult<User>> UpdateAsync(uint id,
                                                           string email = null,
                                                           string password = null,
                                                           string username = null,
                                                           string name = null,
                                                           string skype = null,
                                                           string linkedIn = null,
                                                           string twitter = null,
                                                           string websiteUrl = null,
                                                           uint? projectsLimit = null,
                                                           string externUid = null,
                                                           string provider = null,
                                                           string bio = null,
                                                           string location = null,
                                                           bool? admin = null,
                                                           bool? canCreateGroup = null,
                                                           bool? external = null)
        {
            var request = new UpdateUserRequest(id, email, password, username, name, skype, linkedIn, twitter, websiteUrl, projectsLimit, externUid, provider, bio, location, admin, canCreateGroup,
                                                external);

            var result = await RequestExecutor.ExecuteAsync<User>(request);

            return new RequestResult<User>(result);
        }
    }
}