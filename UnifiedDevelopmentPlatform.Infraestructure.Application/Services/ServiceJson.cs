using System.Text.Json;
using System.Text.Json.Serialization;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Json;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service for (JavaScript Object Notation - JSON).
    /// </summary>
    public class ServiceJson : IServiceJson
    {
        private readonly JsonSerializerOptions _jsonOptions = new()
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public string UDPSerializerJson(object obj)
        {
            return System.Text.Json.JsonSerializer.Serialize(obj, _jsonOptions);

        }

        public object UDPDesSerializerJsonToApp(string json)
        {
            return System.Text.Json.JsonSerializer.Deserialize<JsonApp>(json, _jsonOptions);
        }

        public object UDPDesSerializerJsonToConfiguration(string json)
        {
            return System.Text.Json.JsonSerializer.Deserialize<JsonConfiguration>(json, _jsonOptions);
        }
    }
}