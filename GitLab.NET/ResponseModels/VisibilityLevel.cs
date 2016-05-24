using System.Diagnostics.CodeAnalysis;

namespace GitLab.NET.ResponseModels
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public enum VisibilityLevel
    {
        Private = 0,
        Internal = 10,
        Public = 20,
    }
}
