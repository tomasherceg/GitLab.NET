// ReSharper disable UnusedMember.Global

using System.ComponentModel.DataAnnotations;

namespace GitLab.NET
{
    /// <summary> Contains the potential fields to order issues by. </summary>
    public enum IssueOrderBy
    {
        /// <summary> Order by the date and time the issue was created at. </summary>
        [Display(Name = "created_at")] CreatedAt,

        /// <summary> Order by the date and time the issue was last updated at. </summary>
        [Display(Name = "updated_at")] UpdatedAt
    }
}