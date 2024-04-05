using System.ComponentModel;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.DataTypes
{
    /// <summary>
    /// AnsiSql.
    /// </summary>
    public static class AnsiSql
    {
        /// <summary>
        /// The ansi sql data type.
        /// </summary>
        [Flags]
        public enum DataType : int
        {
            /// <summary>
            /// Undefined.
            /// </summary>
            [Description("Undefined")]
            Undefined = 0,

            /// <summary>
            /// Bit.
            /// </summary>
            [Description("BIT")]
            Bit = 1,

            /// <summary>
            /// Varying.
            /// </summary>
            [Description("BIT")]
            Varying = 2,

            /// <summary>
            /// Date.
            /// </summary>
            [Description("DATE")]
            Date = 3,

            /// <summary>
            /// Time.
            /// </summary>
            [Description("TIME")]
            Time = 4,

            /// <summary>
            /// Timestamp.
            /// </summary>
            [Description("TIMESTAMP")]
            Timestamp = 5,

            /// <summary>
            /// Decimal.
            /// </summary>
            [Description("DECIMAL")]
            Decimal = 6,

            /// <summary>
            /// Real.
            /// </summary>
            [Description("REAL")]
            Real = 7,

            /// <summary>
            /// Double precision.
            /// </summary>
            [Description("DOUBLE PRECISION")]
            DoublePrecision = 8,

            /// <summary>
            /// Float.
            /// </summary>
            [Description("FLOAT")]
            Float = 9,

            /// <summary>
            /// Smallint.
            /// </summary>
            [Description("SMALLINT")] 
            Smallint = 10,

            /// <summary>
            /// Integer.
            /// </summary>
            [Description("INTEGER")] 
            Integer = 11,

            /// <summary>
            /// Interval.
            /// </summary>
            [Description("INTERVAL")] 
            Interval = 12,

            /// <summary>
            /// Character.
            /// </summary>
            [Description("CHARACTER")] 
            Character = 13
        }
    }
}