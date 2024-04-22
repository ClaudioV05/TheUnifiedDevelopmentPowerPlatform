﻿using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message.Text;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message.Type;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service of Message.
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

        public string UDPGetMessage(MessageType enumerated)
        {
            string message = _serviceFuncString.Empty;

            if (Enum.IsDefined(typeof(MessageType), enumerated)) // Create the method for this
            {
                message = enumerated switch
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
                   
                    MessageType.TheArchitecturePatternsIsOk => MessageText.TheArchitecturePatternsIsOk,
                    
                    _ => MessageText.NoHasMessageSpecifield
                };
            }

            return _serviceFuncString.UDPUpper(message);
        }

        public string UDPGetMessage(TypeDevelopmentEnvironments type)
        {
            return _serviceFuncString.UDPUpper(type switch
            {
                TypeDevelopmentEnvironments.DoNotSpecified => TextDevelopmentEnvironments.DoNotSpecified,
                TypeDevelopmentEnvironments.CallStartToTheGetDataTypeFromTableInScriptMetadata => TextDevelopmentEnvironments.CallStartToTheGetDataTypeFromTableInScriptMetadata,
                TypeDevelopmentEnvironments.SuccessToTheGetDataTypeFromTableInScriptMetadata => TextDevelopmentEnvironments.SuccessToTheGetDataTypeFromTableInScriptMetadata,
                TypeDevelopmentEnvironments.ErrorToTheGetDataTypeFromTableInScriptMetadata => TextDevelopmentEnvironments.ErrorToTheGetDataTypeFromTableInScriptMetadata,
                TypeDevelopmentEnvironments.CallStartToGetDataTypeOfCSharp => TextDevelopmentEnvironments.CallStartToGetDataTypeOfCSharp,
                TypeDevelopmentEnvironments.SuccessToGetDataTypeOfCSharp => TextDevelopmentEnvironments.SuccessToGetDataTypeOfCSharp,
                TypeDevelopmentEnvironments.ErrorToGetDataTypeOfCSharp => TextDevelopmentEnvironments.ErrorToGetDataTypeOfCSharp,
                TypeDevelopmentEnvironments.CallStartToGetDataTypeOfPascal => TextDevelopmentEnvironments.CallStartToGetDataTypeOfPascal,
                TypeDevelopmentEnvironments.SuccessToGetDataTypeOfPascal => TextDevelopmentEnvironments.SuccessToGetDataTypeOfPascal,
                TypeDevelopmentEnvironments.ErrorToGetDataTypeOfPascal => TextDevelopmentEnvironments.ErrorToGetDataTypeOfPascal,
                TypeDevelopmentEnvironments.CallStartToTheSelectParametersTheKindsOfDevelopmentEnviroment => TextDevelopmentEnvironments.CallStartToTheSelectParametersTheKindsOfDevelopmentEnviroment,
                TypeDevelopmentEnvironments.SuccessToTheSelectParametersTheKindsOfDevelopmentEnviroment => TextDevelopmentEnvironments.SuccessToTheSelectParametersTheKindsOfDevelopmentEnviroment,
                TypeDevelopmentEnvironments.CallStartToTheSaveIdentifierToTheDevelopmentEnviromentsFromMetadata => TextDevelopmentEnvironments.CallStartToTheSaveIdentifierToTheDevelopmentEnviromentsFromMetadata,
                TypeDevelopmentEnvironments.SuccessToTheSaveIdentifierToTheDevelopmentEnviromentsFromMetadata => TextDevelopmentEnvironments.SuccessToTheSaveIdentifierToTheDevelopmentEnviromentsFromMetadata,
                _ => _serviceFuncString.Empty
            });
        }

        public string UDPGetMessage(TypeArchitecturePatterns type)
        {
            return _serviceFuncString.UDPUpper(type switch
            {
                TypeArchitecturePatterns.DoNotSpecified => TextArchitecturePatterns.DoNotSpecified,
                TypeArchitecturePatterns.CallStartToTheSelectParametersTheKindsOfArchitecturePatterns => TextArchitecturePatterns.CallStartToTheSelectParametersTheKindsOfArchitecturePatterns,
                TypeArchitecturePatterns.SuccessToTheSelectParametersTheKindsOfArchitecturePatterns => TextArchitecturePatterns.SuccessToTheSelectParametersTheKindsOfArchitecturePatterns,
                TypeArchitecturePatterns.CallStartToTheSaveIdentifierToTheArchitecturePatternsFromMetadata => TextArchitecturePatterns.CallStartToTheSaveIdentifierToTheArchitecturePatternsFromMetadata,
                TypeArchitecturePatterns.SuccessToTheSaveIdentifierToTheArchitecturePatternsFromMetadata => TextArchitecturePatterns.SuccessToTheSaveIdentifierToTheArchitecturePatternsFromMetadata,
                _ => _serviceFuncString.Empty
            });
        }

        public string UDPGetMessage(TypeDatabasesEngine type)
        {
            return _serviceFuncString.UDPUpper(type switch
            {
                TypeDatabasesEngine.DoNotSpecified => TextDatabasesEngine.DoNotSpecified,
                TypeDatabasesEngine.CallStartToTheSelectParametersTheKindsOfDatabasesEngine => TextDatabasesEngine.CallStartToTheSelectParametersTheKindsOfDatabasesEngine,
                TypeDatabasesEngine.SuccessToTheSelectParametersTheKindsOfDatabasesEngine => TextDatabasesEngine.SuccessToTheSelectParametersTheKindsOfDatabasesEngine,
                TypeDatabasesEngine.CallStartToTheSaveIdentifierToTheDatabasesEngineFromMetadata => TextDatabasesEngine.CallStartToTheSaveIdentifierToTheDatabasesEngineFromMetadata,
                TypeDatabasesEngine.SuccessToTheSaveIdentifierToTheDatabasesEngineFromMetadata => TextDatabasesEngine.SuccessToTheSaveIdentifierToTheDatabasesEngineFromMetadata,
                _ => _serviceFuncString.Empty
            });
        }

        public string UDPGetMessage(TypeDatabases type)
        {
            return _serviceFuncString.UDPUpper(type switch
            {
                TypeDatabases.DoNotSpecified => TextDatabases.DoNotSpecified,
                TypeDatabases.CallStartToTheSelectParametersTheKindsOfDatabases => TextDatabases.CallStartToTheSelectParametersTheKindsOfDatabases,
                TypeDatabases.SuccessToTheSelectParametersTheKindsOfDatabases => TextDatabases.SuccessToTheSelectParametersTheKindsOfDatabases,
                TypeDatabases.CallStartToTheSaveIdentifierToTheDatabasesFromMetadata => TextDatabases.CallStartToTheSaveIdentifierToTheDatabasesFromMetadata,
                TypeDatabases.SuccessToTheSaveIdentifierToTheDatabasesFromMetadata => TextDatabases.SuccessToTheSaveIdentifierToTheDatabasesFromMetadata,
                TypeDatabases.TheMetricsOfQuantitiesOfTables => TextDatabases.TheMetricsOfQuantitiesOfTables,
                TypeDatabases.TheMetricsOfQuantitiesOfFields => TextDatabases.TheMetricsOfQuantitiesOfFields,
                TypeDatabases.TheMetricsOfTotalSizeOfDirectoryByParallelProcessing => TextDatabases.TheMetricsOfTotalSizeOfDirectoryByParallelProcessing,
                TypeDatabases.ErrorReceiveAndSaveAllTableAndFieldsOfSchemaDatabase => TextDatabases.ErrorReceiveAndSaveAllTableAndFieldsOfSchemaDatabase,
                _ => _serviceFuncString.Empty
            });
        }

        public string UDPGetMessage(TypeFormsView type)
        {
            return _serviceFuncString.UDPUpper(type switch
            {
                TypeFormsView.DoNotSpecified => TextFormsView.DoNotSpecified,
                TypeFormsView.SuccessToTheSelectParametersTheKindsOfForms => TextFormsView.SuccessToTheSelectParametersTheKindsOfForms,
                TypeFormsView.CallStartToTheSelectParametersTheKindsOfForms => TextFormsView.CallStartToTheSelectParametersTheKindsOfForms,
                TypeFormsView.CallStartToTheSaveIdentifierToTheFormFromMetadata => TextFormsView.CallStartToTheSaveIdentifierToTheFormFromMetadata,
                TypeFormsView.SuccessToTheSaveIdentifierToTheFormFromMetadata => TextFormsView.SuccessToTheSaveIdentifierToTheFormFromMetadata,
                _ => _serviceFuncString.Empty
            });
        }

        public string UDPGetMessage(TypeCrypto type)
        {
            return _serviceFuncString.UDPUpper(type switch
            {
                TypeCrypto.DoNotSpecified => TextCrypto.DoNotSpecified,
                TypeCrypto.CallStartToTheEncrypt => TextCrypto.CallStartToTheEncrypt,
                TypeCrypto.SuccessToTheEncrypt => TextCrypto.SuccessToTheEncrypt,
                TypeCrypto.ErrorToTheEncrypt => TextCrypto.ErrorToTheEncrypt,
                TypeCrypto.CallStartToTheDecrypt => TextCrypto.CallStartToTheDecrypt,
                TypeCrypto.SuccessToTheDecrypt => TextCrypto.SuccessToTheDecrypt,
                TypeCrypto.ErrorToTheDecrypt => TextCrypto.ErrorToTheDecrypt,
                TypeCrypto.CallStartToTheDecodeBase64 => TextCrypto.CallStartToTheDecodeBase64,
                TypeCrypto.SuccessToTheDecodeBase64 => TextCrypto.SuccessToTheDecodeBase64,
                TypeCrypto.ErrorToTheDecodeBase64 => TextCrypto.ErrorToTheDecodeBase64,
                _ => _serviceFuncString.Empty
            });
        }

        public string UDPGetMessage(TypeMetadata type)
        {
            return _serviceFuncString.UDPUpper(type switch
            {
                TypeMetadata.DoNotSpecified => TextMetadata.DoNotSpecified,
                TypeMetadata.SuccessAtTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase => TextMetadata.SuccessAtTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase,
                TypeMetadata.CallStartReceiveAndSaveAllTableAndFieldsOfSchemaDatabase => TextMetadata.CallStartReceiveAndSaveAllTableAndFieldsOfSchemaDatabase,
                TypeMetadata.LoadAllOfTheTableAndFieldsOfSchemaDatabase => TextMetadata.LoadAllOfTheTableAndFieldsOfSchemaDatabase,
                TypeMetadata.DecryptOkOfTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase => TextMetadata.DecryptOkOfTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase,
                TypeMetadata.CallStartToTheSelectParametersTheKindsOfUnifiedDevelopmentPlatform => TextMetadata.CallStartToTheSelectParametersTheKindsOfUnifiedDevelopmentPlatform,
                TypeMetadata.SuccessToTheSelectParametersTheKindsOfUnifiedDevelopmentPlatform => TextMetadata.SuccessToTheSelectParametersTheKindsOfUnifiedDevelopmentPlatform,
                _ => _serviceFuncString.Empty
            });
        }

        public string UDPGetMessage(TypeMetadataFields type)
        {
            return _serviceFuncString.UDPUpper(type switch
            {
                TypeMetadataFields.DoNotSpecified => TextMetadataFields.DoNotSpecified,
                TypeMetadataFields.CallStartToTheLoadTheFieldsPrimarykeyAtTable => TextMetadataFields.CallStartToTheLoadTheFieldsPrimarykeyAtTable,
                TypeMetadataFields.SuccessToTheLoadTheFieldsPrimarykeyAtTable => TextMetadataFields.SuccessToTheLoadTheFieldsPrimarykeyAtTable,
                TypeMetadataFields.CallStartToTheLoadTheFieldAtTable => TextMetadataFields.CallStartToTheLoadTheFieldAtTable,
                TypeMetadataFields.SuccessToTheLoadTheFieldAtTable => TextMetadataFields.SuccessToTheLoadTheFieldAtTable,
                TypeMetadataFields.CallStartToTheGetThePrimaryKeyFieldName => TextMetadataFields.CallStartToTheGetThePrimaryKeyFieldName,
                TypeMetadataFields.SuccessToTheGetThePrimaryKeyFieldName => TextMetadataFields.SuccessToTheGetThePrimaryKeyFieldName,
                TypeMetadataFields.CallStartToTheGetMetricsOfQuantitiesOfFields => TextMetadataFields.CallStartToTheGetMetricsOfQuantitiesOfFields,
                TypeMetadataFields.SuccessToTheGetMetricsOfQuantitiesOfFields => TextMetadataFields.SuccessToTheGetMetricsOfQuantitiesOfFields,
                _ => _serviceFuncString.Empty
            });
        }

        public string UDPGetMessage(TypeMetadataTable type)
        {
            return _serviceFuncString.UDPUpper(type switch
            {
                TypeMetadataTable.DoNotSpecified => TextMetadataTables.DoNotSpecified,
                TypeMetadataTable.CallStartToTheSaveDatabaseSchemaFromMetadata => TextMetadataTables.CallStartToTheSaveDatabaseSchemaFromMetadata,
                TypeMetadataTable.SuccessToTheSaveDatabaseSchemaFromMetadata => TextMetadataTables.SuccessToTheSaveDatabaseSchemaFromMetadata,
                TypeMetadataTable.CallStartToTheOpenDatabaseSchemaFromMetadata => TextMetadataTables.CallStartToTheOpenDatabaseSchemaFromMetadata,
                TypeMetadataTable.SuccessToTheOpenDatabaseSchemaFromMetadata => TextMetadataTables.SuccessToTheOpenDatabaseSchemaFromMetadata,
                TypeMetadataTable.CallStartToTheSaveMetricsOfTheGenerationOfTablesAndFields => TextMetadataTables.CallStartToTheSaveMetricsOfTheGenerationOfTablesAndFields,
                TypeMetadataTable.SuccessToTheSaveMetricsOfTheGenerationOfTablesAndFields => TextMetadataTables.SuccessToTheSaveMetricsOfTheGenerationOfTablesAndFields,
                TypeMetadataTable.CallStartToTheGetMetricsOfQuantitiesOfTables => TextMetadataTables.CallStartToTheGetMetricsOfQuantitiesOfTables,
                TypeMetadataTable.SuccessToTheGetMetricsOfQuantitiesOfTables => TextMetadataTables.SuccessToTheGetMetricsOfQuantitiesOfTables,
                _ => _serviceFuncString.Empty
            });
        }
    }
}