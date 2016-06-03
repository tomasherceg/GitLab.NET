using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    /// <summary> Provides GitLab Settings access in a repository pattern. </summary>
    public class GitLabSettingsRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="GitLabSettingsRepository" /> instance. </summary>
        /// <param name="requestFactory"> An instance of <see cref="IRequestFactory" /> to use for this repository. </param>
        public GitLabSettingsRepository(IRequestFactory requestFactory) : base(requestFactory) { }

        /// <summary> Gets the current settings for the server. </summary>
        /// <returns> A <see cref="RequestResult{GitLabSettings}" /> representing the results of the request. </returns>
        public async Task<RequestResult<GitLabSettings>> Get()
        {
            var request = RequestFactory.Create("application/settings", Method.Get);

            return await request.ExecuteAsync<GitLabSettings>();
        }

        /// <summary> Sets the GitLab server's settings. </summary>
        /// <param name="afterSignOutPath"> Where to redirect users after logout. </param>
        /// <param name="defaultBranchProtection"> The protection level for the default branch. </param>
        /// <param name="defaultProjectVisibility"> The visibility level new projects receive by default. </param>
        /// <param name="defaultProjectsLimit"> The default project limit per user. </param>
        /// <param name="defaultSnippetVisibility"> The visibility level new snippets receive by default. </param>
        /// <param name="gravatarEnabled"> Whether or not gravatars are enabled. </param>
        /// <param name="homePageUrl"> Where users will be redirected when not logged in. </param>
        /// <param name="maxAttachmentSize"> The maximum attachment size in MB. </param>
        /// <param name="restrictedSignupDomains"> Restrict registration to email addresses from these domains only. </param>
        /// <param name="restrictedVisbilityLevels">
        ///     The specified levels cannot be used by non-admin users for projects or
        ///     snippets.
        /// </param>
        /// <param name="sessionExpireDelay"> Session duration in minutes. </param>
        /// <param name="signinText"> The text to display on the login page. </param>
        /// <param name="signinEnabled"> Whether or not users can log in via a GitLab account. </param>
        /// <param name="signupEnabled"> Whether or not registration is enabled. </param>
        /// <param name="userOauthApplications"> Allow users to register any application to use GitLab as an OAuth provider. </param>
        /// <returns> A <see cref="RequestResult{GitLabSettings}" /> representing the results of the request. </returns>
        public async Task<RequestResult<GitLabSettings>> Set(string afterSignOutPath = null,
                                                             uint? defaultBranchProtection = null,
                                                             uint? defaultProjectVisibility = null,
                                                             uint? defaultProjectsLimit = null,
                                                             uint? defaultSnippetVisibility = null,
                                                             bool? gravatarEnabled = null,
                                                             string homePageUrl = null,
                                                             uint? maxAttachmentSize = null,
                                                             string[] restrictedSignupDomains = null,
                                                             uint[] restrictedVisbilityLevels = null,
                                                             uint? sessionExpireDelay = null,
                                                             string signinText = null,
                                                             bool? signinEnabled = null,
                                                             bool? signupEnabled = null,
                                                             bool? userOauthApplications = null)
        {
            var request = RequestFactory.Create("application/settings", Method.Put);

            request.AddParameterIfNotNull("after_sign_out_path", afterSignOutPath);
            request.AddParameterIfNotNull("default_branch_protection", defaultBranchProtection);
            request.AddParameterIfNotNull("default_project_visibility", defaultProjectVisibility);
            request.AddParameterIfNotNull("default_projects_limit", defaultProjectsLimit);
            request.AddParameterIfNotNull("default_snippet_visibility", defaultSnippetVisibility);
            request.AddParameterIfNotNull("gravatar_enabled", gravatarEnabled);
            request.AddParameterIfNotNull("home_page_url", homePageUrl);
            request.AddParameterIfNotNull("max_attachment_size", maxAttachmentSize);
            request.AddParameterIfNotNull("restricted_signup_domains", restrictedSignupDomains);
            request.AddParameterIfNotNull("restricted_visibility_levels", restrictedVisbilityLevels);
            request.AddParameterIfNotNull("session_expire_delay", sessionExpireDelay);
            request.AddParameterIfNotNull("sign_in_text", signinText);
            request.AddParameterIfNotNull("signin_enabled", signinEnabled);
            request.AddParameterIfNotNull("signup_enabled", signupEnabled);
            request.AddParameterIfNotNull("user_oauth_applications", userOauthApplications);

            return await request.ExecuteAsync<GitLabSettings>();
        }
    }
}