using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Text;

/// <summary>
/// The text to the metadata fields.
/// </summary>
[ComplexType]
public static class TextMetadataFields
{
    /// <summary>
    /// Message type do not specified.
    /// </summary>
    public static string DoNotSpecified => "THE MESSAGE TYPE DO NOT SPECIFIED.";

    /// <summary>
    /// Call start to the load the fields primary key at the table.
    /// </summary>
    public static string CallStartToTheLoadTheFieldsPrimarykeyAtTable => "CALL START TO THE LOAD THE FIELDS PRIMARY KEY AT THE TABLE.";

    /// <summary>
    /// Success to the load the fields primary key at the table.
    /// </summary>
    public static string SuccessToTheLoadTheFieldsPrimarykeyAtTable => "SUCCESS TO THE LOAD THE FIELDS PRIMARY KEY AT THE TABLE.";

    /// <summary>
    /// Call start to the load the field at the table.
    /// </summary>
    public static string CallStartToTheLoadTheFieldAtTable => "CALL START TO THE LOAD THE FIELD AT THE TABLE.";

    /// <summary>
    /// Success to the load the field at the table.
    /// </summary>
    public static string SuccessToTheLoadTheFieldAtTable => "Success to the load the field at the table.";

    /// <summary>
    /// Call start to the get the primary key field name.
    /// </summary>
    public static string CallStartToTheGetThePrimaryKeyFieldName => "CALL START TO THE GET THE PRIMARY KEY FIELD NAME.";

    /// <summary>
    /// Success to the get the primary key field name.
    /// </summary>
    public static string SuccessToTheGetThePrimaryKeyFieldName => "SUCCESS TO THE LOAD THE GET THE PRIMARY KEY FIELD NAME.";

    /// <summary>
    /// Call start to the get the metrics of quantities of fields.
    /// </summary>
    public static string CallStartToTheGetMetricsOfQuantitiesOfFields => "CALL START TO THE GET THE METRICS OF QUANTITIES OF FIELDS.";

    /// <summary>
    /// Success to the get the metrics of quantities of fields.
    /// </summary>
    public static string SuccessToTheGetMetricsOfQuantitiesOfFields => "SUCCESS TO THE GET THE METRICS OF QUANTITIES OF FIELDS.";
}