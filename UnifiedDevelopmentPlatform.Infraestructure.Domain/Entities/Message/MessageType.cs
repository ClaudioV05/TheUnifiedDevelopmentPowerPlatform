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
        [Description("Error to create all directory")]
        InvalidBase64 = 19,
        #endregion Service metadataTables.

        #region ServiceMetadata.

        [Description("Success at the receive and save all table and fields of schema database")]
        SuccessAtTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase = 20,

        [Description("Call start receive and save all table and fields of schema database")]
        CallStartReceiveAndSaveAllTableAndFieldsOfSchemaDatabase = 21,

        [Description("Load all of the table and fields of schema database")]
        LoadAllOfTheTableAndFieldsOfSchemaDatabase = 22,

        [Description("Decrypt ok of the receive and save all table and fields of schema database")]
        DecryptOkOfTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase = 23,

        [Description("Error receive and save all table and fields of schema database")]
        ErrorReceiveAndSaveAllTableAndFieldsOfSchemaDatabase = 24

        #endregion ServiceMetadata.
    }
}