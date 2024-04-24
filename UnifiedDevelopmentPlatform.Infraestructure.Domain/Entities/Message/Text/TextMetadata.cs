using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Text
{
    /// <summary>
    /// The text to the metadata.
    /// </summary>
    [ComplexType]
    public static class TextMetadata
    {
        /// <summary>
        /// Message type do not specified.
        /// </summary>
        public static string DoNotSpecified => "THE MESSAGE TYPE DO NOT SPECIFIED.";

        /// <summary>
        /// Success at the receive and save all table and fields of schema database.
        /// </summary>
        public static string SuccessAtTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase => "SUCCESS AT THE RECEIVE AND SAVE ALL TABLE AND FIELDS OF SCHEMA DATABASE.";

        /// <summary>
        /// Call start receive and save all table and fields of schema database.
        /// </summary>
        public static string CallStartReceiveAndSaveAllTableAndFieldsOfSchemaDatabase => "CALL START RECEIVE AND SAVE ALL TABLE AND FIELDS OF SCHEMA DATABASE.";

        /// <summary>
        /// Load all of the table and fields of schema database.
        /// </summary>
        public static string LoadAllOfTheTableAndFieldsOfSchemaDatabase => "LOAD ALL OF THE TABLE AND FIELDS OF SCHEMA DATABASE.";

        /// <summary>
        /// Decrypt ok of the receive and save all table and fields of schema database.
        /// </summary>
        public static string DecryptOkOfTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase => "DECRYPT OK OF THE RECEIVE AND SAVE ALL TABLE AND FIELDS OF SCHEMA DATABASE.";

        /// <summary>
        /// Call start to the Select parameters the kinds of unifiedDevelopment platform.
        /// </summary>
        public static string CallStartToTheSelectParametersTheKindsOfUnifiedDevelopmentPowerPlatform => "CALL START TO THE SELECT PARAMETERS THE KINDS OF UNIFIEDDEVELOPMENT PLATFORM.";

        /// <summary>
        /// Success to the Select parameters the kinds of unified development platform.
        /// </summary>
        public static string SuccessToTheSelectParametersTheKindsOfUnifiedDevelopmentPowerPlatform => "SUCCESS TO THE SELECT PARAMETERS THE KINDS OF UNIFIEDDEVELOPMENT PLATFORM.";
    }
}