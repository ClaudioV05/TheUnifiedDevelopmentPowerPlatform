using AppSolution.Infraestructure.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSolution.Infraestructure.Domain.Entities
{
    /// <summary>
    /// Entity Databases.
    /// </summary>
    [ComplexType]
    public class Databases : BaseEntity
    {
        /// <summary>
        /// Name of fields.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Id of Types.
        /// </summary>
        public DatabasesType Type { get; set; } = 0;
    }
}