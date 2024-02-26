using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities
{
    /// <summary>
    /// Entity Fields.
    /// </summary>
    [ComplexType]
    public class Fields : Tables
    {
        /// <summary>
        /// If the field has null value.
        /// </summary>
        public bool IsNull { get; set; }
    }
}