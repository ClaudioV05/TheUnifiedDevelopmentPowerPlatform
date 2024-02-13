namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service JavaScript Object Notation - JSON.
    /// </summary>
    public interface IServiceJson
    {
        /// <summary>
        /// Serializer JSON (JavaScript Object Notation). Using System.Text.Json.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        string UDPSerializerJson(object obj);
    }
}