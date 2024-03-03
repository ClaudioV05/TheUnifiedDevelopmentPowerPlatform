using System.ComponentModel;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message
{
    /// <summary>
    /// Message type
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

        [Description("Error receive and save all table and fields of schema database")]
        ErrorReceiveAndSaveAllTableAndFieldsOfSchemaDatabase = 25,

        [Description("Call start to the Select parameters the kinds of databases")]
        CallStartToTheSelectParametersTheKindsOfDatabases = 26,

        [Description("Call start to the Select parameters the kinds of forms")]
        CallStartToTheSelectParametersTheKindsOfForms = 27,

        [Description("Call start to the Select parameters the kinds of development enviroment")]
        CallStartToTheSelectParametersTheKindsOfDevelopmentEnviroment = 28,

        [Description("Call start to the Select parameters the kinds of databases engine")]
        CallStartToTheSelectParametersTheKindsOfDatabasesEngine = 29,

        [Description("Call start to the Select parameters the kinds of architecture patterns")]
        CallStartToTheSelectParametersTheKindsOfArchitecturePatterns = 30,

        [Description("Call start to the Select parameters the kinds of unifiedDevelopment platform")]
        CallStartToTheSelectParametersTheKindsOfUnifiedDevelopmentPlatform = 31,

        #endregion Service Metadata.

        #region Service Crypto.

        [Description("Call start to the encrypt")]
        CallStartToTheEncrypt = 32,

        [Description("Success to the encrypt")]
        SuccessToTheEncrypt = 33,

        [Description("Error to the encrypt")]
        ErrorToTheEncrypt = 34,

        [Description("Call start to the decrypt")]
        CallStartToTheDecrypt = 35,

        [Description("Success to the decrypt")]
        SuccessToTheDecrypt = 36,

        [Description("Error to the decrypt")]
        ErrorToTheDecrypt = 37,

        [Description("Call start to the decode base 64")]
        CallStartToTheDecodeBase64 = 38,

        [Description("Success to the decode base 64")]
        SuccessToTheDecodeBase64 = 39,

        [Description("Error to the decode base 64")]
        ErrorToTheDecodeBase64 = 40,

        #endregion Service Crypto.

        #region Service Form.

        [Description("Call start to the save identifier to the form from metadata")]
        CallStartToTheSaveIdentifierToTheFormFromMetadata = 41,

        [Description("Success to the save identifier to the form from metadata")]
        SuccessToTheSaveIdentifierToTheFormFromMetadata = 42

        #endregion Service Form.
    }
}