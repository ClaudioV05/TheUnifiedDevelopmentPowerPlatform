using System.Security;
using UnifiedDevelopmentPlatform.Application.Interfaces;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service Plataform.
    /// </summary>
    public class ServicePlataform : IServicePlataform
    {
        /// <summary>
        /// The constructor of Service plataform.
        /// </summary>
        public ServicePlataform() { }

        public string UDPAddNewLine()
        {
            return Environment.NewLine;
        }

        public bool UPDPlataformIsWindows()
        {
            return OperatingSystem.IsWindows();
        }

        public List<string> UPDGetEnvListVariables()
        {
            List<string> envListVariables = new List<string>();
            try
            {
                foreach (string s2 in Environment.GetEnvironmentVariables().Keys)
                {
                    envListVariables.Add(Environment.GetEnvironmentVariable(s2)?.ToString() ?? string.Empty);
                }
            }
            catch (SecurityException)
            {
                // After this use Class of Exception.
                envListVariables.Add("Você não tem permissão para realizar esta operação.\nExecute o programa como Administrador");
            }

            return envListVariables;
        }

        public string? UPDGetEnvVariable(string variable)
        {
            return Environment.GetEnvironmentVariable(variable) ?? null;
        }
        public string? UPDGetOSVersion()
        {
            return Environment.OSVersion.Version.ToString();
        }
    }
}