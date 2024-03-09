using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface ServiceMetadataField.
    /// </summary>
    public interface IServiceMetadataField
    {
        /// <summary>
        /// Get the field name.
        /// </summary>
        /// <param name="text"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The field name</returns>
        string UDPGetTheFieldName(string text);

        /// <summary>
        /// Get the type of field name.
        /// </summary>
        /// <param name="text"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The type of field name</returns>
        string UDPGetTheTypeOfFieldName(string text);

        /// <summary>
        /// Get the primary key field name.
        /// </summary>
        /// <param name="text"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The primary key of field name</returns>
        string UDPGetThePrimaryKeyFieldName(string text);

        /// <summary>
        /// Identify whether the field is not null.
        /// </summary>
        /// <param name="text"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The method will return true, otherwise will return false.</returns>
        bool UDPTheFieldIsNotNull(string text);

        /// <summary>
        /// Load the field at the table.
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
        void UDPLoadTheFieldAtTable(ref List<Tables> listTables, int idTable, string text);

        /// <summary>
        /// Load the fields primary key at the table.
        /// </summary>
        /// <param name="listTables"></param>
        /// <param name="idTable"></param>
        /// <param name="listOfFieldsPrimaryKey"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns></returns>
        void UDPLoadTheFieldsPrimarykeyAtTable(ref List<Tables> listTables, int idTable, string[]? listOfFieldsPrimaryKey);
    }
}