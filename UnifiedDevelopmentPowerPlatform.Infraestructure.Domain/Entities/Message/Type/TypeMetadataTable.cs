using System.ComponentModel;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type
{
    /// <summary>
    /// The type to the metadata table.
    /// </summary>
    public enum TypeMetadataTable : int
    {
        [Description("The Message type do not specified")]
        DoNotSpecified = 0,
        [Description("Call start to the save database schema from metadata")]
        CallStartToTheSaveDatabaseSchemaFromMetadata = 1,
        [Description("Success to the save database schema from metadata")]
        SuccessToTheSaveDatabaseSchemaFromMetadata = 2,
        [Description("Call start to the open the database schema from metadata")]
        CallStartToTheOpenDatabaseSchemaFromMetadata = 3,
        [Description("Success to the open the database schema from metadata")]
        SuccessToTheOpenDatabaseSchemaFromMetadata = 4,
        [Description("Call start to the get the metrics of quantities of tables")]
        CallStartToTheSaveMetricsOfTheGenerationOfTablesAndFields = 5,
        [Description("Success to the get the metrics of quantities of tables")]
        SuccessToTheSaveMetricsOfTheGenerationOfTablesAndFields = 6,
        [Description("Call start to the get the metrics of quantities of tables")]
        CallStartToTheGetMetricsOfQuantitiesOfTables = 7,
        [Description("Success to the get the metrics of quantities of tables")]
        SuccessToTheGetMetricsOfQuantitiesOfTables = 8
    }
}