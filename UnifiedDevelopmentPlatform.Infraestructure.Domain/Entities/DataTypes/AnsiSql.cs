using System.ComponentModel;
using System.Runtime.Serialization;

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
            [EnumMember]
            Undefined = 0,

            /// <summary>
            /// Bit.
            /// </summary>
            [Description("BIT")]
            [EnumMember]
            Bit = 1,

            /// <summary>
            /// Varying.
            /// </summary>
            [Description("BIT")]
            [EnumMember]
            Varying = 2,

            /// <summary>
            /// Date.
            /// </summary>
            [Description("DATE")]
            [EnumMember]
            Date = 3,

            /// <summary>
            /// Time.
            /// </summary>
            [Description("TIME")]
            [EnumMember]
            Time = 4,

            /// <summary>
            /// Timestamp.
            /// </summary>
            [Description("TIMESTAMP")]
            [EnumMember]
            Timestamp = 5,

            /// <summary>
            /// Decimal.
            /// </summary>
            [Description("DECIMAL")]
            [EnumMember]
            Decimal = 6,

            /// <summary>
            /// Real.
            /// </summary>
            [Description("REAL")]
            [EnumMember]
            Real = 7,

            /// <summary>
            /// Double precision.
            /// </summary>
            [Description("DOUBLE PRECISION")]
            [EnumMember]
            DoublePrecision = 8,

            /// <summary>
            /// Float.
            /// </summary>
            [Description("FLOAT")]
            [EnumMember]
            Float = 9,

            /// <summary>
            /// Smallint.
            /// </summary>
            [Description("SMALLINT")]
            [EnumMember]
            Smallint = 10,

            /// <summary>
            /// Integer.
            /// </summary>
            [Description("INTEGER")]
            [EnumMember]
            Integer = 11,

            /// <summary>
            /// Interval.
            /// </summary>
            [Description("INTERVAL")]
            [EnumMember]
            Interval = 12,

            /// <summary>
            /// Char.
            /// </summary>
            [Description("CHAR")]
            [EnumMember]
            Char = 13,

            /// <summary>
            /// Character.
            /// </summary>
            [Description("CHARACTER")]
            [EnumMember]
            Character = 14,

            /// <summary>
            /// Varchar.
            /// </summary>
            [Description("VARCHAR")]
            [EnumMember]
            Varchar = 15
        }
    }
}