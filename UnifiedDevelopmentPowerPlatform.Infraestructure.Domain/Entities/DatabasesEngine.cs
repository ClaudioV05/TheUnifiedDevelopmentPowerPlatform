using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Interfaces;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities
{
    /// <summary>
    /// Entity Databases Engine.
    /// </summary>
    [ComplexType]
    public class DatabasesEngine : IEntity
    {
        /// <summary>
        /// Enum type for entitie Databases Engine.
        /// </summary>
        [Flags]
        public enum EnumeratedDatabasesEngine : int
        {
            [Description("Not Defined")]
            NotDefined = 0,
            [Description("EntityFrameworkCore")]
            EntityFrameworkCore = 1,
            [Description("Dapper")]
            Dapper = 2,
            [Description("SqlClient")]
            SqlClient = 3
        }

        public long Id { get; set; }

        public string? Name { get; set; }

        /// <summary>
        /// Id Enumeration.
        /// </summary>
        public EnumeratedDatabasesEngine IdEnumeration { get; set; } = 0;

        /// <summary>
        /// Name of enumeration.
        /// </summary>
        public string? NameEnumeration { get; set; }
    }
}