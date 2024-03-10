namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface ServiceFuncString.
    /// </summary>
    public interface IServiceFuncString
    {
        /// <summary>
        /// string.Empty.
        /// </summary>
        public string Empty { get; }

        /// <summary>
        /// string with white space.
        /// </summary>
        public string StringWhiteSpace { get; }

        /// <summary>
        /// char with white space.
        /// </summary>
        public char CharWhiteSpace { get; }

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
        string UDPRemoveSpecialCaracter(string text);

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
        string UDPRemoveAllWhiteSpace(string text);

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
        string UDPEncondeToBase64(string data);

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
        string UDPDecodeToBase64(string data);

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
        string UDPRemoveSpecialCaracterFromPath(string path);

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
        string UDPSelectSection(string text);

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
        bool UDPIsOnlyAsciiLetters(string text);

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
        bool UDPIsOnlyAsciiLettersBySwitchCase(string text);

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
        string UDPUpper(string text);

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
        string UDPLower(string text);

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
        IEnumerable<string> UDPLowerInList(string text);

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
        bool UDPNullOrEmpty(string text);

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
        bool UDPNullOrWhiteSpace(string text);

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
        string UDPRemoveWhitespace(string text);

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
        string UDPRemoveWhitespaceAtStart(string text);

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
        bool UDPStringStarts(string text, string value);

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
        bool UDPStringEnds(string text, string value);

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
        string UDPReplace(string text, string oldValue, string newValue);

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
        bool UDPContains(string text, string value);

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
        string UDPRemoveAnyWhiteSpace(string text);

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
        string UDPToCamelCase(string text);

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
        string UDPToPascalCase(string text);

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
        string[]? UDPParseLine(string[] separators, string text);

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
        int UDPIndexOf(string text, string itemToFind);

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
        string UDPSubString(string text, int startIndex, int lenght);
    }
}