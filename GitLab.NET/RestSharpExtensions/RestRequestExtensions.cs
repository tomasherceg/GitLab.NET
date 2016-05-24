using RestSharp;

namespace GitLab.NET.RestSharpExtensions
{
    public static class RestRequestExtensions
    {
        public static void AddParameterIfNotNull(this RestRequest request, string name, object value)
        {
            if (value != null)
                request.AddParameter(name, value);
        }

        public static void AddParameterIfNotNull(this RestRequest request, string name, object value, ParameterType type)
        {
            if (value != null)
                request.AddParameter(name, value, type);
        }

        public static void AddParameterIfNotNull(this RestRequest request, string name, object value, string contentType, ParameterType type)
        {
            if (value != null)
                request.AddParameter(name, value, contentType, type);
        }
    }
}
