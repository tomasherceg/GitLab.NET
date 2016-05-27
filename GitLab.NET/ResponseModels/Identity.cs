namespace GitLab.NET.ResponseModels
{
    /// <summary>
    /// Provides information about an external identity.
    /// </summary>
    public class Identity
    {
        /// <summary> The identity provider. </summary>
        public string Provider { get; set; }

        /// <summary> The UID for the identity. </summary>
        public string ExternUid { get; set; }
    }
}