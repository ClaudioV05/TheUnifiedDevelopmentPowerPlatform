﻿using AppSolution.Application.Interfaces;
using System.Security;

namespace AppSolution.Application.Services
{
    public class ServiceEnvironment : IServiceEnvironment
    {
        public string? GetEnvVariable(string variable) => Environment.GetEnvironmentVariable(variable);

        public List<string> GetEnvListVariables()
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

        public bool PlatformIsWindows() => OperatingSystem.IsWindows();
    }
}