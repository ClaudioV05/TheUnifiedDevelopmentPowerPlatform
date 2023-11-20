using System.ComponentModel.DataAnnotations.Schema;

namespace AppSolution.Infraestructure.Domain.Entities
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
        public enum EnumDatabasesEngine : ushort
        {
            NotDefined = 0,
            EntityFrameworkCore = 1,
            Dapper = 2,
            SqlClient = 3
        }

        /// <summary>
        /// Name of fields.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Id of Types.
        /// </summary>
        public EnumDatabasesEngine Type { get; set; } = 0;
    }
}