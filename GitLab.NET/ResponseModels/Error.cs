using System.Diagnostics.CodeAnalysis;
using RestSharp.Deserializers;

namespace GitLab.NET.ResponseModels
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class Error
    {
        [DeserializeAs(Name = "message")]
        public string Message { get; set; }
    }
}
