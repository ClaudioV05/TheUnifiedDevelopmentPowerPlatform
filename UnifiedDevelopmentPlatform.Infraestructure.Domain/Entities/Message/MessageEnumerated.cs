using System.ComponentModel;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message
{
    /// <summary>
    /// Enumerated of Mensagem.
    /// </summary>
    public enum MessageEnumerated : int
    {
        [Description("No has message")] NoMessage = 0,
        [Description("Initial")] Initial = 1,
        [Description("Platform ok for Windows")] PlatformIsWindowsOk = 2,
        [Description("Platform diferent for Windows")] PlatformIsWindowsErro = 3,
        [Description("Error filter action context controller")] ErrorFilterActionContextController = 4,
        [Description("Message default to service validation")] MessageDefaultToServiceValidation = 5,
        [Description("Message to the model state is ok")] MessageUdpModelStateIsOk = 6,
        [Description("Message to the script metadata is ok")] MessageUdpScriptMetadataIsOk = 7,
        [Description("Message to the metadata is base64 ok")] MessageUdpMetadataIsBase64Ok = 8,
        [Description("Message to the development environment is ok")] MessageUdpDevelopmentEnvironmentIsOk = 9,
        [Description("Message to the databases is ok")] MessageUdpDatabasesIsOk = 10,
        [Description("Message to the databases engine is ok")] MessageUdpDatabasesEngineIsOk = 11,
        [Description("Message to the forms is ok")] MessageUdpFormIsOk = 12,
    }
}