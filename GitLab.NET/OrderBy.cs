// ReSharper disable UnusedMember.Global

using System.ComponentModel;

namespace GitLab.NET
{
    /// <summary> Contains the potential fields to order issues by. </summary>
    public enum OrderBy
    {
        /// <summary> Order by the date and time the issue was created at. </summary>
        [Description("created_at")] CreatedAt,

        /// <summary> Order by the date and time the issue was last updated at. </summary>
        [Description("updated_at")] UpdatedAt
    }
}