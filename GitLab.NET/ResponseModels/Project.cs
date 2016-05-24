using RestSharp.Deserializers;
using System;

namespace GitLab.NET.RestModels
{
    public class Project
    {
        [DeserializeAs(Name = "id")]
        public int Id { get; set; }

        [DeserializeAs(Name = "description")]
        public string Description { get; set; }

        [DeserializeAs(Name = "default_branch")]
        public string DefaultBranch { get; set; }

        [DeserializeAs(Name = "tag_list")]
        public string[] Tags { get; set; }

        [DeserializeAs(Name = "public")]
        public bool Public { get; set; }

        [DeserializeAs(Name = "archived")]
        public bool Archived { get; set; }

        [DeserializeAs(Name = "visibility_level")]
        public VisibilityLevel VisibilityLevel { get; set; }

        [DeserializeAs(Name = "ssh_url_to_repo")]
        public string SshUrlToRepo { get; set; }

        [DeserializeAs(Name = "http_url_to_repo")]
        public string HttpUrlToRepo { get; set; }

        [DeserializeAs(Name = "web_url")]
        public string WebUrl { get; set; }

        [DeserializeAs(Name = "owner")]
        public ProjectOwner Owner { get; set; }

        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "name_with_namespace")]
        public string NameWithNamespace { get; set; }

        [DeserializeAs(Name = "path")]
        public string Path { get; set; }

        [DeserializeAs(Name = "path_with_namespace")]
        public string PathWithNamespace { get; set; }

        [DeserializeAs(Name = "issues_enabled")]
        public bool IssuesEnabled { get; set; }

        [DeserializeAs(Name = "merge_requests_enabled")]
        public bool MergeRequestsEnabled { get; set; }

        [DeserializeAs(Name = "wiki_enabled")]
        public bool WikiEnabled { get; set; }

        [DeserializeAs(Name = "builds_enabled")]
        public bool BuildsEnabled { get; set; }

        [DeserializeAs(Name = "snippets_enabled")]
        public bool SnippetsEnabled { get; set; }

        [DeserializeAs(Name = "container_registry_enabled")]
        public bool ContainerRegistryEnabled { get; set; }

        [DeserializeAs(Name = "created_at")]
        public DateTime CreatedAt { get; set; }

        [DeserializeAs(Name = "last_activity_at")]
        public DateTime LastActivityAt { get; set; }

        [DeserializeAs(Name = "shared_runners_enabled")]
        public bool SharedRunnersEnabled { get; set; }

        [DeserializeAs(Name = "creator_id")]
        public int CreatorId { get; set; }

        [DeserializeAs(Name = "namespace")]
        public ProjectNamespace Namespace { get; set; }

        [DeserializeAs(Name = "avatar_url")]
        public string AvatarUrl { get; set; }

        [DeserializeAs(Name = "star_count")]
        public int StarCount { get; set; }

        [DeserializeAs(Name = "forks_count")]
        public int ForksCount { get; set; }

        [DeserializeAs(Name = "open_issues_count")]
        public int OpenIssuesCount { get; set; }

        [DeserializeAs(Name = "public_builds")]
        public bool PublicBuilds { get; set; }

        [DeserializeAs(Name = "permissions")]
        public ProjectPermissions Permissions { get; set; }

        [DeserializeAs(Name = "runners_token")]
        public string RunnersToken { get; set; }
    }
}
