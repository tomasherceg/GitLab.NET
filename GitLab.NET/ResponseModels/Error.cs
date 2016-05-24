using RestSharp.Deserializers;

namespace GitLab.NET.RestModels
{
    public class Error
    {
        [DeserializeAs(Name = "message")]
        public string Message { get; set; }
    }
}
