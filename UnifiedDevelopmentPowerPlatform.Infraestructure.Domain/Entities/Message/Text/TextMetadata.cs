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
        /// Call start to the receive and save all table(s) and field(s) of schema database.
        /// </summary>
        public static string CallStartToTheReceiveAndSaveAllTablesAndFieldsOfSchemaDatabase => "CALL START TO THE RECEIVE AND SAVE ALL TABLES AND FIELDS OF SCHEMA DATABASE.";

        /// <summary>
        /// Success to the receive and save all table(s) and field(s) of schema database.
        /// </summary>
        public static string SuccessToTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase => "SUCCESS TO THE RECEIVE AND SAVE ALL TABLES AND FIELDS OF SCHEMA DATABASE.";

        /// <summary>
        /// Load all of the table(s) and fields of schema database.
        /// </summary>
        public static string LoadAllOfTheTablesAndFieldsOfSchemaDatabase => "LOAD ALL OF THE TABLES AND FIELDS OF SCHEMA DATABASE.";

        /// <summary>
        /// Decrypt ok from the receive and save all table and fields of schema database.
        /// </summary>
        public static string DecryptOkFromTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase => "DECRYPT OK FROM THE RECEIVE AND SAVE ALL TABLE AND FIELDS OF SCHEMA DATABASE.";

        /// <summary>
        /// Call start to the Select parameters the kinds of unifiedDevelopment platform.
        /// </summary>
        public static string CallStartToTheSelectParametersTheKindsOfUnifiedDevelopmentPowerPlatform => "CALL START TO THE SELECT PARAMETERS THE KINDS OF UNIFIEDDEVELOPMENT PLATFORM.";

        /// <summary>
        /// Success to the Select parameters the kinds of unified development platform.
        /// </summary>
        public static string SuccessToTheSelectParametersTheKindsOfUnifiedDevelopmentPowerPlatform => "SUCCESS TO THE SELECT PARAMETERS THE KINDS OF UNIFIEDDEVELOPMENT PLATFORM.";

        /// <summary>
        /// Call start to the receive the tables data with their fields that will generate the solution.
        /// </summary>
        public static string CallStartToTheReceiveTheTablesdataAndGenerateTheSolution => "CALL START TO THE RECEIVE THE TABLES DATA WITH THEIR FIELDS THAT WILL GENERATE THE SOLUTION.";

        /// <summary>
        /// Success to the receive the tables data with their fields that will generate the solution.
        /// </summary>
        public static string SuccessToTheReceiveTheTablesdataAndGenerateTheSolution => "SUCCESS TO THE RECEIVE THE TABLES DATA WITH THEIR FIELDS THAT WILL GENERATE THE SOLUTION.";

        /// <summary>
        /// Error to the receive the tables data with their fields that will generate the solution.
        /// </summary>
        public static string ErroToTheReceiveTheTablesdataAndGenerateTheSolution => "ERROR TO THE RECEIVE THE TABLES DATA WITH THEIR FIELDS THAT WILL GENERATE THE SOLUTION.";
    }
}