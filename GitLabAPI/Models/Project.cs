using System;
using System.Runtime.Serialization;

namespace GitLabAPI.Models
{
    [DataContract]
    public class Project
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "owner")]
        public User Owner { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "default_branch")]
        public string DefaultBranch { get; set; }

        [DataMember(Name = "public")]
        public bool Public { get; set; }

        [DataMember(Name = "visibility_level")]
        public VisibilityLevel VisibilityLevel { get; set; }

        [DataMember(Name = "ssh_url_to_repo")]
        public string SshUrlToRepo { get; set; }

        [DataMember(Name = "http_url_to_repo")]
        public string HttpUrlToRepo { get; set; }

        [DataMember(Name = "web_url")]
        public string WebUrl { get; set; }

        [DataMember(Name = "tag_list")]
        public string[] Tags { get; set; }

        [DataMember(Name = "name_with_namespace")]
        public string NameWithNamespace { get; set; }

        [DataMember(Name = "path")]
        public string Path { get; set; }

        [DataMember(Name = "path_with_namespace")]
        public string PathWithNamespace { get; set; }

        [DataMember(Name = "issues_enabled")]
        public bool IssuesEnabled { get; set; }

        [DataMember(Name = "open_issues_count")]
        public int OpenIssuesCount { get; set; }

        [DataMember(Name = "merge_requests_enabled")]
        public bool MergeRequestsEnabled { get; set; }

        [DataMember(Name = "builds_enabled")]
        public bool BuildsEnabled { get; set; }

        [DataMember(Name = "wiki_enabled")]
        public bool WikiEnabled { get; set; }

        [DataMember(Name = "snippets_enabled")]
        public bool SnippetsEnabled { get; set; }

        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }

        [DataMember(Name = "last_activity_at")]
        public DateTime LastActivityAt { get; set; }

        [DataMember(Name = "creator_id")]
        public int CreatorId { get; set; }

        [DataMember(Name = "namespace")]
        public Namespace Namespace { get; set; }

        [DataMember(Name = "archived")]
        public bool Archived { get; set; }

        [DataMember(Name = "avatar_url")]
        public string AvatarUrl { get; set; }

        [DataMember(Name = "shared_runners_enabled")]
        public bool SharedRunnersEnabled { get; set; }

        [DataMember(Name = "forks_count")]
        public int ForksCount { get; set; }

        [DataMember(Name = "star_count")]
        public int StarCount { get; set; }

        [DataMember(Name = "runners_token")]
        public string RunnersToken { get; set; }

        [DataMember(Name = "public_builds")]
        public bool PublicBuilds { get; set; }
    }
}
