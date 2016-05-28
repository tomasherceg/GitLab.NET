// ReSharper disable UnusedMember.Global

using System;

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about the GitLab license for the currently connected server. </summary>
    public class GitLabLicense
    {
        /// <summary> The date and time this license starts at. </summary>
        public DateTime? StartsAt { get; set; }

        /// <summary> The date and time this license expires at. </summary>
        public DateTime? ExpiresAt { get; set; }

        /// <summary> The licensee. </summary>
        public Licensee Licensee { get; set; }

        /// <summary> The user limit for this license. </summary>
        public uint? UserLimit { get; set; }

        /// <summary> THe number of active users this license currently has. </summary>
        public uint? ActiveUsers { get; set; }
    }
}