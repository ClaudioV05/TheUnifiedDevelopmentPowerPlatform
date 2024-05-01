using System.ComponentModel;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type;

/// <summary>
/// The type to the architecture patterns.
/// </summary>
public enum TypeArchitecturePatterns : int
{
    [Description("The Message type do not specified")]
    DoNotSpecified = 0,
    [Description("Call start to the select parameters the kinds of architecture patterns")]
    CallStartToTheSelectParametersTheKindsOfArchitecturePatterns = 1,
    [Description("Success to the select parameters the kinds of architecture patterns")]
    SuccessToTheSelectParametersTheKindsOfArchitecturePatterns = 2,
    [Description("Call start to the save identifier to the architecture patterns from metadata")]
    CallStartToTheSaveIdentifierToTheArchitecturePatternsFromMetadata = 3,
    [Description("Success to the save identifier to the architecture patterns from metadata")]
    SuccessToTheSaveIdentifierToTheArchitecturePatternsFromMetadata = 4
}