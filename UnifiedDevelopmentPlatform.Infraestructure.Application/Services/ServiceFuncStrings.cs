using System.Text;
using UnifiedDevelopmentPlatform.Application.Interfaces;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    public class ServiceFuncStrings : IServiceFuncStrings
    {
        public string RemoveSpecialCaracter(string text)
        {
            try
            {
                List<string> specialCaracter = new List<string>()
                {
                    "¹", "²", "³", "£", "¢", "¬", "º", "¨", "\"", "'", ".", ",", "-", ":", "(", ")", "ª", "|", "\\\\", "°",
                    "_", "@", "#", "!", "$", "%", "&", "*", ";", "/", "<", ">", "?","[", "]", "{", "}", "=", "+", "§" ,"´",
                    "`", "^", "~", "\r", "\n"
                };

                specialCaracter.ForEach(t => text = text.Replace(t, " "));
                return text;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public string RemoveAllWhiteSpace(string text)
        {
            try
            {
                return String.Concat(text.Where(t => !Char.IsWhiteSpace(t)));
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public string EncondeToBase64(string data)
        {
            try
            {
                var bytes = Encoding.ASCII.GetBytes(data);
                return Convert.ToBase64String(bytes, Base64FormattingOptions.None);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public string DecodeToBase64(string data)
        {
            try
            {
                var bytes = Convert.FromBase64String(data);
                return ASCIIEncoding.ASCII.GetString(bytes);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        [Obsolete("Method with problem", true)]
        public string RemoveSpecialCaracterFrompath(string path)
        {
            try
            {
                if (!this.NullOrEmpty(path) && path.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
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

        public string SelectSectionStandard(string text)
        {
            string section = string.Empty;
            int posSection = text.LastIndexOf("\\") + 1;

            if (posSection != -1)
            {
                section = text.Substring(posSection);
            }

            return section;
        }

        #region For Treatment of Strings.

        public string Upper(string text)
        {
            string value = string.Empty;

            try
            {
                if (!this.NullOrEmpty(text))
                {
                    value = text.ToUpperInvariant();
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }

            return value;
        }

        public string Lower(string text)
        {
            string value = string.Empty;

            try
            {
                if (!this.NullOrEmpty(text))
                {
                    value = text.ToLowerInvariant();
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }

            return value;
        }

        public bool NullOrEmpty(string text)
        {
            return string.IsNullOrEmpty(text);
        }

        public bool NullOrWhiteSpace(string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }

        public string RemoveWhitespace(string text)
        {
            return text.Trim();
        }

        public bool StringStarts(string text, string value)
        {
            return text.StartsWith(value);
        }

        public bool StringEnds(string text, string value)
        {
            return text.EndsWith(value);
        }

        #endregion For Treatment of Strings.
    }
}