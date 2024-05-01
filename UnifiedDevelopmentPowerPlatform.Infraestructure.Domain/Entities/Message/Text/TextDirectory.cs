using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Text;

/// <summary>
/// The text to the directory.
/// </summary>
[ComplexType]
public static class TextDirectory
{
    /// <summary>
    /// Message type do not specified.
    /// </summary>
    public static string DoNotSpecified => "THE MESSAGE TYPE DO NOT SPECIFIED.";

    /// <summary>
    /// Directory root is empty.
    /// </summary>
    public static string DirectoryRootIsEmpty => "DIRECTORY ROOT IS EMPTY IN SERVICE DIRECTORY.";

    /// <summary>
    /// Message default to service validation.
    /// </summary>
    public static string ErrorCreateAllDirectory => "ERRO TO CREATE DIRECTORY DEFAULT OF UNIFIED DEVELOPMENT PLATFORM - UDP.";

    /// <summary>
    /// Build of all directory standard of solution.
    /// </summary>
    public static string BuildDirectoryStandardOfSolution => "STARTING OF THE CREATION THE INITIAL OF THE DIRECTORY STANDARD.";

    /// <summary>
    /// Call start to the create directory project of solution.
    /// </summary>
    public static string CallStartToTheCreateDirectoryProjectOfSolution => "CALL START TO THE CREATE DIRECTORY PROJECT OF SOLUTION.";

    /// <summary>
    /// Success to the create directory project of solution.
    /// </summary>
    public static string SuccessToTheCreateDirectoryProjectOfSolution => "SUCCESS TO THE CREATE DIRECTORY PROJECT OF SOLUTION.";
}