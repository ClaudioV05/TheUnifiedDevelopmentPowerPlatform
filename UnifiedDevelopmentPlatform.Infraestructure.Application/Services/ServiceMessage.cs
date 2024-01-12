using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service for Message.
    /// </summary>
    public class ServiceMessage : IServiceMessage
    {
        /// <summary>
        /// The constructor of Service Message.
        /// </summary>
        public ServiceMessage()
        {

        }

        public string UDPMensagem(MessageEnumerated messageEnumerated)
        {
            return messageEnumerated switch
            {
                MessageEnumerated.Initial => MessageDescription.Initial,
                MessageEnumerated.PlatformIsWindowsOk => MessageDescription.PlatformIsWindowsOk,
                MessageEnumerated.PlatformIsWindowsErro => MessageDescription.PlatformIsWindowsErro,
                MessageEnumerated.ErrorFilterActionContextController => MessageDescription.ErrorFilterActionContextController,
                MessageEnumerated.ErrorFilterActionContextTables => MessageDescription.ErrorFilterActionContextTables,
                MessageEnumerated.ErrorFilterActionContextFields => MessageDescription.ErrorFilterActionContextFields,
                MessageEnumerated.MessageDefaultToServiceValidation => MessageDescription.MessageDefaultToServiceValidation,
                MessageEnumerated.MessageUdpModelStateIsOk => MessageDescription.MessageUdpModelStateIsOk,
                MessageEnumerated.MessageUdpScriptMetadataIsOk => MessageDescription.MessageUdpScriptMetadataIsOk,
                MessageEnumerated.MessageUdpMetadataIsBase64Ok => MessageDescription.MessageUdpMetadataIsBase64Ok,
                MessageEnumerated.MessageUdpDevelopmentEnvironmentIsOk => MessageDescription.MessageUdpDevelopmentEnvironmentIsOk,
                MessageEnumerated.MessageUdpDatabasesIsOk => MessageDescription.MessageUdpDatabasesIsOk,
                MessageEnumerated.MessageUdpDatabasesEngineIsOk => MessageDescription.MessageUdpDatabasesEngineIsOk,
                MessageEnumerated.BuildDirectoryStandardOfSolution => MessageDescription.BuildDirectoryStandardOfSolution,
                MessageEnumerated.DirectoryRootIsEmpty => MessageDescription.DirectoryRootIsEmpty,
                MessageEnumerated.InvalidBase64 => MessageDescription.InvalidBase64,
                _ => MessageDescription.NoMessage
            };
        }
    }
}