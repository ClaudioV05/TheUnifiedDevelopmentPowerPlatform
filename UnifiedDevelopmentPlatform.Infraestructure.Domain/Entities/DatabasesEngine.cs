using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities
{
    /// <summary>
    /// Entity Databases Engine.
    /// </summary>
    [ComplexType]
    public class DatabasesEngine
    {
        /// <summary>
        /// Enum type for entitie Databases Engine.
        /// </summary>
        public enum EnumDatabasesEngine : int
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

        /// <summary>
        /// Id Enumeration.
        /// </summary>
        public EnumDatabasesEngine IdEnumeration { get; set; } = 0;

        /// <summary>
        /// Name of enumeration.
        /// </summary>
        public string? NameEnumeration { get; set; }
    }
}