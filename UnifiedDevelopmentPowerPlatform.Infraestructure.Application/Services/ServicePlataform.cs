using System.Security;
using UnifiedDevelopmentPowerPlatform.Application.Interfaces;

namespace UnifiedDevelopmentPowerPlatform.Application.Services;

/// <summary>
/// Service plataform.
/// </summary>
public class ServicePlataform : IServicePlataform
{
    /// <summary>
    /// The constructor of service plataform.
    /// </summary>
    /// <param name=""></param>
    public ServicePlataform() { }

    public bool UDPPPlataformIsWindows() => OperatingSystem.IsWindows();

    public string UDPPEnvironmentAddNewLine() => Environment.NewLine;

    public string UDPPGetEnvironmentVariable(string variable) => Environment.GetEnvironmentVariable(variable);

    public string UDPPGetOperationalSystemVersion() => Environment.OSVersion.Version.ToString();

    public List<string> UDPPGetListEnvironmentVariables()
    {
        List<string> listEnvironmentVariables = new List<string>();

        try
        {
            if (Environment.GetEnvironmentVariables().Keys is not null)
            {
                foreach (string environmentVar in Environment.GetEnvironmentVariables().Keys)
                {
                    listEnvironmentVariables.Add(this.UDPPGetEnvironmentVariable(environmentVar));
                }
            }
        }
        catch (SecurityException) { }

        return listEnvironmentVariables;
    }
}