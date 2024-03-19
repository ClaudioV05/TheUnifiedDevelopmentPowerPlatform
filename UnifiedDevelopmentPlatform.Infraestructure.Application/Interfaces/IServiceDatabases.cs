using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface ServiceDatabases.
    /// </summary>
    public interface IServiceDatabases
    {
        /// <summary>
        /// Select parameters the kinds of the databases.
        /// </summary>
        /// <param name=""></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>Return the complete list of databases.</returns>
        List<Databases> UDPSelectParametersTheKindsOfDatabases();

        /// <summary>
        /// Save identifier to the databases from metadata.
        /// </summary>
        /// <param name="metadata"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        void UDPSaveIdentifierToTheDatabasesFromMetadata(MetadataOwner metadata);

        /// <summary>
        /// Save the metrics of the generation of tables and fields.
        /// </summary>
        /// <param name="listOfTables"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        void UDPSaveMetricsOfTheGenerationOfTablesAndFields(List<Tables> listOfTables);

        /// <summary>
        /// Get the metrics of quantities of tables.
        /// </summary>
        /// <param name="listOfTables"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The total number of tables.</returns>
        long UDPGetMetricsOfQuantitiesOfTables(List<Tables> listOfTables);
    }
}