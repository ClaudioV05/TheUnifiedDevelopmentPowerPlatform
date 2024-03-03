using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service message.
    /// </summary>
    public class ServiceMessage : IServiceMessage
    {
        /// <summary>
        /// The constructor of service message.
        /// </summary>
        public ServiceMessage() { }

        public string UDPMensagem(MessageType messageType) => messageType switch
        {
            MessageType.Initial => MessageText.Initial,
            MessageType.PlatformIsWindowsOk => MessageText.PlatformIsWindowsOk,
            MessageType.PlatformIsWindowsErro => MessageText.PlatformIsWindowsErro,
            MessageType.ErrorFilterActionContextController => MessageText.ErrorFilterActionContextController,
            MessageType.ErrorFilterActionContextTables => MessageText.ErrorFilterActionContextTables,
            MessageType.ErrorFilterActionContextFields => MessageText.ErrorFilterActionContextFields,
            MessageType.MessageDefaultToServiceValidation => MessageText.MessageDefaultToServiceValidation,
            MessageType.MessageUdpModelStateIsOk => MessageText.MessageUdpModelStateIsOk,
            MessageType.MessageUdpScriptMetadataIsOk => MessageText.MessageUdpScriptMetadataIsOk,
            MessageType.MessageUdpMetadataIsBase64Ok => MessageText.MessageUdpMetadataIsBase64Ok,
            MessageType.MessageUdpDevelopmentEnvironmentIsOk => MessageText.MessageUdpDevelopmentEnvironmentIsOk,
            MessageType.MessageUdpDatabasesIsOk => MessageText.MessageUdpDatabasesIsOk,
            MessageType.MessageUdpDatabasesEngineIsOk => MessageText.MessageUdpDatabasesEngineIsOk,
            MessageType.BuildDirectoryStandardOfSolution => MessageText.BuildDirectoryStandardOfSolution,
            MessageType.DirectoryRootIsEmpty => MessageText.DirectoryRootIsEmpty,
            MessageType.CallStartToTheSaveDatabaseSchemaFromMetadata => MessageText.CallStartToTheSaveDatabaseSchemaFromMetadata,
            MessageType.SuccessToTheSaveDatabaseSchemaFromMetadata => MessageText.SuccessToTheSaveDatabaseSchemaFromMetadata,
            MessageType.MessageUdpArchitectureIsOk => MessageText.MessageUdpArchitectureIsOk,
            MessageType.SuccessAtTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase => MessageText.SuccessAtTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase,
            MessageType.CallStartReceiveAndSaveAllTableAndFieldsOfSchemaDatabase => MessageText.CallStartReceiveAndSaveAllTableAndFieldsOfSchemaDatabase,
            MessageType.LoadAllOfTheTableAndFieldsOfSchemaDatabase => MessageText.LoadAllOfTheTableAndFieldsOfSchemaDatabase,
            MessageType.DecryptOkOfTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase => MessageText.DecryptOkOfTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase,
            MessageType.ErrorReceiveAndSaveAllTableAndFieldsOfSchemaDatabase => MessageText.ErrorReceiveAndSaveAllTableAndFieldsOfSchemaDatabase,
            MessageType.CallStartToTheSelectParametersTheKindsOfDatabases => MessageText.CallStartToTheSelectParametersTheKindsOfDatabases,
            MessageType.CallStartToTheSelectParametersTheKindsOfForms => MessageText.CallStartToTheSelectParametersTheKindsOfForms,
            MessageType.CallStartToTheSelectParametersTheKindsOfDevelopmentEnviroment => MessageText.CallStartToTheSelectParametersTheKindsOfDevelopmentEnviroment,
            MessageType.CallStartToTheSelectParametersTheKindsOfArchitecturePatterns => MessageText.CallStartToTheSelectParametersTheKindsOfArchitecturePatterns,
            MessageType.CallStartToTheSelectParametersTheKindsOfUnifiedDevelopmentPlatform => MessageText.CallStartToTheSelectParametersTheKindsOfUnifiedDevelopmentPlatform,
            MessageType.CallStartToTheEncrypt => MessageText.CallStartToTheEncrypt,
            MessageType.SuccessToTheEncrypt => MessageText.SuccessToTheEncrypt,
            MessageType.ErrorToTheEncrypt => MessageText.ErrorToTheEncrypt,
            MessageType.CallStartToTheDecrypt => MessageText.CallStartToTheDecrypt,
            MessageType.SuccessToTheDecrypt => MessageText.SuccessToTheDecrypt,
            MessageType.ErrorToTheDecrypt => MessageText.ErrorToTheDecrypt,
            MessageType.CallStartToTheDecodeBase64 => MessageText.CallStartToTheDecodeBase64,
            MessageType.SuccessToTheDecodeBase64 => MessageText.SuccessToTheDecodeBase64,
            MessageType.ErrorToTheDecodeBase64 => MessageText.ErrorToTheDecodeBase64,
            MessageType.CallStartToTheSaveIdentifierToTheFormFromMetadata => MessageText.CallStartToTheSaveIdentifierToTheFormFromMetadata,
            MessageType.SuccessToTheSaveIdentifierToTheFormFromMetadata => MessageText.SuccessToTheSaveIdentifierToTheFormFromMetadata,
            _ => MessageText.NoMessage
        };
    }
}