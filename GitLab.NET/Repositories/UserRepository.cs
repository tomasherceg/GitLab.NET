using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    /// <summary> Provides GitLab User access in a repository pattern. </summary>
    public class UserRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="UserRepository" /> instance. </summary>
        /// <param name="requestFactory"> An instance of <see cref="IRequestFactory" /> to use for this repository. </param>
        public UserRepository(IRequestFactory requestFactory) : base(requestFactory) { }

        /// <summary> Blocks a user. </summary>
        /// <param name="id"> The user's ID. </param>
        /// <returns> A <see cref="RequestResult{User}" /> representing the results of the request. </returns>
        public async Task<RequestResult<User>> Block(uint id)
        {
            var request = RequestFactory.Create("users/{id}/block", Method.Put);

            request.AddUrlSegment("id", id);

            return await request.ExecuteAsync<User>();
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
        public async Task<RequestResult<User>> Create(string email,
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

            var request = RequestFactory.Create("users", Method.Post);

            request.AddParameter("email", email);
            request.AddParameter("password", password);
            request.AddParameter("username", username);
            request.AddParameter("name", name);
            request.AddParameterIfNotNull("skype", skype);
            request.AddParameterIfNotNull("linkedin", linkedIn);
            request.AddParameterIfNotNull("twitter", twitter);
            request.AddParameterIfNotNull("website_url", websiteUrl);
            request.AddParameterIfNotNull("projects_limit", projectsLimit);
            request.AddParameterIfNotNull("extern_uid", externUid);
            request.AddParameterIfNotNull("provider", provider);
            request.AddParameterIfNotNull("bio", bio);
            request.AddParameterIfNotNull("location", location);
            request.AddParameterIfNotNull("admin", admin);
            request.AddParameterIfNotNull("can_create_group", canCreateGroup);
            request.AddParameterIfNotNull("confirm", confirm);
            request.AddParameterIfNotNull("external", external);

            return await request.ExecuteAsync<User>();
        }

        /// <summary> Deletes a user. </summary>
        /// <param name="id"> The user's id. </param>
        /// <returns> A <see cref="RequestResult{User}" /> representing the results of the request. </returns>
        public async Task<RequestResult<User>> Delete(uint id)
        {
            var request = RequestFactory.Create("users/{id}", Method.Delete);

            request.AddUrlSegment("id", id);

            return await request.ExecuteAsync<User>();
        }

        /// <summary> Finds a user by id. </summary>
        /// <param name="id"> The user's id. </param>
        /// <returns> A <see cref="RequestResult{User}" /> representing the results of the request. </returns>
        public async Task<RequestResult<User>> Find(uint id)
        {
            var request = RequestFactory.Create("users/{id}", Method.Get);

            request.AddUrlSegment("id", id);

            return await request.ExecuteAsync<User>();
        }

        /// <summary> Finds a user by username. </summary>
        /// <param name="username"> The user's username. </param>
        /// <returns> A <see cref="RequestResult{User}" /> representing the results of the request. </returns>
        public async Task<RequestResult<User>> Find(string username)
        {
            if (username == null)
                throw new ArgumentNullException(nameof(username));

            var request = RequestFactory.Create("users", Method.Get);

            request.AddParameter("username", username);

            return await request.ExecuteAsync<User>();
        }

        /// <summary> Gets all users. </summary>
        /// <param name="page"> The page number for a paginated request. </param>
        /// <param name="resultsPerPage"> The number of results to return per request. </param>
        /// <returns> A <see cref="PaginatedResult{User}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<User>> GetAll(uint page = Config.DefaultPage, uint resultsPerPage = Config.DefaultResultsPerPage)
        {
            if (page < Config.DefaultPage)
                throw new ArgumentOutOfRangeException(nameof(page), page, "The parameter 'page' must be greater than " + Config.DefaultPage + ".");

            if (resultsPerPage < Config.MinResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage, "The parameter 'resultsPerPage' must be greater than " + Config.MinResultsPerPage + ".");

            if (resultsPerPage > Config.MaxResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage, "The parameter 'resultsPerPage' must be less than " + Config.MaxResultsPerPage + ".");

            var request = RequestFactory.Create("users", Method.Get);

            request.AddParameterIfNotNull("page", page);
            request.AddParameterIfNotNull("per_page", resultsPerPage);

            return await request.ExecutePaginatedAsync<User>();
        }

        /// <summary> Gets the currently authenticated user. </summary>
        /// <returns> A <see cref="RequestResult{User}" /> representing the results of the request. </returns>
        public async Task<RequestResult<User>> GetCurrent()
        {
            var request = RequestFactory.Create("user", Method.Get);

            return await request.ExecuteAsync<User>();
        }

        /// <summary> Searches for a user by email address or name. </summary>
        /// <param name="searchQuery"> The user's name or email address. </param>
        /// <param name="page"> The page number for a paginated request. </param>
        /// <param name="resultsPerPage"> The number of results to return per request. </param>
        /// <returns> A <see cref="PaginatedResult{User}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<User>> Search(string searchQuery, uint page = Config.DefaultPage, uint resultsPerPage = Config.DefaultResultsPerPage)
        {
            if (searchQuery == null)
                throw new ArgumentNullException(nameof(searchQuery));

            if (page < Config.DefaultPage)
                throw new ArgumentOutOfRangeException(nameof(page), page, "The parameter 'page' must be greater than " + Config.DefaultPage + ".");

            if (resultsPerPage < Config.MinResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage, "The parameter 'resultsPerPage' must be greater than " + Config.MinResultsPerPage + ".");

            if (resultsPerPage > Config.MaxResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage, "The parameter 'resultsPerPage' must be less than " + Config.MaxResultsPerPage + ".");

            var request = RequestFactory.Create("users", Method.Get);

            request.AddParameter("search", searchQuery);
            request.AddParameterIfNotNull("page", page);
            request.AddParameterIfNotNull("per_page", resultsPerPage);

            return await request.ExecutePaginatedAsync<User>();
        }

        /// <summary> Unblocks a user. </summary>
        /// <param name="id"> The user's ID. </param>
        /// <returns> A <see cref="RequestResult{User}" /> representing the results of the request. </returns>
        public async Task<RequestResult<User>> Unblock(uint id)
        {
            var request = RequestFactory.Create("users/{id}/unblock", Method.Put);

            request.AddUrlSegment("id", id);

            return await request.ExecuteAsync<User>();
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
        public async Task<RequestResult<User>> Update(uint id,
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
            var request = RequestFactory.Create("users/{id}", Method.Put);

            request.AddUrlSegment("id", id);
            request.AddParameterIfNotNull("email", email);
            request.AddParameterIfNotNull("password", password);
            request.AddParameterIfNotNull("username", username);
            request.AddParameterIfNotNull("name", name);
            request.AddParameterIfNotNull("skype", skype);
            request.AddParameterIfNotNull("linkedin", linkedIn);
            request.AddParameterIfNotNull("twitter", twitter);
            request.AddParameterIfNotNull("website_url", websiteUrl);
            request.AddParameterIfNotNull("projects_limit", projectsLimit);
            request.AddParameterIfNotNull("extern_uid", externUid);
            request.AddParameterIfNotNull("provider", provider);
            request.AddParameterIfNotNull("bio", bio);
            request.AddParameterIfNotNull("location", location);
            request.AddParameterIfNotNull("admin", admin);
            request.AddParameterIfNotNull("can_create_group", canCreateGroup);
            request.AddParameterIfNotNull("external", external);

            return await request.ExecuteAsync<User>();
        }
    }
}