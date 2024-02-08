using System.Text.Encodings.Web;
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
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web)
        {
            AllowTrailingCommas = false,
            MaxDepth = 64,
            Encoder = JavaScriptEncoder.Default,
            WriteIndented = true,
            IncludeFields = false,
            IgnoreReadOnlyFields = false,
            IgnoreReadOnlyProperties = false,
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        /// <summary>
        /// The constructor of Service for JavaScript Object Notation - JSON.
        /// </summary>
        public ServiceJson() { }

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