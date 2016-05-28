// ReSharper disable UnusedMember.Global

using System;

namespace GitLab.NET.ResponseModels
{
    /// <summary> Provides details about a user. </summary>
    public class User
    {
        /// <summary> The user's ID. </summary>
        public int Id { get; set; }

        /// <summary> The user's username. </summary>
        public string Username { get; set; }

        /// <summary> The user's email address. </summary>
        public string Email { get; set; }

        /// <summary> The user's full name. </summary>
        public string Name { get; set; }

        /// <summary> The current state of the user (active/blocked). </summary>
        public string State { get; set; }

        /// <summary> The URL for the user's avatar. </summary>
        public string AvatarUrl { get; set; }

        /// <summary> The URL for the user's profile. </summary>
        public string WebUrl { get; set; }

        /// <summary> The date and time the user's account was created. </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary> Whether or not the user has admin privileges. </summary>
        public bool? IsAdmin { get; set; }

        /// <summary> The user's bio. </summary>
        public string Bio { get; set; }

        /// <summary> The user's location. </summary>
        public string Location { get; set; }

        /// <summary> The user's Skype username. </summary>
        public string Skype { get; set; }

        /// <summary> The user's LinkedIn profile. </summary>
        public string LinkedIn { get; set; }

        /// <summary> The user's Twitter profile. </summary>
        public string Twitter { get; set; }

        /// <summary> The user's website URL. </summary>
        public string WebsiteUrl { get; set; }

        /// <summary> The date and time of the user's last sign in. </summary>
        public DateTime? LastSignInAt { get; set; }

        /// <summary> The date and time the user's account was confirmed at. </summary>
        public DateTime? ConfirmedAt { get; set; }

        /// <summary> The ID of the user's currently selected theme. </summary>
        public int? ThemeId { get; set; }

        /// <summary> The ID of the user's currently selected color scheme. </summary>
        public int? ColorSchemeId { get; set; }

        /// <summary> The maximum number of projects the user is allowed to create. </summary>
        public int? ProjectsLimit { get; set; }

        /// <summary> The date and time of the user's current sign in. </summary>
        public DateTime? CurrentSignInAt { get; set; }

        /// <summary> The external identites attached to the user's account. </summary>
        public Identity[] Identities { get; set; }

        /// <summary> Whether or not the user can create groups. </summary>
        public bool? CanCreateGroup { get; set; }

        /// <summary> Whether or not the user can create projects. </summary>
        public bool? CanCreateProject { get; set; }

        /// <summary> Whether or not the user's account requires two-factor authentication for login. </summary>
        public bool? TwoFactorEnabled { get; set; }

        /// <summary> Whether or not the user's account is flagged as external. </summary>
        public bool? External { get; set; }

        /// <summary> The user's private token. </summary>
        public string PrivateToken { get; set; }
    }
}