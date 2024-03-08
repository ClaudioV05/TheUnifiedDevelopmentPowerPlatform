using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service message.
    /// </summary>
    public class ServiceMessage : IServiceMessage
    {
        private readonly IServiceFuncString _serviceFuncString;

        /// <summary>
        /// The constructor of service message.
        /// </summary>
        /// <param name="serviceFuncString"></param>
        public ServiceMessage(IServiceFuncString serviceFuncString)
        {
            _serviceFuncString = serviceFuncString;
        }

        public string UDPMensagem(MessageType messageType)
        {
            string message = _serviceFuncString.Empty;

            message = messageType switch
            {
                MessageType.TheInitialMessage => MessageText.TheInitialMessage,
                MessageType.ThePlatformWindowsIsOk => MessageText.ThePlatformWindowsIsOk,
                MessageType.ThePlatformWindowsIsNotOk => MessageText.ThePlatformWindowsIsNotOk,
                MessageType.TheGlobalErrorMessage => MessageText.TheGlobalErrorMessage,
                MessageType.ErrorFilterActionContextController => MessageText.ErrorFilterActionContextController,
                MessageType.ErrorFilterActionContextTables => MessageText.ErrorFilterActionContextTables,
                MessageType.ErrorFilterActionContextFields => MessageText.ErrorFilterActionContextFields,
                MessageType.MessageDefaultToServiceValidation => MessageText.MessageDefaultToServiceValidation,
                MessageType.TheModelStateIsOk => MessageText.TheModelStateIsOk,
                MessageType.TheScriptMetadataIsOk => MessageText.TheScriptMetadataIsOk,
                MessageType.TheMetadataIsBase64Ok => MessageText.TheMetadataIsBase64Ok,
                MessageType.TheDevelopmentEnvironmentIsOk => MessageText.TheDevelopmentEnvironmentIsOk,
                MessageType.TheDatabasesIsOk => MessageText.TheDatabasesIsOk,
                MessageType.TheDatabasesImplementedIsntOk => MessageText.TheDatabasesImplementedIsntOk,
                MessageType.TheDatabasesEngineIsOk => MessageText.TheDatabasesEngineIsOk,
                MessageType.BuildDirectoryStandardOfSolution => MessageText.BuildDirectoryStandardOfSolution,
                MessageType.DirectoryRootIsEmpty => MessageText.DirectoryRootIsEmpty,
                MessageType.CallStartToTheSaveDatabaseSchemaFromMetadata => MessageText.CallStartToTheSaveDatabaseSchemaFromMetadata,
                MessageType.SuccessToTheSaveDatabaseSchemaFromMetadata => MessageText.SuccessToTheSaveDatabaseSchemaFromMetadata,
                MessageType.TheArchitecturePatternsIsOk => MessageText.TheArchitecturePatternsIsOk,
                MessageType.SuccessAtTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase => MessageText.SuccessAtTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase,
                MessageType.CallStartReceiveAndSaveAllTableAndFieldsOfSchemaDatabase => MessageText.CallStartReceiveAndSaveAllTableAndFieldsOfSchemaDatabase,
                MessageType.LoadAllOfTheTableAndFieldsOfSchemaDatabase => MessageText.LoadAllOfTheTableAndFieldsOfSchemaDatabase,
                MessageType.DecryptOkOfTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase => MessageText.DecryptOkOfTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase,
                MessageType.ErrorReceiveAndSaveAllTableAndFieldsOfSchemaDatabase => MessageText.ErrorReceiveAndSaveAllTableAndFieldsOfSchemaDatabase,
                MessageType.CallStartToTheEncrypt => MessageText.CallStartToTheEncrypt,
                MessageType.SuccessToTheEncrypt => MessageText.SuccessToTheEncrypt,
                MessageType.ErrorToTheEncrypt => MessageText.ErrorToTheEncrypt,
                MessageType.CallStartToTheDecrypt => MessageText.CallStartToTheDecrypt,
                MessageType.SuccessToTheDecrypt => MessageText.SuccessToTheDecrypt,
                MessageType.ErrorToTheDecrypt => MessageText.ErrorToTheDecrypt,
                MessageType.CallStartToTheDecodeBase64 => MessageText.CallStartToTheDecodeBase64,
                MessageType.SuccessToTheDecodeBase64 => MessageText.SuccessToTheDecodeBase64,
                MessageType.ErrorToTheDecodeBase64 => MessageText.ErrorToTheDecodeBase64,
                MessageType.CallStartToTheSelectParametersTheKindsOfUnifiedDevelopmentPlatform => MessageText.CallStartToTheSelectParametersTheKindsOfUnifiedDevelopmentPlatform,
                MessageType.SuccessToTheSelectParametersTheKindsOfUnifiedDevelopmentPlatform => MessageText.SuccessToTheSelectParametersTheKindsOfUnifiedDevelopmentPlatform,
                MessageType.SuccessToTheSelectParametersTheKindsOfForms => MessageText.SuccessToTheSelectParametersTheKindsOfForms,
                MessageType.CallStartToTheSelectParametersTheKindsOfForms => MessageText.CallStartToTheSelectParametersTheKindsOfForms,
                MessageType.CallStartToTheSaveIdentifierToTheFormFromMetadata => MessageText.CallStartToTheSaveIdentifierToTheFormFromMetadata,
                MessageType.SuccessToTheSaveIdentifierToTheFormFromMetadata => MessageText.SuccessToTheSaveIdentifierToTheFormFromMetadata,
                MessageType.CallStartToTheSelectParametersTheKindsOfDevelopmentEnviroment => MessageText.CallStartToTheSelectParametersTheKindsOfDevelopmentEnviroment,
                MessageType.SuccessToTheSelectParametersTheKindsOfDevelopmentEnviroment => MessageText.SuccessToTheSelectParametersTheKindsOfDevelopmentEnviroment,
                MessageType.CallStartToTheSaveIdentifierToTheDevelopmentEnviromentsFromMetadata => MessageText.CallStartToTheSaveIdentifierToTheDevelopmentEnviromentsFromMetadata,
                MessageType.SuccessToTheSaveIdentifierToTheDevelopmentEnviromentsFromMetadata => MessageText.SuccessToTheSaveIdentifierToTheDevelopmentEnviromentsFromMetadata,
                MessageType.CallStartToTheSelectParametersTheKindsOfDatabases => MessageText.CallStartToTheSelectParametersTheKindsOfDatabases,
                MessageType.SuccessToTheSelectParametersTheKindsOfDatabases => MessageText.SuccessToTheSelectParametersTheKindsOfDatabases,
                MessageType.CallStartToTheSaveIdentifierToTheDatabasesFromMetadata => MessageText.CallStartToTheSaveIdentifierToTheDatabasesFromMetadata,
                MessageType.SuccessToTheSaveIdentifierToTheDatabasesFromMetadata => MessageText.SuccessToTheSaveIdentifierToTheDatabasesFromMetadata,
                MessageType.CallStartToTheSelectParametersTheKindsOfDatabasesEngine => MessageText.CallStartToTheSelectParametersTheKindsOfDatabasesEngine,
                MessageType.SuccessToTheSelectParametersTheKindsOfDatabasesEngine => MessageText.SuccessToTheSelectParametersTheKindsOfDatabasesEngine,
                MessageType.CallStartToTheSaveIdentifierToTheDatabasesEngineFromMetadata => MessageText.CallStartToTheSaveIdentifierToTheDatabasesEngineFromMetadata,
                MessageType.SuccessToTheSaveIdentifierToTheDatabasesEngineFromMetadata => MessageText.SuccessToTheSaveIdentifierToTheDatabasesEngineFromMetadata,
                MessageType.CallStartToTheSelectParametersTheKindsOfArchitecturePatterns => MessageText.CallStartToTheSelectParametersTheKindsOfArchitecturePatterns,
                MessageType.SuccessToTheSelectParametersTheKindsOfArchitecturePatterns => MessageText.SuccessToTheSelectParametersTheKindsOfArchitecturePatterns,
                MessageType.CallStartToTheSaveIdentifierToTheArchitecturePatternsFromMetadata => MessageText.CallStartToTheSaveIdentifierToTheArchitecturePatternsFromMetadata,
                MessageType.SuccessToTheSaveIdentifierToTheArchitecturePatternsFromMetadata => MessageText.SuccessToTheSaveIdentifierToTheArchitecturePatternsFromMetadata,
                _ => MessageText.NoHasMessageSpecifield
            };

            return _serviceFuncString.UDPUpper(message);
        }
    }
}