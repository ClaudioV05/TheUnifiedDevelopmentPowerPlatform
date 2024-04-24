using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Text
{
    /// <summary>
    /// The text to the architecture patterns.
    /// </summary>
    [ComplexType]
    public static class TextArchitecturePatterns
    {
        /// <summary>
        /// Message type do not specified.
        /// </summary>
        public static string DoNotSpecified => "THE MESSAGE TYPE DO NOT SPECIFIED.";

        /// <summary>
        /// Call start to the Select parameters the kinds of architecture patterns.
        /// </summary>
        public static string CallStartToTheSelectParametersTheKindsOfArchitecturePatterns => "CALL START TO THE SELECT PARAMETERS THE KINDS OF ARCHITECTURE PATTERNS.";

        /// <summary>
        /// Success to the Select parameters the kinds of architecture patterns.
        /// </summary>
        public static string SuccessToTheSelectParametersTheKindsOfArchitecturePatterns => "SUCCESS TO THE SELECT PARAMETERS THE KINDS OF ARCHITECTURE PATTERNS.";

        /// <summary>
        /// Call start to the save identifier to the architecture patterns from metadata.
        /// </summary>
        public static string CallStartToTheSaveIdentifierToTheArchitecturePatternsFromMetadata => "CALL START TO THE SAVE IDENTIFIER TO THE ARCHITECTURE PATTERNS FROM METADATA.";

        /// <summary>
        /// Success to the save identifier to the architecture patterns from metadata.
        /// </summary>
        public static string SuccessToTheSaveIdentifierToTheArchitecturePatternsFromMetadata => "SUCCESS TO THE SAVE IDENTIFIER TO THE ARCHITECTURE PATTERNS FROM METADATA.";
    }
}