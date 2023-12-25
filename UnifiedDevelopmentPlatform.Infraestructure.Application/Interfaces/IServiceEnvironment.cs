namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service for (Environment).
    /// </summary>
    public interface IServiceEnvironment
    {
        /// <summary>
        /// Get variable of Environment.
        /// </summary>
        /// <param name="variable"></param>
        /// <returns>Text with name of environment.</returns>
        string? UPDGetEnvVariable(string variable);

        /// <summary>
        /// Get list of variable of Environment.
        /// </summary>
        /// <returns>List of text with name of environment.</returns>
        List<string> UPDGetEnvListVariables();
    }
}