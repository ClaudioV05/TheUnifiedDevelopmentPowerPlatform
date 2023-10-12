using System.ComponentModel.DataAnnotations;

namespace AppSolution.Presentation.Api.Models
{
    public class Metadata
    {
        /// <summary>
        /// Script of Metadata.
        /// </summary>
        [Required]
        public string? MetadataScript { get; set; }

        /// <summary>
        /// Identify of fields.
        /// </summary>
        [Required]
        public List<long>? IdField { get; set; }

        /// <summary>
        /// Identify of databases.
        /// </summary>
        [Required]
        public List<long>? IdDatabases { get; set; }

        /// <summary>
        /// Identify of forms.
        /// </summary>
        [Required]
        public List<long>? IdForms { get; set; }
    }
}