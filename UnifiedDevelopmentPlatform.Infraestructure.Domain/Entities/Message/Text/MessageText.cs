using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message.Text
{
    /// <summary>
    /// The text of message.
    /// </summary>
    [ComplexType]
    public static class MessageText
    {
        /// <summary>
        /// No has message specifield.
        /// </summary>
        public static string NoHasMessageSpecifield => "ERROR MESSAGE DON'T SPECIFIELD.";

        /// <summary>
        /// The message initial of build of UDPP.
        /// </summary>
        public static string TheInitialMessage => "WAS STARTED THE CREATION OF UNIFIED DEVELOPMENT POWER PLATFORM - UDPP.";

        /// <summary>
        /// The message default when occurred error.
        /// </summary>
        public static string TheGlobalErrorMessage => "AN ERROR OCCURRED AT GENERATING THE SERVICE. CONTACT THE TEAM OF UNIFIED DEVELOPMENT POWER PLATFORM - UDPP.";

        /// <summary>
        /// The platform Windows is ok.
        /// </summary>
        public static string ThePlatformWindowsIsOk => "PLATFORM TO BUILD UNIFIED DEVELOPMENT PLATFORM IS WINDOWS.";

        /// <summary>
        /// The platform Windows isn't ok.
        /// </summary>
        public static string ThePlatformWindowsIsNotOk => "THIS VERSION OF (UNIFIED DEVELOPMENT PLATFORM) DON'T RUN IN CROSS CROSS PLATFORM. ONLY WINDOWS.";

        #region The filter action context.

        /// <summary>
        /// Error filter action context controller.
        /// </summary>
        public static string ErrorFilterActionContextController => "AN ERROR OCCURRED OF THE CREATION THE";

        /// <summary>
        /// Error filter action context tables.
        /// </summary>
        public static string ErrorFilterActionContextTables => "ERROR OCORRED IN THE VALIDATION OF TABLES.";

        /// <summary>
        /// Error filter action context fields.
        /// </summary>
        public static string ErrorFilterActionContextFields => "ERROR OCORRED IN THE VALIDATION OF FIELDS.";

        #region The validation of filter action.

        /// <summary>
        /// Message default to service validation.
        /// </summary>
        public static string MessageDefaultToServiceValidation => "IS NECESSARY FOR GENERATE THE APP.";

        /// <summary>
        /// The model state is ok.
        /// </summary>
        public static string TheModelStateIsOk => $"THE (JSON) {MessageDefaultToServiceValidation}";

        /// <summary>
        /// The script metadata is ok.
        /// </summary>
        public static string TheScriptMetadataIsOk => $"THE (METADATA) {MessageDefaultToServiceValidation}";

        /// <summary>
        /// The metadata is base64 ok.
        /// </summary>
        public static string TheMetadataIsBase64Ok => $"THE (METADATA) ON THE FORMAT BASE64 {MessageDefaultToServiceValidation}";

        /// <summary>
        /// The development environment is ok.
        /// </summary>
        public static string TheDevelopmentEnvironmentIsOk => $"THE (DEVELOPMENT ENVIRONMENT) {MessageDefaultToServiceValidation}";

        /// <summary>
        /// The databases is ok.
        /// </summary>
        public static string TheDatabasesIsOk => $"THE (DATABASES) {MessageDefaultToServiceValidation}";

        /// <summary>
        /// The databases implemented isn't ok.
        /// </summary>
        public static string TheDatabasesImplementedIsntOk => "THE DATABASES IMPLEMENTED ISN'T OK";

        /// <summary>
        /// The databases engine is ok.
        /// </summary>
        public static string TheDatabasesEngineIsOk => $"THE (DATABASES ENGINE) {MessageDefaultToServiceValidation}";

        /// <summary>
        /// The form view is ok.
        /// </summary>
        public static string TheFormViewIsOk => $"THE (FORMS VIEW) {MessageDefaultToServiceValidation}";

        /// <summary>
        /// The architecture patterns is ok.
        /// </summary>
        public static string TheArchitecturePatternsIsOk => $"THE (ARCHITECTURE PATTERNS) {MessageDefaultToServiceValidation}";

        #endregion The validation of filter action.

        #endregion The filter action context.

        #region Service directory.

        /// <summary>
        /// Message default to service validation.
        /// </summary>
        public static string ErrorCreateAllDirectory => "ERRO TO CREATE DIRECTORY DEFAULT OF UNIFIED DEVELOPMENT PLATFORM - UDP.";

        /// <summary>
        /// Build of all directory standard of solution.
        /// </summary>
        public static string BuildDirectoryStandardOfSolution => "STARTING OF THE CREATION THE INITIAL OF THE DIRECTORY STANDARD.";

        /// <summary>
        /// Directory root is empty.
        /// </summary>
        public static string DirectoryRootIsEmpty => "DIRECTORY ROOT IS EMPTY IN SERVICE DIRECTORY.";

        #endregion Service directory.
    }
}