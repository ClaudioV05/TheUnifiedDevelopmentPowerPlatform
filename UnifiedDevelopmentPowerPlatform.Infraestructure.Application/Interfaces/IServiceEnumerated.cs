namespace UnifiedDevelopmentPowerPlatform.Application.Interfaces;

/// <summary>
/// Interface service enumerated
/// </summary>
/// <remarks>This class cannot be inherited.</remarks>
public interface IServiceEnumerated
{
    /// <summary>
    /// Get the enumerated description.
    /// </summary>
    /// <param name="EnumeratedValue"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The string with enumerated description.</returns>
    string UDPPGetEnumeratedDescription(Enum EnumeratedValue);
}