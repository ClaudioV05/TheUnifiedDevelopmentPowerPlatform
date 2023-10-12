using AppSolution.Infraestructure.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSolution.Infraestructure.Domain.Entities
{
    /// <summary>
    /// Entitie Databases.
    /// </summary>
    [ComplexType]
    public class Databases
    {
        /// <summary>
        /// Id of Types.
        /// </summary>
        public DatabasesType Type { get; set; } = 0;

        /// <summary>
        /// Id of fields.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of fields.
        /// </summary>
        public string? Name { get; set; }
    }
}