﻿namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service The Operational System.
    /// </summary>
    public interface IServicePlataform
    {
        /// <summary>
        /// Add a new line.
        /// </summary>
        /// <returns>String with caracter \n.</returns>
        string UDPAddNewLine();

        /// <summary>
        /// Make validation if platform is Windows.
        /// </summary>
        /// <returns>The method will return true, otherwise will return false.</returns>
        bool UPDPlataformIsWindows();

        /// <summary>
        /// Get list of variable of Environment.
        /// </summary>
        /// <returns>List of text with name of environment.</returns>
        List<string> UPDGetEnvListVariables();

        /// <summary>
        /// Get variable of Environment.
        /// </summary>
        /// <param name="variable"></param>
        /// <returns>Text with name of environment.</returns>
        string? UPDGetEnvVariable(string variable);

        /// <summary>
        /// Get variable of OS version.
        /// </summary>
        /// <param name=""></param>
        /// <returns>Text with name of OS version.</returns>
        string? UPDGetOSVersion();
    }
}