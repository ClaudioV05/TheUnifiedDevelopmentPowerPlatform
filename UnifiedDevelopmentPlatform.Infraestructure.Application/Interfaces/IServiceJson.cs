namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service for (JavaScript Object Notation - JSON).
    /// </summary>
    public interface IServiceJson
    {
        /// <summary>
        /// Serializer JSON (JavaScript Object Notation). Using System.Text.Json.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        string UDPSerializerJson(object obj);

        /// <summary>
        /// Desserializer JSON to object App (JavaScript Object Notation). Using System.Text.Json.
        /// </summary>
        /// <param name="json"></param>
        /// <returns>Object Desserialized</returns>
        object UDPDesSerializerJsonToApp(string json);

        /// <summary>
        /// Desserializer JSON to object Configuration (JavaScript Object Notation). Using System.Text.Json.
        /// </summary>
        /// <param name="json"></param>
        /// <returns>Object Desserialized</returns>
        object UDPDesSerializerJsonToConfiguration(string json);
    }
}