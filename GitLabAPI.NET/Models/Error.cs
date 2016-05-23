using RestSharp.Deserializers;

namespace GitLabAPI.NET.Models
{
    public class Error
    {
        [DeserializeAs(Name = "message")]
        public string Message { get; set; }
    }
}
