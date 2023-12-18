using Newtonsoft.Json.Linq;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    public interface IServiceJson
    {
        #region Methods using Serializer and Desserializer.

        #region Using System.Text.Json.

        /// <summary>
        /// Serializer JSON (JavaScript Object Notation). Using System.Text.Json.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        string UDPSerializerWithSystemTextJson(object obj);

        /// <summary>
        /// Desserializer JSON (JavaScript Object Notation). Using System.Text.Json.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        object UDPDesSerializerWithSystemTextJso(object obj, string json);

        #endregion Using System.Text.Json.

        #region Using Newtonsoft.Json.

        /// <summary>
        /// Serializer JSON (JavaScript Object Notation). Using Newtonsoft.Json.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        string UDPSerializerWithNewtonsoftJson(object obj);

        /// <summary>
        /// Desserializer JSON (JavaScript Object Notation). Using Newtonsoft.Json.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        object UDPDesSerializerWithNewtonsoftJson(string data);

        #endregion Using Newtonsoft.Json.

        #endregion Methods using Serializer and Desserializer.

        /// <summary>
        /// Contains key.
        /// </summary>
        /// <param name="json"></param>
        /// <param name="propertyName"></param>
        /// <returns>Return true otherwise false.</returns>
        bool ContainsKey(string json, string propertyName);

        /// <summary>
        /// Remove all from the file JSON.
        /// </summary>
        /// <param name="json"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        void RemoveAll(string json, string propertyName);

        /// <summary>
        /// Add value to file JSON.
        /// </summary>
        /// <param name="json"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns>JObject that represents a JSON object.</returns>
        JObject AddValue(string json, string propertyName, string value);

        /// <summary>
        /// Add value to file JSON.
        /// </summary>
        /// <param name="json"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns>JObject that represents a JSON object.</returns>
        JObject AddValue(string json, string propertyName, object value);

        /// <summary>
        /// Insert existing value to JSON.
        /// </summary>
        /// <param name="json"></param>
        /// <param name="existingProperty"></param>
        /// <param name="newProperty"></param>
        /// <param name="value"></param>
        /// <returns>JObject that represents a JSON object.</returns>
        JObject InsertExistingValue(string json, string existingProperty, string newProperty, string value);

        /// <summary>
        /// Insert existing value to JSON.
        /// </summary>
        /// <param name="json"></param>
        /// <param name="existingProperty"></param>
        /// <param name="newProperty"></param>
        /// <param name="value"></param>
        /// <returns>JObject that represents a JSON object.</returns>
        JObject InsertExistingValue(string json, string existingProperty, string newProperty, object value);
    }
}