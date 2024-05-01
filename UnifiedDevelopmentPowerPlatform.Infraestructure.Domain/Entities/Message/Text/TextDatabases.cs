using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Text;

/// <summary>
/// The text to the databases.
/// </summary>
[ComplexType]
public static class TextDatabases
{
    /// <summary>
    /// Message type do not specified.
    /// </summary>
    public static string DoNotSpecified => "THE MESSAGE TYPE DO NOT SPECIFIED.";

    /// <summary>
    /// Call start to the Select parameters the kinds of databases.
    /// </summary>
    public static string CallStartToTheSelectParametersTheKindsOfDatabases => "CALL START TO THE SELECT PARAMETERS THE KINDS OF DATABASES.";

    /// <summary>
    /// Success to the Select parameters the kinds of databases.
    /// </summary>
    public static string SuccessToTheSelectParametersTheKindsOfDatabases => "SUCCESS TO THE SELECT PARAMETERS THE KINDS OF DATABASES.";

    /// <summary>
    /// Call start to the save identifier to the databases from metadata.
    /// </summary>
    public static string CallStartToTheSaveIdentifierToTheDatabasesFromMetadata => "CALL START TO THE SAVE IDENTIFIER TO THE DATABASES FROM METADATA.";

    /// <summary>
    /// Success to the save identifier to the databases from metadata.
    /// </summary>
    public static string SuccessToTheSaveIdentifierToTheDatabasesFromMetadata => "SUCCESS TO THE SAVE IDENTIFIER TO THE DATABASES FROM METADATA.";

    /// <summary>
    /// Error receive and save all table(s) and field(s) of schema database.
    /// </summary>
    public static string ErrorReceiveAndSaveAllTablesAndFieldsOfSchemaDatabase => "ERROR OCCURRED AT RETURN ALL OF THE TABLES AND FIELDS OF SCHEMA DATABASEIN THE VALIDATION OF FIELDS.";

    /// <summary>
    /// The metrics of quantities of the tables.
    /// </summary>
    public static string TheMetricsOfQuantitiesOfTables => "THE QUANTITY OF THE TOTAL OF TABLES WHITHIN THE DATABASE SCHEMA.";

    /// <summary>
    /// The metrics of quantities of the fields.
    /// </summary>
    public static string TheMetricsOfQuantitiesOfFields => "THE QUANTITY OF THE TOTAL OF FIELDS WHITHIN THE DATABASE SCHEMA.";

    /// <summary>
    /// The metrics of total size of directory by parallel processing.
    /// </summary>
    public static string TheMetricsOfTotalSizeOfDirectoryByParallelProcessing => "THE TOTAL SIZE OF DIRECTORY APP AT THE MOMENT OF GENERATION OF THE TABLES AND FIELDS.";
}