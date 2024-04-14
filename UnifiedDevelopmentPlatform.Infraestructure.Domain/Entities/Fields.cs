using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities
{
    /// <summary>
    /// Entity Fields.
    /// </summary>
    [ComplexType]
    public class Fields
    {
        /// <summary>
        /// Id Tables.
        /// </summary>
        public int IdTables { get; set; }

        /// <summary>
        /// The Name of field.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The type of field.
        /// </summary>
        public string? TypeField { get; set; }

        /// <summary>
        /// The lenght of field.
        /// </summary>
        public int? FieldLenght { get; set; }

        /// <summary>
        /// Whether the field is primary key.
        /// </summary>
        public bool IsPrimaryKey { get; set; }

        /// <summary>
        /// Whether the field has null value.
        /// </summary>
        public bool IsNull { get; set; }
    }
}