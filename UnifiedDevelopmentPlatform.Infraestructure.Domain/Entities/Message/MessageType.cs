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
        TheMessageDefaultWhenOccurredError = 2,

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

        [Description("Message to the model state is ok")]
        MessageUdpModelStateIsOk = 11,

        [Description("Message to the script metadata is ok")]
        MessageUdpScriptMetadataIsOk = 12,

        [Description("Message to the metadata is base64 ok")]
        MessageUdpMetadataIsBase64Ok = 13,

        [Description("Message to the development environment is ok")]
        MessageUdpDevelopmentEnvironmentIsOk = 14,

        [Description("Message to the databases is ok")]
        MessageUdpDatabasesIsOk = 15,

        [Description("Message to the databases engine is ok")]
        MessageUdpDatabasesEngineIsOk = 16,

        [Description("Message to the forms is ok")]
        MessageUdpFormIsOk = 17,

        [Description("Message to the architecture is ok")]
        MessageUdpArchitectureIsOk = 18,

        #endregion The validation of filter action context.

        #region Service directory.

        [Description("Error to create all directory")]
        ErrorCreateAllDirectory = 19,

        [Description("Build of all directory standard of solution")]
        BuildDirectoryStandardOfSolution = 20,

        [Description("Directory root is empty")]
        DirectoryRootIsEmpty = 21,

        #endregion Service directory.

        #region Service metadataTables.

        [Description("Call start to the save database schema from metadata")]
        CallStartToTheSaveDatabaseSchemaFromMetadata = 22,

        [Description("Success to the save database schema from metadata")]
        SuccessToTheSaveDatabaseSchemaFromMetadata = 23,

        #endregion Service metadataTables.

        #region Service Metadata.

        [Description("Success at the receive and save all table and fields of schema database")]
        SuccessAtTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase = 24,

        [Description("Call start receive and save all table and fields of schema database")]
        CallStartReceiveAndSaveAllTableAndFieldsOfSchemaDatabase = 25,

        [Description("Load all of the table and fields of schema database")]
        LoadAllOfTheTableAndFieldsOfSchemaDatabase = 26,

        [Description("Decrypt ok of the receive and save all table and fields of schema database")]
        DecryptOkOfTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase = 27,

        [Description("Call start to the select parameters the kinds of unifiedDevelopment platform")]
        CallStartToTheSelectParametersTheKindsOfUnifiedDevelopmentPlatform = 28,

        [Description("Success to the select parameters the kinds of unifiedDevelopment platform")]
        SuccessToTheSelectParametersTheKindsOfUnifiedDevelopmentPlatform = 29,

        #endregion Service Metadata.

        #region Service Crypto.

        [Description("Call start to the encrypt")]
        CallStartToTheEncrypt = 30,

        [Description("Success to the encrypt")]
        SuccessToTheEncrypt = 31,

        [Description("Error to the encrypt")]
        ErrorToTheEncrypt = 32,

        [Description("Call start to the decrypt")]
        CallStartToTheDecrypt = 33,

        [Description("Success to the decrypt")]
        SuccessToTheDecrypt = 34,

        [Description("Error to the decrypt")]
        ErrorToTheDecrypt = 35,

        [Description("Call start to the decode base 64")]
        CallStartToTheDecodeBase64 = 36,

        [Description("Success to the decode base 64")]
        SuccessToTheDecodeBase64 = 37,

        [Description("Error to the decode base 64")]
        ErrorToTheDecodeBase64 = 38,

        #endregion Service Crypto.

        #region Service Form.

        [Description("Call start to the Select parameters the kinds of forms")]
        CallStartToTheSelectParametersTheKindsOfForms = 39,

        [Description("Success to the select parameters the kinds of forms")]
        SuccessToTheSelectParametersTheKindsOfForms = 40,

        [Description("Call start to the save identifier to the form from metadata")]
        CallStartToTheSaveIdentifierToTheFormFromMetadata = 41,

        [Description("Success to the save identifier to the form from metadata")]
        SuccessToTheSaveIdentifierToTheFormFromMetadata = 42,

        #endregion Service Form.

        #region Service Development environments.

        [Description("Call start to the select parameters the kinds of development enviroment")]
        CallStartToTheSelectParametersTheKindsOfDevelopmentEnviroment = 43,

        [Description("Success to the select parameters the kinds of development enviroment")]
        SuccessToTheSelectParametersTheKindsOfDevelopmentEnviroment = 44,

        [Description("Call start to the save identifier to the development enviroments from metadata")]
        CallStartToTheSaveIdentifierToTheDevelopmentEnviromentsFromMetadata = 45,

        [Description("Success to the save identifier to the development enviroments from metadata")]
        SuccessToTheSaveIdentifierToTheDevelopmentEnviromentsFromMetadata = 46,

        #endregion Service Development environments.

        #region Service Databases.

        [Description("Error receive and save all table and fields of schema database")]
        ErrorReceiveAndSaveAllTableAndFieldsOfSchemaDatabase = 47,

        [Description("Call start to the select parameters the kinds of databases")]
        CallStartToTheSelectParametersTheKindsOfDatabases = 48,

        [Description("Success to the select parameters the kinds of databases")]
        SuccessToTheSelectParametersTheKindsOfDatabases = 49,

        [Description("Call start to the save identifier to the databases from metadata")]
        CallStartToTheSaveIdentifierToTheDatabasesFromMetadata = 50,

        [Description("Success to the save identifier to the databases from metadata")]
        SuccessToTheSaveIdentifierToTheDatabasesFromMetadata = 51,

        #endregion Service Databases.

        #region Service Databases engine.

        [Description("Call start to the Select parameters the kinds of databases engine")]
        CallStartToTheSelectParametersTheKindsOfDatabasesEngine = 52,

        [Description("Success to the select parameters the kinds of databases engine")]
        SuccessToTheSelectParametersTheKindsOfDatabasesEngine = 53,

        [Description("Call start to the save identifier to the databases engine from metadata")]
        CallStartToTheSaveIdentifierToTheDatabasesEngineFromMetadata = 54,

        [Description("Success to the save identifier to the databases engine from metadata")]
        SuccessToTheSaveIdentifierToTheDatabasesEngineFromMetadata = 55,

        #endregion Service Databases engine.

        #region Service Architecture patterns.

        [Description("Call start to the select parameters the kinds of architecture patterns")]
        CallStartToTheSelectParametersTheKindsOfArchitecturePatterns = 56,

        [Description("Success to the select parameters the kinds of architecture patterns")]
        SuccessToTheSelectParametersTheKindsOfArchitecturePatterns = 57,

        [Description("Call start to the save identifier to the architecture patterns from metadata")]
        CallStartToTheSaveIdentifierToTheArchitecturePatternsFromMetadata = 58,

        [Description("Success to the save identifier to the architecture patterns from metadata")]
        SuccessToTheSaveIdentifierToTheArchitecturePatternsFromMetadata = 59

        #endregion Service Architecture patterns.
    }
}