using System.ComponentModel.DataAnnotations.Schema;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Interfaces;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities
{
    /// <summary>
    /// Entity Tables.
    /// </summary>
    [ComplexType]
    public class Tables : IEntity
    {
        public long Id { get; set; }

        public string? Name { get; set; }

        /// <summary>
        /// Name of fields.
        /// </summary>
        public List<string>? Names { get; set; }
    }
}