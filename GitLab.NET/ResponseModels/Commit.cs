// ReSharper disable UnusedMember.Global

using System;
using System.Collections.Generic;

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about a commit. </summary>
    public class Commit
    {
        /// <summary> The ID of the commit. </summary>
        public string Id { get; set; }

        /// <summary> The short ID of the commit. </summary>
        public string ShortId { get; set; }

        /// <summary> The title for the commit. </summary>
        public string Title { get; set; }

        /// <summary> The name of the commit's author. </summary>
        public string AuthorName { get; set; }

        /// <summary> The email address of the commit's author. </summary>
        public string AuthorEmail { get; set; }

        /// <summary> The commit message. </summary>
        public string Message { get; set; }

        /// <summary> The parent IDs of the commit. </summary>
        public List<string> ParentIds { get; set; }

        /// <summary> The date and time the commit was created at. </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary> The date and time the commit was committed at. </summary>
        public DateTime? CommittedDate { get; set; }

        /// <summary> The date and time the commit was authored at. </summary>
        public DateTime? AuthoredDate { get; set; }

        /// <summary> The status of the commit. </summary>
        public string Status { get; set; }
    }
}