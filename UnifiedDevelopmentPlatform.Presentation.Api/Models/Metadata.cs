using System.ComponentModel.DataAnnotations;

namespace UnifiedDevelopmentPlatform.Presentation.Api.Models
{
    /// <summary>
    /// Metadata.
    /// </summary>
    public class Metadata
    {
        /// <summary>
        /// The database schema.
        /// </summary>
        [Required]
        public string DatabaseSchema { get; set; }

        /// <summary>
        /// The identify of architecture.
        /// </summary>
        [Required]
        public int Architecture { get; set; }

        /// <summary>
        /// The identify of development Environment.
        /// </summary>
        [Required]
        public int IdDevelopmentEnvironment { get; set; }

        /// <summary>
        /// The identify of databases.
        /// </summary>
        [Required]
        public int IdDatabases { get; set; }

        /// <summary>
        /// The identify of databases engine.
        /// </summary>
        [Required]
        public int IdDatabasesEngine { get; set; }

        /// <summary>
        /// The identify of forms.
        /// </summary>
        [Required]
        public int IdForms { get; set; }
    }
}