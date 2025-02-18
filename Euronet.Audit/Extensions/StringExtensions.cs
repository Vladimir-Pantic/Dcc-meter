namespace System
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string s)
        {
            return String.IsNullOrWhiteSpace(s);
        }

        public static bool IsNotNullOrWhiteSpace(this string s)
        {
            return !String.IsNullOrWhiteSpace(s);
        }

        public static bool IsNullOrEmpty(this string s)
        {
            return String.IsNullOrEmpty(s);
        }

        public static bool IsNotNullOrEmpty(this string s)
        {
            return !String.IsNullOrEmpty(s);
        }

        public static string IfNullOrEmpty(this string s, params string[] fallbacks)
        {
            if (s.IsNullOrEmpty())
            {
                foreach (string fallback in fallbacks)
                {
                    if (!fallback.IsNullOrEmpty())
                    {
                        return fallback;
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

            string result = s.Substring(0, 1).ToUpperInvariant();

            if (s.Length > 1)
            {
                result += s.Substring(1);
            }

            return result;
        }

        public static string ToInitialLower(this string s)
        {
            if (s.IsNullOrEmpty())
            {
                return s;
            }

            string result = s.Substring(0, 1).ToLowerInvariant();

            if (s.Length > 1)
            {
                result += s.Substring(1);
            }

            return result;
        }

        public static string Capitalize(this string s)
        {
            if (s.IsNullOrEmpty())
            {
                return s;
            }

            string result = s.Substring(0, 1).ToUpperInvariant();

            if (s.Length > 1)
            {
                result += s.Substring(1).ToLowerInvariant(); ;
            }

            return result;
        }

        public static string ToCamelCase(this string s, bool capitalize = true, bool abbreviationsLikeOrdinaryWords = true)
        {
            string result = String.Empty;

            bool previousWasUpper = false;

            foreach (char c in s)
            {
                if (result.IsNullOrEmpty())
                {
                    if (capitalize)
                    {
                        result = Char.ToUpperInvariant(c).ToString();

                        previousWasUpper = true;
                    }
                    else
                    {
                        result += c.ToString();

                        previousWasUpper = c == Char.ToUpperInvariant(c);
                    }
                }
                else
                {
                    if (c == Char.ToUpperInvariant(c))
                    {
                        if (previousWasUpper && abbreviationsLikeOrdinaryWords)
                        {
                            result += c.ToString().ToLowerInvariant();
                        }
                        else
                        {
                            result += c.ToString();
                        }

                        previousWasUpper = true && abbreviationsLikeOrdinaryWords;
                    }
                    else
                    {
                        result += c.ToString();

                        previousWasUpper = false;
                    }
                }
            }

            return result;
        }

        public static string ToTitleCase(this string s, bool abbreviationsLikeOrdinaryWords = true)
        {
            string result = String.Empty;

            bool previousWasUpper = false;

            foreach (char c in s)
            {
                if (result.IsNullOrEmpty())
                {
                    result = Char.ToUpperInvariant(c).ToString();

                    previousWasUpper = true;
                }
                else
                {
                    if (c == Char.ToUpperInvariant(c))
                    {
                        if (previousWasUpper)
                        {
                            result += c.ToString().ToLowerInvariant();
                        }
                        else
                        {
                            result += $" {c.ToString()}";
                        }

                        previousWasUpper = true;
                    }
                    else
                    {
                        result += c.ToString();

                        previousWasUpper = false;
                    }
                }
            }

            return result;
        }
        public static string ToInitials(this string s)
        {
            if (s.IsNullOrEmpty())
            {
                return s;
            }

            s = s.ToInitialUpper();

            string result = String.Empty;

            foreach (char c in s)
            {
                if (c == Char.ToUpperInvariant(c))
                {
                    result += $"{c}";
                }
            }

            return result;
        }

        public static string ToSnakeCase(this string s)
        {
            if (s.IsNullOrEmpty())
            {
                return s;
            }

            string result = String.Empty;

            foreach (char c in s)
            {
                if (result.IsNullOrEmpty())
                {
                    result = Char.ToLowerInvariant(c).ToString();
                }
                else
                {
                    if (c == Char.ToUpperInvariant(c))
                    {
                        result += $"_{Char.ToLowerInvariant(c).ToString()}";
                    }
                    else
                    {
                        result += c.ToString();
                    }
                }
            }

            return result;
        }

        public static string ToTrainCase(this string s)
        {
            if (s.IsNullOrEmpty())
            {
                return s;
            }

            string result = String.Empty;

            foreach (char c in s)
            {
                if (result.IsNullOrEmpty())
                {
                    result = Char.ToLowerInvariant(c).ToString();
                }
                else
                {
                    if (c == Char.ToUpperInvariant(c))
                    {
                        result += $"-{Char.ToLowerInvariant(c).ToString()}";
                    }
                    else
                    {
                        result += c.ToString();
                    }
                }
            }

            return result;
        }

        public static string Pluralize(this string s)
        {
            if (s.IsNullOrEmpty())
            {
                return s;
            }

            //already pluralized
            if (s.EndsWith("zes") || s.EndsWith("ses") || s.EndsWith("ies"))
            {
                return s;
            }

            if (s.EndsWith("s", StringComparison.InvariantCultureIgnoreCase) ||
                s.EndsWith("z", StringComparison.InvariantCultureIgnoreCase))
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
