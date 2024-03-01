using System.ComponentModel;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Types
{
    public static class Pascal
    {
        /// <summary>
        /// Pascal type.
        /// </summary>
        public enum PascalType
        {
            [Description("No has type")]
            NoType = 0,

            [Description("Integer")]
            Integer = 1,

            [Description("Double")]
            Double = 2,

            [Description("String")]
            String = 3,

            [Description("Boolean")]
            Boolean = 4,

            [Description("Datetime")]
            Datetime = 5,

            [Description("Single")]
            Single = 6,

            [Description("TStrings")]
            TStrings = 7
        }
    }
}