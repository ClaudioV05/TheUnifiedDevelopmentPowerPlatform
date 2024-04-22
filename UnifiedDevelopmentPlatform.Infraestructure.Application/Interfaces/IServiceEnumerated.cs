namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service enumerated
    /// </summary>
    public interface IServiceEnumerated
    {
        /// <summary>
        /// Get the enumerated description.
        /// </summary>
        /// <param name="EnumeratedValue"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The string with enumerated description.</returns>
        string UDPGetEnumeratedDescription(Enum EnumeratedValue);
    }
}