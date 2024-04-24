using System.ComponentModel;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type
{
    /// <summary>
    /// The type to the metadata.
    /// </summary>
    public enum TypeMetadata : int
    {
        [Description("The Message type do not specified")] DoNotSpecified = 0,
        [Description("Success at the receive and save all table and fields of schema database")] SuccessAtTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase = 1,
        [Description("Call start receive and save all table and fields of schema database")] CallStartReceiveAndSaveAllTableAndFieldsOfSchemaDatabase = 2,
        [Description("Load all of the table and fields of schema database")] LoadAllOfTheTableAndFieldsOfSchemaDatabase = 3,
        [Description("Decrypt ok of the receive and save all table and fields of schema database")] DecryptOkOfTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase = 4,
        [Description("Call start to the select parameters the kinds of unifiedDevelopment platform")] CallStartToTheSelectParametersTheKindsOfUnifiedDevelopmentPowerPlatform = 5,
        [Description("Success to the select parameters the kinds of unifiedDevelopment platform")] SuccessToTheSelectParametersTheKindsOfUnifiedDevelopmentPowerPlatform = 6
    }
}