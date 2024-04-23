using System.Text;
using System.Text.RegularExpressions;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.MetaCharacter;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service func string.
    /// </summary>
    public class ServiceFuncString : IServiceFuncString
    {
        /// <summary>
        /// The constructor of service func string.
        /// </summary>
        public ServiceFuncString() { }

        public string Empty { get; } = string.Empty;

        public char[] Base64Chars { get; } = new[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '/' };

        public string UDPRemoveSpecialCaracter(string text)
        {
            try
            {
                List<string> specialCaracter = new List<string>()
                {
                    "¹", "²", "³", "£", "¢", "¬", "º", "¨", "\"", "'", ".", ",", "-", ":", "(", ")", "ª",
                    "|", "\\\\", "°", "_", "@", "#", "!", "$", "%", "&", "*", ";", "/", "<", ">", "?","[",
                    "]", "{", "}", "=", "+", "§" ,"´", "`", "^", "~", "\r", "\n"
                };

                specialCaracter.ForEach(t => text = text.Replace(t, MetaCharacterSymbols.WhiteSpace));
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

        [Obsolete("deprecated method", true)]
        public string UDPRemoveSpecialCaracterFromPath(string path)
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
            try
            {
                return string.Concat(text.Where(char.IsLetter));
            }
            catch (Exception)
            {
                return this.Empty;
            }
        }

        public string UDPOnlyNumber(string text)
        {
            try
            {
                return string.Concat(text.Where(char.IsNumber));
            }
            catch (Exception)
            {
                return this.Empty;
            }
        }

        public bool UDPIsOnlyAsciiLetters(string text)
        {
            return text.All(char.IsAscii);
        }

        public bool UDPIsOnlyDigit(string text)
        {
            return int.TryParse(text, out _);
        }

        public bool UDPIsOnlyAsciiLettersBySwitchCase(string text)
        {
            foreach (var item in text)
            {
                switch (item)
                {
                    case >= 'A' and <= 'Z':
                    case >= 'a' and <= 'z':
                        continue;
                    default:
                        return false;
                }
            }
            return true;
        }

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
            foreach (var item in text.Split(MetaCharacterSymbols.CharWhiteSpace, StringSplitOptions.None))
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

        public string UDPRemoveWhitespaceAtStart(string text)
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

        public bool UDPContains(string text, string value)
        {
            return text.Contains(value);
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

        public string[]? UDPParseLine(string[] separators, string text)
        {
            return text.Split(separators, StringSplitOptions.None);
        }

        public int UDPIndexOf(string text, string itemToFind)
        {
            return text.IndexOf(itemToFind);
        }

        public int UDPLastIndexOf(string text, string itemToFind)
        {
            return text.LastIndexOf(itemToFind);
        }

        public string UDPSubString(string text, int startIndex, int lenght)
        {
            string textValue = this.Empty;

            if (lenght > 0)
            {
                textValue = text.Substring(startIndex, lenght);
            }
            else
            {
                textValue = text;
            }

            return textValue;
        }
    }
}