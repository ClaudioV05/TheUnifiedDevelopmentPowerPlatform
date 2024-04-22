﻿using System.ComponentModel;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message.Type
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

        #region Service Metadata Tables.

        [Description("Call start to the save database schema from metadata")]
        CallStartToTheSaveDatabaseSchemaFromMetadata = 23,

        [Description("Success to the save database schema from metadata")]
        SuccessToTheSaveDatabaseSchemaFromMetadata = 24,

        [Description("Call start to the open the database schema from metadata")]
        CallStartToTheOpenDatabaseSchemaFromMetadata = 25,

        [Description("Success to the open the database schema from metadata")]
        SuccessToTheOpenDatabaseSchemaFromMetadata = 26,

        [Description("Call start to the get the metrics of quantities of tables")]
        CallStartToTheSaveMetricsOfTheGenerationOfTablesAndFields = 27,

        [Description("Success to the get the metrics of quantities of tables")]
        SuccessToTheSaveMetricsOfTheGenerationOfTablesAndFields = 28,

        [Description("Call start to the get the metrics of quantities of tables")]
        CallStartToTheGetMetricsOfQuantitiesOfTables = 29,

        [Description("Success to the get the metrics of quantities of tables")]
        SuccessToTheGetMetricsOfQuantitiesOfTables = 30,

        #endregion Service Metadata Tables.

        #region Service Metadata Fields.

        [Description("Call start to the load the fields primary key at the table")]
        CallStartToTheLoadTheFieldsPrimarykeyAtTable = 31,

        [Description("Success to the load the fields primary key at the table")]
        SuccessToTheLoadTheFieldsPrimarykeyAtTable = 32,

        [Description("Call start to the load the field at the table")]
        CallStartToTheLoadTheFieldAtTable = 33,

        [Description("Success to the load the field at the table")]
        SuccessToTheLoadTheFieldAtTable = 34,

        [Description("Call start to the get the primary key field name")]
        CallStartToTheGetThePrimaryKeyFieldName = 35,

        [Description("Success to the get the primary key field name")]
        SuccessToTheGetThePrimaryKeyFieldName = 36,

        [Description("Call start to the get the metrics of quantities of fields")]
        CallStartToTheGetMetricsOfQuantitiesOfFields = 37,

        [Description("Success to the get the metrics of quantities of fields")]
        SuccessToTheGetMetricsOfQuantitiesOfFields = 38,

        #endregion Service Metadata Fields.

        #region Service Metadata.

        [Description("Success at the receive and save all table and fields of schema database")]
        SuccessAtTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase = 39,

        [Description("Call start receive and save all table and fields of schema database")]
        CallStartReceiveAndSaveAllTableAndFieldsOfSchemaDatabase = 40,

        [Description("Load all of the table and fields of schema database")]
        LoadAllOfTheTableAndFieldsOfSchemaDatabase = 41,

        [Description("Decrypt ok of the receive and save all table and fields of schema database")]
        DecryptOkOfTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase = 42,

        [Description("Call start to the select parameters the kinds of unifiedDevelopment platform")]
        CallStartToTheSelectParametersTheKindsOfUnifiedDevelopmentPlatform = 43,

        [Description("Success to the select parameters the kinds of unifiedDevelopment platform")]
        SuccessToTheSelectParametersTheKindsOfUnifiedDevelopmentPlatform = 44,

        #endregion Service Metadata.
    }
}