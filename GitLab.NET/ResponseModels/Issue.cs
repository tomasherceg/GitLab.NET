// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

using System;
using System.Collections.Generic;

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about an issue. </summary>
    public class Issue
    {
        /// <summary> The ID of the issue. </summary>
        public uint Id { get; set; }

        /// <summary> The ID of the issue in relation to the project. </summary>
        public uint Iid { get; set; }

        /// <summary> The ID of the project that owns this issue. </summary>
        public uint ProjectId { get; set; }

        /// <summary> The title of the issue. </summary>
        public string Title { get; set; }

        /// <summary> The description for the issue. </summary>
        public string Description { get; set; }

        /// <summary> The current state of the issue. </summary>
        public string State { get; set; }

        /// <summary> The date and time the issue was created at. </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary> The date and time the issue was last updated at. </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary> The labels attached to the issue. </summary>
        public List<string> Labels { get; set; }

        /// <summary> The milestone that owns the issue, if any. </summary>
        public Milestone Milestone { get; set; }

        /// <summary> The user currently assigned to the issue. </summary>
        public UserPreview Assignee { get; set; }

        /// <summary> The user that created the issue. </summary>
        public UserPreview Author { get; set; }

        /// <summary> Whether or not the currently authenticated user is subscribed to the issue. </summary>
        public bool? Subscribed { get; set; }

        /// <summary> The total number of user-created notes attached to the issue. </summary>
        public uint? UserNotesCount { get; set; }
    }
}