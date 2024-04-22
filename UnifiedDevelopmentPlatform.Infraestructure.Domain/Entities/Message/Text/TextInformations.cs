using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message.Text
{
    /// <summary>
    /// The text of informations.
    /// </summary>
    [ComplexType]
    public static class TextInformations
    {
        /// <summary>
        /// Message type do not specified.
        /// </summary>
        public static string DoNotSpecified => "THE MESSAGE TYPE DO NOT SPECIFIED.";

        /// <summary>
        /// The message initial of build of UDPP.
        /// </summary>
        public static string TheInitialMessage => "WAS STARTED THE CREATION OF UNIFIED DEVELOPMENT POWER PLATFORM - UDPP.";

        /// <summary>
        /// The message default when occurred error.
        /// </summary>
        public static string TheGlobalErrorMessage => "AN ERROR OCCURRED AT GENERATING THE SERVICE. CONTACT THE TEAM OF UNIFIED DEVELOPMENT POWER PLATFORM - UDPP.";

        /// <summary>
        /// Error filter action context controller.
        /// </summary>
        public static string ErrorFilterActionContextController => "AN ERROR OCCURRED OF THE CREATION THE";

        /// <summary>
        /// Error filter action context tables.
        /// </summary>
        public static string ErrorFilterActionContextTables => "ERROR OCORRED IN THE VALIDATION OF TABLES.";

        /// <summary>
        /// Error filter action context fields.
        /// </summary>
        public static string ErrorFilterActionContextFields => "ERROR OCORRED IN THE VALIDATION OF FIELDS.";
    }
}