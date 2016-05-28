// ReSharper disable UnusedMember.Global

using System;

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about a deploy key. </summary>
    public class DeployKey
    {
        /// <summary> The ID for this deploy key. </summary>
        public uint Id { get; set; }

        /// <summary> The ID for the user that owns this deploy key. </summary>
        public uint? UserId { get; set; }

        /// <summary> Whether or not this deploy key is public. </summary>
        public bool? Public { get; set; }

        /// <summary> The title for this deploy key. </summary>
        public string Title { get; set; }

        /// <summary> The deploy key. </summary>
        public string Key { get; set; }

        /// <summary> The fingerprint for this deploy key. </summary>
        public string Fingerprint { get; set; }

        /// <summary> The date and time this deploy key was created at. </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary> The date and time this deploy key was updated at. </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}