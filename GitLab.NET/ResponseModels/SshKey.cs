// ReSharper disable UnusedMember.Global

using System;

namespace GitLab.NET.ResponseModels
{
    /// <summary> Provides information about an SSH Key. </summary>
    public class SshKey
    {
        /// <summary> The ID of this key. </summary>
        public uint Id { get; set; }

        /// <summary> The title for this key. </summary>
        public string Title { get; set; }

        /// <summary> The public key. </summary>
        public string Key { get; set; }

        /// <summary> The date and time this key was created at. </summary>
        public DateTime? CreatedAt { get; set; }
    }
}