using RestSharp;

namespace GitLab.NET.RestSharpExtensions
{
    public static class RestRequestExtensions
    {
        public static void AddParameterIfNotNull(this RestRequest r, string name, object value)
        {
            if (value != null)
                r.AddParameter(name, value);
        }

        public static void AddParameterIfNotNull(this RestRequest r, string name, object value, ParameterType type)
        {
            if (value != null)
                r.AddParameter(name, value, type);
        }

        public static void AddParameterIfNotNull(this RestRequest r, string name, object value, string contentType, ParameterType type)
        {
            if (value != null)
                r.AddParameter(name, value, contentType, type);
        }
    }
}
