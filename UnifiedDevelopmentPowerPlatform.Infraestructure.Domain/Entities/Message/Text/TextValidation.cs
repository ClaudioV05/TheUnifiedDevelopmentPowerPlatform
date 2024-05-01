using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Text;

/// <summary>
/// The text to the validation.
/// </summary>
[ComplexType]
public static class TextValidation
{
    /// <summary>
    /// Message default to service validation.
    /// </summary>
    private static string _messageDefaultToServiceValidation => "IS NECESSARY FOR GENERATE THE APP.";

    /// <summary>
    /// Message type do not specified.
    /// </summary>
    public static string DoNotSpecified => "THE MESSAGE TYPE DO NOT SPECIFIED.";

    /// <summary>
    /// The model state isn't ok.
    /// </summary>
    public static string TheModelStateIsNotOk => $"THE (JSON) {_messageDefaultToServiceValidation}";

    /// <summary>
    /// The script metadata isn't ok.
    /// </summary>
    public static string TheScriptMetadataIsNotOk => $"THE (METADATA) {_messageDefaultToServiceValidation}";

    /// <summary>
    /// The metadata isn't in base64 ok.
    /// </summary>
    public static string TheMetadataIsNotInBase64Ok => $"THE (METADATA) ON THE FORMAT BASE64 {_messageDefaultToServiceValidation}";

    /// <summary>
    /// The development environment isn't ok.
    /// </summary>
    public static string TheDevelopmentEnvironmentIsNotOk => $"THE (DEVELOPMENT ENVIRONMENT) {_messageDefaultToServiceValidation}";

    /// <summary>
    /// The databases isn't ok.
    /// </summary>
    public static string TheDatabasesIsNotOk => $"THE (DATABASES) {_messageDefaultToServiceValidation}";

    /// <summary>
    /// The databases implemented isn't ok.
    /// </summary>
    public static string TheDatabasesImplementedIsNotOk => "THE DATABASES IMPLEMENTED ISN'T OK";

    /// <summary>
    /// The databases engine isn't ok.
    /// </summary>
    public static string TheDatabasesEngineIsNotOk => $"THE (DATABASES ENGINE) {_messageDefaultToServiceValidation}";

    /// <summary>
    /// The forms view is ok.
    /// </summary>
    public static string TheFormsViewIsNotOk => $"THE (FORMS VIEW) {_messageDefaultToServiceValidation}";

    /// <summary>
    /// The architecture patterns isn't ok.
    /// </summary>
    public static string TheArchitecturePatternsIsNotOk => $"THE (ARCHITECTURE PATTERNS) {_messageDefaultToServiceValidation}";

    /// <summary>
    /// The platform Windows is ok.
    /// </summary>
    public static string ThePlatformWindowsIsOk => "PLATFORM TO BUILD UNIFIED DEVELOPMENT POWER PLATFORM IS WINDOWS.";

    /// <summary>
    /// The platform Windows isn't ok.
    /// </summary>
    public static string ThePlatformWindowsIsNotOk => "THIS VERSION OF (UNIFIED DEVELOPMENT POWER PLATFORM) DON'T RUN IN CROSS PLATFORM. ONLY IN WINDOWS.";

    /// <summary>
    /// The tables data isn't ok.
    /// </summary>
    public static string TheTablesdataIsNotOk => "THE TABLES DATA ISN'T OK.";

    /// <summary>
    /// The tables data has no fields content.
    /// </summary>
    public static string TheTablesdataHasNoFieldsContent => "THE TABLES DATA HAS NO FIELDS CONTENT.";

    /// <summary>
    /// The directories isn't ok.
    /// </summary>
    public static string TheDirectoriesIsNotOk => "THE DIRECTORIES ISN'T OK.";

    /// <summary>
    /// The files isn't ok.
    /// </summary>
    public static string TheFilesIsNotOk => "THE FILES ISN'T OK.";
}