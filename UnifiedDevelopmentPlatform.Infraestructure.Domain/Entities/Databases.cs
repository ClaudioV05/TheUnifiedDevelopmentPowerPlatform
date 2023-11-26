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
        public enum EnumDatabases : ushort
        {
            NotDefined = 0,
            SqlServer = 1,
            MySql = 2,
            Firebird = 3
        }

        /// <summary>
        /// Name of fields.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Id of Types.
        /// </summary>
        public EnumDatabases Type { get; set; } = 0;
    }
}