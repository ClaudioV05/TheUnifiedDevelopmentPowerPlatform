namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
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
        /// Load files in directory.
        /// </summary>
        /// <param name="pathOne"></param>
        /// <param name="pathTwo"></param>
        /// <returns></returns>
        string UDPLoadFilesDirectory(string pathOne, string pathTwo);
    }
}