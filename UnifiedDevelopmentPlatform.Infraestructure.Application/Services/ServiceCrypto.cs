using System.Text;
using UnifiedDevelopmentPlatform.Application.Interfaces;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service Crypto.
    /// </summary>
    public class ServiceCrypto : IServiceCrypto
    {
        //private readonly string _keyCrypto = "3b4750253d5b274b6346545f3c2b323f6b436c596e6d3c6e5d23552d4a";

        /// <summary>
        /// The constructor of Service Crypto.
        /// </summary>
        public ServiceCrypto() { }

        public string UPDEncrypt(string value)
        {
            /*
            byte[] input;
            byte[] key = { };
            byte[] newValue = { 12, 34, 56, 78, 90, 102, 114, 126 };

            DESCryptoServiceProvider? provider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            try
            {
                input = Encoding.UTF8.GetBytes(value);
                key = Encoding.UTF8.GetBytes(_keyCrypto.Substring(0, 8));

                var cryptoStream = new CryptoStream(memoryStream, provider.CreateEncryptor(key, newValue), CryptoStreamMode.Write);
                cryptoStream.Write(input, 0, input.Length);
                cryptoStream.FlushFinalBlock();
            }
            catch (Exception)
            {
                return string.Empty;
            }
            */
            return "";// Convert.ToBase64String(memoryStream.ToArray());
        }

        public string UPDDecrypt(string value)
        {
            /*
            byte[] input;
            byte[] key = { };
            byte[] newValue = { 12, 34, 56, 78, 90, 102, 114, 126 };

            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            try
            {
                input = new byte[value.Length];
                input = Convert.FromBase64String(value.Replace(" ", "+"));

                key = Encoding.UTF8.GetBytes(_keyCrypto.Substring(0, 8));

                var cryptoStream = new CryptoStream(memoryStream, provider.CreateDecryptor(key, newValue), CryptoStreamMode.Write);
                cryptoStream.Write(input, 0, input.Length);
                cryptoStream.FlushFinalBlock();
            }
            catch (Exception)
            {
                return string.Empty;
            }
            */
            return "";// Encoding.UTF8.GetString(memoryStream.ToArray());
        }

        public string UPDDecodeBase64(string? value)
        {
            try
            {
                var valueBytes = Convert.FromBase64String(value ?? string.Empty);
                return Encoding.UTF8.GetString(valueBytes);
            }
            catch (Exception)
            {
                return string.Empty;
            }

        }
    }
}