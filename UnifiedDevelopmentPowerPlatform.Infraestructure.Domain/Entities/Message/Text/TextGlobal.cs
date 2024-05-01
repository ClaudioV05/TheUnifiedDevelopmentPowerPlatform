using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Text;

/// <summary>
/// The text global.
/// </summary>
[ComplexType]
public static class TextGlobal
{
    /// <summary>
    /// Message type do not specified.
    /// </summary>
    public static string DoNotSpecified => "THE MESSAGE TYPE DO NOT SPECIFIED.";

    /// <summary>
    /// Call start to the creation of Unified Development Power Platform - UDPP.
    /// </summary>
    public static string CallStartToTheCreationOfUnifiedDevelopmentPowerPlatform => "WAS STARTED THE CREATION OF UNIFIED DEVELOPMENT POWER PLATFORM - UDPP.";

    /// <summary>
    /// The exception global message when occurred error.
    /// </summary>
    public static string TheExceptionGlobalErrorMessage => "AN ERROR OCCURRED AT GENERATING THE SERVICE. CONTACT THE TEAM OF UNIFIED DEVELOPMENT POWER PLATFORM - UDPP.";

    /// <summary>
    /// Error filter action context controller.
    /// </summary>
    public static string ErrorFilterActionContextController => "AN ERROR OCCURRED OF THE CREATION THE";

    /// <summary>
    /// Call start to the filter action context metadata.
    /// </summary>
    public static string CallStartToTheFilterActionContextMetadata => "CALL START TO THE FILTER ACTION CONTEXT METADATA.";

    /// <summary>
    /// Call start to the filter action context metadata.
    /// </summary>
    public static string SuccessToTheFilterActionContextMetadata => "SUCCESS TO THE FILTER ACTION CONTEXT METADATA.";

    /// <summary>
    /// Error filter action context metadata.
    /// </summary>
    public static string ErrorFilterActionContextMetadata => "ERROR OCORRED ON VALIDATION THE METADATA.";

    /// <summary>
    /// Call start to the filter action context table data.
    /// </summary>
    public static string CallStartToTheFilterActionContextTablesdata => "CALL START TO THE FILTER ACTION CONTEXT TABLE DATA.";

    /// <summary>
    /// Call start to the filter action context table data.
    /// </summary>
    public static string SuccessToTheFilterActionContextTablesdata => "SUCCESS TO THE FILTER ACTION CONTEXT TABLE DATA.";

    /// <summary>
    /// Error filter action context table data.
    /// </summary>
    public static string ErrorFilterActionContextTablesdata => "ERROR OCORRED ON VALIDATION THE METADATA.";
}