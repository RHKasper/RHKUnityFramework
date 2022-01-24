using System.Collections.Generic;
using System.IO;

namespace RHKUnityFramework.Scripts.ExtensionMethods
{
    public static class StringExtensionMethods
    {
        /// <summary>
        /// Convert string to int.
        /// </summary>
        public static int IntValue(this string str)
        {
            return int.Parse(str);
        }

        /// <summary>
        /// Attempt to convert string to int. 
        /// </summary>
        /// <returns>Whether parsing was successful.</returns>
        public static bool TryGetIntValue(this string str, out int value)
        {
            return int.TryParse(str, out value);
        }

        /// <summary>
        /// Convert string to int.
        /// </summary>
        public static float FloatValue(this string str)
        {
            return float.Parse(str);
        }

        /// <summary>
        /// Convert a string from camel-case to space-delimited title case.
        /// </summary>
        /// <example>
        ///   CamelCaseToEnglishTitle("everyoneLikesCamels")
        ///   >>>> Everyone Likes Camels
        /// </example>
        public static string CamelCaseToEnglishTitle(this string camel)
        {
            string title = "";

            for (int i = 0; i < camel.Length; i++)
            {
                if (i == 0)
                {
                    title += char.ToUpperInvariant(camel[i]);
                }
                else
                {
                    if (char.IsUpper(camel[i]))
                        title += " ";
                    title += camel[i];
                }

            }

            return title;
        }

        /// <summary>
        /// removes "(Clone)" and "(Instance)" from any string passed in
        /// </summary>
        public static string CleanPrefabInstanceName(this string s)
        {
            return s.Replace("(Clone)", "").Replace(" (Instance)", "");

        }
    }
}