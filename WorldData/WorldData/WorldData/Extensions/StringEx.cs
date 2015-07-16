// copyright Infragistics, Inc. 2015

using System.Collections.Generic;

namespace System
{
    public static class StringEx
    {

        /// <summary>
        /// Remove occurrences of a string from the current string
        /// </summary>
        public static string Remove(this string label, string removeStrings)
        {
            var result = label.Replace(removeStrings, "");
            return result;
        }
        /// <summary>
        /// Remove occurrences of list of strings from the current string
        /// </summary>
        public static string Remove(this string label, List<string> removeStrings)
        {
            var result = label.Remove(removeStrings.ToArray());
            return result;
        }
        /// <summary>
        /// Removes occurrences of strings from the current string
        /// </summary>
        public static string Remove(this string label, string[] removeStrings)
        {
            var result = label;
            foreach (var str in removeStrings)
            {
                result = result.Replace(str, "");
            }
            return result;
        }

 
    }
}