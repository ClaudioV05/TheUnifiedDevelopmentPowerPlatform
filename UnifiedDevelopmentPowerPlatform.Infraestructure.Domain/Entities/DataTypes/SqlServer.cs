using System.ComponentModel;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.DataTypes;

/// <summary>
/// SqlServer.
/// </summary>
public static class SqlServer
{
    /// <summary>
    /// The SqlServer data type.
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
        /// Binary.
        /// </summary>
        [Description("BINARY")]
        Binary = 1,

        /// <summary>
        /// Varbinary.
        /// </summary>
        [Description("VARBINARY")]
        Varbinary = 2,

        /// <summary>
        /// Bit.
        /// </summary>
        [Description("BIT")]
        Bit = 3,

        /// <summary>
        /// Tinyint.
        /// </summary>
        [Description("TINYINT")]
        Tinyint = 4,

        /// <summary>
        /// Money.
        /// </summary>
        [Description("MONEY")]
        Money = 5,

        /// <summary>
        /// Datetime.
        /// </summary>
        [Description("DATETIME")]
        Datetime = 6,

        /// <summary>
        /// Unique Identifier.
        /// </summary>
        [Description("UNIQUEIDENTIFIER")]
        UniqueIdentifier = 7,

        /// <summary>
        /// Decimal.
        /// </summary>
        [Description("DECIMAL")]
        Decimal = 8,

        /// <summary>
        /// Real.
        /// </summary>
        [Description("REAL")]
        Real = 9,

        /// <summary>
        /// Float.
        /// </summary>
        [Description("FLOAT")]
        Float = 10,

        /// <summary>
        /// System.Double.
        /// </summary>
        [Description("double")]
        Double = 11,

        /// <summary>
        /// Smallint.
        /// </summary>
        [Description("SMALLINT")]
        Smallint = 12,

        /// <summary>
        /// Integer.
        /// </summary>
        [Description("INTEGER")]
        Integer = 13,

        /// <summary>
        /// Image.
        /// </summary>
        [Description("IMAGE")]
        Image = 14,

        /// <summary>
        /// Text.
        /// </summary>
        [Description("TEXT")]
        Text = 15,

        /// <summary>
        /// Char.
        /// </summary>
        [Description("CHAR")]
        Char = 16,

        /// <summary>
        /// Varchar.
        /// </summary>
        [Description("VARCHAR")]
        Varchar = 17,

        /// <summary>
        /// Nchar.
        /// </summary>
        [Description("NCHAR")]
        Nchar = 18,

        /// <summary>
        /// Nvarchar.
        /// </summary>
        [Description("NVARCHAR")]
        Nvarchar = 19
    }
}