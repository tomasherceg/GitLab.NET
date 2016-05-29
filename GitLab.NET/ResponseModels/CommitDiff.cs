// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedMember.Global

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about a repository diff. </summary>
    public class CommitDiff
    {
        /// <summary> A string representation of the diff. </summary>
        public string Diff { get; set; }

        /// <summary> The new path. </summary>
        public string NewPath { get; set; }

        /// <summary> The old path. </summary>
        public string OldPath { get; set; }

        /// <summary> The mode for item A in the comparison. </summary>
        public string AMode { get; set; }

        /// <summary> The mode for item B in the comparison. </summary>
        public string BMode { get; set; }

        /// <summary> Whether or not this is a new file. </summary>
        public bool? NewFile { get; set; }

        /// <summary> Whether or not the file was renamed. </summary>
        public bool? RenamedFile { get; set; }

        /// <summary> Whether or not the file was deleted. </summary>
        public bool? DeletedFile { get; set; }

        /// <summary> Whether or not the diff was too large. </summary>
        public bool? TooLarge { get; set; }
    }
}