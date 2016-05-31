// ReSharper disable UnusedMember.Global

namespace GitLab.NET
{
    /// <summary> Visibility level for an object. </summary>
    public enum VisibilityLevel
    {
        /// <summary> The object in question is private. </summary>
        Private = 0,

        /// <summary> The object in question is internal. </summary>
        Internal = 10,

        /// <summary> The object in question is public. </summary>
        Public = 20
    }
}