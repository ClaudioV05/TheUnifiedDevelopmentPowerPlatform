using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.DataTypes;

namespace UnifiedDevelopmentPowerPlatform.Application.Interfaces;

/// <summary>
/// Interface service data type c-sharp.
/// </summary>
public interface IServiceDataTypeCSharp
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
    bool UDPPByIndexEnumTypeIsDefined(int index);

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
    CSharp.DataType UDPPGetAsEnumeratedTheEnumType(int index);

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
    int UDPPReturnIndexFromTheListOfDataTypes(string dataType);

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
    string UDPPGetAsStringTheEnumType(CSharp.DataType dataType);
}