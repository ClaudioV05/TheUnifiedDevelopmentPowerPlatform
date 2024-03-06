using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory;

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

        /// <summary>
        /// Obtain directory root.
        /// </summary>
        /// <param name="directoryRootType"></param>
        /// <returns></returns>
        string UDPObtainDirectory(DirectoryRootType directoryRootType);

        /// <summary>
        /// Verify if directory exists.
        /// </summary>
        /// <param name="rootPath"></param>
        /// <returns>The method will return true, otherwise will return false.</returns>
        bool UDPDirectoryExists(string rootPath);
    }
}