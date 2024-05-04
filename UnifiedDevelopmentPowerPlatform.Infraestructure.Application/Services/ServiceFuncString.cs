using System.Text;
using System.Text.RegularExpressions;
using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.MetaCharacter;

namespace UnifiedDevelopmentPowerPlatform.Application.Services;

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

    public string UDPPRemoveSpecialCaracter(string text)
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

    public string UDPPRemoveAllWhiteSpace(string text)
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

    public string UDPPEncondeToBase64(string data)
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

    public string UDPPDecodeToBase64(string data)
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
    public string UDPPRemoveSpecialCaracterFromPath(string path)
    {
        try
        {
            if (!this.UDPPNullOrEmpty(path) && path.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
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

    public string UDPPSelectSection(string text)
    {
        string section = this.Empty;
        int posSection = text.LastIndexOf("\\") + 1;

        if (posSection != -1)
        {
            section = text.Substring(posSection);
        }

        return section;
    }

    public string UDPPOnlyLetter(string text)
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

    public string UDPPOnlyNumber(string text)
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

    public bool UDPPIsOnlyAsciiLetters(string text)
    {
        return text.All(char.IsAscii);
    }

    public bool UDPPIsOnlyDigit(string text)
    {
        return int.TryParse(text, out _);
    }

    public bool UDPPIsOnlyAsciiLettersBySwitchCase(string text)
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

    public string UDPPUpper(string text)
    {
        string value = this.Empty;

        try
        {
            if (!this.UDPPNullOrEmpty(text))
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

    public string UDPPLower(string text)
    {
        string value = this.Empty;

        try
        {
            if (!this.UDPPNullOrEmpty(text))
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

    public IEnumerable<string> UDPPLowerInList(string text)
    {
        foreach (var item in text.Split(MetaCharacterSymbols.CharWhiteSpace, StringSplitOptions.None))
        {
            yield return this.UDPPLower(item);
        }
    }

    public bool UDPPNullOrEmpty(string text)
    {
        return string.IsNullOrEmpty(text);
    }

    public bool UDPPNullOrWhiteSpace(string text)
    {
        return string.IsNullOrWhiteSpace(text);
    }

    public string UDPPRemoveWhitespace(string text)
    {
        return text.Trim();
    }

    public string UDPPRemoveWhitespaceAtStart(string text)
    {
        return text.Trim();
    }

    public bool UDPPStringStarts(string text, string value)
    {
        return text.StartsWith(value);
    }

    public bool UDPPStringEnds(string text, string value)
    {
        return text.EndsWith(value);
    }

    public string UDPPReplace(string text, string oldValue, string newValue)
    {
        return text.Replace(oldValue, newValue);
    }

    public bool UDPPContains(string text, string value)
    {
        return text.Contains(value);
    }

    public string UDPPRemoveAnyWhiteSpace(string text)
    {
        return String.Concat(text.Where(c => !Char.IsWhiteSpace(c)));
    }

    public string UDPPToCamelCase(string text)
    {
        if (this.UDPPNullOrEmpty(text) || char.IsLower(text[0]))
        {
            return text;
        }

        var chars = text.ToCharArray();
        chars[0] = char.ToLowerInvariant(text[0]);

        return new(chars);
    }

    public string UDPPToPascalCase(string text)
    {
        return Regex.Replace(text, @"([^\p{Pc}]+)[\p{Pc}]*", new MatchEvaluator(mtch =>
                         {
                             var word = this.UDPPLower(mtch.Groups[1].Value);
                             return $"{Char.ToUpper(word[0])}{word.Substring(1)}";
                         }));
    }

    public string[]? UDPPParseLine(string[] separators, string text)
    {
        return text.Split(separators, StringSplitOptions.None);
    }

    public int UDPPIndexOf(string text, string itemToFind)
    {
        return text.IndexOf(itemToFind);
    }

    public int UDPPLastIndexOf(string text, string itemToFind)
    {
        return text.LastIndexOf(itemToFind);
    }

    public string UDPPSubString(string text, int startIndex, int lenght)
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