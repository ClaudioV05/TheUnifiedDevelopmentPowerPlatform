namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service Directory.
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
    }
}