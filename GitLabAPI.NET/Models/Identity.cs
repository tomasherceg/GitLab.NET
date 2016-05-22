using RestSharp.Deserializers;

namespace GitLabAPI.NET.Models
{
    public class Identity
    {
        [DeserializeAs(Name = "provider")]
        public string Provider { get; set; }

        [DeserializeAs(Name = "extern_uid")]
        public string ExternUid { get; set; }
    }
}
