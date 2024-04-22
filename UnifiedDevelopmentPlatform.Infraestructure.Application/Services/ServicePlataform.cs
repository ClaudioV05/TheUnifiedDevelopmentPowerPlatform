using System.Security;
using UnifiedDevelopmentPlatform.Application.Interfaces;

namespace UnifiedDevelopmentPlatform.Application.Services
{
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

        public bool UPDPlataformIsWindows() => OperatingSystem.IsWindows();

        public string UDPEnvironmentAddNewLine() => Environment.NewLine;

        public string UPDGetEnvironmentVariable(string variable) => Environment.GetEnvironmentVariable(variable);

        public string UPDGetOperationalSystemVersion() => Environment.OSVersion.Version.ToString();

        public List<string> UPDGetListEnvironmentVariables()
        {
            List<string> listEnvironmentVariables = new List<string>();

            try
            {
                if (Environment.GetEnvironmentVariables().Keys is not null)
                {
                    foreach (string environmentVar in Environment.GetEnvironmentVariables().Keys)
                    {
                        listEnvironmentVariables.Add(this.UPDGetEnvironmentVariable(environmentVar));
                    }
                }
            }
            catch (SecurityException) { }

            return listEnvironmentVariables;
        }
    }
}