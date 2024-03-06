using System.ComponentModel;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message
{
    /// <summary>
    /// The type of message.
    /// </summary>
    public enum MessageType : int
    {
        [Description("No has message")]
        NoMessage = 0,

        [Description("Initial")]
        Initial = 1,

        [Description("Platform ok for Windows")]
        PlatformIsWindowsOk = 2,

        [Description("Platform diferent for Windows")]
        PlatformIsWindowsErro = 3,

        #region Filter action.
        [Description("Error filter action context controller")]
        ErrorFilterActionContextController = 4,

        [Description("Error filter action Context tables")]
        ErrorFilterActionContextTables = 5,

        [Description("Error filter action Context fields")]
        ErrorFilterActionContextFields = 6,

        #endregion Filter action.

        #region The validation of filter action.
        [Description("Message default to service validation")]
        MessageDefaultToServiceValidation = 7,

        [Description("Message to the model state is ok")]
        MessageUdpModelStateIsOk = 8,

        [Description("Message to the script metadata is ok")]
        MessageUdpScriptMetadataIsOk = 9,

        [Description("Message to the metadata is base64 ok")]
        MessageUdpMetadataIsBase64Ok = 10,

        [Description("Message to the development environment is ok")]
        MessageUdpDevelopmentEnvironmentIsOk = 11,

        [Description("Message to the databases is ok")]
        MessageUdpDatabasesIsOk = 12,

        [Description("Message to the databases engine is ok")]
        MessageUdpDatabasesEngineIsOk = 13,

        [Description("Message to the forms is ok")]
        MessageUdpFormIsOk = 14,

        [Description("Message to the architecture is ok")]
        MessageUdpArchitectureIsOk = 15,

        #endregion The validation of filter action.

        #region Service directory.
        [Description("Error to create all directory")]
        ErrorCreateAllDirectory = 16,

        [Description("Build of all directory standard of solution")]
        BuildDirectoryStandardOfSolution = 17,

        [Description("Directory root is empty")]
        DirectoryRootIsEmpty = 18,

        #endregion Service directory.

        #region Service metadataTables.

        [Description("Call start to the save database schema from metadata")]
        CallStartToTheSaveDatabaseSchemaFromMetadata = 19,

        [Description("Success to the save database schema from metadata")]
        SuccessToTheSaveDatabaseSchemaFromMetadata = 20,

        #endregion Service metadataTables.

        #region Service Metadata.

        [Description("Success at the receive and save all table and fields of schema database")]
        SuccessAtTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase = 21,

        [Description("Call start receive and save all table and fields of schema database")]
        CallStartReceiveAndSaveAllTableAndFieldsOfSchemaDatabase = 22,

        [Description("Load all of the table and fields of schema database")]
        LoadAllOfTheTableAndFieldsOfSchemaDatabase = 23,

        [Description("Decrypt ok of the receive and save all table and fields of schema database")]
        DecryptOkOfTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase = 24,

        [Description("Call start to the select parameters the kinds of unifiedDevelopment platform")]
        CallStartToTheSelectParametersTheKindsOfUnifiedDevelopmentPlatform = 25,

        [Description("Success to the select parameters the kinds of unifiedDevelopment platform")]
        SuccessToTheSelectParametersTheKindsOfUnifiedDevelopmentPlatform = 26,

        #endregion Service Metadata.

        #region Service Crypto.

        [Description("Call start to the encrypt")]
        CallStartToTheEncrypt = 27,

        [Description("Success to the encrypt")]
        SuccessToTheEncrypt = 28,

        [Description("Error to the encrypt")]
        ErrorToTheEncrypt = 29,

        [Description("Call start to the decrypt")]
        CallStartToTheDecrypt = 30,

        [Description("Success to the decrypt")]
        SuccessToTheDecrypt = 31,

        [Description("Error to the decrypt")]
        ErrorToTheDecrypt = 32,

        [Description("Call start to the decode base 64")]
        CallStartToTheDecodeBase64 = 33,

        [Description("Success to the decode base 64")]
        SuccessToTheDecodeBase64 = 34,

        [Description("Error to the decode base 64")]
        ErrorToTheDecodeBase64 = 35,

        #endregion Service Crypto.

        #region Service Form.

        [Description("Call start to the Select parameters the kinds of forms")]
        CallStartToTheSelectParametersTheKindsOfForms = 36,

        [Description("Success to the select parameters the kinds of forms")]
        SuccessToTheSelectParametersTheKindsOfForms = 37,

        [Description("Call start to the save identifier to the form from metadata")]
        CallStartToTheSaveIdentifierToTheFormFromMetadata = 38,

        [Description("Success to the save identifier to the form from metadata")]
        SuccessToTheSaveIdentifierToTheFormFromMetadata = 39,

        #endregion Service Form.

        #region Service Development environments.

        [Description("Call start to the select parameters the kinds of development enviroment")]
        CallStartToTheSelectParametersTheKindsOfDevelopmentEnviroment = 40,

        [Description("Success to the select parameters the kinds of development enviroment")]
        SuccessToTheSelectParametersTheKindsOfDevelopmentEnviroment = 41,

        [Description("Call start to the save identifier to the development enviroments from metadata")]
        CallStartToTheSaveIdentifierToTheDevelopmentEnviromentsFromMetadata = 42,

        [Description("Success to the save identifier to the development enviroments from metadata")]
        SuccessToTheSaveIdentifierToTheDevelopmentEnviromentsFromMetadata = 43,

        #endregion Service Development environments.

        #region Service Databases.

        [Description("Error receive and save all table and fields of schema database")]
        ErrorReceiveAndSaveAllTableAndFieldsOfSchemaDatabase = 44,

        [Description("Call start to the select parameters the kinds of databases")]
        CallStartToTheSelectParametersTheKindsOfDatabases = 45,

        [Description("Success to the select parameters the kinds of databases")]
        SuccessToTheSelectParametersTheKindsOfDatabases = 46,

        [Description("Call start to the save identifier to the databases from metadata")]
        CallStartToTheSaveIdentifierToTheDatabasesFromMetadata = 47,

        [Description("Success to the save identifier to the databases from metadata")]
        SuccessToTheSaveIdentifierToTheDatabasesFromMetadata = 48,

        #endregion Service Databases.

        #region Service Databases engine.

        [Description("Call start to the Select parameters the kinds of databases engine")]
        CallStartToTheSelectParametersTheKindsOfDatabasesEngine = 49,

        [Description("Success to the select parameters the kinds of databases engine")]
        SuccessToTheSelectParametersTheKindsOfDatabasesEngine = 50,

        [Description("Call start to the save identifier to the databases engine from metadata")]
        CallStartToTheSaveIdentifierToTheDatabasesEngineFromMetadata = 51,

        [Description("Success to the save identifier to the databases engine from metadata")]
        SuccessToTheSaveIdentifierToTheDatabasesEngineFromMetadata = 52,

        #endregion Service Databases engine.

        #region Service Architecture patterns.

        [Description("Call start to the select parameters the kinds of architecture patterns")]
        CallStartToTheSelectParametersTheKindsOfArchitecturePatterns = 53,

        [Description("Success to the select parameters the kinds of architecture patterns")]
        SuccessToTheSelectParametersTheKindsOfArchitecturePatterns = 54,

        [Description("Call start to the save identifier to the architecture patterns from metadata")]
        CallStartToTheSaveIdentifierToTheArchitecturePatternsFromMetadata = 55,

        [Description("Success to the save identifier to the architecture patterns from metadata")]
        SuccessToTheSaveIdentifierToTheArchitecturePatternsFromMetadata = 56

        #endregion Service Architecture patterns.
    }
}