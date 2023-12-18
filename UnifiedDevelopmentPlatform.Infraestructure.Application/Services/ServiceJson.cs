using Newtonsoft.Json.Linq;
using System.Text.Json;
using UnifiedDevelopmentPlatform.Application.Interfaces;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    public class ServiceJson : IServiceJson
    {
        #region Using System.Text.Json.

        public string UDPSerializerWithSystemTextJson(object obj)
        {
            return System.Text.Json.JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true });
        }

        public object UDPDesSerializerWithSystemTextJso(object obj, string json)
        {
            return System.Text.Json.JsonSerializer.Deserialize<object>(json);
        }

        #endregion Using System.Text.Json.

        #region Using Newtonsoft.Json.

        public string UDPSerializerWithNewtonsoftJson(object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

        public object UDPDesSerializerWithNewtonsoftJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject(data);
        }

        #endregion Using Newtonsoft.Json.

        public bool ContainsKey(string json, string propertyName)
        {
            var modifyJson = JObject.Parse(json);
            return modifyJson.ContainsKey(propertyName);
        }

        public void RemoveAll(string json, string propertyName)
        {
            var modifyJson = JObject.Parse(json);
            modifyJson.Remove(propertyName);
        }

        public JObject AddValue(string json, string propertyName, string value)
        {
            var modifyJson = JObject.Parse(json);
            modifyJson.Add(propertyName, value);

            return modifyJson;
        }

        public JObject AddValue(string json, string propertyName, object value)
        {
            var modifyJson = JObject.Parse(json);
            modifyJson.Add(propertyName, JObject.FromObject(value));

            return modifyJson;
        }

        public JObject InsertExistingValue(string json, string existingProperty, string newProperty, string value)
        {
            var modifyJson = JObject.Parse(json);
            modifyJson[existingProperty][newProperty] = value;

            return modifyJson;
        }

        public JObject InsertExistingValue(string json, string existingProperty, string newProperty, object value)
        {
            var modifyJson = JObject.Parse(json);
            modifyJson[existingProperty][newProperty] = JObject.FromObject(value);

            return modifyJson;
        }
    }
}