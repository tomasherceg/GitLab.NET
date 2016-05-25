using System.Diagnostics.CodeAnalysis;
using RestSharp.Deserializers;

namespace GitLab.NET.ResponseModels
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class NamespaceAvatar
    {
        [DeserializeAs(Name = "url")]
        public string Url { get; set; }
    }
}