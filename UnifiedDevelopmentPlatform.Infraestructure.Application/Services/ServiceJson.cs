using System.Text.Json;
using System.Text.Json.Serialization;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Json;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service JavaScript Object Notation - JSON.
    /// </summary>
    public class ServiceJson : IServiceJson
    {
        private readonly JsonSerializerOptions _jsonOptions = new()
        {
            WriteIndented = true, // Write indented.
            PropertyNameCaseInsensitive = true, // Property with name case insensitive.
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull // To default ignore condition when writing null.
        };

        /// <summary>
        /// The constructor of Service for JavaScript Object Notation - JSON.
        /// </summary>
        public ServiceJson()
        {

        }

        public string UDPSerializerJson(object obj)
        {
            return System.Text.Json.JsonSerializer.Serialize(obj, _jsonOptions);

        }

        public object UDPDesSerializerJsonToApp(string json)
        {
            return System.Text.Json.JsonSerializer.Deserialize<JsonApp>(json, _jsonOptions) ?? new JsonApp() { };
        }

        public object UDPDesSerializerJsonToConfiguration(string json)
        {
            return System.Text.Json.JsonSerializer.Deserialize<JsonConfiguration>(json, _jsonOptions) ?? new JsonConfiguration() { };
        }
    }
}