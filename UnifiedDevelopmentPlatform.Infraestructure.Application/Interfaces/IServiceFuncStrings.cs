﻿namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service for (Functions String).
    /// </summary>
    public interface IServiceFuncStrings
    {
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
        string Upper(string text);

        /// <summary>
        /// To Lower.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>String to lower.</returns>
        string Lower(string text);

        /// <summary>
        /// If string contains caracther null or empty.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Return true otherwise false.</returns>
        bool NullOrEmpty(string text);

        /// <summary>
        /// If string contains caracther null or with white space.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Return true otherwise false.</returns>
        bool NullOrWhiteSpace(string text);

        /// <summary>
        /// Removes white space from both sides of a string.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        string RemoveWhitespace(string text);

        /// <summary>
        /// If string starts with the value specified.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="value"></param>
        /// <returns>Return true otherwise false.</returns>
        bool StringStarts(string text, string value);

        /// <summary>
        /// If string ends with the value specified.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="value"></param>
        /// <returns>Return true otherwise false.</returns>
        bool StringEnds(string text, string value);

        #endregion For Treatment of Strings.
    }
}