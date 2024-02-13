using UnifiedDevelopmentPlatform.Application.Interfaces;
using System.Security;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service Environment.
    /// </summary>
    public class ServiceEnvironment : IServiceEnvironment
    {
        /// <summary>
        /// The constructor of Service Environment.
        /// </summary>
        public ServiceEnvironment() { }

        public string? UPDGetEnvVariable(string variable)
        {
            return Environment.GetEnvironmentVariable(variable) ?? null;
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

        public string UDPNewLine()
        {
            return Environment.NewLine;
        }
    }
}