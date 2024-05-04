using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Text;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type;

namespace UnifiedDevelopmentPowerPlatform.Application.Services;

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

    public string UDPPGetMessage(TypeGlobal type)
    {
        return _serviceFuncString.UDPPUpper(type switch
        {
            TypeGlobal.DoNotSpecified => TextGlobal.DoNotSpecified,
            TypeGlobal.CallStartToTheCreationOfUnifiedDevelopmentPowerPlatform => TextGlobal.CallStartToTheCreationOfUnifiedDevelopmentPowerPlatform,
            TypeGlobal.TheExceptionGlobalErrorMessage => TextGlobal.TheExceptionGlobalErrorMessage,
            TypeGlobal.ErrorFilterActionContextController => TextGlobal.ErrorFilterActionContextController,
            TypeGlobal.CallStartToTheFilterActionContextMetadata => TextGlobal.CallStartToTheFilterActionContextMetadata,
            TypeGlobal.SuccessToTheFilterActionContextMetadata => TextGlobal.SuccessToTheFilterActionContextMetadata,
            TypeGlobal.ErrorFilterActionContextMetadata => TextGlobal.ErrorFilterActionContextMetadata,
            TypeGlobal.CallStartToTheFilterActionContextTablesdata => TextGlobal.CallStartToTheFilterActionContextTablesdata,
            TypeGlobal.SuccessToTheFilterActionContextTablesdata => TextGlobal.SuccessToTheFilterActionContextTablesdata,
            TypeGlobal.ErrorFilterActionContextTablesdata => TextGlobal.ErrorFilterActionContextTablesdata,
            _ => _serviceFuncString.Empty
        });
    }

    public string UDPGetMessage(TypeDevelopmentEnvironments type)
    {
        return _serviceFuncString.UDPPUpper(type switch
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
        return _serviceFuncString.UDPPUpper(type switch
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
        return _serviceFuncString.UDPPUpper(type switch
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
        return _serviceFuncString.UDPPUpper(type switch
        {
            TypeDatabases.DoNotSpecified => TextDatabases.DoNotSpecified,
            TypeDatabases.CallStartToTheSelectParametersTheKindsOfDatabases => TextDatabases.CallStartToTheSelectParametersTheKindsOfDatabases,
            TypeDatabases.SuccessToTheSelectParametersTheKindsOfDatabases => TextDatabases.SuccessToTheSelectParametersTheKindsOfDatabases,
            TypeDatabases.CallStartToTheSaveIdentifierToTheDatabasesFromMetadata => TextDatabases.CallStartToTheSaveIdentifierToTheDatabasesFromMetadata,
            TypeDatabases.SuccessToTheSaveIdentifierToTheDatabasesFromMetadata => TextDatabases.SuccessToTheSaveIdentifierToTheDatabasesFromMetadata,
            TypeDatabases.TheMetricsOfQuantitiesOfTables => TextDatabases.TheMetricsOfQuantitiesOfTables,
            TypeDatabases.TheMetricsOfQuantitiesOfFields => TextDatabases.TheMetricsOfQuantitiesOfFields,
            TypeDatabases.TheMetricsOfTotalSizeOfDirectoryByParallelProcessing => TextDatabases.TheMetricsOfTotalSizeOfDirectoryByParallelProcessing,
            TypeDatabases.ErrorReceiveAndSaveAllTablesAndFieldsOfSchemaDatabase => TextDatabases.ErrorReceiveAndSaveAllTablesAndFieldsOfSchemaDatabase,
            _ => _serviceFuncString.Empty
        });
    }

    public string UDPGetMessage(TypeFormsView type)
    {
        return _serviceFuncString.UDPPUpper(type switch
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
        return _serviceFuncString.UDPPUpper(type switch
        {
            TypeCrypto.DoNotSpecified => TextCrypto.DoNotSpecified,
            TypeCrypto.CallStartToTheEncrypt => TextCrypto.CallStartToTheEncrypt,
            TypeCrypto.SuccessToTheEncrypt => TextCrypto.SuccessToTheEncrypt,
            TypeCrypto.ErrorToTheEncrypt => TextCrypto.ErrorToTheEncrypt,
            TypeCrypto.CallStartToTheDecrypt => TextCrypto.CallStartToTheDecrypt,
            TypeCrypto.SuccessToTheDecrypt => TextCrypto.SuccessToTheDecrypt,
            TypeCrypto.ErrorToTheDecrypt => TextCrypto.ErrorToTheDecrypt,
            TypeCrypto.CallStartToTheDecodeFromBase64 => TextCrypto.CallStartToTheDecodeFromBase64,
            TypeCrypto.SuccessToTheDecodeFromBase64 => TextCrypto.SuccessToTheDecodeFromBase64,
            TypeCrypto.ErrorToTheDecodeFromBase64 => TextCrypto.ErrorToTheDecodeFromBase64,
            TypeCrypto.CallStartToTheEncodeToBase64 => TextCrypto.CallStartToTheEncodeToBase64,
            TypeCrypto.SuccessToTheEncodeToBase64 => TextCrypto.SuccessToTheEncodeToBase64,
            TypeCrypto.ErrorToTheEncodeToBase64 => TextCrypto.ErrorToTheEncodeToBase64,
            _ => _serviceFuncString.Empty
        });
    }

    public string UDPGetMessage(TypeMetadata type)
    {
        return _serviceFuncString.UDPPUpper(type switch
        {
            TypeMetadata.DoNotSpecified => TextMetadata.DoNotSpecified,
            TypeMetadata.CallStartToTheReceiveAndSaveAllTablesAndFieldsOfSchemaDatabase => TextMetadata.CallStartToTheReceiveAndSaveAllTablesAndFieldsOfSchemaDatabase,
            TypeMetadata.SuccessToTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase => TextMetadata.SuccessToTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase,
            TypeMetadata.LoadAllOfTheTablesAndFieldsOfSchemaDatabase => TextMetadata.LoadAllOfTheTablesAndFieldsOfSchemaDatabase,
            TypeMetadata.DecryptOkFromTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase => TextMetadata.DecryptOkFromTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase,
            TypeMetadata.CallStartToTheSelectParametersTheKindsOfUnifiedDevelopmentPowerPlatform => TextMetadata.CallStartToTheSelectParametersTheKindsOfUnifiedDevelopmentPowerPlatform,
            TypeMetadata.SuccessToTheSelectParametersTheKindsOfUnifiedDevelopmentPowerPlatform => TextMetadata.SuccessToTheSelectParametersTheKindsOfUnifiedDevelopmentPowerPlatform,
            TypeMetadata.CallStartToTheReceiveTheTablesdataAndGenerateTheSolution => TextMetadata.CallStartToTheReceiveTheTablesdataAndGenerateTheSolution,
            TypeMetadata.SuccessToTheReceiveTheTablesdataAndGenerateTheSolution => TextMetadata.SuccessToTheReceiveTheTablesdataAndGenerateTheSolution,
            TypeMetadata.ErroToTheReceiveTheTablesdataAndGenerateTheSolution => TextMetadata.ErroToTheReceiveTheTablesdataAndGenerateTheSolution,
            _ => _serviceFuncString.Empty
        });
    }

    public string UDPGetMessage(TypeMetadataFields type)
    {
        return _serviceFuncString.UDPPUpper(type switch
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
        return _serviceFuncString.UDPPUpper(type switch
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

    public string UDPGetMessage(TypeDirectory type)
    {
        return _serviceFuncString.UDPPUpper(type switch
        {
            TypeDirectory.DoNotSpecified => TextDirectory.DoNotSpecified,
            TypeDirectory.DirectoryRootIsEmpty => TextDirectory.DirectoryRootIsEmpty,
            TypeDirectory.ErrorCreateAllDirectory => TextDirectory.ErrorCreateAllDirectory,
            TypeDirectory.BuildDirectoryStandardOfSolution => TextDirectory.BuildDirectoryStandardOfSolution,
            TypeDirectory.CallStartToTheCreateDirectoryProjectOfSolution => TextDirectory.CallStartToTheCreateDirectoryProjectOfSolution,
            TypeDirectory.SuccessToTheCreateDirectoryProjectOfSolution => TextDirectory.SuccessToTheCreateDirectoryProjectOfSolution,
            _ => _serviceFuncString.Empty
        });
    }

    public string UDPGetMessage(TypeValidation type)
    {
        return _serviceFuncString.UDPPUpper(type switch
        {
            TypeValidation.DoNotSpecified => TextValidation.DoNotSpecified,
            TypeValidation.TheModelStateIsNotOk => TextValidation.TheModelStateIsNotOk,
            TypeValidation.TheScriptMetadataIsNotOk => TextValidation.TheScriptMetadataIsNotOk,
            TypeValidation.TheMetadataIsNotInBase64Ok => TextValidation.TheMetadataIsNotInBase64Ok,
            TypeValidation.TheDevelopmentEnvironmentIsNotOk => TextValidation.TheDevelopmentEnvironmentIsNotOk,
            TypeValidation.TheFormsViewIsNotOk => TextValidation.TheFormsViewIsNotOk,
            TypeValidation.TheDatabasesIsNotOk => TextValidation.TheDatabasesIsNotOk,
            TypeValidation.TheDatabasesImplementedIsNotOk => TextValidation.TheDatabasesImplementedIsNotOk,
            TypeValidation.TheDatabasesEngineIsNotOk => TextValidation.TheDatabasesEngineIsNotOk,
            TypeValidation.TheArchitecturePatternsIsNotOk => TextValidation.TheArchitecturePatternsIsNotOk,
            TypeValidation.ThePlatformWindowsIsOk => TextValidation.ThePlatformWindowsIsOk,
            TypeValidation.ThePlatformWindowsIsNotOk => TextValidation.ThePlatformWindowsIsNotOk,
            TypeValidation.TheTablesdataIsNotOk => TextValidation.TheTablesdataIsNotOk,
            TypeValidation.TheTablesdataHasNoFieldsContent => TextValidation.TheTablesdataHasNoFieldsContent,
            TypeValidation.TheDirectoriesIsNotOk => TextValidation.TheDirectoriesIsNotOk,
            TypeValidation.TheFilesIsNotOk => TextValidation.TheFilesIsNotOk,
            _ => _serviceFuncString.Empty
        });
    }
}