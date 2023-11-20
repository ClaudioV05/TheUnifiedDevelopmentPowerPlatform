using AppSolution.Application.Interfaces;

namespace AppSolution.Application.Services
{
    public class ServiceValidation : IServiceValidation
    {
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
            // Credit: oybek https://stackoverflow.com/users/794764/oybek

            bool returnValidation = true;

            if (string.IsNullOrEmpty(text) || text.Length % 4 != 0 || text.Contains(" ") || text.Contains("\t") || text.Contains("\r") || text.Contains("\n"))
            {
                returnValidation = false;
            }

            try
            {
                Convert.FromBase64String(text);
            }
            catch (Exception)
            {
                returnValidation = false;
            }

            return returnValidation;
        }

       
    }
}