namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    public interface IServiceJavaScriptObjectNotation
    {
        #region Using System.Text.Json.

        /// <summary>
        /// Serializer JSON (JavaScript Object Notation). Using System.Text.Json.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        string UDPSerializer(object obj);

        /// <summary>
        /// Desserializer JSON (JavaScript Object Notation). Using System.Text.Json.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        object UDPDesSerializer(object obj, string json);

        #endregion Using System.Text.Json.

        #region Using Newtonsoft.Json.

        /// <summary>
        /// Serializer JSON (JavaScript Object Notation). Using Newtonsoft.Json.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        string UDPSerializer(string json);

        /// <summary>
        /// Desserializer JSON (JavaScript Object Notation). Using Newtonsoft.Json.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        object UDPDesSerializer(string data);

        #endregion Using Newtonsoft.Json.
    }
}