using AppSolution.Application.Interfaces;

namespace AppSolution.Application.Services
{
    public class ServiceValidation : IServiceValidation
    {
        // Characters that are used in base64 strings.
        private readonly Char[] Base64Chars = new[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '/' };

        #region Validation for FilterActionContextTables.
        private record FilterActionTables
        {
            public const string METADATA = "metadata";
        }

        public bool ScriptMetadataIsOk(dynamic context, ref string message)
        {
            dynamic? obj = null;
            context.ActionArguments.TryGetValue(FilterActionTables.METADATA, out obj);
            message = !string.IsNullOrEmpty(obj?.ScriptMetadata) ? string.Empty : "É obrigatório informar o (Metadata) para gerar o app.";
            return string.IsNullOrEmpty(message);
        }

        public bool MetadataIsBase64Ok(dynamic context, ref string message)
        {
            dynamic? obj = null;
            context.ActionArguments.TryGetValue(FilterActionTables.METADATA, out obj);
            message = this.ValidateBase64(obj?.ScriptMetadata) ? string.Empty : "É obrigatório informar o (Metadata) no formato base64.";
            return string.IsNullOrEmpty(message);
        }

        public bool DevelopmentEnvironmentIsOk(dynamic context, ref string message)
        {
            dynamic? obj = null;
            context.ActionArguments.TryGetValue(FilterActionTables.METADATA, out obj);
            message = obj?.IdDevelopmentEnvironment <= 0 ? "É obrigatório informar o (Development Environment) para gerar o app." : string.Empty;
            return string.IsNullOrEmpty(message);
        }

        public bool DatabasesIsOk(dynamic context, ref string message)
        {
            dynamic? obj = null;
            context.ActionArguments.TryGetValue(FilterActionTables.METADATA, out obj);
            message = obj?.IdDatabases <= 0 ? "É obrigatório informar o (Databases) para gerar o app." : string.Empty;
            return string.IsNullOrEmpty(message);
        }

        public bool DatabasesEngineIsOk(dynamic context, ref string message)
        {
            dynamic? obj = null;
            context.ActionArguments.TryGetValue(FilterActionTables.METADATA, out obj);
            message = obj?.IdDatabasesEngine <= 0 ? "É obrigatório informar o (Databases Engine) para gerar o app." : string.Empty;
            return string.IsNullOrEmpty(message);
        }

        public bool FormIsOk(dynamic context, ref string message)
        {
            dynamic? obj = null;
            context.ActionArguments.TryGetValue(FilterActionTables.METADATA, out obj);
            message = obj?.IdForms <= 0 ? "É obrigatório informar o (Forms) para gerar o app." : string.Empty;
            return string.IsNullOrEmpty(message);
        }
        #endregion Validation for FilterActionContextTables.

        public bool ValidateBase64(string? text)
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
                if (string.IsNullOrEmpty(text) ||
                text.Length == 0 ||
                text.Length % 4 != 0 ||
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