// ReSharper disable UnusedMember.Global

namespace GitLab.NET
{
    /// <summary> Contains the possible scopes to use for runner queries. </summary>
    public enum RunnerScope
    {
        /// <summary> The runner is active. </summary>
        Active,

        /// <summary> The runner is online. </summary>
        Online,

        /// <summary> The runner is paused. </summary>
        Paused,

        /// <summary> The runner is shared. </summary>
        Shared,

        /// <summary> The runner is specific. </summary>
        Specific
    }
}