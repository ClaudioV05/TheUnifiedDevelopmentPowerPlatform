using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using UnifiedDevelopmentPowerPlatform.Application.Interfaces;

namespace UnifiedDevelopmentPowerPlatform.Application.Services;

/// <summary>
/// Service json.
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
    /// The constructor of service json.
    /// </summary>
    public ServiceJson() { }

    public string UDPPSerializerJson(object obj)
    {
        return System.Text.Json.JsonSerializer.Serialize(obj, _jsonOptions);
    }
}