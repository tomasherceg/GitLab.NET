// ReSharper disable UnusedMember.Global
using System;

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about a project snippet. </summary>
    public class ProjectSnippet
    {
        /// <summary> The ID of this project snippet. </summary>
        public uint Id { get; set; }

        /// <summary> The title of this project snippet. </summary>
        public string Title { get; set; }

        /// <summary> The file name of this project snippet. </summary>
        public string FileName { get; set; }

        /// <summary> The author of this project snippet. </summary>
        public ProjectSnippetAuthor Author { get; set; }

        /// <summary> The date and time this project snippet expires at. </summary>
        public DateTime? ExpiresAt { get; set; }

        /// <summary> The date and time this project snippet was updated at. </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary> The date and time this project snippet was created at. </summary>
        public DateTime? CreatedAt { get; set; }
    }
}