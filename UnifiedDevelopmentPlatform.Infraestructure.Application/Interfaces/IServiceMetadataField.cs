using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service metadata field.
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
        /// Indicates the maximum number of characters that are required to represent data in character format.
        /// </summary>
        /// <param name="text"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The maximum number of characters.</returns>
        int? UDPGetFieldLenght(string text);

        /// <summary>
        /// Load the fields at the table.
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
        void UDPLoadTheFieldsAtTable(ref List<Tables> listTables, int idTable, string text);

        /// <summary>
        /// Load the fields primary key at the table.
        /// </summary>
        /// <param name="listTables"></param>
        /// <param name="idTable"></param>
        /// <param name="fieldsPrimaryKey"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns></returns>
        void UDPLoadTheFieldsPrimarykeyAtTable(ref List<Tables> listTables, int idTable, string fieldsPrimaryKey);

        /// <summary>
        /// Get the metrics of quantities of fields.
        /// </summary>
        /// <param name="listOfFields"></param>
        /// <param name="quantityOfTables"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The total number of fields.</returns>
        long UDPGetMetricsOfQuantitiesOfFields(List<Tables> listOfTables, long quantityOfTables);
    }
}