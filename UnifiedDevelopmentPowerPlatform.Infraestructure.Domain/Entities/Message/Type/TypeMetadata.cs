using System.ComponentModel;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type;

/// <summary>
/// The type to the metadata.
/// </summary>
public enum TypeMetadata : int
{
    [Description("The Message type do not specified")]
    DoNotSpecified = 0,
    [Description("Call start to the receive and save all tables and fields of schema database")]
    CallStartToTheReceiveAndSaveAllTablesAndFieldsOfSchemaDatabase = 1,
    [Description("Success to the receive and save all tables and fields of schema database")]
    SuccessToTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase = 2,
    [Description("Load all of the tables and fields of schema database")]
    LoadAllOfTheTablesAndFieldsOfSchemaDatabase = 3,
    [Description("Decrypt ok from the receive and save all table and fields of schema database")]
    DecryptOkFromTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase = 4,
    [Description("Call start to the select parameters the kinds of unifiedDevelopment platform")]
    CallStartToTheSelectParametersTheKindsOfUnifiedDevelopmentPowerPlatform = 5,
    [Description("Success to the select parameters the kinds of unifiedDevelopment platform")]
    SuccessToTheSelectParametersTheKindsOfUnifiedDevelopmentPowerPlatform = 6,
    [Description("Call start to the receive the tables data with their fields that will generate the solution")]
    CallStartToTheReceiveTheTablesdataAndGenerateTheSolution = 7,
    [Description("Success to the receive the tables data with their fields that will generate the solution")]
    SuccessToTheReceiveTheTablesdataAndGenerateTheSolution = 8,
    [Description("Error to the receive the tables data with their fields that will generate the solution")]
    ErroToTheReceiveTheTablesdataAndGenerateTheSolution = 9
}