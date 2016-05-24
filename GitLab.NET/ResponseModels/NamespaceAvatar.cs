using RestSharp.Deserializers;

namespace GitLab.NET.RestModels
{
    public class NamespaceAvatar
    {
        [DeserializeAs(Name = "url")]
        public string Url { get; set; }
    }
}
