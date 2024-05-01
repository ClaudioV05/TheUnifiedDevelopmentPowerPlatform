using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Text;

/// <summary>
/// The text to the databases engine.
/// </summary>
[ComplexType]
public static class TextDatabasesEngine
{
    /// <summary>
    /// Message type do not specified.
    /// </summary>
    public static string DoNotSpecified => "THE MESSAGE TYPE DO NOT SPECIFIED.";

    /// <summary>
    /// Call start to the Select parameters the kinds of databases engine.
    /// </summary>
    public static string CallStartToTheSelectParametersTheKindsOfDatabasesEngine => "CALL START TO THE SELECT PARAMETERS THE KINDS OF DATABASES ENGINE.";

    /// <summary>
    /// Success to the Select parameters the kinds of databases engine.
    /// </summary>
    public static string SuccessToTheSelectParametersTheKindsOfDatabasesEngine => "SUCCESS TO THE SELECT PARAMETERS THE KINDS OF DATABASES ENGINE.";

    /// <summary>
    /// Call start to the save identifier to the databases engine from metadata.
    /// </summary>
    public static string CallStartToTheSaveIdentifierToTheDatabasesEngineFromMetadata => "CALL START TO THE SAVE IDENTIFIER TO THE DATABASES ENGINE FROM METADATA.";

    /// <summary>
    /// Success to the save identifier to the databases engine from metadata.
    /// </summary>
    public static string SuccessToTheSaveIdentifierToTheDatabasesEngineFromMetadata => "SUCCESS TO THE SAVE IDENTIFIER TO THE DATABASES ENGINE FROM METADATA.";
}