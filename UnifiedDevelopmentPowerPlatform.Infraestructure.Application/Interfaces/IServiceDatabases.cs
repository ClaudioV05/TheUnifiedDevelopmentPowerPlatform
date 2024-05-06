﻿using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPowerPlatform.Application.Interfaces;

/// <summary>
/// Interface service databases.
/// </summary>
public interface IServiceDatabases
{
    /// <summary>
    /// Select parameters the kinds of the databases.
    /// </summary>
    /// <param name=""></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>Return the complete list of databases.</returns>
    List<Databases> UDPPSelectParametersTheKindsOfDatabases();

    /// <summary>
    /// Save identifier to the databases from metadata.
    /// </summary>
    /// <param name="metadata"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    void UDPPSaveIdentifierToTheDatabasesFromMetadata(MetadataOwner metadata);

    /// <summary>
    /// Save the metrics of the generation of tables and fields.
    /// </summary>
    /// <param name="listOfTables"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    void UDPPSaveMetricsOfTheGenerationOfTablesAndFields(List<Tables> listOfTables);

    /// <summary>
    /// Get the metrics of quantities of tables.
    /// </summary>
    /// <param name="listOfTables"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The total number of tables.</returns>
    long UDPPGetMetricsOfQuantitiesOfTables(List<Tables> listOfTables);
}