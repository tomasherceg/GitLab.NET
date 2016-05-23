using RestSharp.Deserializers;

namespace GitLab.NET.Models
{
    public class Error
    {
        [DeserializeAs(Name = "message")]
        public string Message { get; set; }
    }
}
