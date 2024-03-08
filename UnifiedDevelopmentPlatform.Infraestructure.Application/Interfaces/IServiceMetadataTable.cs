﻿using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface ServiceMetadataTable.
    /// </summary>
    public interface IServiceMetadataTable
    {
        /// <summary>
        /// Return a list with tables name of metadata.
        /// </summary>
        /// <param name="metadata"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>List with names of table.</returns>
        List<string> UDPListWithTablesNameOfMetadata(MetadataOwner metadata);

        /// <summary>
        /// Save the database schema from metadata.
        /// </summary>
        /// <param name="metadata"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns></returns>
        void UDPSaveDatabaseSchemaFromMetadata(MetadataOwner metadata);

        /// <summary>
        /// Open the database schema from metadata.
        /// </summary>
        /// <param name=""></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The string with database schema.</returns>
        string UDPOpenDatabaseSchemaFromMetadata();

        /// <summary>
        /// Get the table name.
        /// </summary>
        /// <param name="text"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The table name</returns>
        string UDPGetTableName(string text);
    }
}