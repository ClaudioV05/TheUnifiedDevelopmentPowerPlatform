using System.ComponentModel;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type
{
    /// <summary>
    /// The type global.
    /// </summary>
    public enum TypeGlobal : int
    {
        [Description("The Message type do not specified")] DoNotSpecified = 0,
        [Description("Call start to the creation of Unified Development Power Platform - UDPP")] CallStartToTheCreationOfUnifiedDevelopmentPowerPlatform = 1,
        [Description("The exception global message when occurred error")] TheExceptionGlobalErrorMessage = 2,
        [Description("Error filter action context controller")] ErrorFilterActionContextController = 3,
        [Description("Call start to the filter action context metadata")] CallStartToTheFilterActionContextMetadata = 4,
        [Description("Success to the filter action context metadata")] SuccessToTheFilterActionContextMetadata = 5,
        [Description("Error filter action context metadata")] ErrorFilterActionContextMetadata = 6,
        [Description("Call start to the filter action context table data")] CallStartToTheFilterActionContextTablesdata = 7,
        [Description("Success to the filter action context table data")] SuccessToTheFilterActionContextTablesdata = 8,
        [Description("Error filter action context table data")] ErrorFilterActionContextTablesdata = 9
    }
}