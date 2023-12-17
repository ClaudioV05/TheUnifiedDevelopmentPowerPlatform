using UnifiedDevelopmentPlatform.Application.Interfaces;
using System.Text.Json;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    public class ServiceJavaScriptObjectNotation : IServiceJavaScriptObjectNotation
    {
        #region Using System.Text.Json.

        public string UDPSerializer(object obj)
        {
            return JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true });
        }

        public object UDPDesSerializer(object obj, string json)
        {
            return JsonSerializer.Deserialize<object>(json);
        }

        #endregion Using System.Text.Json.

        #region Using Newtonsoft.Json.

        public string UDPSerializer(string json)
        {
            throw new NotImplementedException();
        }

        public object UDPDesSerializer(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject(data);
        }

        #endregion Using Newtonsoft.Json.
    }
}