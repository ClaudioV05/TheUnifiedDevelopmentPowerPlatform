namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service Crypto.
    /// </summary>
    public interface IServiceCrypto
    {
        /// <summary>
        /// Encrypt.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Data encrypt.</returns>
        string UPDEncrypt(string value);

        /// <summary>
        /// Decrypt.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Data decrypt.</returns>
        string UPDDecrypt(string value);

        /// <summary>
        /// Decode to base64.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Data decode in base64.</returns>
        string UPDDecodeBase64(string? value);
    }
}