using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message.Text
{
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
        /// The model state is ok.
        /// </summary>
        public static string TheModelStateIsOk => $"THE (JSON) {_messageDefaultToServiceValidation}";

        /// <summary>
        /// The script metadata is ok.
        /// </summary>
        public static string TheScriptMetadataIsOk => $"THE (METADATA) {_messageDefaultToServiceValidation}";

        /// <summary>
        /// The metadata is base64 ok.
        /// </summary>
        public static string TheMetadataIsBase64Ok => $"THE (METADATA) ON THE FORMAT BASE64 {_messageDefaultToServiceValidation}";

        /// <summary>
        /// The development environment is ok.
        /// </summary>
        public static string TheDevelopmentEnvironmentIsOk => $"THE (DEVELOPMENT ENVIRONMENT) {_messageDefaultToServiceValidation}";

        /// <summary>
        /// The databases is ok.
        /// </summary>
        public static string TheDatabasesIsOk => $"THE (DATABASES) {_messageDefaultToServiceValidation}";

        /// <summary>
        /// The databases implemented isn't ok.
        /// </summary>
        public static string TheDatabasesImplementedIsntOk => "THE DATABASES IMPLEMENTED ISN'T OK";

        /// <summary>
        /// The databases engine is ok.
        /// </summary>
        public static string TheDatabasesEngineIsOk => $"THE (DATABASES ENGINE) {_messageDefaultToServiceValidation}";

        /// <summary>
        /// The form view is ok.
        /// </summary>
        public static string TheFormsViewIsOk => $"THE (FORMS VIEW) {_messageDefaultToServiceValidation}";

        /// <summary>
        /// The architecture patterns is ok.
        /// </summary>
        public static string TheArchitecturePatternsIsOk => $"THE (ARCHITECTURE PATTERNS) {_messageDefaultToServiceValidation}";

        /// <summary>
        /// The platform Windows is ok.
        /// </summary>
        public static string ThePlatformWindowsIsOk => "PLATFORM TO BUILD UNIFIED DEVELOPMENT PLATFORM IS WINDOWS.";

        /// <summary>
        /// The platform Windows isn't ok.
        /// </summary>
        public static string ThePlatformWindowsIsNotOk => "THIS VERSION OF (UNIFIED DEVELOPMENT PLATFORM) DON'T RUN IN CROSS CROSS PLATFORM. ONLY WINDOWS.";
    }
}