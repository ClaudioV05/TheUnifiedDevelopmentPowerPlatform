namespace UnifiedDevelopmentPowerPlatform.Application.Interfaces;

/// <summary>
/// Interface service func string.
/// </summary>
public interface IServiceFuncString
{
    /// <summary>
    /// string.Empty.
    /// </summary>
    public string Empty { get; }

    /// <summary>
    /// Base 64 chars.
    /// </summary>
    public char[] Base64Chars { get; }

    /// <summary>
    /// Remove special caracter.
    /// </summary>
    /// <param name="text"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The strings without special caracter.</returns>
    string UDPPRemoveSpecialCaracter(string text);

    /// <summary>
    /// Remove all white space.
    /// </summary>
    /// <param name="text"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The strings without white space.</returns>
    string UDPPRemoveAllWhiteSpace(string text);

    /// <summary>
    /// Enconde to base64.
    /// </summary>
    /// <param name="data"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns></returns>
    string UDPPEncondeToBase64(string data);

    /// <summary>
    /// Decode to base64.
    /// </summary>
    /// <param name="data"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns></returns>
    string UDPPDecodeToBase64(string data);

    /// <summary>
    /// Remove special caracter from path.
    /// </summary>
    /// <param name="path"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns></returns>
    string UDPPRemoveSpecialCaracterFromPath(string path);

    /// <summary>
    /// Select section.
    /// </summary>
    /// <param name="text"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>Section name.</returns>
    string UDPPSelectSection(string text);

    /// <summary>
    /// Only letter.
    /// </summary>
    /// <param name="text"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The text only with letter.</returns>
    string UDPPOnlyLetter(string text);

    /// <summary>
    /// Only number.
    /// </summary>
    /// <param name="text"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The text only with number.</returns>
    string UDPPOnlyNumber(string text);

    /// <summary>
    /// Verify if string contains only ascii letters.
    /// </summary>
    /// <param name="text"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPPIsOnlyAsciiLetters(string text);

    /// <summary>
    /// Verify if string contains only value numeric.
    /// </summary>
    /// <param name="text"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPPIsOnlyDigit(string text);

    /// <summary>
    /// Verify if string contains only ascii letters.
    /// </summary>
    /// <param name="text"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPPIsOnlyAsciiLettersBySwitchCase(string text);

    /// <summary>
    /// To Upper.
    /// </summary>
    /// <param name="text"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>String to upper.</returns>
    string UDPPUpper(string text);

    /// <summary>
    /// To Lower.
    /// </summary>
    /// <param name="text"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>String to lower.</returns>
    string UDPPLower(string text);

    /// <summary>
    /// Lower in list.
    /// </summary>
    /// <param name="text"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns></returns>
    IEnumerable<string> UDPPLowerInList(string text);

    /// <summary>
    /// If string contains caracther null or empty.
    /// </summary>
    /// <param name="text"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPPNullOrEmpty(string text);

    /// <summary>
    /// If string contains caracther null or with white space.
    /// </summary>
    /// <param name="text"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPPNullOrWhiteSpace(string text);

    /// <summary>
    /// Removes white space from both sides of a string.
    /// </summary>
    /// <param name="text"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns></returns>
    string UDPPRemoveWhitespace(string text);

    /// <summary>
    /// Removes white space at the start of a string.
    /// </summary>
    /// <param name="text"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns></returns>
    string UDPPRemoveWhitespaceAtStart(string text);

    /// <summary>
    /// If string starts with the value specified.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="value"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPPStringStarts(string text, string value);

    /// <summary>
    /// If string ends with the value specified.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="value"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPPStringEnds(string text, string value);

    /// <summary>
    /// To replace.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns></returns>
    string UDPPReplace(string text, string oldValue, string newValue);

    /// <summary>
    /// Contains.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="value"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPPContains(string text, string value);

    /// <summary>
    /// Remove any whitespace in string.
    /// </summary>
    /// <param name="text"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns></returns>
    string UDPPRemoveAnyWhiteSpace(string text);

    /// <summary>
    /// To Camel Case.
    /// </summary>
    /// <param name="text"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns></returns>
    string UDPPToCamelCase(string text);

    /// <summary>
    /// To Pascal Case.
    /// </summary>
    /// <param name="text"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns></returns>
    string UDPPToPascalCase(string text);

    /// <summary>
    /// To string split with options none.
    /// </summary>
    /// <param name="separators"></param>
    /// <param name="text"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The array of string</returns>
    string[]? UDPPParseLine(string[] separators, string text);

    /// <summary>
    /// Do find index of in a string.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="itemToFind"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>Position of string.</returns>
    int UDPPIndexOf(string text, string itemToFind);

    /// <summary>
    /// Do find the last index of in a string.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="itemToFind"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>Position of string.</returns>
    int UDPPLastIndexOf(string text, string itemToFind);

    /// <summary>
    /// Sub String.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="startIndex"></param>
    /// <param name="lenght"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>Retrieve a substring for a instance.</returns>
    string UDPPSubString(string text, int startIndex, int lenght);
}