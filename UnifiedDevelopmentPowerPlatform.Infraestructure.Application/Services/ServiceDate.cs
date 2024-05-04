using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Datetime;

namespace UnifiedDevelopmentPowerPlatform.Application.Services;

/// <summary>
/// Service date.
/// </summary>
public class ServiceDate : IServiceDate
{
    /// <summary>
    /// The constructor of service date.
    /// </summary>
    public ServiceDate() { }

    public string UDPPGetDateTimeNowFormat()
    {
        return DateTime.Now.ToString(DatetimeFormat.Format_13);
    }

    public string UDPPGetDateTimeToLongTime()
    {
        return DateTime.Now.ToLongTimeString();
    }
}