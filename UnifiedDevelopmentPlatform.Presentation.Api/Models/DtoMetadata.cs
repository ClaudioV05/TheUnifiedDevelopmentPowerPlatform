using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UnifiedDevelopmentPlatform.Presentation.Api.Models
{
    /// <summary>
    /// Metadata.
    /// </summary>
    public class DtoMetadata
    {
        /// <summary>
        /// The database schema.
        /// </summary>
        [Required]
        [Base64String]
        [JsonPropertyName("databaseSchema")]
        public string? DatabaseSchema { get; set; }

        /// <summary>
        /// The identify of architecture.
        /// </summary>
        [Required]
        [JsonPropertyName("architecture")]
        public int Architecture { get; set; }

        /// <summary>
        /// The identify of development Environment.
        /// </summary>
        [Required]
        [JsonPropertyName("idDevelopmentEnvironment")]
        public int IdDevelopmentEnvironment { get; set; }

        /// <summary>
        /// The identify of databases.
        /// </summary>
        [Required]
        [JsonPropertyName("idDatabases")]
        public int IdDatabases { get; set; }

        /// <summary>
        /// The identify of databases engine.
        /// </summary>
        [Required]
        [JsonPropertyName("idDatabasesEngine")]
        public int IdDatabasesEngine { get; set; }

        /// <summary>
        /// The identify of forms.
        /// </summary>
        [Required]
        [JsonPropertyName("idForms")]
        public int IdForms { get; set; }
    }
}