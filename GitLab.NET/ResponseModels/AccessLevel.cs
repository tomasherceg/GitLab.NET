using System.Diagnostics.CodeAnalysis;

namespace GitLab.NET.ResponseModels
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public enum AccessLevel
    {
        Guest = 10,
        Reporter = 20,
        Developer = 30,
        Master = 40,
        Owner = 50,
    }
}
