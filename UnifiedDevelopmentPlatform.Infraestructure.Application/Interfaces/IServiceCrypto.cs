namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    public interface IServiceCrypto
    {
        /// <summary>
        /// Encrypt.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Text encrypt.</returns>
        string UPDEncrypt(string value);

        /// <summary>
        /// Decrypt.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Text decrypt.</returns>
        string UPDDecrypt(string value);

        /// <summary>
        /// Decode to base64.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Text decode in base64.</returns>
        string UPDDecodeBase64(string? value);
    }
}