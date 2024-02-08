using System.Text;
using System.Text.RegularExpressions;
using UnifiedDevelopmentPlatform.Application.Interfaces;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service Functions of String.
    /// </summary>
    public class ServiceFuncString : IServiceFuncString
    {
        /// <summary>
        /// The constructor of Service Functions of Strings.
        /// </summary>
        public ServiceFuncString() { }

        public string Empty { get; } = string.Empty;

        public string StringWhiteSpace { get; } = " ";

        public char CharWhiteSpace { get; } = ' ';

        public char[] Base64Chars { get; } = new[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '/' };

        public string UDPRemoveSpecialCaracter(string text)
        {
            try
            {
                List<string> specialCaracter = new List<string>()
                {
                    "¹", "²", "³", "£", "¢", "¬", "º", "¨", "\"", "'", ".", ",", "-", ":", "(", ")", "ª", "|", "\\\\", "°",
                    "_", "@", "#", "!", "$", "%", "&", "*", ";", "/", "<", ">", "?","[", "]", "{", "}", "=", "+", "§" ,"´",
                    "`", "^", "~", "\r", "\n"
                };

                specialCaracter.ForEach(t => text = text.Replace(t, this.StringWhiteSpace));
                return text;
            }
            catch (Exception)
            {
                return this.Empty;
            }
        }

        public string UDPRemoveAllWhiteSpace(string text)
        {
            try
            {
                return String.Concat(text.Where(t => !Char.IsWhiteSpace(t)));
            }
            catch (Exception)
            {
                return this.Empty;
            }
        }

        public string UDPEncondeToBase64(string data)
        {
            try
            {
                var bytes = Encoding.ASCII.GetBytes(data);
                return Convert.ToBase64String(bytes, Base64FormattingOptions.None);
            }
            catch (Exception)
            {
                return this.Empty;
            }
        }

        public string UDPDecodeToBase64(string data)
        {
            try
            {
                var bytes = Convert.FromBase64String(data);
                return ASCIIEncoding.ASCII.GetString(bytes);
            }
            catch (Exception)
            {
                return this.Empty;
            }
        }

        [Obsolete("Method with problem", true)]
        public string UDPRemoveSpecialCaracterFrompath(string path)
        {
            try
            {
                if (!this.UDPNullOrEmpty(path) && path.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                {
                    foreach (char c in Path.GetInvalidFileNameChars())
                    {
                        path = path.Replace(c.ToString(), string.Empty);
                    }
                }

                return path;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public string UDPSelectSection(string text)
        {
            string section = this.Empty;
            int posSection = text.LastIndexOf("\\") + 1;

            if (posSection != -1)
            {
                section = text.Substring(posSection);
            }

            return section;
        }

        public string UDPOnlyLetter(string text)
        {
            string onlyLetter = this.Empty;

            try
            {
                foreach (char c in text)
                {
                    if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c.Equals(' '))
                    {
                        onlyLetter += c;
                    }
                }

                return onlyLetter;
            }
            catch (Exception)
            {
                return this.Empty;
            }
        }

        #region For Treatment of Strings.

        public string UDPUpper(string text)
        {
            string value = this.Empty;

            try
            {
                if (!this.UDPNullOrEmpty(text))
                {
                    value = text.ToUpperInvariant();
                }

                return value;
            }
            catch (Exception)
            {
                return this.Empty;
            }
        }

        public string UDPLower(string text)
        {
            string value = this.Empty;

            try
            {
                if (!this.UDPNullOrEmpty(text))
                {
                    value = text.ToLowerInvariant();
                }

                return value;
            }
            catch (Exception)
            {
                return this.Empty;
            }
        }

        public IEnumerable<string> UDPLowerInList(string text)
        {
            foreach (var item in text.Split(this.CharWhiteSpace, StringSplitOptions.None))
            {
                yield return this.UDPLower(item);
            }
        }

        public bool UDPNullOrEmpty(string text)
        {
            return string.IsNullOrEmpty(text);
        }

        public bool UDPNullOrWhiteSpace(string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }

        public string UDPRemoveWhitespace(string text)
        {
            return text.Trim();
        }

        public bool UDPStringStarts(string text, string value)
        {
            return text.StartsWith(value);
        }

        public bool UDPStringEnds(string text, string value)
        {
            return text.EndsWith(value);
        }

        public string UDPReplace(string text, string oldValue, string newValue)
        {
            return text.Replace(oldValue, newValue);
        }

        public string UDPRemoveAnyWhiteSpace(string text)
        {
            return String.Concat(text.Where(c => !Char.IsWhiteSpace(c)));
        }

        public string UDPToCamelCase(string text)
        {
            if (this.UDPNullOrEmpty(text) || char.IsLower(text[0]))
            {
                return text;
            }

            var chars = text.ToCharArray();
            chars[0] = char.ToLowerInvariant(text[0]);

            return new(chars);
        }

        public string UDPToPascalCase(string text)
        {
            return Regex.Replace(text, @"([^\p{Pc}]+)[\p{Pc}]*", new MatchEvaluator(mtch =>
                             {
                                 var word = this.UDPLower(mtch.Groups[1].Value);
                                 return $"{Char.ToUpper(word[0])}{word.Substring(1)}";
                             }));
        }
        #endregion For Treatment of Strings.
    }
}