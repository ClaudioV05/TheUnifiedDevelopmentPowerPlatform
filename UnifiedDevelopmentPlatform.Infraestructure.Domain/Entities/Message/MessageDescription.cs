namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message
{
    /// <summary>
    /// Description of Mensagem.
    /// </summary>
    public static class MessageDescription
    {
        /// <summary>
        /// No message.
        /// </summary>
        public static string NoMessage { get; set; } = "ERROR MESSAGE DON'T SPECIFIELD.";

        /// <summary>
        /// Message initial of build of UDP.
        /// </summary>
        public static string Initial { get; set; } = "WAS STARTED THE CREATION OF UNIFIED DEVELOPMENT PLATFORM - UDP.";

        /// <summary>
        /// Platform is Windows Ok.
        /// </summary>
        public static string PlatformIsWindowsOk { get; set; } = "PLATFORM TO BUILD UNIFIED DEVELOPMENT PLATFORM IS WINDOWS.";

        /// <summary>
        /// Platform is Windows erro.
        /// </summary>
        public static string PlatformIsWindowsErro { get; set; } = "THIS VERSION OF (UNIFIED DEVELOPMENT PLATFORM) DON'T RUN IN CROSS CROSS PLATFORM. ONLY WINDOWS.";

        /// <summary>
        /// Error filter action context controller.
        /// </summary>
        public static string ErrorFilterActionContextController { get; set; } = "ERROR OCORRED OF THE CREATION THE UNIFIED DEVELOPMENT PLATFORM - UDP.";

        /// <summary>
        /// Message default to service validation.
        /// </summary>
        public static string MessageDefaultToServiceValidation { get; set; } = "IS NECESSARY FOR GENERATE THE APP.";

        /// <summary>
        /// Message to the model state is ok.
        /// </summary>
        public static string MessageUdpModelStateIsOk { get; set; } = $"THE (JSON) {MessageDescription.MessageDefaultToServiceValidation}";

        /// <summary>
        /// Message to the script metadata is ok.
        /// </summary>
        public static string MessageUdpScriptMetadataIsOk { get; set; } = $"THE (METADATA) {MessageDescription.MessageDefaultToServiceValidation}";

        /// <summary>
        /// Message to the metadata is base64 ok.
        /// </summary>
        public static string MessageUdpMetadataIsBase64Ok { get; set; } = $"THE (METADATA) ON THE FORMAT BASE64 {MessageDescription.MessageDefaultToServiceValidation}";

        /// <summary>
        /// Message to the development environment is ok.
        /// </summary>
        public static string MessageUdpDevelopmentEnvironmentIsOk { get; set; } = $"THE (DEVELOPMENT ENVIRONMENT) {MessageDescription.MessageDefaultToServiceValidation}";

        /// <summary>
        /// Message to the databases is ok.
        /// </summary>
        public static string MessageUdpDatabasesIsOk { get; set; } = $"THE (DATABASES) {MessageDescription.MessageDefaultToServiceValidation}";

        /// <summary>
        /// Message to the databases engine is ok.
        /// </summary>
        public static string MessageUdpDatabasesEngineIsOk { get; set; } = $"THE (DATABASES ENGINE) {MessageDescription.MessageDefaultToServiceValidation}";

        /// <summary>
        /// Message to the forms is ok.
        /// </summary>
        public static string MessageUdpFormIsOk { get; set; } = $"THE (FORMS) {MessageDescription.MessageDefaultToServiceValidation}";
    }
}