using System.ComponentModel;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.DataTypes
{
    /// <summary>
    /// CSharp.
    /// </summary>
    public static class CSharp
    {
        /// <summary>
        /// The CSharp data type.
        /// </summary>
        [Flags]
        public enum DataType : int
        {
            /// <summary>
            /// System.Undefined.
            /// </summary>
            [Description("undefined")]
            Undefined = 0,

            /// <summary>
            /// System.Sbyte.
            /// </summary>
            [Description("sbyte")]
            Sbyte = 1,

            /// <summary>
            /// System.Byte.
            /// </summary>
            [Description("byte")]
            Byte = 2,

            /// <summary>
            /// System.Short.
            /// </summary>
            [Description("short")]
            Short = 3,

            /// <summary>
            /// System.Ushort.
            /// </summary>
            [Description("ushort")]
            Ushort = 4,

            /// <summary>
            /// System.Int.
            /// </summary>
            [Description("int")]
            Int = 5,

            /// <summary>
            /// System.Uint.
            /// </summary>
            [Description("uint")]
            Uint = 6,

            /// <summary>
            /// System.Long.
            /// </summary>
            [Description("long")]
            Long = 7,

            /// <summary>
            /// System.Ulong.
            /// </summary>
            [Description("ulong")]
            Ulong = 8,

            /// <summary>
            /// System.Char.
            /// </summary>
            [Description("char")]
            Char = 9,

            /// <summary>
            /// System.Float.
            /// </summary>
            [Description("float")]
            Float = 10,

            /// <summary>
            /// System.Double.
            /// </summary>
            [Description("double")]
            Double = 11,

            /// <summary>
            /// System.Bool.
            /// </summary>
            [Description("bool")]
            Bool = 12,

            /// <summary>
            /// System.String.
            /// </summary>
            [Description("string")]
            String = 13,

            /// <summary>
            /// System.Decimal.
            /// </summary>
            [Description("decimal")]
            Decimal = 14
        }
    }
}