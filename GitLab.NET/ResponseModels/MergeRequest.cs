// ReSharper disable UnusedMember.Global

using System;
using System.Collections.Generic;

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about a merge request. </summary>
    public class MergeRequest
    {
        /// <summary> The ID of the merge request. </summary>
        public uint? Id { get; set; }

        /// <summary> The ID of the merge request within the project. </summary>
        public uint? Iid { get; set; }

        /// <summary> The ID of the project that owns this merge request. </summary>
        public uint? ProjectId { get; set; }

        /// <summary> The title of the merge request. </summary>
        public string Title { get; set; }

        /// <summary> The description for the merge request. </summary>
        public string Description { get; set; }

        /// <summary> The state of the merge request. </summary>
        public string State { get; set; }

        /// <summary> The date and time the merge request was created at. </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary> The date and time the merge request was last updated at. </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary> The branch to merge into. </summary>
        public string TargetBranch { get; set; }

        /// <summary> The branch to merge from. </summary>
        public string SourceBranch { get; set; }

        /// <summary> The number of upvotes this merge request has. </summary>
        public uint? Upvotes { get; set; }

        /// <summary> The number of downvotes this merge request has. </summary>
        public uint? Downvotes { get; set; }

        /// <summary> The author of this merge request. </summary>
        public UserPreview Author { get; set; }

        /// <summary> The assignee for this merge request. </summary>
        public UserPreview Assignee { get; set; }

        /// <summary> The source project ID. </summary>
        public uint? SourceProjectId { get; set; }

        /// <summary> The target project ID. </summary>
        public uint? TargetProjectId { get; set; }

        /// <summary> The labels assigned to this merge request. </summary>
        public List<string> Labels { get; set; }

        /// <summary> Whether or not the merge request is marked as WIP. </summary>
        public bool? WorkInProgress { get; set; }

        /// <summary> The milestone for this merge request. </summary>
        public Milestone Milestone { get; set; }

        /// <summary> Whether or not the merge request will automatically be merged when the build succeeds. </summary>
        public bool? MergeWhenBuildSucceeds { get; set; }

        /// <summary> The merge status. </summary>
        public string MergeStatus { get; set; }

        /// <summary> Whether or not the currently authenticated user is subscribed to this merge request. </summary>
        public bool? Subscribed { get; set; }

        /// <summary> The number of user notes the merge request has. </summary>
        public uint? UserNotesCount { get; set; }

        /// <summary> The changes that will be applied by this merge request. </summary>
        public List<CommitDiff> Changes { get; set; }
    }
}