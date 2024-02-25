using System.ComponentModel.DataAnnotations;

namespace UnifiedDevelopmentPlatform.Presentation.Api.Models
{
    public class Metadata
    {
        /// <summary>
        /// Database schema.
        /// </summary>
        [Required]
        public string? DatabaseSchema { get; set; }

        /// <summary>
        /// Architecture.
        /// </summary>
        [Required]
        public int Architecture { get; set; }

        /// <summary>
        /// Identify of development Environment.
        /// </summary>
        [Required]
        public int IdDevelopmentEnvironment { get; set; }

        /// <summary>
        /// Identify of databases.
        /// </summary>
        [Required]
        public int IdDatabases { get; set; }

        /// <summary>
        /// Identify of databases engine.
        /// </summary>
        [Required]
        public int IdDatabasesEngine { get; set; }

        /// <summary>
        /// Identify of forms.
        /// </summary>
        [Required]
        public int IdForms { get; set; }
    }
}