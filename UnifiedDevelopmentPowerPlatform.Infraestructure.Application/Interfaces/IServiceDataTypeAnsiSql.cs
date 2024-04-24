using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.DataTypes;

namespace UnifiedDevelopmentPowerPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service data type ansi sql.
    /// </summary>
    public interface IServiceDataTypeAnsiSql
    {
        /// <summary>
        /// By index enum type is defined.
        /// </summary>
        /// <param name="index"/>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The method will return true, otherwise will return false.</returns>
        bool UDPByIndexEnumTypeIsDefined(int index);

        /// <summary>
        /// Get the enum type as enumerated.
        /// </summary>
        /// <param name="index"/>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The method will return the enumerated with the name of enum type.
        AnsiSql.DataType UDPGetAsEnumeratedTheEnumType(int index);

        /// <summary>
        /// Return the index from list of data types.
        /// </summary>
        /// <param name="dataType"/>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The index from data type.</returns>
        int UDPReturnIndexFromTheListOfDataTypes(string dataType);

        /// <summary>
        /// Get the enum type as string.
        /// </summary>
        /// <param name="dataType"/>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The method will return the string with the name of enum type.
        string UDPGetAsStringTheEnumType(AnsiSql.DataType dataType);
    }
}