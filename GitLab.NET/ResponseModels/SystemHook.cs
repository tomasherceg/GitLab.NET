// ReSharper disable UnusedMember.Global

using System;

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about a system hook. </summary>
    public class SystemHook
    {
        /// <summary> The ID for this system hook. </summary>
        public uint Id { get; set; }

        /// <summary> The ID of the project this system hook is attached to. </summary>
        public uint? ProjectId { get; set; }

        /// <summary> The ID of the service this system hook is attached to. </summary>
        public uint? ServiceId { get; set; }

        /// <summary> The URL for this system hook. </summary>
        public string Url { get; set; }

        /// <summary> Whether or not this system hook fires note events. </summary>
        public bool? NoteEvents { get; set; }

        /// <summary> Whether or not this system hook fires issue events. </summary>
        public bool? IssuesEvents { get; set; }

        /// <summary> Whether or not this system hook fires merge request events. </summary>
        public bool? MergeRequestsEvents { get; set; }

        /// <summary> Whether or not this system hook fires push events. </summary>
        public bool? PushEvents { get; set; }

        public bool? BuildEvents { get; set; }

        public bool? EnableSSLVerification { get; set; }

        /// <summary> Whether or not this system hook fires tag push events. </summary>
        public bool? TagPushEvents { get; set; }

        /// <summary> Whether or not SSL verification is enabled for this system hook. </summary>
        public bool? EnableSslVerification { get; set; }

        /// <summary> The date and time this system hook was created at. </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary> The date and time this system hook was updated at. </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}