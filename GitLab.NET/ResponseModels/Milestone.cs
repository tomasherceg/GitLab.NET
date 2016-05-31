// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedMember.Global

using System;

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about a milestone. </summary>
    public class Milestone
    {
        /// <summary> The ID of the milestone. </summary>
        public uint Id { get; set; }

        /// <summary> The ID of the milestone in relation to the project. </summary>
        public uint Iid { get; set; }

        /// <summary> The ID of the project that owns this milestone. </summary>
        public uint ProjectId { get; set; }

        /// <summary> The title of the milestone. </summary>
        public string Title { get; set; }

        /// <summary> The description for the milestone. </summary>
        public string Description { get; set; }

        /// <summary> The current state of the milestone. </summary>
        public string State { get; set; }

        /// <summary> The date and time the milestone was created at. </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary> The date and time the milestone was last updated at. </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary> The date the milestone is due. </summary>
        public DateTime? DueDate { get; set; }
    }
}