// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedMember.Global

using System;

namespace GitLab.NET.ResponseModels
{
    /// <summary> Represents a repository commit. </summary>
    public class RepositoryCommit
    {
        /// <summary> The ID for this commit. </summary>
        public string Id { get; set; }

        /// <summary> The short ID for this commit. </summary>
        public string ShortId { get; set; }

        /// <summary> The title for this commit. </summary>
        public string Title { get; set; }

        /// <summary> The author's name for this commit. </summary>
        public string AuthorName { get; set; }

        /// <summary> The author's email for this commit. </summary>
        public string AuthorEmail { get; set; }

        /// <summary> The date and time this commit was created at. </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary> The message for this commit. </summary>
        public string Message { get; set; }
    }
}