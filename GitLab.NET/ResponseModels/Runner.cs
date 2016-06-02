// ReSharper disable UnusedMember.Global

using System;
using System.Collections.Generic;

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about a runner. </summary>
    public class Runner
    {
        /// <summary> The ID for this runner. </summary>
        public uint? Id { get; set; }

        /// <summary> The name for this runner. </summary>
        public string Name { get; set; }

        /// <summary> The description for this runner. </summary>
        public string Description { get; set; }

        /// <summary> Whether or not this runner is active. </summary>
        public bool? Active { get; set; }

        /// <summary> Whether or not this runner is shared. </summary>
        public bool? IsShared { get; set; }

        /// <summary> Whether or not this runner can run untagged projects. </summary>
        public bool? RunUntagged { get; set; }

        /// <summary> The tags for this runner. </summary>
        public List<string> TagList { get; set; }

        /// <summary> The version for this runner. </summary>
        public string Version { get; set; }

        /// <summary> The revision for this runner. </summary>
        public string Revision { get; set; }

        /// <summary> The platform of this runner. </summary>
        public string Platform { get; set; }

        /// <summary> The CPU architecture for this runner. </summary>
        public string Architecture { get; set; }

        /// <summary> This runner's token. </summary>
        public string Token { get; set; }

        /// <summary> The date and time this runner was last contacted at. </summary>
        public DateTime? ContactedAt { get; set; }

        /// <summary> The projects this runner is assigned to. </summary>
        public List<Project> Projects { get; set; }
    }
}