// ReSharper disable ClassNeverInstantiated.Global

using System;
using System.Collections.Generic;

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about a project. </summary>
    public class Project {

        public uint Id { get; set; }

        public string Description { get; set; }

        public string DefaultBranch { get; set; }

        public bool Public { get; set; }

        public int VisibilityLevel { get; set; }

        public string SshUrl { get; set; }

        public string HttpUrlToRepo { get; set; }

        public string WebUrl { get; set; }

        List<string> TagList { get; set; }

        public User Owner { get; set; }

        public string Name { get; set; }

        public string NameWithNamespace { get; set; }

        public string Path { get; set; }

        public string PathWithNamespace { get; set; }

        public bool IssuesEnabled { get; set; }

        public int OpenIssuesCount { get; set; }

        public bool MergeRequestsEnabled { get; set; }

        public bool BuildsEnabled { get; set; }

        public bool WikiEnabled { get; set; }

        public bool SnippetsEnabled { get; set; }

        public bool ContainerRepositoryEnabled { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime LastActivityAt { get; set; }

        public int CreatorId { get; set; }

        public Namespace Namespace { get; set; }

        public bool Archived { get; set; }

        public string AvatarUlr { get; set; }

        public bool SharedRunnersEnabled { get; set; }

        public int ForksCount { get; set; }

        public int StarCount { get; set; }

        public string RunnersToken { get; set; }

        public bool PublicBuilds { get; set; }

        public List<Group> SharedWithGroups { get; set; }
    }
}