using System.Security.Cryptography;
using System.Text;
using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Cryptography;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.MetaCharacter;

namespace UnifiedDevelopmentPowerPlatform.Application.Services
{
    /// <summary>
    /// Service crypto.
    /// </summary>
    public class ServiceCrypto : IServiceCrypto
    {
        private readonly IServiceLog _serviceLog;
        private readonly IServiceMessage _serviceMessage;
        private readonly IServiceFuncString _serviceFuncString;

        /// <summary>
        /// The constructor of service crypto.
        /// </summary>
        /// <param name="serviceLog"></param>
        /// <param name="serviceMessage"></param>
        /// <param name="serviceFuncString"></param>
        public ServiceCrypto(IServiceLog serviceLog,
                             IServiceMessage serviceMessage,
                             IServiceFuncString serviceFuncString)
        {
            _serviceLog = serviceLog;
            _serviceMessage = serviceMessage;
            _serviceFuncString = serviceFuncString;
        }

        public string UPDEncryptData(string value)
        {
            byte[] input;
            byte[] key = { };
            string data = _serviceFuncString.Empty;
            MemoryStream memoryStream = new MemoryStream();
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();

            try
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPGetMessage(TypeCrypto.CallStartToTheEncrypt), _serviceFuncString.Empty);
                input = Encoding.UTF8.GetBytes(value);
                key = Encoding.UTF8.GetBytes(CryptographyConfiguration.CryptographyKey.Substring(0, 8));

                CryptoStream cryptoStream = new CryptoStream(memoryStream, provider.CreateEncryptor(key, CryptographyConfiguration.CryptographyByteArray), CryptoStreamMode.Write);
                cryptoStream.Write(input, 0, input.Length);
                cryptoStream.FlushFinalBlock();
                data = Convert.ToBase64String(memoryStream.ToArray());

                _serviceLog.UDPLogReport(_serviceMessage.UDPGetMessage(TypeCrypto.SuccessToTheEncrypt), _serviceFuncString.Empty);

                return data;
            }
            catch (CryptographicException ex)
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPGetMessage(TypeCrypto.ErrorToTheEncrypt), ex.Message);
                return _serviceFuncString.Empty;
            }
            catch (Exception ex)
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPGetMessage(TypeCrypto.ErrorToTheEncrypt), ex.Message);
                return _serviceFuncString.Empty;
            }
        }

        public string UPDDecryptData(string value)
        {
            byte[] input;
            byte[] key = { };
            string data = _serviceFuncString.Empty;
            MemoryStream memoryStream = new MemoryStream();
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();

            try
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPGetMessage(TypeCrypto.CallStartToTheDecrypt), _serviceFuncString.Empty);
                input = new byte[value.Length];
                input = Convert.FromBase64String(value.Replace(MetaCharacterSymbols.WhiteSpace, "+"));
                key = Encoding.UTF8.GetBytes(CryptographyConfiguration.CryptographyKey.Substring(0, 8));

                CryptoStream cryptoStream = new CryptoStream(memoryStream, provider.CreateDecryptor(key, CryptographyConfiguration.CryptographyByteArray), CryptoStreamMode.Write);
                cryptoStream.Write(input, 0, input.Length);
                cryptoStream.FlushFinalBlock();
                data = Encoding.UTF8.GetString(memoryStream.ToArray());

                _serviceLog.UDPLogReport(_serviceMessage.UDPGetMessage(TypeCrypto.SuccessToTheDecrypt), _serviceFuncString.Empty);

                return data;
            }
            catch (CryptographicException ex)
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPGetMessage(TypeCrypto.ErrorToTheDecrypt), ex.Message);
                return _serviceFuncString.Empty;
            }
            catch (Exception ex)
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPGetMessage(TypeCrypto.ErrorToTheDecrypt), ex.Message);
                return _serviceFuncString.Empty;
            }
        }

        public string UPDEncodeToBase64(string? value)
        {
            string data = _serviceFuncString.Empty;

            try
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPGetMessage(TypeCrypto.CallStartToTheEncodeToBase64), _serviceFuncString.Empty);
                
                byte[] textBytes = Encoding.ASCII.GetBytes(value);
                data = Convert.ToBase64String(textBytes, Base64FormattingOptions.None);

               _serviceLog.UDPLogReport(_serviceMessage.UDPGetMessage(TypeCrypto.SuccessToTheEncodeToBase64), _serviceFuncString.Empty);

                return data;
            }
            catch (Exception ex)
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPGetMessage(TypeCrypto.ErrorToTheEncodeToBase64), ex.Message);
                return _serviceFuncString.Empty;
            }
        }

        public string UPDDecodeFromBase64(string? value)
        {
            string data = _serviceFuncString.Empty;

            try
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPGetMessage(TypeCrypto.CallStartToTheDecodeFromBase64), _serviceFuncString.Empty);

                var valueBytes = Convert.FromBase64String(value ?? _serviceFuncString.Empty);
                data = Encoding.UTF8.GetString(valueBytes);

                _serviceLog.UDPLogReport(_serviceMessage.UDPGetMessage(TypeCrypto.SuccessToTheDecodeFromBase64), _serviceFuncString.Empty);

                return data;
            }
            catch (Exception ex)
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPGetMessage(TypeCrypto.ErrorToTheDecodeFromBase64), ex.Message);
                return _serviceFuncString.Empty;
            }
        }
    }
}