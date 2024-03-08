using System.ComponentModel;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message
{
    /// <summary>
    /// The type of message.
    /// </summary>
    public enum MessageType : int
    {
        [Description("No has message specifield")]
        NoHasMessageSpecifield = 0,

        [Description("The initial message")]
        TheInitialMessage = 1,

        [Description("The message default when occurred error")]
        TheGlobalErrorMessage = 2,

        [Description("The platform Windows is ok")]
        ThePlatformWindowsIsOk = 3,

        [Description("The platform Windows isn't ok")]
        ThePlatformWindowsIsNotOk = 4,

        #region The filter action context.

        [Description("Error filter action context controller")]
        ErrorFilterActionContextController = 5,

        [Description("Error filter action Context tables")]
        ErrorFilterActionContextTables = 6,

        [Description("Error filter action Context fields")]
        ErrorFilterActionContextFields = 7,

        [Description("Call start to the create directory project of solution")]
        CallStartToTheCreateDirectoryProjectOfSolution = 8,

        [Description("Success to the create directory project of solution")]
        SuccessToTheCreateDirectoryProjectOfSolution = 9,

        #endregion The filter action context.

        #region The validation of filter action context.

        [Description("Message default to service validation")]
        MessageDefaultToServiceValidation = 10,

        [Description("The model state is ok")]
        TheModelStateIsOk = 11,

        [Description("The script metadata is ok")]
        TheScriptMetadataIsOk = 12,

        [Description("The metadata is base64 ok")]
        TheMetadataIsBase64Ok = 13,

        [Description("The development environment is ok")]
        TheDevelopmentEnvironmentIsOk = 14,

        [Description("The databases is ok")]
        TheDatabasesIsOk = 15,

        [Description("The databases implemented isn't ok")]
        TheDatabasesImplementedIsntOk = 16,

        [Description("The databases engine is ok")]
        TheDatabasesEngineIsOk = 17,

        [Description("The form view is ok")]
        TheFormViewIsOk = 18,

        [Description("The architecture patterns is ok")]
        TheArchitecturePatternsIsOk = 19,

        #endregion The validation of filter action context.

        #region Service directory.

        [Description("Error to create all directory")]
        ErrorCreateAllDirectory = 20,

        [Description("Build of all directory standard of solution")]
        BuildDirectoryStandardOfSolution = 21,

        [Description("Directory root is empty")]
        DirectoryRootIsEmpty = 22,

        #endregion Service directory.

        #region Service metadataTables.

        [Description("Call start to the save database schema from metadata")]
        CallStartToTheSaveDatabaseSchemaFromMetadata = 23,

        [Description("Success to the save database schema from metadata")]
        SuccessToTheSaveDatabaseSchemaFromMetadata = 24,

        #endregion Service metadataTables.

        #region Service Metadata.

        [Description("Success at the receive and save all table and fields of schema database")]
        SuccessAtTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase = 25,

        [Description("Call start receive and save all table and fields of schema database")]
        CallStartReceiveAndSaveAllTableAndFieldsOfSchemaDatabase = 26,

        [Description("Load all of the table and fields of schema database")]
        LoadAllOfTheTableAndFieldsOfSchemaDatabase = 27,

        [Description("Decrypt ok of the receive and save all table and fields of schema database")]
        DecryptOkOfTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase = 28,

        [Description("Call start to the select parameters the kinds of unifiedDevelopment platform")]
        CallStartToTheSelectParametersTheKindsOfUnifiedDevelopmentPlatform = 29,

        [Description("Success to the select parameters the kinds of unifiedDevelopment platform")]
        SuccessToTheSelectParametersTheKindsOfUnifiedDevelopmentPlatform = 30,

        #endregion Service Metadata.

        #region Service Crypto.

        [Description("Call start to the encrypt")]
        CallStartToTheEncrypt = 31,

        [Description("Success to the encrypt")]
        SuccessToTheEncrypt = 32,

        [Description("Error to the encrypt")]
        ErrorToTheEncrypt = 33,

        [Description("Call start to the decrypt")]
        CallStartToTheDecrypt = 34,

        [Description("Success to the decrypt")]
        SuccessToTheDecrypt = 35,

        [Description("Error to the decrypt")]
        ErrorToTheDecrypt = 36,

        [Description("Call start to the decode base 64")]
        CallStartToTheDecodeBase64 = 37,

        [Description("Success to the decode base 64")]
        SuccessToTheDecodeBase64 = 38,

        [Description("Error to the decode base 64")]
        ErrorToTheDecodeBase64 = 39,

        #endregion Service Crypto.

        #region Service Form.

        [Description("Call start to the Select parameters the kinds of forms")]
        CallStartToTheSelectParametersTheKindsOfForms = 40,

        [Description("Success to the select parameters the kinds of forms")]
        SuccessToTheSelectParametersTheKindsOfForms = 41,

        [Description("Call start to the save identifier to the form from metadata")]
        CallStartToTheSaveIdentifierToTheFormFromMetadata = 42,

        [Description("Success to the save identifier to the form from metadata")]
        SuccessToTheSaveIdentifierToTheFormFromMetadata = 43,

        #endregion Service Form.

        #region Service Development environments.

        [Description("Call start to the select parameters the kinds of development enviroment")]
        CallStartToTheSelectParametersTheKindsOfDevelopmentEnviroment = 44,

        [Description("Success to the select parameters the kinds of development enviroment")]
        SuccessToTheSelectParametersTheKindsOfDevelopmentEnviroment = 45,

        [Description("Call start to the save identifier to the development enviroments from metadata")]
        CallStartToTheSaveIdentifierToTheDevelopmentEnviromentsFromMetadata = 46,

        [Description("Success to the save identifier to the development enviroments from metadata")]
        SuccessToTheSaveIdentifierToTheDevelopmentEnviromentsFromMetadata = 47,

        #endregion Service Development environments.

        #region Service Databases.

        [Description("Error receive and save all table and fields of schema database")]
        ErrorReceiveAndSaveAllTableAndFieldsOfSchemaDatabase = 48,

        [Description("Call start to the select parameters the kinds of databases")]
        CallStartToTheSelectParametersTheKindsOfDatabases = 49,

        [Description("Success to the select parameters the kinds of databases")]
        SuccessToTheSelectParametersTheKindsOfDatabases = 50,

        [Description("Call start to the save identifier to the databases from metadata")]
        CallStartToTheSaveIdentifierToTheDatabasesFromMetadata = 51,

        [Description("Success to the save identifier to the databases from metadata")]
        SuccessToTheSaveIdentifierToTheDatabasesFromMetadata = 52,

        #endregion Service Databases.

        #region Service Databases engine.

        [Description("Call start to the Select parameters the kinds of databases engine")]
        CallStartToTheSelectParametersTheKindsOfDatabasesEngine = 53,

        [Description("Success to the select parameters the kinds of databases engine")]
        SuccessToTheSelectParametersTheKindsOfDatabasesEngine = 54,

        [Description("Call start to the save identifier to the databases engine from metadata")]
        CallStartToTheSaveIdentifierToTheDatabasesEngineFromMetadata = 55,

        [Description("Success to the save identifier to the databases engine from metadata")]
        SuccessToTheSaveIdentifierToTheDatabasesEngineFromMetadata = 56,

        #endregion Service Databases engine.

        #region Service Architecture patterns.

        [Description("Call start to the select parameters the kinds of architecture patterns")]
        CallStartToTheSelectParametersTheKindsOfArchitecturePatterns = 57,

        [Description("Success to the select parameters the kinds of architecture patterns")]
        SuccessToTheSelectParametersTheKindsOfArchitecturePatterns = 58,

        [Description("Call start to the save identifier to the architecture patterns from metadata")]
        CallStartToTheSaveIdentifierToTheArchitecturePatternsFromMetadata = 59,

        [Description("Success to the save identifier to the architecture patterns from metadata")]
        SuccessToTheSaveIdentifierToTheArchitecturePatternsFromMetadata = 60

        #endregion Service Architecture patterns.
    }
}