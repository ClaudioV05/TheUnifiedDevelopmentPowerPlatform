using System.ComponentModel;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message.Type
{
    /// <summary>
    /// The type to the databases.
    /// </summary>
    public enum TypeDatabases : int
    {
        [Description("The Message type do not specified")] DoNotSpecified = 0,
        [Description("Error receive and save all table and fields of schema database")] ErrorReceiveAndSaveAllTableAndFieldsOfSchemaDatabase = 1,
        [Description("Call start to the select parameters the kinds of databases")] CallStartToTheSelectParametersTheKindsOfDatabases = 2,
        [Description("Success to the select parameters the kinds of databases")] SuccessToTheSelectParametersTheKindsOfDatabases = 3,
        [Description("Call start to the save identifier to the databases from metadata")] CallStartToTheSaveIdentifierToTheDatabasesFromMetadata = 4,
        [Description("Success to the save identifier to the databases from metadata")] SuccessToTheSaveIdentifierToTheDatabasesFromMetadata = 5,
        [Description("The metrics of quantities of the tables")] TheMetricsOfQuantitiesOfTables = 6,
        [Description("The metrics of quantities of the fields")] TheMetricsOfQuantitiesOfFields = 7,
        [Description("The metrics of total size of directory by parallel processing")] TheMetricsOfTotalSizeOfDirectoryByParallelProcessing = 8
    }
}