using System.ComponentModel;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.DataTypes
{
    /// <summary>
    /// Pascal.
    /// </summary>
    public static class Pascal
    {
        /// <summary>
        /// The Pascal data type.
        /// </summary>
        public enum DataType : int
        {
            /// <summary>
            /// System.Undefined.
            /// </summary>
            [Description("undefined")]
            Undefined = 0,

            /// <summary>
            /// Integer.
            /// </summary>
            [Description("Integer")]
            Integer = 1,

            /// <summary>
            /// Double.
            /// </summary>
            [Description("Double")]
            Double = 2,

            /// <summary>
            /// String.
            /// </summary>
            [Description("String")]
            String = 3,

            /// <summary>
            /// Boolean.
            /// </summary>
            [Description("Boolean")]
            Boolean = 4,

            /// <summary>
            /// Datetime.
            /// </summary>
            [Description("Datetime")]
            Datetime = 5,

            /// <summary>
            /// Single.
            /// </summary>
            [Description("Single")]
            Single = 6,

            /// <summary>
            /// TStrings.
            /// </summary>
            [Description("TStrings")]
            TStrings = 7
        }
    }
}