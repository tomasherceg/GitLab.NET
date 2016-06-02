// ReSharper disable UnusedMember.Global

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about a build's artifacts. </summary>
    public class BuildArtifact
    {
        /// <summary> The name of the archive containing the build artifacts. </summary>
        public string Filename { get; set; }

        /// <summary> The size of the archive containing the build artifacts. </summary>
        public uint Size { get; set; }
    }
}