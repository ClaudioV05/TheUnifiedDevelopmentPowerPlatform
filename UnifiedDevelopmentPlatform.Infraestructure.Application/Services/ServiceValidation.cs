using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Controller;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service Validation.
    /// </summary>
    public class ServiceValidation : IServiceValidation
    {
        private readonly IServiceMessage _serviceMessage;
        private readonly IServiceFuncString _serviceFuncStrings;
        private readonly IServiceOperationalSystem _serviceOperationalSystem;

        /// <summary>
        /// The constructor of Service Validation.
        /// </summary>
        /// <param name="serviceMessage"></param>
        /// <param name="serviceFuncStrings"></param>
        /// <param name="serviceOperationalSystem"></param>
        public ServiceValidation(IServiceMessage serviceMessage, IServiceFuncString serviceFuncStrings, IServiceOperationalSystem serviceOperationalSystem)
        {
            _serviceMessage = serviceMessage;
            _serviceFuncStrings = serviceFuncStrings;
            _serviceOperationalSystem = serviceOperationalSystem;
        }

        #region Validation for Filter Action Controller.

        public bool UDPPlatformWindowsIsOk(ref string message)
        {
            message = !_serviceOperationalSystem.UPDOperationalSystemIsWindows() ? _serviceMessage.UDPMensagem(MessageType.PlatformIsWindowsErro) : string.Empty;
            return _serviceFuncStrings.UDPNullOrEmpty(message);
        }

        #endregion Validation for Filter Action Controller.

        #region Validation for Filters Actions Context Tables and Fields.

        public bool UDPModelStateIsOk(dynamic context, ref string message)
        {
            message = !context.ModelState.IsValid ? _serviceMessage.UDPMensagem(MessageType.MessageUdpModelStateIsOk) : _serviceFuncStrings.Empty;
            return _serviceFuncStrings.UDPNullOrEmpty(message);
        }

        public bool UDPDatabaseSchemaIsOk(dynamic context, ref string message)
        {
            dynamic? obj = null;
            context.ActionArguments.TryGetValue(ControllerFilterActionName.Metadata, out obj);
            message = _serviceFuncStrings.UDPNullOrEmpty(obj?.DatabaseSchema) ? _serviceMessage.UDPMensagem(MessageType.MessageUdpScriptMetadataIsOk) : _serviceFuncStrings.Empty;
            return _serviceFuncStrings.UDPNullOrEmpty(message);
        }

        public bool UDPMetadataIsBase64Ok(dynamic context, ref string message)
        {
            dynamic? obj = null;
            context.ActionArguments.TryGetValue(ControllerFilterActionName.Metadata, out obj);
            message = !this.UDPValidateBase64(obj?.DatabaseSchema) ? _serviceMessage.UDPMensagem(MessageType.MessageUdpMetadataIsBase64Ok) : _serviceFuncStrings.Empty;
            return _serviceFuncStrings.UDPNullOrEmpty(message);
        }

        public bool UDPDevelopmentEnvironmentIsOk(dynamic context, ref string message)
        {
            dynamic? obj = null;
            context.ActionArguments.TryGetValue(ControllerFilterActionName.Metadata, out obj);
            message = obj?.IdDevelopmentEnvironment <= 0 ? _serviceMessage.UDPMensagem(MessageType.MessageUdpDevelopmentEnvironmentIsOk) : _serviceFuncStrings.Empty;
            return _serviceFuncStrings.UDPNullOrEmpty(message);
        }

        public bool UDPDatabasesIsOk(dynamic context, ref string message)
        {
            dynamic? obj = null;
            context.ActionArguments.TryGetValue(ControllerFilterActionName.Metadata, out obj);
            message = obj?.IdDatabases <= 0 ? _serviceMessage.UDPMensagem(MessageType.MessageUdpDatabasesIsOk) : _serviceFuncStrings.Empty;
            return _serviceFuncStrings.UDPNullOrEmpty(message);
        }

        public bool UDPDatabasesEngineIsOk(dynamic context, ref string message)
        {
            dynamic? obj = null;
            context.ActionArguments.TryGetValue(ControllerFilterActionName.Metadata, out obj);
            message = obj?.IdDatabasesEngine <= 0 ? _serviceMessage.UDPMensagem(MessageType.MessageUdpDatabasesEngineIsOk) : _serviceFuncStrings.Empty;
            return _serviceFuncStrings.UDPNullOrEmpty(message);
        }

        public bool UDPFormIsOk(dynamic context, ref string message)
        {
            dynamic? obj = null;
            context.ActionArguments.TryGetValue(ControllerFilterActionName.Metadata, out obj);
            message = obj?.IdForms <= 0 ? _serviceMessage.UDPMensagem(MessageType.MessageDefaultToServiceValidation) : _serviceFuncStrings.Empty;
            return _serviceFuncStrings.UDPNullOrEmpty(message);
        }

        #endregion Validation for Filters Actions Context Tables and Fields.

        #region Validation for Files.
        public bool IsFileInUseGeneric(FileInfo file)
        {
            bool validfile = false;

            try
            {
                using var stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                validfile = true;
            }

            return validfile;
        }

        public bool IsFileInUse(FileInfo file)
        {
            bool validfile = false;

            try
            {
                using var stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32)
            {
                validfile = true;
            }

            return validfile;
        }
        #endregion Validation for Files.

        public bool UDPValidateBase64(string? text)
        {
            int indexBase64 = 0;
            bool validBase64 = true;

            try
            {
                // The quickest test. If the value is null or empty string or is equal to 0 it is not base64
                // Base64 string's length is always divisible by four, i.e. 8, 16, 20 etc. 
                // If it is not you can return false. Quite effective
                // Further, if it meets the above criterias, then test for spaces.
                // If it contains spaces, it is not base64.
                if (_serviceFuncStrings.UDPNullOrEmpty(text ?? _serviceFuncStrings.Empty) ||
                text?.Length == 0 ||
                text?.Length % 4 != 0 ||
                text.Contains(' ') ||
                text.Contains('\t') ||
                text.Contains('\r') ||
                text.Contains('\n'))
                {
                    validBase64 = false;
                }
                else
                {
                    // 98% of all non base64 values are invalidated by this time.
                    indexBase64 = text.Length - 1;

                    // If there is padding step back.
                    if (text[indexBase64] == '=')
                    {
                        indexBase64--;
                    }

                    // If there are two padding chars step back a second time.
                    if (text[indexBase64] == '=')
                    {
                        indexBase64--;
                    }

                    // Now traverse over characters.
                    // You should note that I'm not creating any copy of the existing strings,
                    // assuming that they may be quite large.
                    for (var i = 0; i <= indexBase64; i++)
                    {
                        // If any of the character is not from the allowed list.
                        if (!_serviceFuncStrings.Base64Chars.Contains(text[i]))
                        {
                            validBase64 = false;
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                validBase64 = false;
            }

            return validBase64;
        }
    }
}