// ReSharper disable UnusedMember.Global

using System;

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about a commit's build status. </summary>
    public class CommitStatus
    {
        /// <summary> The ID of the status. </summary>
        public uint Id { get; set; }

        /// <summary> The SHA of the commit. </summary>
        public string Sha { get; set; }

        /// <summary> The branch or tag for this status. </summary>
        public string Ref { get; set; }

        /// <summary> The status of this build. </summary>
        public string Status { get; set; }

        /// <summary> The name of the build. </summary>
        public string Name { get; set; }

        /// <summary> The target URL for the build. </summary>
        public string TargetUrl { get; set; }

        /// <summary> The description for the build. </summary>
        public string Description { get; set; }

        /// <summary> Whether or not failure is allowed. </summary>
        public bool? AllowFailure { get; set; }

        /// <summary> The date and time the build was created at. </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary> The date and time the build was started at. </summary>
        public DateTime? StartedAt { get; set; }

        /// <summary> The date and time the build was finished at. </summary>
        public DateTime? FinishedAt { get; set; }

        /// <summary> The author of the build. </summary>
        public UserPreview Author { get; set; }
    }
}