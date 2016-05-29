// ReSharper disable UnusedMember.Global

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about a repository file. </summary>
    public class RepositoryFile
    {
        /// <summary> The name of the file. </summary>
        public string FileName { get; set; }

        /// <summary> The path of the file. </summary>
        public string FilePath { get; set; }

        /// <summary> The size of the file. </summary>
        public uint Size { get; set; }

        /// <summary> The encoding for the Content field. </summary>
        public string Encoding { get; set; }

        /// <summary> The branch or tag name for the file. </summary>
        public string Ref { get; set; }

        /// <summary> The file's blob ID. </summary>
        public string BlobId { get; set; }

        /// <summary> The commit ID for the file. </summary>
        public string CommitId { get; set; }

        /// <summary> The last commit ID for the file. </summary>
        public string LastCommitId { get; set; }

        /// <summary> The file contents. </summary>
        public string Content { get; set; }
    }
}