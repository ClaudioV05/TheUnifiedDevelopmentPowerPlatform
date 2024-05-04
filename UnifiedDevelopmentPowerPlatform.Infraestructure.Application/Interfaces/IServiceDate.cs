namespace UnifiedDevelopmentPowerPlatform.Application.Interfaces;

/// <summary>
/// Interface service date.
/// </summary>
public interface IServiceDate
{
    /// <summary>
    /// Get the date time now with string format.
    /// </summary>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns></returns>
    string UDPPGetDateTimeNowFormat();

    /// <summary>
    /// Date time to long time.
    /// </summary>
    /// <paramref name=""/>
    /// <returns></returns>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns></returns>
    string UDPPGetDateTimeToLongTime();
}