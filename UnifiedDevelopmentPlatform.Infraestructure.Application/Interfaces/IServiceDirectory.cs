namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service for Directory.
    /// </summary>
    public interface IServiceDirectory
    {
        /// <summary>
        /// Create directory project of solution.
        /// </summary>
        /// <returns></returns>
        void UPDCreateDirectoryProjectOfSolution();

        /// <summary>
        /// Build directory standard of solution.
        /// </summary>
        /// <returns></returns>
        void UPDBuildDirectoryStandardOfSolution();

        /// <summary>
        /// Get root path file in Configuration.
        /// </summary>
        /// <returns>Return the root path of configuration in Unified development platform.</returns>
        string UDPGetRootPathFileInConfiguration(string fileName);

        /// <summary>
        /// Get root path file in App.
        /// </summary>
        /// <returns>Return the root path of configuration in Unified development platform.</returns>
        string UDPGetRootPathFileInApp(string fileName);
    }
}