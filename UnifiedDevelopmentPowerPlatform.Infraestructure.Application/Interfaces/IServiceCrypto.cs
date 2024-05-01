namespace UnifiedDevelopmentPowerPlatform.Application.Interfaces;

/// <summary>
/// Interface service crypto.
/// </summary>
public interface IServiceCrypto
{
    /// <summary>
    /// Encrypt data.
    /// </summary>
    /// <param name="value"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>Data encrypt.</returns>
    string UPDEncryptData(string value);

    /// <summary>
    /// Decrypt data.
    /// </summary>
    /// <param name="value"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>Data decrypt.</returns>
    string UPDDecryptData(string value);

    /// <summary>
    /// Encode to base64.
    /// </summary>
    /// <param name="value"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>Data encoded from base 64 to format string.</returns>
    string UPDEncodeToBase64(string? value);

    /// <summary>
    /// Decode from base 64.
    /// </summary>
    /// <param name="value"></param>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>Data decode from base 64.</returns>
    string UPDDecodeFromBase64(string? value);
}