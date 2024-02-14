using System.Security.Cryptography;
using System.Text;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Cryptography;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service Crypto.
    /// </summary>
    public class ServiceCrypto : IServiceCrypto
    {
        private readonly IServiceFuncString _serviceFuncStrings;

        /// <summary>
        /// The constructor of Service Crypto.
        /// </summary>
        /// <param name="serviceFuncString"></param>
        public ServiceCrypto(IServiceFuncString serviceFuncString)
        {
            _serviceFuncStrings = serviceFuncString;
        }

        public string UPDEncrypt(string value)
        {
            byte[] input;
            byte[] key = { };
            MemoryStream memoryStream = new MemoryStream();
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();

            try
            {
                input = Encoding.UTF8.GetBytes(value);
                key = Encoding.UTF8.GetBytes(CryptographyConfiguration.CryptographyKey.Substring(0, 8));

                CryptoStream cryptoStream = new CryptoStream(memoryStream, provider.CreateEncryptor(key, CryptographyConfiguration.CryptographyByteArray), CryptoStreamMode.Write);
                cryptoStream.Write(input, 0, input.Length);
                cryptoStream.FlushFinalBlock();
                return Convert.ToBase64String(memoryStream.ToArray());
            }
            catch (CryptographicException)
            {
                return _serviceFuncStrings.Empty;
            }
        }

        public string UPDDecrypt(string value)
        {
            byte[] input;
            byte[] key = { };
            MemoryStream memoryStream = new MemoryStream();
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();

            try
            {
                input = new byte[value.Length];
                input = Convert.FromBase64String(value.Replace(_serviceFuncStrings.StringWhiteSpace, "+"));
                key = Encoding.UTF8.GetBytes(CryptographyConfiguration.CryptographyKey.Substring(0, 8));
               
                CryptoStream cryptoStream = new CryptoStream(memoryStream, provider.CreateDecryptor(key, CryptographyConfiguration.CryptographyByteArray), CryptoStreamMode.Write);
                cryptoStream.Write(input, 0, input.Length);
                cryptoStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
            catch (CryptographicException)
            {
                return _serviceFuncStrings.Empty;
            }
        }

        public string UPDDecodeBase64(string? value)
        {
            try
            {
                var valueBytes = Convert.FromBase64String(value ?? _serviceFuncStrings.Empty);
                return Encoding.UTF8.GetString(valueBytes);
            }
            catch (Exception)
            {
                return _serviceFuncStrings.Empty;
            }
        }
    }
}