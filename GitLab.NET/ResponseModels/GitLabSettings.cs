// ReSharper disable UnusedMember.Global

using System;
using System.Collections.Generic;

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about GitLab's settings. </summary>
    public class GitLabSettings
    {
        /// <summary> Unknown. </summary>
        public uint? Id { get; set; }

        /// <summary> The text shown on the login page. </summary>
        public string SignInText { get; set; }

        /// <summary> Redirect to this URL when not logged in. </summary>
        public string HomePageUrl { get; set; }

        /// <summary> Where to redirect users after logout. </summary>
        public string AfterSignOutPath { get; set; }

        /// <summary> Force people to use only emails from the domains provided for signup. </summary>
        public List<string> RestrictedSignupDomains { get; set; }

        /// <summary> The protection level for the default branch. </summary>
        public uint? DefaultBranchProtection { get; set; }

        /// <summary> The default projects limit for users. </summary>
        public uint? DefaultProjectsLimit { get; set; }

        /// <summary> What visibility level new projects receive. </summary>
        public uint? DefaultProjectVisibility { get; set; }

        /// <summary> What visibility level new snippets receive. </summary>
        public uint? DefaultSnippetVisibility { get; set; }

        /// <summary> The maximum attachment size in MB. </summary>
        public uint? MaxAttachmentSize { get; set; }

        /// <summary> Session duration in minutes. </summary>
        public uint? SessionExpireDelay { get; set; }

        /// <summary> Selected levels cannot be used by non-admin users for projects or snippets. </summary>
        public List<uint> RestrictedVisibilityLevels { get; set; }

        /// <summary> Enable gravatar. </summary>
        public bool? GravatarEnabled { get; set; }

        /// <summary> Whether or not registration is enabled. </summary>
        public bool? SignupEnabled { get; set; }

        /// <summary> Whether or not signin via a GitLab account is enabled. </summary>
        public bool? SigninEnabled { get; set; }

        /// <summary> Allow users to register any application to use GitLab as an OAuth provider. </summary>
        public bool? UserOauthApplications { get; set; }

        /// <summary> Unknown </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary> Unknown </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}