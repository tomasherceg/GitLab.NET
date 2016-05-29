// ReSharper disable UnusedMember.Global

using System;

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about a comment on a commit. </summary>
    public class CommitComment
    {
        /// <summary> The text of the comment. </summary>
        public string Note { get; set; }

        /// <summary> The path of the file being commented on. </summary>
        public string Path { get; set; }

        /// <summary> The line in the file that the comment is on. </summary>
        public uint? Line { get; set; }

        /// <summary> The type of line the comment is on. </summary>
        public string LineType { get; set; }

        /// <summary> The date and time the comment was created at. </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary> The author of the comment. </summary>
        public Author Author { get; set; }
    }
}