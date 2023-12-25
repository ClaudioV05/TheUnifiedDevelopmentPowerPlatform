using System.Text.Json;
using UnifiedDevelopmentPlatform.Application.Interfaces;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service for (Validation).
    /// </summary>
    public class ServiceValidation : IServiceValidation
    {
        // Characters that are used in base64 strings.
        private readonly Char[] Base64Chars = new[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '/' };
        private string messageDefault = "is necessary for generate the App.";
        private readonly IServiceFuncStrings _serviceFuncStrings;
        private readonly IServiceOperationalSystem _serviceOperationalSystem;

        private record FilterActionTables
        {
            public const string METADATA = "metadata";
        }

        public ServiceValidation(IServiceFuncStrings serviceFuncStrings, IServiceOperationalSystem serviceOperationalSystem)
        {
            _serviceFuncStrings = serviceFuncStrings;
            _serviceOperationalSystem = serviceOperationalSystem;
        }

        #region Validation for Filter Action Controller.

        public bool UDPPlatformWindowsIsOk(ref string message)
        {
            bool platformWindows = true;

            if (!_serviceOperationalSystem.UPDOperationalSystemIsWindows())
            {
                platformWindows = false;
                message = $"This version of (Unified Development Platform) don't run in cross cross platform. Only windows.";
            }

            return platformWindows;
        }

        #endregion Validation for Filter Action Controller.

        #region Validation for Filters Actions Context Tables and Fields.

        public bool UDPModelStateIsOk(dynamic context, ref string message)
        {
            message = !context.ModelState.IsValid ? $"The (JSON) {messageDefault}" : string.Empty;
            return _serviceFuncStrings.NullOrEmpty(message);
        }

        public bool UDPScriptMetadataIsOk(dynamic context, ref string message)
        {
            dynamic? obj = null;
            context.ActionArguments.TryGetValue(FilterActionTables.METADATA, out obj);
            message = _serviceFuncStrings.NullOrEmpty(obj?.ScriptMetadata) ? $"The (METADATA) {messageDefault}" : string.Empty ;
            return _serviceFuncStrings.NullOrEmpty(message);
        }

        public bool UDPMetadataIsBase64Ok(dynamic context, ref string message)
        {
            dynamic? obj = null;
            context.ActionArguments.TryGetValue(FilterActionTables.METADATA, out obj);
            message = !this.UDPValidateBase64(obj?.ScriptMetadata) ? $"The (METADATA) on format base64 {messageDefault}" : string.Empty;
            return _serviceFuncStrings.NullOrEmpty(message);
        }

        public bool UDPDevelopmentEnvironmentIsOk(dynamic context, ref string message)
        {
            dynamic? obj = null;
            context.ActionArguments.TryGetValue(FilterActionTables.METADATA, out obj);
            message = obj?.IdDevelopmentEnvironment <= 0 ? $"The (DEVELOPMENT ENVIRONMENT) {messageDefault}" : string.Empty;
            return _serviceFuncStrings.NullOrEmpty(message);
        }

        public bool UDPDatabasesIsOk(dynamic context, ref string message)
        {
            dynamic? obj = null;
            context.ActionArguments.TryGetValue(FilterActionTables.METADATA, out obj);
            message = obj?.IdDatabases <= 0 ? $"The (DATABASES) {messageDefault}" : string.Empty;
            return _serviceFuncStrings.NullOrEmpty(message);
        }

        public bool UDPDatabasesEngineIsOk(dynamic context, ref string message)
        {
            dynamic? obj = null;
            context.ActionArguments.TryGetValue(FilterActionTables.METADATA, out obj);
            message = obj?.IdDatabasesEngine <= 0 ? $"The (DATABASES ENGINE) {messageDefault}" : string.Empty;
            return _serviceFuncStrings.NullOrEmpty(message);
        }

        public bool UDPFormIsOk(dynamic context, ref string message)
        {
            dynamic? obj = null;
            context.ActionArguments.TryGetValue(FilterActionTables.METADATA, out obj);
            message = obj?.IdForms <= 0 ? $"The (FORMS) {messageDefault}" : string.Empty;
            return _serviceFuncStrings.NullOrEmpty(message);
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
                if (_serviceFuncStrings.NullOrEmpty(text ?? string.Empty) ||
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
                        if (!Base64Chars.Contains(text[i]))
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