using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities
{
    /// <summary>
    /// Entity Databases.
    /// </summary>
    [ComplexType]
    public class Databases
    {
        /// <summary>
        /// Enum type for entitie Databases.
        /// </summary>
        public enum EnumDatabases : int
        {
            [Description("Not Defined")]
            NotDefined = 0,
            [Description("SqlServer")]
            SqlServer = 1,
            [Description("MySql")]
            MySql = 2,
            [Description("Firebird")]
            Firebird = 3,
            [Description("Oracle")]
            Oracle = 4
        }

        /// <summary>
        /// Id Enumeration.
        /// </summary>
        public EnumDatabases IdEnumeration { get; set; } = 0;

        /// <summary>
        /// Name of enumeration.
        /// </summary>
        public string? NameEnumeration { get; set; }
    }
}