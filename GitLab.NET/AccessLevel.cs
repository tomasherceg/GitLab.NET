// ReSharper disable UnusedMember.Global

namespace GitLab.NET
{
    /// <summary> Group access level. </summary>
    public enum AccessLevel
    {
        /// <summary> Guest </summary>
        Guest = 10,

        /// <summary> Reporter </summary>
        Reporter = 20,

        /// <summary> Developer </summary>
        Developer = 30,

        /// <summary> Master </summary>
        Master = 40,

        /// <summary> Owner </summary>
        Owner = 50
    }
}