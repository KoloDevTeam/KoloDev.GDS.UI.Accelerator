using System.ComponentModel;
using System.Reflection;

namespace KoloDev.GDS.UI.Extensions
{
    /// <summary>
    /// Enum extensions
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// Get the ["Description("")"] attribute from an enum value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string DescriptionAttr<T>(this T source)
        {
            if(source != null)
            {
                FieldInfo fieldInformation = source.GetType().GetField(source.ToString());

                if(fieldInformation != null)
                {
                    DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInformation.GetCustomAttributes(
                                        typeof(DescriptionAttribute), false);

                    if (attributes != null && attributes.Length > 0) return attributes[0].Description;
                }
            }
            throw new ArgumentNullException("Source parameter cannot be null");
        }
    }
}
