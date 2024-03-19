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
        /// <returns>The table name.</returns>
        string UDPGetTableName(string text);

        /// <summary>
        /// Load the database schema.
        /// </summary>
        /// <param name="listDatabaseSchema"></param>
        /// <param name="databaseSchema"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso> 
        void UDPLoadTheDatabaseSchema(ref List<string> listDatabaseSchema, string[]? databaseSchema);

        /// <summary>
        /// To does add and save the table.
        /// </summary>
        /// <param name="listTables"></param>
        /// <param name="idTable"></param>
        /// <param name="text"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns></returns>
        void UDPAddAndSaveTheTable(ref List<Tables> listTables, int idTable, string text);
    }
}