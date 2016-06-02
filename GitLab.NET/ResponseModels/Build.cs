// ReSharper disable UnusedMember.Global

using System;

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about a build. </summary>
    public class Build
    {
        /// <summary> The ID for this build. </summary>
        public uint Id { get; set; }

        /// <summary> The status of this build. </summary>
        public string Status { get; set; }

        /// <summary> The stage for this build. </summary>
        public string Stage { get; set; }

        /// <summary> The name for this build. </summary>
        public string Name { get; set; }

        /// <summary> The branch or tag for this build. </summary>
        public string Ref { get; set; }

        /// <summary> Whether or not this build is for a tag. </summary>
        public bool? Tag { get; set; }

        /// <summary> The test coverage reported by this build. </summary>
        public string Coverage { get; set; }

        /// <summary> The date and time this build was created at. </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary> The date and time this build was started at. </summary>
        public DateTime? StartedAt { get; set; }

        /// <summary> The date and time this build was finished at. </summary>
        public DateTime? FinishedAt { get; set; }

        /// <summary> The user that initiated this build. </summary>
        public User User { get; set; }

        /// <summary> The build artifact for this build. </summary>
        public BuildArtifact ArtifactsFile { get; set; }

        /// <summary> The commit for this build. </summary>
        public Commit Commit { get; set; }

        /// <summary> The runner used for this build. </summary>
        public Runner Runner { get; set; }
    }
}