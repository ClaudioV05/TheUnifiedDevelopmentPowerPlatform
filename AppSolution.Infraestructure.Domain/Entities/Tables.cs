using System.ComponentModel.DataAnnotations.Schema;

namespace AppSolution.Infraestructure.Domain.Entities
{
    /// <summary>
    /// Entitie Tables.
    /// </summary>
    [ComplexType]
    public class Tables
    {
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