namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface ServiceJson.
    /// </summary>
    public interface IServiceJson
    {
        /// <summary>
        /// Serializer JSON (JavaScript Object Notation). Using System.Text.Json.
        /// </summary>
        /// <param name="obj"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns></returns>
        string UDPSerializerJson(object obj);
    }
}