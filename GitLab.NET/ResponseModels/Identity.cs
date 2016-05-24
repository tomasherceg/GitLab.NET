using RestSharp.Deserializers;

namespace GitLab.NET.RestModels
{
    public class Identity
    {
        [DeserializeAs(Name = "provider")]
        public string Provider { get; set; }

        [DeserializeAs(Name = "extern_uid")]
        public string ExternUid { get; set; }
    }
}
