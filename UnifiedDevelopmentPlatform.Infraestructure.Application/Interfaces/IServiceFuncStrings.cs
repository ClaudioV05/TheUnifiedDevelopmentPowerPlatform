namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service Functions String.
    /// </summary>
    public interface IServiceFuncStrings
    {
        /// <summary>
        /// string.Empty.
        /// </summary>
        public string Empty { get; }

        /// <summary>
        /// string with white space.
        /// </summary>
        public string WhiteSpace { get; }

        /// <summary>
        /// Base 64 chars.
        /// </summary>
        public char[] Base64Chars { get; }

        /// <summary>
        /// Remove special caracter.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>The strings without special caracter.</returns>
        string UDPRemoveSpecialCaracter(string text);

        /// <summary>
        /// Remove all white space.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>The strings without white space.</returns>
        string UDPRemoveAllWhiteSpace(string text);

        /// <summary>
        /// Enconde to base64.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        string UDPEncondeToBase64(string data);

        /// <summary>
        /// Decode to base64.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        string UDPDecodeToBase64(string data);

        /// <summary>
        /// Remove special caracter from path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        string UDPRemoveSpecialCaracterFrompath(string path);

        /// <summary>
        /// Select section.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Section name.</returns>
        string UDPSelectSection(string text);

        #region For Treatment of Strings.

        /// <summary>
        /// To Upper.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>String to upper.</returns>
        string UDPUpper(string text);

        /// <summary>
        /// To Lower.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>String to lower.</returns>
        string UDPLower(string text);

        /// <summary>
        /// If string contains caracther null or empty.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>The method will return true, otherwise will return false.</returns>
        bool UDPNullOrEmpty(string text);

        /// <summary>
        /// If string contains caracther null or with white space.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>The method will return true, otherwise will return false.</returns>
        bool UDPNullOrWhiteSpace(string text);

        /// <summary>
        /// Removes white space from both sides of a string.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        string UDPRemoveWhitespace(string text);

        /// <summary>
        /// If string starts with the value specified.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="value"></param>
        /// <returns>The method will return true, otherwise will return false.</returns>
        bool UDPStringStarts(string text, string value);

        /// <summary>
        /// If string ends with the value specified.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="value"></param>
        /// <returns>The method will return true, otherwise will return false.</returns>
        bool UDPStringEnds(string text, string value);

        /// <summary>
        /// To replace.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        string UDPReplace(string text, string oldValue, string newValue);
        
        /// <summary>
        /// Remove any whitespace in string.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        string UDPRemoveAnyWhiteSpace(string text);

        /// <summary>
        /// To Camel Case.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        string UDPToCamelCase(string text);

        /// <summary>
        /// To Pascal Case.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        string UDPToPascalCase(string text);

        #endregion For Treatment of Strings.
    }
}