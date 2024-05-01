using System.ComponentModel;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type;

/// <summary>
/// The type to the databases engine.
/// </summary>
public enum TypeDatabasesEngine : int
{
    [Description("The Message type do not specified")]
    DoNotSpecified = 0,
    [Description("Call start to the Select parameters the kinds of databases engine")]
    CallStartToTheSelectParametersTheKindsOfDatabasesEngine = 1,
    [Description("Success to the select parameters the kinds of databases engine")]
    SuccessToTheSelectParametersTheKindsOfDatabasesEngine = 2,
    [Description("Call start to the save identifier to the databases engine from metadata")]
    CallStartToTheSaveIdentifierToTheDatabasesEngineFromMetadata = 3,
    [Description("Success to the save identifier to the databases engine from metadata")]
    SuccessToTheSaveIdentifierToTheDatabasesEngineFromMetadata = 4
}