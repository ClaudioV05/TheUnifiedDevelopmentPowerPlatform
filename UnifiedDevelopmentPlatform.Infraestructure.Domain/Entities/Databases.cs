using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Interfaces;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities
{
    /// <summary>
    /// Entity Databases.
    /// </summary>
    [ComplexType]
    public class Databases : IEntity
    {
        /// <summary>
        /// Enum type for entitie Databases.
        /// </summary>
        [Flags]
        public enum EnumeratedDatabases : int
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

        public long Id { get; set; }

        public string? Name { get; set; }

        /// <summary>
        /// Id Enumeration.
        /// </summary>
        public EnumeratedDatabases IdEnumeration { get; set; } = 0;

        /// <summary>
        /// Name of enumeration.
        /// </summary>
        public string? NameEnumeration { get; set; }
    }
}