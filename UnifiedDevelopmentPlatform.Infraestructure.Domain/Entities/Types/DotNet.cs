using System.ComponentModel;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Types
{
    public static class DotNet
    {
        /// <summary>
        /// DotNet type.
        /// </summary>
        public enum DotNetType
        {
            [Description("No has type")]
            NoType = 0,

            [Description("Integer")]
            Int = 1,

            [Description("Float")]
            Float = 2,

            [Description("Decimal")]
            Decimal = 3,

            [Description("Double")]
            Double = 4,

            [Description("Char")]
            Char = 5,

            [Description("String")]
            String = 6,

            [Description("Boolean")]
            Boolean = 7,

            [Description("Datetime")]
            Datetime = 8
        }
    }
}