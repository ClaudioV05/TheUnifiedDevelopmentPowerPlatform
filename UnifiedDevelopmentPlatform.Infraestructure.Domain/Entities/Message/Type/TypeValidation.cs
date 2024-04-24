using System.ComponentModel;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type
{
    /// <summary>
    /// The type to the validation.
    /// </summary>
    public enum TypeValidation : int
    {
        [Description("The Message type do not specified")] DoNotSpecified = 0,
        [Description("The model state is ok")] TheModelStateIsOk = 1,
        [Description("The script metadata is ok")] TheScriptMetadataIsOk = 2,
        [Description("The metadata is base64 ok")] TheMetadataIsBase64Ok = 3,
        [Description("The development environment is ok")] TheDevelopmentEnvironmentIsOk = 4,
        [Description("The databases is ok")] TheDatabasesIsOk = 5,
        [Description("The databases implemented isn't ok")] TheDatabasesImplementedIsntOk = 6,
        [Description("The databases engine is ok")] TheDatabasesEngineIsOk = 7,
        [Description("The form view is ok")] TheFormsViewIsOk = 8,
        [Description("The architecture patterns is ok")] TheArchitecturePatternsIsOk = 9,
        [Description("The platform Windows is ok")] ThePlatformWindowsIsOk = 10,
        [Description("The platform Windows isn't ok")] ThePlatformWindowsIsNotOk = 11
    }
}