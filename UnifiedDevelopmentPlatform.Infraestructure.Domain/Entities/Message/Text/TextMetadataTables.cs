using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message.Text
{
    /// <summary>
    /// The text to the metadata tables.
    /// </summary>
    [ComplexType]
    public static class TextMetadataTables
    {
        /// <summary>
        /// Message type do not specified.
        /// </summary>
        public static string DoNotSpecified => "THE MESSAGE TYPE DO NOT SPECIFIED.";

        /// <summary>
        /// Call start to the save database schema from metadata.
        /// </summary>
        public static string CallStartToTheSaveDatabaseSchemaFromMetadata => "CALL START TO THE SAVE DATABASE SCHEMA FROM METADATA.";

        /// <summary>
        /// Success to the save database schema from metadata.
        /// </summary>
        public static string SuccessToTheSaveDatabaseSchemaFromMetadata => "SUCCESS TO THE SAVE DATABASE SCHEMA FROM METADATA.";

        /// <summary>
        /// Call start to the open the database schema from metadata.
        /// </summary>
        public static string CallStartToTheOpenDatabaseSchemaFromMetadata => "CALL START TO THE OPEN THE DATABASE SCHEMA FROM METADATA.";

        /// <summary>
        /// Success to the open the database schema from metadata.
        /// </summary>
        public static string SuccessToTheOpenDatabaseSchemaFromMetadata => "SUCCESS TO THE OPEN THE DATABASE SCHEMA FROM METADATA.";

        /// <summary>
        /// Call start to the get the metrics of quantities of tables.
        /// </summary>
        public static string CallStartToTheSaveMetricsOfTheGenerationOfTablesAndFields => "CALL START TO THE GET THE METRICS OF QUANTITIES OF TABLES.";

        /// <summary>
        /// Success to the get the metrics of quantities of tables.
        /// </summary>
        public static string SuccessToTheSaveMetricsOfTheGenerationOfTablesAndFields => "SUCCESS TO THE GET THE METRICS OF QUANTITIES OF TABLES.";

        /// <summary>
        /// Call start to the get the metrics of quantities of tables.
        /// </summary>
        public static string CallStartToTheGetMetricsOfQuantitiesOfTables => "CALL START TO THE GET THE METRICS OF QUANTITIES OF TABLES.";

        /// <summary>
        /// Success to the get the metrics of quantities of tables.
        /// </summary>
        public static string SuccessToTheGetMetricsOfQuantitiesOfTables => "SUCCESS TO THE GET THE METRICS OF QUANTITIES OF TABLES.";
    }
}