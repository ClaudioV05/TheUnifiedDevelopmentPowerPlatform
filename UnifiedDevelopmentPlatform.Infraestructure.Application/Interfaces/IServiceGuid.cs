﻿namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface ServiceGuid.
    /// </summary>
    public interface IServiceGuid
    {
        /// <summary>
        /// To generate the new "universally unique identifier" (UUID) object.
        /// </summary>
        /// <param name=""></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The guid object.</returns>
        string? UDPGenerateTheNewUniversallyUniqueIdentifier();

        /// <summary>
        /// To validate the "universally unique identifier" (UUID) with regex.
        /// </summary>
        /// <param name="value"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The method will return true, otherwise will return false.</returns>
        bool UDValidateWithRegexTheUniversallyUniqueIdentifier(string value);

        /// <summary>
        /// To validate the "universally unique identifier" (UUID) with guid parse.
        /// </summary>
        /// <param name="value"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The method will return true, otherwise will return false.</returns>
        bool UDValidateWithGuidParseTheUniversallyUniqueIdentifier(string value);
    }
}