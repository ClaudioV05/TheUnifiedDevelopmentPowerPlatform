using System.ComponentModel;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Types
{
    public static class Firebird
    {
        /// <summary>
        /// Firebird type.
        /// </summary>
        public enum FirebirdType
        {
            [Description("No has type")]
            NoType = 0,

            [Description("Integer")]
            Integer = 1,

            [Description("Double")]
            Double = 2,

            [Description("String")]
            String = 3,

            [Description("Logical")]
            Logical = 4,

            [Description("Timestamp")]
            Timestamp = 5,

            [Description("Date")]
            Date = 6,

            [Description("Time")]
            Time = 7,

            [Description("Blob")]
            Blob = 8
        }
    }
}