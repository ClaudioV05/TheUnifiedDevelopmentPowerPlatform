namespace UnifiedDevelopmentPowerPlatform.Application.Interfaces;

/// <summary>
/// Interface service crypto.
/// </summary>
/// <remarks>This class cannot be inherited.</remarks>
public interface IServiceCrypto
{
    /// <summary>
    /// Encrypt data.
    /// </summary>
    /// <param name="value"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>Data encrypt.</returns>
    string UDPPEncryptData(string value);

    /// <summary>
    /// Decrypt data.
    /// </summary>
    /// <param name="value"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>Data decrypt.</returns>
    string UDPPDecryptData(string value);

    /// <summary>
    /// Encode to base64.
    /// </summary>
    /// <param name="value"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>Data encoded from base 64 to format string.</returns>
    string UDPPEncodeToBase64(string? value);

    /// <summary>
    /// Decode from base 64.
    /// </summary>
    /// <param name="value"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>Data decode from base 64.</returns>
    string UDPPDecodeFromBase64(string? value);
}