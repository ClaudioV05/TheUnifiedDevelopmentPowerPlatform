using System.ComponentModel;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message.Type
{
    /// <summary>
    /// The type to the metadata fields.
    /// </summary>
    public enum TypeMetadataFields : int
    {
        [Description("The Message type do not specified")] DoNotSpecified = 0,
        [Description("Call start to the load the fields primary key at the table")] CallStartToTheLoadTheFieldsPrimarykeyAtTable = 1,
        [Description("Success to the load the fields primary key at the table")] SuccessToTheLoadTheFieldsPrimarykeyAtTable = 2,
        [Description("Call start to the load the field at the table")] CallStartToTheLoadTheFieldAtTable = 3,
        [Description("Success to the load the field at the table")] SuccessToTheLoadTheFieldAtTable = 4,
        [Description("Call start to the get the primary key field name")] CallStartToTheGetThePrimaryKeyFieldName = 5,
        [Description("Success to the get the primary key field name")] SuccessToTheGetThePrimaryKeyFieldName = 6,
        [Description("Call start to the get the metrics of quantities of fields")] CallStartToTheGetMetricsOfQuantitiesOfFields = 7,
        [Description("Success to the get the metrics of quantities of fields")] SuccessToTheGetMetricsOfQuantitiesOfFields = 8
    }
}