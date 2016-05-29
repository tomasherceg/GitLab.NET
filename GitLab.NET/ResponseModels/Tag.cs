// ReSharper disable UnusedMember.Global

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about a tag. </summary>
    public class Tag
    {
        /// <summary> The name for this tag. </summary>
        public string Name { get; set; }

        /// <summary> The message for this tag. </summary>
        public string Message { get; set; }

        /// <summary> The commit this tag is attached to. </summary>
        public Commit Commit { get; set; }

        /// <summary> The release for this tag. </summary>
        public Release Release { get; set; }
    }
}