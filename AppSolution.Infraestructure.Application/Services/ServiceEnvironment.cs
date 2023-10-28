using AppSolution.Infraestructure.Application.Interfaces;
using System.Security;

namespace AppSolution.Infraestructure.Application.Services
{
    public class ServiceEnvironment : IServiceEnvironment
    {
        public string? GetEnvOSVersion()
        {
            string? value = string.Empty;
            try
            {
                value = Environment.OSVersion.ToString();
            }
            catch (SecurityException)
            {
                // After this use Class of Exception.
                value = "Você não tem permissão para realizar esta operação.\nExecute o programa como Administrador";
            }

            return value;
        }

        public string? GetEnvVariable(string variable)
        {
            string? value = string.Empty;
            try
            {
                value = Environment.GetEnvironmentVariable(variable);
            }
            catch (SecurityException)
            {
                // After this use Class of Exception.
                value = "Você não tem permissão para realizar esta operação.\nExecute o programa como Administrador";
            }

            return value;
        }

        public List<string> GetEnvListVariables()
        {
            List<string> envListVariables = new List<string>();
            try
            {
                foreach (string s2 in Environment.GetEnvironmentVariables().Keys)
                {
                    envListVariables.Add(Environment.GetEnvironmentVariable(s2)?.ToString());
                }
            }
            catch (SecurityException)
            {
                // After this use Class of Exception.
                envListVariables.Add("Você não tem permissão para realizar esta operação.\nExecute o programa como Administrador");
            }

            return envListVariables;
        }
    }
}