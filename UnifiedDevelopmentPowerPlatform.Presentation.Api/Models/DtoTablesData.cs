using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPowerPlatform.Presentation.Api.Models
{
    /// <summary>
    /// The data transfer object - Tables Data.
    /// </summary>
    public class DtoTablesData
    {
        /// <summary>
        /// The list of tables .
        /// </summary>
        [Required]
        [JsonPropertyName("tables")]
        public List<Tables>? Tables { get; set; }
    }
}