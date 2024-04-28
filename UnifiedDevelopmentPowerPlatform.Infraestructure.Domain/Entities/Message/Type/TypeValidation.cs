using System.ComponentModel;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type
{
    /// <summary>
    /// The type to the validation.
    /// </summary>
    public enum TypeValidation : int
    {
        [Description("The Message type do not specified")]
        DoNotSpecified = 0,
        [Description("The model state isn't ok")]
        TheModelStateIsNotOk = 1,
        [Description("The script metadata isn't ok")]
        TheScriptMetadataIsNotOk = 2,
        [Description("The metadata isn't in base64 ok")]
        TheMetadataIsNotInBase64Ok = 3,
        [Description("The development environment isn't ok")]
        TheDevelopmentEnvironmentIsNotOk = 4,
        [Description("The databases isn't ok")]
        TheDatabasesIsNotOk = 5,
        [Description("The databases implemented isn't ok")]
        TheDatabasesImplementedIsNotOk = 6,
        [Description("The databases engine isn't ok")]
        TheDatabasesEngineIsNotOk = 7,
        [Description("The forms view isn't ok")]
        TheFormsViewIsNotOk = 8,
        [Description("The architecture patterns isn't ok")]
        TheArchitecturePatternsIsNotOk = 9,
        [Description("The platform Windows ok")]
        ThePlatformWindowsIsOk = 10,
        [Description("The platform Windows isn't ok")]
        ThePlatformWindowsIsNotOk = 11,
        [Description("The tables data isn't ok")]
        TheTablesdataIsNotOk = 12,
        [Description("The tables data has no fields content")]
        TheTablesdataHasNoFieldsContent = 13,
        [Description("The directories isn't ok")]
        TheDirectoriesIsNotOk = 14,
        [Description("The files isn't ok")]
        TheFilesIsNotOk = 15
    }
}