namespace GitLab.NET.Helpers
{
    internal static class ArrayToCommaSeparatedHelper
    {
        public static string ToCommaSeparated(this string[] input)
        {
            if (input == null || input.Length <= 0)
                return null;

            var result = input[0];

            for (var i = 1; i < input.Length; i++)
                result += "," + input[i];

            return result;
        }
    }
}