using System;
using System.Collections.Generic;

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about a project. </summary>
    public class Project
    {
        /// <summary> The ID for this project. </summary>
        public uint Id { get; set; }

        /// <summary> The Description for this project. </summary>
        public string Description { get; set; }

        /// <summary> The DefaultBranch for this project. </summary>
        public string DefaultBranch { get; set; }

        /// <summary> Is project public. </summary>
        public bool? Public { get; set; }

        /// <summary> The VisibilityLevel for this project. </summary>
        public VisibilityLevel VisibilityLevel { get; set; }

        /// <summary> The ssh url to this project. </summary>
        public string SshUrl { get; set; }

        /// <summary> The http url to this project. </summary>
        public string HttpUrlToRepo { get; set; }

        /// <summary> The web url to this project. </summary>
        public string WebUrl { get; set; }

        /// <summary> The tags for this project. </summary>
        private List<string> TagList { get; set; }

        /// <summary> The project owner. </summary>
        public User Owner { get; set; }

        /// <summary> The name for this project. </summary>
        public string Name { get; set; }

        /// <summary> The name with namespace for this project. </summary>
        public string NameWithNamespace { get; set; }

        /// <summary> The custom repository name for this project. </summary>
        public string Path { get; set; }

        /// <summary> The custom repository name with namespace for this project. </summary>
        public string PathWithNamespace { get; set; }

        /// <summary> Is issues enabled for this project. </summary>
        public bool? IssuesEnabled { get; set; }

        /// <summary> How many issues are open for this project. </summary>
        public int OpenIssuesCount { get; set; }

        /// <summary> Is this project allows merge requests. </summary>
        public bool MergeRequestsEnabled { get; set; }

        /// <summary> Is builds enabled for this project. </summary>
        public bool BuildsEnabled { get; set; }

        /// <summary> Is wiki enabled for this project. </summary>
        public bool WikiEnabled { get; set; }

        /// <summary> Is snippets enabled for this project. </summary>
        public bool SnippetsEnabled { get; set; }

        /// <summary> Is container repository enabled for this project. </summary>
        public bool ContainerRegistryEnabled { get; set; }

        /// <summary> The date and time this project was created at. </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary> The date and time this project was updated at. </summary>
        public DateTime LastActivityAt { get; set; }

        /// <summary> The creator id for this project. </summary>
        public int CreatorId { get; set; }

        /// <summary> The namespace for this project. </summary>
        public Namespace Namespace { get; set; }

        /// <summary> Is this project archived. </summary>
        public bool Archived { get; set; }

        /// <summary> The avatar url for this project. </summary>
        public string AvatarUlr { get; set; }

        /// <summary> Is shared runners enabled for this project. </summary>
        public bool SharedRunnersEnabled { get; set; }

        /// <summary> The forks count for this project. </summary>
        public int ForksCount { get; set; }

        /// <summary> The stars count for this project. </summary>
        public int StarCount { get; set; }

        /// <summary> The runners token for this project. </summary>
        public string RunnersToken { get; set; }

        /// <summary> Is public builds enabled for this project. </summary>
        public bool PublicBuilds { get; set; }

        /// <summary> The groups what shared this project. </summary>
        public List<Group> SharedWithGroups { get; set; }
    }
}