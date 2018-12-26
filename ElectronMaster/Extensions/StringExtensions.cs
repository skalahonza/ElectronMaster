using System;

namespace ElectronMaster.Extensions
{
    public static class StringExtensions
    {
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            if (toCheck == null) toCheck = string.Empty;
            return source?.IndexOf(toCheck, comp) >= 0;
        }
    }
}