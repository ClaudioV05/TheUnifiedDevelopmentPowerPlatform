using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service Message.
    /// </summary>
    public class ServiceMessage : IServiceMessage
    {
        /// <summary>
        /// The constructor of Service Message.
        /// </summary>
        public ServiceMessage() { }

        public string UDPMensagem(MessageType messageType) => messageType switch
        {
            MessageType.Initial => MessageDescription.Initial,
            MessageType.PlatformIsWindowsOk => MessageDescription.PlatformIsWindowsOk,
            MessageType.PlatformIsWindowsErro => MessageDescription.PlatformIsWindowsErro,
            MessageType.ErrorFilterActionContextController => MessageDescription.ErrorFilterActionContextController,
            MessageType.ErrorFilterActionContextTables => MessageDescription.ErrorFilterActionContextTables,
            MessageType.ErrorFilterActionContextFields => MessageDescription.ErrorFilterActionContextFields,
            MessageType.MessageDefaultToServiceValidation => MessageDescription.MessageDefaultToServiceValidation,
            MessageType.MessageUdpModelStateIsOk => MessageDescription.MessageUdpModelStateIsOk,
            MessageType.MessageUdpScriptMetadataIsOk => MessageDescription.MessageUdpScriptMetadataIsOk,
            MessageType.MessageUdpMetadataIsBase64Ok => MessageDescription.MessageUdpMetadataIsBase64Ok,
            MessageType.MessageUdpDevelopmentEnvironmentIsOk => MessageDescription.MessageUdpDevelopmentEnvironmentIsOk,
            MessageType.MessageUdpDatabasesIsOk => MessageDescription.MessageUdpDatabasesIsOk,
            MessageType.MessageUdpDatabasesEngineIsOk => MessageDescription.MessageUdpDatabasesEngineIsOk,
            MessageType.BuildDirectoryStandardOfSolution => MessageDescription.BuildDirectoryStandardOfSolution,
            MessageType.DirectoryRootIsEmpty => MessageDescription.DirectoryRootIsEmpty,
            MessageType.InvalidBase64 => MessageDescription.InvalidBase64,
            MessageType.MessageUdpArchitectureIsOk => MessageDescription.MessageUdpArchitectureIsOk,
            _ => MessageDescription.NoMessage
        };
    }
}