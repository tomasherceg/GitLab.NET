// ReSharper disable UnusedMember.Global

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about a label. </summary>
    public class Label
    {
        /// <summary> The name for this label. </summary>
        public string Name { get; set; }

        /// <summary> The color for this label. </summary>
        public string Color { get; set; }

        /// <summary> The description for this label. </summary>
        public string Description { get; set; }

        /// <summary> The number of open issues with this label. </summary>
        public uint? OpenIssuesCount { get; set; }

        /// <summary> The number of closed issues with this label. </summary>
        public uint? ClosedIssuesCount { get; set; }

        /// <summary> The number of open merge requests with this label. </summary>
        public uint? OpenMergeRequestsCount { get; set; }

        /// <summary> Whether or not the current user is subscribed to this label. </summary>
        public bool? Subscribed { get; set; }
    }
}