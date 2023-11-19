using AppSolution.Application.Interfaces;

namespace AppSolution.Application.Services
{
    public class ServiceValidation : IServiceValidation
    {
        #region Validation for FilterActionContextTables.
        private record FilterActionTables
        {
            public const string METADATA = "metadata";
            public const string DEVELOPMENTENVIRONMENT = "idDevelopmentEnvironment";
            public const string DATABASES = "idDatabases";
            public const string FORMS = "idForms";
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
            context.ActionArguments.TryGetValue(FilterActionTables.DEVELOPMENTENVIRONMENT, out obj);
            return !string.IsNullOrEmpty(obj?.ScriptMetadata);
        }

        public bool DatabasesIsOk(dynamic context)
        {
            dynamic? obj = null;
            context.ActionArguments.TryGetValue(FilterActionTables.DATABASES, out obj);
            return !string.IsNullOrEmpty(obj?.ScriptMetadata);
        }

        public bool FormIsOk(dynamic context)
        {
            dynamic? obj = null;
            context.ActionArguments.TryGetValue(FilterActionTables.FORMS, out obj);
            return !string.IsNullOrEmpty(obj?.ScriptMetadata);
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