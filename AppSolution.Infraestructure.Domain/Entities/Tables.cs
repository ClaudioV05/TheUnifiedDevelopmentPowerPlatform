using System.ComponentModel.DataAnnotations.Schema;

namespace AppSolution.Infraestructure.Domain.Entities
{
    /// <summary>
    /// Entity Tables.
    /// </summary>
    [ComplexType]
    public class Tables
    {
        /// <summary>
        /// Name of fields.
        /// </summary>
        public List<string>? Name { get; set; }
    }
}