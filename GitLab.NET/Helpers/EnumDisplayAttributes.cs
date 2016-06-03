using System;
using System.ComponentModel;

namespace GitLab.NET.Helpers
{
    internal static class EnumDisplayAttributes
    {
        /// <summary> Gets the description attribute on an enum field value. </summary>
        /// <param name="enumVal"> The enum value. </param>
        /// <returns> The description attribute from the enum value. </returns>
        public static string GetDescription(this Enum enumVal)
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? ((DescriptionAttribute)attributes[0]).Description : null;
        }
    }
}