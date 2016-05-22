using System;
using System.Runtime.Serialization;

namespace GitLabAPI.Models
{
    [DataContract]
    public class User
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "state")]
        public string State { get; set; }

        [DataMember(Name = "avatar_url")]
        public string AvatarUrl { get; set; }

        [DataMember(Name = "web_url")]
        public string WebUrl { get; set; }

        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }

        [DataMember(Name = "is_admin")]
        public bool IsAdmin { get; set; }

        [DataMember(Name = "bio")]
        public string Bio { get; set; }

        [DataMember(Name = "location")]
        public string Location { get; set; }

        [DataMember(Name = "skype")]
        public string Skype { get; set; }

        [DataMember(Name = "linkedin")]
        public string LinkedIn { get; set; }

        [DataMember(Name = "twitter")]
        public string Twitter { get; set; }

        [DataMember(Name = "website_url")]
        public string WebsiteUrl { get; set; }

        [DataMember(Name = "last_sign_in_at")]
        public DateTime LastSignInAt { get; set; }

        [DataMember(Name = "confirmed_at")]
        public DateTime ConfirmedAt { get; set; }

        [DataMember(Name = "theme_id")]
        public int ThemeId { get; set; }

        [DataMember(Name = "color_scheme_id")]
        public int ColorSchemeId { get; set; }

        [DataMember(Name = "projects_limit")]
        public int ProjectsLimit { get; set; }

        [DataMember(Name = "current_sign_in_at")]
        public DateTime CurrentSignInAt { get; set; }

        [DataMember(Name = "identities")]
        public Identity[] Identities { get; set; }

        [DataMember(Name = "can_create_group")]
        public bool CanCreateGroup { get; set; }

        [DataMember(Name = "can_create_project")]
        public bool CanCreateProject { get; set; }

        [DataMember(Name = "two_factor_enabled")]
        public bool TwoFactorEnabled { get; set; }

        [DataMember(Name = "external")]
        public bool External { get; set; }

        [DataMember(Name = "private_token")]
        public string PrivateToken { get; set; }
    }
}
