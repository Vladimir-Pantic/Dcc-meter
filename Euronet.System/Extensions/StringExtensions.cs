using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        public static bool IsNotNullOrWhiteSpace(this string s)
        {
            return !string.IsNullOrWhiteSpace(s);
        }

        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        public static bool IsNotNullOrEmpty(this string? s)
        {
            return !string.IsNullOrEmpty(s);
        }

        public static string IfNullOrEmpty(this string s, params string[] fallbacks)
        {
            if (s.IsNullOrEmpty())
            {
                foreach (string text in fallbacks)
                {
                    if (!text.IsNullOrEmpty())
                    {
                        return text;
                    }
                }
            }

            return s;
        }

        public static string ToInitialUpper(this string s)
        {
            if (s.IsNullOrEmpty())
            {
                return s;
            }

            string text = s.Substring(0, 1).ToUpperInvariant();
            if (s.Length > 1)
            {
                text += s.Substring(1);
            }

            return text;
        }

        public static string ToInitialLower(this string s)
        {
            if (s.IsNullOrEmpty())
            {
                return s;
            }

            string text = s.Substring(0, 1).ToLowerInvariant();
            if (s.Length > 1)
            {
                text += s.Substring(1);
            }

            return text;
        }

        public static string Capitalize(this string s)
        {
            if (s.IsNullOrEmpty())
            {
                return s;
            }

            string text = s.Substring(0, 1).ToUpperInvariant();
            if (s.Length > 1)
            {
                text += s.Substring(1).ToLowerInvariant();
            }

            return text;
        }

        public static string ToCamelCase(this string s, bool capitalize = true, bool abbreviationsLikeOrdinaryWords = true)
        {
            string text = string.Empty;
            bool flag = false;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (text.IsNullOrEmpty())
                {
                    if (capitalize)
                    {
                        text = char.ToUpperInvariant(c).ToString();
                        flag = true;
                    }
                    else
                    {
                        text += c;
                        flag = c == char.ToUpperInvariant(c);
                    }
                }
                else if (c == char.ToUpperInvariant(c))
                {
                    text = ((!(flag && abbreviationsLikeOrdinaryWords)) ? (text + c) : (text + c.ToString().ToLowerInvariant()));
                    flag = abbreviationsLikeOrdinaryWords;
                }
                else
                {
                    text += c;
                    flag = false;
                }
            }

            return text;
        }

        public static string ToTitleCase(this string s, bool abbreviationsLikeOrdinaryWords = true)
        {
            string text = string.Empty;
            bool flag = false;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (text.IsNullOrEmpty())
                {
                    text = char.ToUpperInvariant(c).ToString();
                    flag = true;
                }
                else if (c == char.ToUpperInvariant(c))
                {
                    text = ((!flag) ? (text + " " + c) : (text + c.ToString().ToLowerInvariant()));
                    flag = true;
                }
                else
                {
                    text += c;
                    flag = false;
                }
            }

            return text;
        }

        public static string ToInitials(this string s)
        {
            if (s.IsNullOrEmpty())
            {
                return s;
            }

            s = s.ToInitialUpper();
            string text = string.Empty;
            string text2 = s;
            foreach (char c in text2)
            {
                if (c == char.ToUpperInvariant(c))
                {
                    text += $"{c}";
                }
            }

            return text;
        }

        public static string ToSnakeCase(this string s)
        {
            if (s.IsNullOrEmpty())
            {
                return s;
            }

            string text = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                text = ((!text.IsNullOrEmpty()) ? ((c != char.ToUpperInvariant(c)) ? (text + c) : (text + "_" + char.ToLowerInvariant(c))) : char.ToLowerInvariant(c).ToString());
            }

            return text;
        }

        public static string ToTrainCase(this string s)
        {
            if (s.IsNullOrEmpty())
            {
                return s;
            }

            string text = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                text = ((!text.IsNullOrEmpty()) ? ((c != char.ToUpperInvariant(c)) ? (text + c) : (text + "-" + char.ToLowerInvariant(c))) : char.ToLowerInvariant(c).ToString());
            }

            return text;
        }

        public static string Pluralize(this string s)
        {
            if (s.IsNullOrEmpty())
            {
                return s;
            }

            if (s.EndsWith("zes") || s.EndsWith("ses") || s.EndsWith("ies"))
            {
                return s;
            }

            if (s.EndsWith("s", StringComparison.InvariantCultureIgnoreCase) || s.EndsWith("z", StringComparison.InvariantCultureIgnoreCase))
            {
                return s + "es";
            }

            if (s.EndsWith("y", StringComparison.InvariantCultureIgnoreCase))
            {
                return s.Substring(0, s.Length - 1) + "ies";
            }

            return s + "s";
        }

        public static string Singularize(this string s)
        {
            if (s.IsNullOrEmpty())
            {
                return s;
            }

            if (s.EndsWith("ies"))
            {
                return s.Substring(0, s.Length - 3) + "y";
            }

            if (s.EndsWith("zes") || s.EndsWith("ses"))
            {
                return s.Substring(0, s.Length - 2);
            }

            if (s.EndsWith("s") && !s.ToLower().EndsWith("status"))
            {
                return s.Substring(0, s.Length - 1);
            }

            return s;
        }
    }
}
