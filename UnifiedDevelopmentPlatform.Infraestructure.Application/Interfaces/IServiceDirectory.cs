namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service for (Directory).
    /// </summary>
    public interface IServiceDirectory
    {
        /// <summary>
        /// Create directory project of solution.
        /// </summary>
        /// <returns></returns>
        void UPDCreateDirectoryProjectOfSolution();

        /// <summary>
        /// Create directory standard of solution.
        /// </summary>
        /// <returns></returns>
        void UPDCreateDirectoryStandardOfSolution();

        /// <summary>
        /// Get root path file in configuration.
        /// </summary>
        /// <returns>Return the root path of configuration in Unified development platform.</returns>
        string UDPGetRootPathFileInConfiguration(string fileName);
    }
}