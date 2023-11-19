using System.Web.Mvc;

namespace AppSolution.Application.Interfaces
{
    public interface IServiceValidation
    {
        bool ValidateBase64(string? text);

        #region Validation for FilterActionContextTables.
        bool ScriptMetadataIsOk(dynamic context);
        bool DevelopmentEnvironmentIsOk(dynamic context);
        bool DatabasesIsOk(dynamic context);
        bool FormIsOk(dynamic context);
        #endregion Validation for FilterActionContextTables.
    }
}