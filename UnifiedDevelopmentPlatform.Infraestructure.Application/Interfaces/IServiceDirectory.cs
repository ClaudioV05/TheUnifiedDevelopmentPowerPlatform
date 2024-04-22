using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service directory.
    /// </summary>
    public interface IServiceDirectory
    {
        /// <summary>
        /// Create directory project of solution.
        /// </summary>
        /// <param name=""></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns></returns>
        void UPDCreateDirectoryProjectOfSolution();

        /// <summary>
        /// Get metrics of the total size of directory by parallel processing.
        /// </summary>
        /// <param name="directory"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>Return the total size of directoy at the moment of call.</returns>
        long GetMetricsOfTheTotalSizeOfDirectoryByParallelProcessing(DirectoryInfo directory);

        /// <summary>
        /// Build directory standard of solution.
        /// </summary>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns></returns>
        void UPDBuildDirectoryStandardOfSolution();

        /// <summary>
        /// Obtain directory root.
        /// </summary>
        /// <param name="directoryRootType"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns></returns>
        string UDPObtainDirectory(DirectoryRootType directoryRootType);

        /// <summary>
        /// Verify if directory exists.
        /// </summary>
        /// <param name="absolutePath"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The method will return true, otherwise will return false.</returns>
        bool UDPDirectoryExists(string absolutePath);
    }
}