// ReSharper disable UnusedMember.Global

using System;

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about a build trigger. </summary>
    public class BuildTrigger
    {
        /// <summary> The token for this build trigger. </summary>
        public string Token { get; set; }

        /// <summary> The date and time this build trigger was created at. </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary> The date and time this build trigger was updated at. </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary> The date and time this build trigger was deleted at. </summary>
        public DateTime? DeletedAt { get; set; }

        /// <summary> The date and time this build trigger was last used at. </summary>
        public DateTime? LastUsed { get; set; }
    }
}