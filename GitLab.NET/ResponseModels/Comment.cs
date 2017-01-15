namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about a comment on a merge request. </summary>
    public class Comment
    {
        /// <summary> The text of the comment. </summary>
        public string Note { get; set; }

        /// <summary> The author of the comment. </summary>
        public User Author { get; set; }
    }
}