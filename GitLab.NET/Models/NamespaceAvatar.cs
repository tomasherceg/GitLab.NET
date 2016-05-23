using RestSharp.Deserializers;

namespace GitLab.NET.Models
{
    public class NamespaceAvatar
    {
        [DeserializeAs(Name = "url")]
        public string Url { get; set; }
    }
}
