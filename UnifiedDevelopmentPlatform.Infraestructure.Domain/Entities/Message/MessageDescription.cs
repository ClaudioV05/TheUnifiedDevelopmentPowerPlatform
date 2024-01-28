using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message
{
    [ComplexType]
    /// <summary>
    /// Description of Mensagem.
    /// </summary>
    public static class MessageDescription
    {
        /// <summary>
        /// No message.
        /// </summary>
        public static string NoMessage { get; } = "ERROR MESSAGE DON'T SPECIFIELD.";

        /// <summary>
        /// Message initial of build of UDP.
        /// </summary>
        public static string Initial { get; } = "WAS STARTED THE CREATION OF UNIFIED DEVELOPMENT PLATFORM - UDP.";

        /// <summary>
        /// Platform is Windows Ok.
        /// </summary>
        public static string PlatformIsWindowsOk { get; } = "PLATFORM TO BUILD UNIFIED DEVELOPMENT PLATFORM IS WINDOWS.";

        /// <summary>
        /// Platform is Windows erro.
        /// </summary>
        public static string PlatformIsWindowsErro { get; } = "THIS VERSION OF (UNIFIED DEVELOPMENT PLATFORM) DON'T RUN IN CROSS CROSS PLATFORM. ONLY WINDOWS.";

        #region Filter action.

        /// <summary>
        /// Error filter action context controller.
        /// </summary>
        public static string ErrorFilterActionContextController { get; } = "ERROR OCORRED OF THE CREATION THE";

        /// <summary>
        /// Error filter action context tables.
        /// </summary>
        public static string ErrorFilterActionContextTables { get; } = "ERROR OCORRED IN THE VALIDATION OF TABLES.";

        /// <summary>
        /// Error filter action context fields.
        /// </summary>
        public static string ErrorFilterActionContextFields { get; } = "ERROR OCORRED IN THE VALIDATION OF FIELDS.";

        #region The validation of filter action.

        /// <summary>
        /// Message default to service validation.
        /// </summary>
        public static string MessageDefaultToServiceValidation { get; } = "IS NECESSARY FOR GENERATE THE APP.";

        /// <summary>
        /// Message to the model state is ok.
        /// </summary>
        public static string MessageUdpModelStateIsOk { get; } = $"THE (JSON) {MessageDescription.MessageDefaultToServiceValidation}";

        /// <summary>
        /// Message to the script metadata is ok.
        /// </summary>
        public static string MessageUdpScriptMetadataIsOk { get; } = $"THE (METADATA) {MessageDescription.MessageDefaultToServiceValidation}";

        /// <summary>
        /// Message to the metadata is base64 ok.
        /// </summary>
        public static string MessageUdpMetadataIsBase64Ok { get; } = $"THE (METADATA) ON THE FORMAT BASE64 {MessageDescription.MessageDefaultToServiceValidation}";

        /// <summary>
        /// Message to the development environment is ok.
        /// </summary>
        public static string MessageUdpDevelopmentEnvironmentIsOk { get; } = $"THE (DEVELOPMENT ENVIRONMENT) {MessageDescription.MessageDefaultToServiceValidation}";

        /// <summary>
        /// Message to the databases is ok.
        /// </summary>
        public static string MessageUdpDatabasesIsOk { get; } = $"THE (DATABASES) {MessageDescription.MessageDefaultToServiceValidation}";

        /// <summary>
        /// Message to the databases engine is ok.
        /// </summary>
        public static string MessageUdpDatabasesEngineIsOk { get; } = $"THE (DATABASES ENGINE) {MessageDescription.MessageDefaultToServiceValidation}";

        /// <summary>
        /// Message to the forms is ok.
        /// </summary>
        public static string MessageUdpFormIsOk { get; } = $"THE (FORMS) {MessageDescription.MessageDefaultToServiceValidation}";

        #endregion The validation of filter action.

        #endregion Filter action.

        #region Service directory.

        /// <summary>
        /// Message default to service validation.
        /// </summary>
        public static string ErrorCreateAllDirectory { get; } = "ERRO TO CREATE DIRECTORY DEFAULT OF UNIFIED DEVELOPMENT PLATFORM - UDP.";

        /// <summary>
        /// Build of all directory standard of solution.
        /// </summary>
        public static string BuildDirectoryStandardOfSolution { get; } = "STARTING OF THE CREATION THE INITIAL OF THE DIRECTORY STANDARD.";

        /// <summary>
        /// Directory root is empty.
        /// </summary>
        public static string DirectoryRootIsEmpty { get; } = "DIRECTORY ROOT IS EMPTY IN SERVICE DIRECTORY.";

        #endregion Service directory.

        #region ServiceMetadataTables.
        /// <summary>
        /// Invalid Base 64.
        /// </summary>
        public static string InvalidBase64 { get; } = "THIS BASE 64 ISA INVALID TO GENERATED THE TABLES NAME.";
        #endregion ServiceMetadataTables.
    }
}