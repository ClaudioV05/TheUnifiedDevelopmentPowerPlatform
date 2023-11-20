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

        public bool ScriptMetadataIsOk(dynamic context)
        {
            dynamic? obj = null;
            context.ActionArguments.TryGetValue(FilterActionTables.METADATA, out obj);
            return !string.IsNullOrEmpty(obj?.ScriptMetadata);
        }

        public bool DevelopmentEnvironmentIsOk(dynamic context)
        {
            dynamic? obj = null;
            context.ActionArguments.TryGetValue(FilterActionTables.METADATA, out obj);
            return obj?.IdDevelopmentEnvironment >= 0 ? true : false;
        }

        public bool DatabasesIsOk(dynamic context)
        {
            dynamic? obj = null;
            context.ActionArguments.TryGetValue(FilterActionTables.METADATA, out obj);
            return obj?.IdDatabases >= 0 ? true : false;
        }

        public bool FormIsOk(dynamic context)
        {
            dynamic? obj = null;
            context.ActionArguments.TryGetValue(FilterActionTables.METADATA, out obj);
            return obj?.IdForms >= 0 ? true : false;
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