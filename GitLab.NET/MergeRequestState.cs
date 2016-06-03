// ReSharper disable UnusedMember.Global

namespace GitLab.NET
{
    /// <summary> Contains the states for a merge request. </summary>
    public enum MergeRequestState
    {
        /// <summary> The merge request is closed. </summary>
        Closed,

        /// <summary> The merge request has been merged. </summary>
        Merged,

        /// <summary> The merge request is opened. </summary>
        Opened
    }
}