using RestSharp.Deserializers;
using System;

namespace GitLab.NET.Models
{
    public class User
    {
        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "username")]
        public string Username { get; set; }

        [DeserializeAs(Name = "id")]
        public int Id { get; set; }

        [DeserializeAs(Name = "state")]
        public string State { get; set; }

        [DeserializeAs(Name = "avatar_url")]
        public string AvatarUrl { get; set; }

        [DeserializeAs(Name = "web_url")]
        public string WebUrl { get; set; }

        [DeserializeAs(Name = "created_at")]
        public DateTime CreatedAt { get; set; }

        [DeserializeAs(Name = "is_admin")]
        public bool IsAdmin { get; set; }

        [DeserializeAs(Name = "bio")]
        public string Bio { get; set; }

        [DeserializeAs(Name = "location")]
        public string Location { get; set; }

        [DeserializeAs(Name = "skype")]
        public string Skype { get; set; }

        [DeserializeAs(Name = "linkedin")]
        public string LinkedIn { get; set; }

        [DeserializeAs(Name = "twitter")]
        public string Twitter { get; set; }

        [DeserializeAs(Name = "website_url")]
        public string WebsiteUrl { get; set; }

        [DeserializeAs(Name = "last_sign_in_at")]
        public DateTime LastSignInAt { get; set; }

        [DeserializeAs(Name = "confirmed_at")]
        public DateTime ConfirmedAt { get; set; }

        [DeserializeAs(Name = "email")]
        public string Email { get; set; }

        [DeserializeAs(Name = "theme_id")]
        public int ThemeId { get; set; }

        [DeserializeAs(Name = "color_scheme_id")]
        public int ColorSchemeId { get; set; }

        [DeserializeAs(Name = "projects_limit")]
        public int ProjectsLimit { get; set; }

        [DeserializeAs(Name = "current_sign_in_at")]
        public DateTime CurrentSignInAt { get; set; }

        [DeserializeAs(Name = "identities")]
        public Identity[] Identities { get; set; }

        [DeserializeAs(Name = "can_create_group")]
        public bool CanCreateGroup { get; set; }

        [DeserializeAs(Name = "can_create_project")]
        public bool CanCreateProject { get; set; }

        [DeserializeAs(Name = "two_factor_enabled")]
        public bool TwoFactorEnabled { get; set; }

        [DeserializeAs(Name = "external")]
        public bool External { get; set; }

        [DeserializeAs(Name = "private_token")]
        public string PrivateToken { get; set; }
    }
}
