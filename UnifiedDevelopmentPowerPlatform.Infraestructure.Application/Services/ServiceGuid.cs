using System.Text.RegularExpressions;
using UnifiedDevelopmentPowerPlatform.Application.Interfaces;

namespace UnifiedDevelopmentPowerPlatform.Application.Services;

/// <summary>
/// Service guid.
/// </summary>
public class ServiceGuid : IServiceGuid
{
    private readonly IServiceFuncString _serviceFuncString;

    /// <summary>
    /// The constructor of service guid.
    /// </summary>
    /// <param name="serviceFuncString"></param>
    public ServiceGuid(IServiceFuncString serviceFuncString)
    {
        _serviceFuncString = serviceFuncString;
    }

    public string? UDPPGenerateTheNewUniversallyUniqueIdentifier()
    {
        string? value;

        try
        {
            value = Convert.ToString(Guid.NewGuid());

            if (!this.UDPPValidateWithRegexTheUniversallyUniqueIdentifier(value))
            {
                value = _serviceFuncString.Empty;
            }

            return value;
        }
        catch (Exception)
        {
            return _serviceFuncString.Empty;
        }
    }

    public bool UDPPValidateWithRegexTheUniversallyUniqueIdentifier(string value)
    {
        Regex? regex = new Regex(@"^[0-9A-Fa-f]{8}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{12}$");

        try
        {
            return regex.IsMatch(value);
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool UDPPValidateWithGuidParseTheUniversallyUniqueIdentifier(string value)
    {
        try
        {
            Guid.Parse(value);
        }
        catch (FormatException)
        {
            return false;
        }

        return true;
    }
}