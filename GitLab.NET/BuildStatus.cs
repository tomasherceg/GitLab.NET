// ReSharper disable UnusedMember.Global

namespace GitLab.NET
{
    /// <summary> Contains the possible status' for a build. </summary>
    public enum BuildStatus
    {
        /// <summary> The build has failed. </summary>
        Failed,

        /// <summary> The build is pending. </summary>
        Pending,

        /// <summary> The build is running. </summary>
        Running,

        /// <summary> The build succeeded. </summary>
        Success
    }
}