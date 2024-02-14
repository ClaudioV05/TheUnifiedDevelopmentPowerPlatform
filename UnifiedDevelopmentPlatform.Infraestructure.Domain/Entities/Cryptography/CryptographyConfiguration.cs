using System.Text;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Cryptography
{
    /// <summary>
    /// Cryptography.
    /// </summary>
    public static class CryptographyConfiguration
    {
        /// <summary>
        /// the cryptography key.
        /// </summary>
        public static string CryptographyKey => "3b4750253d5b274b6346545f3c2b323f6b436c596e6d3c6e5d23552d4a";

        /// <summary>
        /// the cryptography key of byte array.
        /// </summary>
        public static byte[] CryptographyByteArray { get; } = { 12, 34, 56, 78, 90, 102, 114, 126 };
    }
}