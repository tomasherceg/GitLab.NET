using System.Runtime.Serialization;

namespace GitLabAPI.NET.Models
{
    [DataContract]
    public class NamespaceAvatar
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }
    }
}
