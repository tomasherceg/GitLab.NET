using RestSharp.Deserializers;

namespace GitLabAPI.NET.Models
{
    public class NamespaceAvatar
    {
        [DeserializeAs(Name = "url")]
        public string Url { get; set; }
    }
}
