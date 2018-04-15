using System.Text.RegularExpressions;

namespace ManageFleet.Infra.Extensions
{
    public static class ExtensionMethods
    {
        public static bool IsNull(this object obj) => obj == null;
        
        public static object GetPropertyValue(this object obj, string propertyName)
        {
            try
            {
                return obj.GetType().GetProperty(propertyName).GetValue(obj, null);
            }
            catch
            {
                return string.Empty;
            }
        }

        public static object GetPropertyValueRegex(this object obj, string propertyName, string propertyToVerify, string pattern)
        {
            string property = string.Empty;

            var match = new Regex(pattern).Match(propertyName);

            if (match.Success && propertyToVerify.Equals(match.Value))
            {
                property = match.Value;
                return obj.GetPropertyValue(property);
            }

            return null;
        }

        public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);

        public static bool IsDefault<T>(this T obj) => obj.Equals(default(T));

        public static T ToEnum<T>(this object obj) => obj.IsNull() ? default(T) : (T)obj;
    }
}