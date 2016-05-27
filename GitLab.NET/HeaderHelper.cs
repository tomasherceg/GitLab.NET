using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace GitLab.NET
{
    internal static class HeaderHelper
    {
        public static uint? GetAsUInt(this IEnumerable<Parameter> headers, string name)
        {
            var header = (string)headers.FirstOrDefault(h => h.Name == name)?.Value;

            uint result;

            var didParse = uint.TryParse(header, out result);

            if (didParse)
                return result;

            return null;
        }
    }
}