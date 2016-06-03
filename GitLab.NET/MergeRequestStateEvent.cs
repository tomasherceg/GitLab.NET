// ReSharper disable UnusedMember.Global

namespace GitLab.NET
{
    /// <summary> Contains state events for a merge request. </summary>
    public enum MergeRequestStateEvent
    {
        /// <summary> Closes the merge request. </summary>
        Close,

        /// <summary> Merges the merge request. </summary>
        Merge,

        /// <summary> Reopens a closed merge request. </summary>
        Reopen
    }
}