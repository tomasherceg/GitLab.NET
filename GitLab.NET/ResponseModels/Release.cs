// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about a release. </summary>
    public class Release
    {
        /// <summary> The tag name for this release. </summary>
        public string TagName { get; set; }

        /// <summary> The description for this release. </summary>
        public string Description { get; set; }
    }
}