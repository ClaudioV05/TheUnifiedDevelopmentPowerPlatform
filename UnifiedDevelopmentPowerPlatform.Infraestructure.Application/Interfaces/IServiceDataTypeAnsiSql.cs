using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.DataTypes;

namespace UnifiedDevelopmentPowerPlatform.Application.Interfaces;

/// <summary>
/// Interface service data type ansi sql.
/// </summary>
/// <remarks>This class cannot be inherited.</remarks>
public interface IServiceDataTypeAnsiSql
{
    /// <summary>
    /// By index enum type is defined.
    /// </summary>
    /// <param name="index"/>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return true, otherwise will return false.</returns>
    bool UDPPByIndexEnumTypeIsDefined(int index);

    /// <summary>
    /// Get the enum type as enumerated.
    /// </summary>
    /// <param name="index"/>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return the enumerated with the name of enum type.
    AnsiSql.DataType UDPPGetAsEnumeratedTheEnumType(int index);

    /// <summary>
    /// Return the index from list of data types.
    /// </summary>
    /// <param name="dataType"/>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The index from data type.</returns>
    int UDPPReturnIndexFromTheListOfDataTypes(string dataType);

    /// <summary>
    /// Get the enum type as string.
    /// </summary>
    /// <param name="dataType"/>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The method will return the string with the name of enum type.
    string UDPPGetAsStringTheEnumType(AnsiSql.DataType dataType);
}