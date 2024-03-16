using System.Security.Cryptography;
using System.Text;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Cryptography;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.MetaCharacter;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service Crypto.
    /// </summary>
    public class ServiceCrypto : IServiceCrypto
    {
        private readonly IServiceLog _serviceLog;
        private readonly IServiceMessage _serviceMessage;
        private readonly IServiceFuncString _serviceFuncString;

        /// <summary>
        /// The constructor of Service Crypto.
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

        public string UPDEncrypt(string value)
        {
            byte[] input;
            byte[] key = { };
            string data = _serviceFuncString.Empty;
            MemoryStream memoryStream = new MemoryStream();
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();

            try
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.CallStartToTheEncrypt), _serviceFuncString.Empty);
                input = Encoding.UTF8.GetBytes(value);
                key = Encoding.UTF8.GetBytes(CryptographyConfiguration.CryptographyKey.Substring(0, 8));

                CryptoStream cryptoStream = new CryptoStream(memoryStream, provider.CreateEncryptor(key, CryptographyConfiguration.CryptographyByteArray), CryptoStreamMode.Write);
                cryptoStream.Write(input, 0, input.Length);
                cryptoStream.FlushFinalBlock();
                data = Convert.ToBase64String(memoryStream.ToArray());

                _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.SuccessToTheEncrypt), _serviceFuncString.Empty);

                return data;
            }
            catch (CryptographicException ex)
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.ErrorToTheEncrypt), ex.Message);
                return _serviceFuncString.Empty;
            }
            catch (Exception ex)
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.ErrorToTheEncrypt), ex.Message);
                return _serviceFuncString.Empty;
            }
        }

        public string UPDDecrypt(string value)
        {
            byte[] input;
            byte[] key = { };
            string data = _serviceFuncString.Empty;
            MemoryStream memoryStream = new MemoryStream();
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();

            try
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.CallStartToTheDecrypt), _serviceFuncString.Empty);
                input = new byte[value.Length];
                input = Convert.FromBase64String(value.Replace(MetaCharacterSymbols.WhiteSpace, "+"));
                key = Encoding.UTF8.GetBytes(CryptographyConfiguration.CryptographyKey.Substring(0, 8));

                CryptoStream cryptoStream = new CryptoStream(memoryStream, provider.CreateDecryptor(key, CryptographyConfiguration.CryptographyByteArray), CryptoStreamMode.Write);
                cryptoStream.Write(input, 0, input.Length);
                cryptoStream.FlushFinalBlock();
                data = Encoding.UTF8.GetString(memoryStream.ToArray());

                _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.SuccessToTheDecrypt), _serviceFuncString.Empty);

                return data;
            }
            catch (CryptographicException ex)
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.ErrorToTheDecrypt), ex.Message);
                return _serviceFuncString.Empty;
            }
            catch (Exception ex)
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.ErrorToTheDecrypt), ex.Message);
                return _serviceFuncString.Empty;
            }
        }

        public string UPDDecodeBase64(string? value)
        {
            string data = _serviceFuncString.Empty;

            try
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.CallStartToTheDecodeBase64), _serviceFuncString.Empty);
                var valueBytes = Convert.FromBase64String(value ?? _serviceFuncString.Empty);
                data = Encoding.UTF8.GetString(valueBytes);

                _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.SuccessToTheDecodeBase64), _serviceFuncString.Empty);

                return data;
            }
            catch (Exception ex)
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.ErrorToTheDecodeBase64), ex.Message);
                return _serviceFuncString.Empty;
            }
        }
    }
}